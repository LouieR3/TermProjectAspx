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
        string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string email = Session["AccountID"].ToString();
            email = "burger@gmail.com";
            if (!IsPostBack)
            {
                FillGvMenu(email);
            }
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
                objCommand.CommandText = "Tp_CheckAddOns";
                SqlParameter restEmail = new SqlParameter("@theEmail", email);
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
            int count = 0;
            string ID = "";
            validate.CheckSelectedMenuID(gvMenu, out count, out ID);
            if (count == 1)
            {
                dbCommand.Parameters.Clear();
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "TP_DeleteMenuItem";
                SqlParameter inputItemID = new SqlParameter("@ItemID", ID);

                inputItemID.Direction = ParameterDirection.Input;
                inputItemID.SqlDbType = SqlDbType.Int;
                dbCommand.Parameters.Add(inputItemID);

                int insert = db.DoUpdateUsingCmdObj(dbCommand);
                if (insert == 1)
                {

                }
                FillGvMenu(email);
            }

        }

        protected void btnNewItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuildMenuItem.aspx");
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            int count = 0;
            string id = "";
            validate.CheckSelectedMenuID(gvMenu, out count, out id);
            if(count == 1)
            {
                Session["MenuID"] = int.Parse(id);
                Response.Redirect("EditMenuItem.aspx");
            }
            
        }
    }
}