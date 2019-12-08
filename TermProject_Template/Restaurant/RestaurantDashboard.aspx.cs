using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using Utilities;
using System.Web.Script.Serialization;
using System.Text;
using System.IO;
using System.Net;

namespace TermProject_Template.Restaurant
{
    public partial class ResturantDashboard : System.Web.UI.Page
    {
        string webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug45415/WebAPITest/api/service/PaymentProcessor/";
        int total = 0;
        DataSet dsRest = new DataSet();
        SqlCommand objCommand = new SqlCommand();
        DBConnect db = new DBConnect();
        private string APIKey = "nV17vFTeaH";
        private int MerchantAccountID = 2;
        string accountID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            accountID = Session["AccountID"].ToString();
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
            else
            {
                displayPreviousOrders(accountID);
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
            Label myLabel = (Label)rptRest.Items[rowIndex].FindControl("lblProductID");
            String productNumber = myLabel.Text;
        }
        public void displayPreviousOrders(string ID)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetOrders";
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
                OrderID.Text = "ID";
                OrderName.Text = "Name";
                OrderUserEmail.Text = "Order Email";
                OrderRestEmail.Text = "Rest Email";
                OrderCost.Text = "Cost";
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
                    TableCell dropDownStatus = new TableCell();
                    drOrderRecord = dtOrders.Rows[row];
                    OrderIDCell.Text = drOrderRecord["Order_ID"].ToString();
                    OrderNameCell.Text = drOrderRecord["Order_Name"].ToString();
                    OrderUserEmailCell.Text = drOrderRecord["Order_User_Email"].ToString();
                    OrderRestEmailCell.Text = drOrderRecord["Restaurant_Email"].ToString();
                    OrderCostCell.Text = drOrderRecord["Order_Cost"].ToString();

                    List<string> countries = new List<string>();
                    countries.Add("Submitted");
                    countries.Add("Being Prepared");
                    countries.Add("Being Delivered");
                    countries.Add("Completed");
                    countries.Add("Problem Occurred");

                    // Create a Button used select an item
                    Button btnUpdate = new Button();
                    btnUpdate.Text = "Update Status";
                    btnUpdate.ID = "btnUpdate" + drOrderRecord["Order_ID"].ToString();
                    btnUpdate.Width = 120;
                    btnUpdate.Click += new EventHandler(this.UpdateButtonHandler);
                    

                    DropDownList ddlStatus = new DropDownList();
                    ddlStatus.DataSource = countries;
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = drOrderRecord["Order_Status"].ToString();
                    ddlStatus.ID = "ddl" + drOrderRecord["Order_ID"].ToString();
                    ddlStatus.Width = 120;
                    dropDownStatus.Controls.Add(ddlStatus);
                    dropDownStatus.Controls.Add(btnUpdate);

                    Button objButton = new Button();
                    objButton.Text = "Select Product";
                    objButton.ID = drOrderRecord["Order_ID"].ToString();
                    objButton.Width = 120;
                    objButton.Click += new EventHandler(this.SelectButtonHandler);
                    selectOrderCell.Controls.Add(objButton);

                    productRow.Cells.Add(OrderIDCell);
                    productRow.Cells.Add(OrderNameCell);
                    productRow.Cells.Add(OrderUserEmailCell);
                    productRow.Cells.Add(OrderRestEmailCell);
                    productRow.Cells.Add(OrderCostCell);
                    productRow.Cells.Add(dropDownStatus);
                    productRow.Cells.Add(selectOrderCell);
                    tblRecords.Rows.Add(productRow);
                }
            }
        }
        public void submit_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Response.Redirect("RestaurantRegistration.aspx");
        }
        public void SelectButtonHandler(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["OrderID"] = button.ID;
            Response.Redirect("ViewAllOrders.aspx");
        }
        public void UpdateButtonHandler(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.ID.Replace("btnUpdate", "");
            string idStatus = "ddl" + id;
            DropDownList ddlStatus =(DropDownList)MyPlaceHolder.FindControl(idStatus);
            string status = ddlStatus.SelectedValue;

            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateOrderStatus";
            SqlParameter inputID = new SqlParameter("@OrderID", id);
            SqlParameter inputStatus = new SqlParameter("@Status", status);
            objCommand.Parameters.Add(inputID);
            objCommand.Parameters.Add(inputStatus);
            int count = db.DoUpdateUsingCmdObj(objCommand);
            displayPreviousOrders(accountID);
        }
    }
}