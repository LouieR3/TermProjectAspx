using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using Utilities;
using System.Data;

namespace TermProject_Template.Restaurant
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Validation validate = new Validation();
        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            fillGvMenuAddOns();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            gvMenu.Columns[0].Visible = true;
        }
        public void fillGvMenuAddOns()
        {
            ListBox lsbxAddOns = (ListBox)gvMenu.FindControl("lsbxAddOns");

            lsbxAddOns.DataSource = data;
            lsbxAddOns.DataTextField = "Text";
            lsbxAddOns.DataValueField = "Value";
            lsbxAddOns.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CheckBox check = new CheckBox();
            if()
           int ItemID = (int)gvMenu.Columns
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_DeleteMenuItem";
            SqlParameter inputItemID = new SqlParameter("ItemID",)
        }
    }
}