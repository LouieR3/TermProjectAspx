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
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string email = Session["AccountID"].ToString();
            string email = "burger@gmail.com";
            FillGvMenu(email);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            gvMenu.Columns[0].Visible = true;
            btnChange.Visible = true;
            btnDelete.Visible = true;
        }
        public void FillGvMenu(string email)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Tp_GetMenu";
            SqlParameter inputEmail = new SqlParameter("@Email", email);
            objCommand.Parameters.Add(inputEmail);
            DataSet result = db.GetDataSetUsingCmdObj(objCommand);
            gvMenu.DataSource = result;
            gvMenu.DataBind();

            ListBox lb;
            for (int i = 0; i < result.Tables[0].Rows.Count; i++)
            {
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "Tp_GetMenuID";
                SqlParameter menuID = new SqlParameter("@theEmail", email);
                objCommand.Parameters.Add(menuID);
                DataSet idResult = db.GetDataSetUsingCmdObj(objCommand);
                string theMenuID = Convert.ToString(idResult.Tables[0].Rows[i]["Menu_ID"]);
                int mID = int.Parse(theMenuID);
                for (int j = 0; j < idResult.Tables[0].Rows.Count; j++)
                {
                    objCommand.Parameters.Clear();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "Tp_GetAddOns";
                    SqlParameter menuAddOn = new SqlParameter("@MenuID", mID);
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
        public void FillGvMenuAddOns(int It)
        {
            ListBox lsbxAddOns = (ListBox)gvMenu.FindControl("lsbxAddOns");
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_FillAddOns";
            SqlParameter inputItemID = new SqlParameter("@ItemID", ID);

            inputItemID.Direction = ParameterDirection.Input;
            inputItemID.SqlDbType = SqlDbType.Int;

            dbCommand.Parameters.Add(inputItemID);

            DataSet data = db.GetDataSetUsingCmdObj(dbCommand);
            lsbxAddOns.DataSource = data;
            lsbxAddOns.DataTextField = "Text";
            lsbxAddOns.DataValueField = "Value";
            lsbxAddOns.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CheckBox check = new CheckBox();
            int count = 0;
            string ID = "";
            if (count == 1)
            {
                validate.CheckSelectedMenuItem(gvMenu, out count, out ID);
                dbCommand.Parameters.Clear();
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "TP_DeleteMenuItem";
                SqlParameter inputItemID = new SqlParameter("ItemID", ID);

                inputItemID.Direction = ParameterDirection.Input;
                inputItemID.SqlDbType = SqlDbType.Int;

                dbCommand.Parameters.Add(inputItemID);

                int insert = db.DoUpdateUsingCmdObj(dbCommand);
                if (insert == 1)
                {

                }
                gvMenu.DataBind();
            }

        }

        protected void btnNewItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuildMenuItem.aspx");
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {

        }
    }
}