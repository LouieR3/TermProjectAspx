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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug45415/TermProject/api/service/PaymentProcessor/";
        int total = 0;
        DataSet dsRest = new DataSet();
        SqlCommand objCommand = new SqlCommand();
        DBConnect db = new DBConnect();
        private string APIKey = "nV17vFTeaH";
        private int MerchantAccountID = 2;
        string accountID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            accountID = "gav@gmail.com";
            Session["AccountID"] = accountID;
            displayPreviousOrders(accountID);
            if (!IsPostBack)
            {
                //string accountID = Session["AccountID"].ToString();             
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetRestaurants";
                dsRest = db.GetDataSetUsingCmdObj(objCommand);
                rptRest.DataSource = dsRest;
                rptRest.DataBind();
            }
        }
        public void bindData()
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Tp_GetRestaurants";
            dsRest = db.GetDataSetUsingCmdObj(objCommand);
            int countValue = Convert.ToInt16(txtHidden.Value);
            if (countValue <= 0)
            {
                countValue = 0;
            }
            rptRest.DataSource = dsRest;
            rptRest.DataBind();
        }

        protected void repeaterRest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int rowIndex = e.Item.ItemIndex;
            Label myLabel = (Label)rptRest.Items[rowIndex].FindControl("lblRestEmail");
            String productNumber = myLabel.Text;
            Session["RestaurantID"] = productNumber;
            Response.Redirect("ViewMenu.aspx");
        }
        public void displayPreviousOrders(string ID)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Tp_GetOrders";
            SqlParameter inputEmail = new SqlParameter("@Email", accountID);
            objCommand.Parameters.Add(inputEmail);
            DataSet result = db.GetDataSetUsingCmdObj(objCommand);
            DataTable dtOrders = result.Tables[0];
            DataRow drOrderRecord;
            dtOrders = result.Tables[0];
            MyPlaceHolder.Controls.Clear();
            if (dtOrders.Rows.Count != 0)
            {
                Table tblRecords = new Table();
                TableHeaderRow thr = new TableHeaderRow();
                TableHeaderCell OrderID = new TableHeaderCell();
                TableHeaderCell OrderName = new TableHeaderCell();
                TableHeaderCell OrderUserEmail = new TableHeaderCell();
                TableHeaderCell OrderRestEmail = new TableHeaderCell();
                TableHeaderCell OrderCost = new TableHeaderCell();
                TableHeaderCell Status = new TableHeaderCell();
                TableHeaderCell OrderSelect = new TableHeaderCell();
                OrderID.Text = "Order ID";
                OrderName.Text = "Order Name";
                OrderUserEmail.Text = "Customer Email";
                OrderRestEmail.Text = "Restaurant Email";
                OrderCost.Text = "Order Cost";
                Status.Text = "Status";
                OrderSelect.Text = "View Order";
                thr.Cells.Add(OrderID);
                thr.Cells.Add(OrderName);
                thr.Cells.Add(OrderUserEmail);
                thr.Cells.Add(OrderRestEmail);
                thr.Cells.Add(OrderCost);
                thr.Cells.Add(Status);
                thr.Cells.Add(OrderSelect);
                tblRecords.Rows.Add(thr);
                tblRecords.ForeColor = System.Drawing.Color.Black;
                MyPlaceHolder.Controls.Add(tblRecords);
                
                for (int row = 0; row < dtOrders.Rows.Count; row++)
                {
                    TableRow productRow = new TableRow();
                    TableCell OrderIDCell = new TableCell();
                    TableCell OrderNameCell = new TableCell();
                    TableCell OrderUserEmailCell = new TableCell();
                    TableCell OrderRestEmailCell = new TableCell();  
                    TableCell selectOrderCell = new TableCell();
                    TableCell OrderCostCell = new TableCell();
                    TableCell OrderStatus = new TableCell();

                    drOrderRecord = dtOrders.Rows[row];
                    OrderIDCell.Text = drOrderRecord["Order_ID"].ToString();
                    OrderNameCell.Text = drOrderRecord["Order_Name"].ToString();
                    OrderUserEmailCell.Text = drOrderRecord["Order_User_Email"].ToString();
                    OrderRestEmailCell.Text = drOrderRecord["Restaurant_Email"].ToString();
                    OrderCostCell.Text = drOrderRecord["Order_Cost"].ToString();
                    OrderStatus.Text = drOrderRecord["Order_Status"].ToString();

                    // Create a Button used select an item

                    Button objButton = new Button();
                    objButton.Text = "Select Product";
                    objButton.ID = drOrderRecord["Order_ID"].ToString();
                    objButton.Width = 120;
                    objButton.Click += new EventHandler(this.SelectButtonHandler);
                    selectOrderCell.Controls.Add(objButton);

                    productRow.Cells.Add(OrderIDCell);
                    productRow.Cells.Add(OrderNameCell);
                    productRow.Cells.Add(OrderStatus);
                    productRow.Cells.Add(OrderUserEmailCell);
                    productRow.Cells.Add(OrderRestEmailCell);
                    productRow.Cells.Add(OrderCostCell);
                    productRow.Cells.Add(selectOrderCell);
                    tblRecords.Rows.Add(productRow);
                }
            }
        }
        public void SelectButtonHandler(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["OrderID"] = button.ID;
            Response.Redirect("ViewOrder.aspx");

        }
    }
}
