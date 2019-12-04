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
        protected void lnkBtnNext_Click(object sender, EventArgs e)
        {
            txtHidden.Value = Convert.ToString(Convert.ToInt16(txtHidden.Value) + 5);
            bindData();
        }

        protected void lnkBtnPrev_Click(object sender, EventArgs e)
        {
            txtHidden.Value = Convert.ToString(Convert.ToInt16(txtHidden.Value) - 5);
            bindData();
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

            if (countValue <= 0)
            {
                lnkBtnPrev.Visible = false;
                lnkBtnNext.Visible = true;
            }

            if (countValue >= 5)
            {
                lnkBtnPrev.Visible = true;
                lnkBtnNext.Visible = true;
            }

            if ((countValue + 5) >= total)
            {
                lnkBtnNext.Visible = false;
            }
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
            objCommand.CommandText = "Tp_GetOrders";
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
                             "<td> Order Status </td>" +
                             "<td> Order Cost </td>" +
                             "</tr>";
                for (int row = 0; row <= dtPreviousOrders.Rows.Count; row++)
                {
                    drPreviousOrders = dtPreviousOrders.Rows[row];
                    Button select = new Button();
                    select.Text = "View Order";
                    select.ID = drPreviousOrders["Transaction_ID"].ToString();

                    StringBuilder strBuilder = new StringBuilder();
                    StringWriter strWriter = new StringWriter(strBuilder);
                    HtmlTextWriter htmlWriter = new HtmlTextWriter(strWriter);


                    strHTML = strHTML + "<tr>" +
                                        "<td>" + drPreviousOrders["Order_ID"] + "</td>" +
                                        "<td>" + drPreviousOrders["Order_name"] + "</td>" +
                                        "<td>" + drPreviousOrders["Order_User_Email"] + "</td>" +
                                        "<td>" + drPreviousOrders["Restaurant_Email"] + "</td>" +
                                        "<td>" + drPreviousOrders["Order_Status"] + "</td>" +
                                        "<td>" + drPreviousOrders["Order_Cost"] + "</td>" +
                                        "<td>" + select + "</td>" +
                                        "</tr>";
                }
                strHTML += "</table>";
            }
            divOrders.InnerHtml = strHTML;
        }
    }
}