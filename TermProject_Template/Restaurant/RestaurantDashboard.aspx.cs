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
            if (!IsPostBack)
            {
                //string accountID = Session["AccountID"].ToString();
                accountID = "gav@gmail.com";
                Session["AccountID"] = accountID;
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetRestaurants";
                dsRest = db.GetDataSetUsingCmdObj(objCommand);
                rptRest.DataSource = dsRest;
                rptRest.DataBind();
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
            string strHTML = "";
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Tp_GetUserOrders";
            SqlParameter inputEmail = new SqlParameter("@Email", accountID);

            objCommand.Parameters.Add(inputEmail);
            DataSet result = db.GetDataSetUsingCmdObj(objCommand);

            DataTable dtPreviousOrders = result.Tables[0];
            DataRow drPreviousOrders;
            if (dtPreviousOrders.Rows.Count != 0)
            {
                strHTML = strHTML + "<table>" +
                             "<tr style='font-weight:bold'>" +
                             "<td> OrderID </td>" +
                             "<td> Order Name </td>" +
                             "<td> Order Email </td>" +
                             "<td> Restaurant Email </td>" +
                             "<td> Order Cost </td>" +
                             "<td> Order Status </td>" +
                             "</tr>";
                for (int row = 0; row < dtPreviousOrders.Rows.Count; row++)
                {
                    drPreviousOrders = dtPreviousOrders.Rows[row];
                    Button select = new Button();
                    String selectHTML = "";
                    String ddlHTML = "";
                    select.Text = "View Order";
                    select.ID = drPreviousOrders["Order_ID"].ToString();
                    select.Click += new EventHandler(this.SelectButtonHandler);
                    select.Width = 120;

                    List<string> countries = new List<string>();
                    countries.Add("Submitted");
                    countries.Add("Being Prepared");
                    countries.Add("Being Delivered");
                    countries.Add("Completed");
                    countries.Add("Problem Occurred");
                    DropDownList ddlStatus = new DropDownList();
                    ddlStatus.DataSource = countries;
                    ddlStatus.DataBind();
                    ddlStatus.SelectedValue = drPreviousOrders["Order_Status"].ToString();
                    ddlStatus.ID = drPreviousOrders["Order_ID"].ToString();
                    //ddlStatus.ViewStateMode = ViewStateMode.Enabled;
                    ddlStatus.AutoPostBack = true;
                    ddlStatus.EnableViewState = true;
                    ddlStatus.SelectedIndexChanged += new EventHandler (this.DDLStatus_StatusChange);

                    StringBuilder strBuilder = new StringBuilder();
                    StringWriter strWriter = new StringWriter(strBuilder);
                    HtmlTextWriter htmlWriter = new HtmlTextWriter(strWriter);

                    select.RenderControl(htmlWriter);
                    selectHTML = strBuilder.ToString();

                    StringBuilder strBuilderList = new StringBuilder();
                    StringWriter strWriterList = new StringWriter(strBuilderList);
                    HtmlTextWriter htmlWriterList = new HtmlTextWriter(strWriterList);

                    ddlStatus.RenderControl(htmlWriterList);
                    ddlHTML = strBuilderList.ToString();

                    strHTML = strHTML + "<tr>" +
                                        "<td>" + drPreviousOrders["Order_ID"] + "</td>" +
                                        "<td>" + drPreviousOrders["Order_name"] + "</td>" +
                                        "<td>" + drPreviousOrders["Order_User_Email"] + "</td>" +
                                        "<td>" + drPreviousOrders["Restaurant_Email"] + "</td>" +
                                        "<td>" + drPreviousOrders["Order_Cost"] + "</td>" +
                                        "<td>" + ddlHTML + "</td>" +
                                        "<td>" + selectHTML + "</td>" +
                                        "</tr>";
                }
                strHTML += "</table>";
            }
            divOrders.InnerHtml = strHTML;
        }
        public void SelectButtonHandler(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Session["OrderID"] = button.ID;
            Response.Redirect("ViewOrder.aspx");

        }
        public void DDLStatus_StatusChange(Object sender, EventArgs e)
        {
            DropDownList ddlStatus = (DropDownList)sender;
            Response.Write(@"<script language='text/javascript'>alert
            ('Please fill out all the fields before creating an account');</script>");
            return;
        }
    }
}