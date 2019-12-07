using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Utilities;
using System.Collections;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using System.Text;

namespace TermProject_Template.Users
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug45415/WebAPI/api/service/PaymentProcessor/";
        private int MerchantAccountID = 2;
        private string APIKey = "nV17vFTeaH";
        Validation validate = new Validation();
        SqlCommand objCommand = new SqlCommand();
        DBConnect db = new DBConnect();

        string email = "";
        string accountID = "";
        string restaurantID = "";
        Payment payment = new Payment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*email = Session["AccountID"].ToString()*/;
                Session["AccountID"] = "gav@gmail.com";
                restaurantID = "burger@gmail.com";
                LoadMenu(restaurantID);
            }
        }

        public void LoadMenu(string restID)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Tp_GetMenu";
            SqlParameter inputEmail = new SqlParameter("@Email", restID);
            objCommand.Parameters.Add(inputEmail);
            DataSet result = db.GetDataSetUsingCmdObj(objCommand);
            gvMenu.DataSource = result;
            gvMenu.DataBind();

            ListBox lb;
            for (int i = 0; i < result.Tables[0].Rows.Count; i++)
            {
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "Tp_CheckAddOns";
                SqlParameter restEmail = new SqlParameter("@theEmail", restID);
                objCommand.Parameters.Add(restEmail);
                string stringID = Convert.ToString(result.Tables[0].Rows[i]["Menu_ID"]);
                int theID = Int32.Parse(stringID);
                objCommand.Parameters.AddWithValue("@theID", theID);
                DataSet idResult = db.GetDataSetUsingCmdObj(objCommand);
                int size = idResult.Tables[0].Rows.Count;
                if (size == 0)
                {
                    lb = (ListBox)gvMenu.Rows[i].FindControl("lbAddOns");
                    lb.Visible = false;
                }
                else
                {
                    objCommand.Parameters.Clear();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "Tp_GetAddOns";
                    SqlParameter menuAddOn = new SqlParameter("@MenuID", theID);
                    objCommand.Parameters.Add(menuAddOn);
                    DataSet lbResult = db.GetDataSetUsingCmdObj(objCommand);
                    lb = (ListBox)gvMenu.Rows[i].FindControl("lbAddOns");
                    lb.DataSource = lbResult;
                    lb.DataTextField = "Add_On_Name";
                    lb.DataValueField = "Add_On_Name";
                    lb.DataBind();
                }
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            int check = 0;
            OrderItem item;
            validate.checkChecks(gvMenu, out check);
            float orderPrice =0;
            if (check > 0)
            {
                for (int row = 0; row < gvMenu.Rows.Count; row++)
                {
                    CheckBox CBox;
                    // Get the reference for the chkSelect control in the current row
                    CBox = (CheckBox)gvMenu.Rows[row].FindControl("chkSelect");
                    ListBox lb = (ListBox)gvMenu.Rows[row].FindControl("lbAddOns");
                    if (CBox.Checked == true)
                    {
                        item = new OrderItem();
                        item.Name = gvMenu.Rows[row].Cells[2].Text;
                        string Price = gvMenu.Rows[row].Cells[5].Text.Replace("$", "");
                        item.Price = float.Parse(Price);
                        float price = item.Price;
                        orderPrice += price;
                        item.Type = gvMenu.Rows[row].Cells[3].Text;
                        for (int a = 0; a <= lb.SelectedValue.Count(); a++)
                        {
                            item.createAddOn(lb.SelectedValue);
                        }
                    }
                }
                ProcessPayment(orderPrice);
            }
            else
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('You must select something to order before checking out');</script>");
                return;
            }
        }
        public void ProcessPayment(float orderPrice)
        {
            email = Session["AccountId"].ToString();
            float balance = float.Parse(validate.GetUserBalance(email));
            if (orderPrice < balance)
            {
                payment.Reciever = restaurantID;
                payment.Sender = email;
                payment.Type = "payment";
                payment.Amount = orderPrice;
                payment.CardNumber = validate.GetCardNumber(email);
                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonCustomer = js.Serialize(payment);

                WebRequest request = WebRequest.Create(webApiUrl + "ProcessPayment/" + MerchantAccountID + "/" + APIKey);
                request.Method = "POST";
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonCustomer);
                writer.Flush();
                writer.Close();
                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                if(data == "true")
                {
                    CreateOrder(orderPrice);
                }

            }
            else
            {
                
            }
        }
        public void CreateOrder(float orderPrice)
        {
            email = Session["AccountId"].ToString();
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Tp_NewOrder";
            string name = validate.getAccountName(email);
            DateTime date = DateTime.Today;
            SqlParameter inputName = new SqlParameter("@Order_Name", name);
            SqlParameter inputEmail = new SqlParameter("@Order_User_Email", email);
            SqlParameter inputRestEmail = new SqlParameter("@Order_Rest_Email", restaurantID);
            SqlParameter inputCost = new SqlParameter("@Order_Cost", orderPrice);
            SqlParameter inputDate = new SqlParameter("@Order_Date", date);
            SqlParameter outputID = new SqlParameter("@Order_ID", 0);

            outputID.Direction = ParameterDirection.Output;
            outputID.SqlDbType = SqlDbType.Int;

            objCommand.Parameters.Add(inputName);
            objCommand.Parameters.Add(inputEmail);
            objCommand.Parameters.Add(inputRestEmail);
            objCommand.Parameters.Add(inputCost);
            objCommand.Parameters.Add(inputDate);
            objCommand.Parameters.Add(outputID);
            db.DoUpdateUsingCmdObj(objCommand);
            int orderID = int.Parse(objCommand.Parameters["@Order_ID"].Value.ToString());
            Session["OrderID"] = orderID;
            int check = 0;
            int itemCount = 0;
            validate.checkChecks(gvMenu, out check);
            
            if (check >= 1)
            {
                for (int row = 0; row < gvMenu.Rows.Count; row++)
                {
                    ArrayList addOns = new ArrayList();
                    CheckBox CBox;
                    // Get the reference for the chkSelect control in the current row
                    CBox = (CheckBox)gvMenu.Rows[row].FindControl("chkSelect");
                    ListBox lb = (ListBox)gvMenu.Rows[row].FindControl("lbAddOns");
                    if (CBox.Checked == true)
                    {                       
                        string ItemName = gvMenu.Rows[row].Cells[2].Text;
                        string Price = gvMenu.Rows[row].Cells[5].Text.Replace("$", "");
                        float ItemPrice = float.Parse(Price);
                        
                        string ItemType = gvMenu.Rows[row].Cells[3].Text;
                        for (int a = 0; a <= lb.GetSelectedIndices().Count(); a++)
                        {
                            addOns.Add(lb.SelectedValue);
                        }

                        objCommand.Parameters.Clear();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "Tp_NewOrderItem";
                        
                        SqlParameter inputItemName = new SqlParameter("@OrderItemName", ItemName);
                        SqlParameter inputItemCost = new SqlParameter("@OrderItemCost", ItemPrice);
                        SqlParameter inputItemAddOns = new SqlParameter("@OrderItemAddOns", addOns);
                        SqlParameter inputItemType = new SqlParameter("@OrderItemType", ItemType);
                        SqlParameter inputOrderID = new SqlParameter("@OrderID", orderID);
                        objCommand.Parameters.Add(inputItemName);
                        objCommand.Parameters.Add(inputItemCost);
                        objCommand.Parameters.Add(inputItemAddOns);
                        objCommand.Parameters.Add(inputItemType);
                        objCommand.Parameters.Add(inputOrderID);
                       
                        itemCount += db.DoUpdateUsingCmdObj(objCommand);

                    }
                }
                Response.Redirect("ViewOrder.aspx");
        }   }
    }
}