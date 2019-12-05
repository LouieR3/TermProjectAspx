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
        Validation validate = new Validation();
        SqlCommand objCommand = new SqlCommand();
        DBConnect db = new DBConnect();
        private string APIKey = "nV17vFTeaH";
        private int MerchantAccountID = 2;
        string accountID = "";
        string restaurantID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            ListBox lb;
            gvMenu.DataSource = result;
            gvMenu.DataBind();
            for (int i = 0; i < result.Tables[0].Rows.Count; i++)
            {                
                lb = (ListBox)gvMenu.Rows[i].FindControl("lbAddOns");
                lb.DataSource = result;
                lb.DataTextField = "Add_On_Name";
                lb.DataValueField = "Add_On_Name";
                lb.DataBind();
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            int check = 0;
            validate.checkChecks(gvMenu, out check);
            if (check >= 1)
            {
                for (int row = 0; row < gvMenu.Rows.Count; row++)
                {
                    CheckBox CBox;
                    // Get the reference for the chkSelect control in the current row
                    CBox = (CheckBox)gvMenu.Rows[row].FindControl("checkSelect");
                    ListBox lb = (ListBox)gvMenu.Rows[row].FindControl("lbAddOns");
                    if (CBox.Checked == true)
                    {
                        OrderItem item = new OrderItem();
                        item.Name = gvMenu.Rows[row].Cells[0].Text;
                        item.Price = gvMenu.Rows[row].Cells[0].Text;
                        item.Type = gvMenu.Rows[row].Cells[0].Text;
                        for (int a = 0; a <= lb.SelectedValue.Count(); a++)
                        {
                            item.createAddOn(lb.SelectedValue);
                        }
                    }
                }
            }
        }

    }
}