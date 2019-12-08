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
    public partial class NewOrderaspx : System.Web.UI.Page
    {
        DataSet dsRest = new DataSet();
        SqlCommand objCommand = new SqlCommand();
        DBConnect db = new DBConnect();
        Email email = new Email();
        string accountID;
        
        int OrderID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                accountID = Session["AccountID"].ToString();
                OrderID = int.Parse(Session["OrderID"].ToString());
                loadOrder(OrderID);
            }

        }
        public void loadOrder(int OrderID)
        {
            string strTO = "orderconfirmation@quickeats.com";
            string strFROM = accountID;
            string strSubject = "Order";
            string strMessage= ""
            
            string strHTML = "";
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Tp_GetOrderInfo";
            SqlParameter inputEmail = new SqlParameter("@OrderID", OrderID);

            objCommand.Parameters.Add(inputEmail);
            DataSet result = db.GetDataSetUsingCmdObj(objCommand);
            lblOrderName.Text = Convert.ToString(result.Tables[0].Rows[0]["Order_Name"]);
            lblUserEmail.Text = Convert.ToString(result.Tables[0].Rows[0]["Order_User_Email"]);
            lblRestaurantEmail.Text = Convert.ToString(result.Tables[0].Rows[0]["Restaurant_Email"]);
            lblOrderStatus.Text = Convert.ToString(result.Tables[0].Rows[0]["Order_Status"]);
            lblOrderCost.Text = Convert.ToString(result.Tables[0].Rows[0]["Order_Cost"]);
            lblOrderDate.Text = Convert.ToString(result.Tables[0].Rows[0]["Order_Date"]);

            strMessage = "Order Name: " + lblOrderName.Text +
                            "Order Email: " + lblUserEmail.Text +
                            "Restaurant Email: " + lblRestaurantEmail.Text +
                            "Order Status:" + lblOrderStatus.Text +
                            "Order Cost" + lblOrderCost.Text + "<br>" + "<br>";

            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Tp_GetOrderItem";
            SqlParameter inputOrderID = new SqlParameter("@OrderID", OrderID);

            objCommand.Parameters.Add(inputOrderID);
            DataSet ds = db.GetDataSetUsingCmdObj(objCommand);

            DataTable dtPreviousOrders = ds.Tables[0];
            DataRow drPreviousOrders;
            if (dtPreviousOrders.Rows.Count != 0)
            {
                
                strHTML = strHTML + "<table>" +
                             "<tr style='font-weight:bold; color:black'>" +
                             "<td> Item Name</td>" +
                             "<td> Item Cost </td>" +
                             "<td> Item Add Ons </td>" +
                             "<td> Item Type </td>" +
                             "</tr>";
                for (int row = 0; row < dtPreviousOrders.Rows.Count; row++)
                {
                    drPreviousOrders = dtPreviousOrders.Rows[row];

                    StringBuilder strBuilder = new StringBuilder();
                    StringWriter strWriter = new StringWriter(strBuilder);
                    HtmlTextWriter htmlWriter = new HtmlTextWriter(strWriter);

                    strHTML = strHTML + "<tr>" +
                                        "<td>" + drPreviousOrders["Order_Item_Name"] + "</td>" +
                                        "<td>" + drPreviousOrders["Order_Item_Cost"] + "</td>" +
                                        "<td>" + drPreviousOrders["Order_Item_Add_Ons"] + "</td>" +
                                        "<td>" + drPreviousOrders["Order_Item_Type"] + "</td>" +
                                        "</tr>";
                    strMessage += "Item Name: " + drPreviousOrders["Order_Item_Name"] +
                                     "Item Cost: " + drPreviousOrders["Order_Item_Cost"] +
                                     "Item Add Ons" + drPreviousOrders["Order_Item_Add_Ons"] +
                                     "Item Type" + drPreviousOrders["Order_Item_Type"];

                }
                strHTML += "</table>";
            }
            ViewOrder.InnerHtml = strHTML;
            email.SendMail(strTO, strFROM, strSubject, strMessage);
        }
    }
}