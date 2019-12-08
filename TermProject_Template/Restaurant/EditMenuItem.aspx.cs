using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Net;
using System.Data;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Windows.Forms;
using Utilities;

namespace TermProject_Template.Restaurant
{
    public partial class EditMenuItem : System.Web.UI.Page
    {
        Validation validate = new Validation();
        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();
        string email;
        int menuID;
        protected void Page_Load(object sender, EventArgs e)
        {
            email = Session["AccountID"].ToString();
            if (!IsPostBack)
            {
                menuID = int.Parse(Session["MenuID"].ToString());
                SetForNotNull(menuID);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string price = txtItemPrice.Text;
            if (txtItemName.Text != "" || ddlType.Text != "" || txtItemPrice.Text != "" || fleuplItemImage.FileName != "" || !price.Contains("qwertyuiop[]\asdfghjkl;'zxcvbnm,/_~`!@#$%^&*()+"))
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                dbCommand.Parameters.Clear();
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "TP_UpdateMenuItem";

                SqlParameter inputItemName = new SqlParameter("@ItemName", txtItemName.Text);
                SqlParameter inputItemType = new SqlParameter("@ItemType", ddlType.SelectedValue.ToString());
                SqlParameter inputItemPrice = new SqlParameter("@ItemPrice", double.Parse(txtItemPrice.Text));
                SqlParameter inputItemEmail = new SqlParameter("@Email", email);

                inputItemName.Direction = ParameterDirection.Input;
                inputItemName.SqlDbType = SqlDbType.VarChar;
                inputItemType.Direction = ParameterDirection.Input;
                inputItemType.SqlDbType = SqlDbType.VarChar;
                inputItemPrice.Direction = ParameterDirection.Input;
                inputItemPrice.SqlDbType = SqlDbType.Float;
                inputItemEmail.Direction = ParameterDirection.Input;
                inputItemEmail.SqlDbType = SqlDbType.VarChar;
                inputItemEmail.Direction = ParameterDirection.Input;
                inputItemEmail.SqlDbType = SqlDbType.VarChar;
                dbCommand.Parameters.Add(inputItemName);
                dbCommand.Parameters.Add(inputItemType);
                dbCommand.Parameters.Add(inputItemPrice);
                dbCommand.Parameters.Add(inputItemEmail);

                int countMenuItem = db.DoUpdateUsingCmdObj(dbCommand);
                if (countMenuItem >= 1)
                {
                    txtItemName.Enabled = false;
                    txtItemPrice.Enabled = false;
                    ddlType.Enabled = false;
                    btnNewAddOn.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDeleteAddOn.Enabled = false;
                    btnEdit.Enabled = true;
                    Response.Write(@"<script langauge='text/javascript'>alert
                    ('Updated');</script>");
                    return;
                }
                else
                {
                    Response.Write(@"<script langauge='text/javascript'>alert
                    ('Something went wrong with updating, make sure all fields are filled out correctly');</script>");
                    return;
                }
            }
            else
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Please fill out all fields');</script>");
                return;
            }
        }
        public void SetForNotNull(int menuID)
        {
            txtItemName.Enabled = false;
            txtItemPrice.Enabled = false;
            fleuplItemImage.Enabled = false;
            ddlType.Enabled = false;
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_GetMenuItem";
            SqlParameter inputMenuID = new SqlParameter("@MenuID", menuID);
            inputMenuID.Direction = ParameterDirection.Input;
            inputMenuID.SqlDbType = SqlDbType.Int;
            dbCommand.Parameters.Add(inputMenuID);
            DataSet ds = db.GetDataSetUsingCmdObj(dbCommand);
            txtItemName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Item_Name"]);
            txtItemPrice.Text = Convert.ToString(ds.Tables[0].Rows[0]["Item_Price"]);
            ddlType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Item_Type"]);

            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_GetAddOns";
            SqlParameter inputID = new SqlParameter("@MenuID", menuID);
            inputMenuID.Direction = ParameterDirection.Input;
            inputMenuID.SqlDbType = SqlDbType.Int;
            dbCommand.Parameters.Add(inputMenuID);
            DataSet Ds = db.GetDataSetUsingCmdObj(dbCommand);
            gvAddOn.DataSource = Ds;
            gvAddOn.DataBind();

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int MenuID = int.Parse(Session["MenuID"].ToString());
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_NewAddOns";

            SqlParameter inputAddOnName = new SqlParameter("@AddOnName", txtNewAddOn.Text);
            SqlParameter inputAddOnEmail = new SqlParameter("@Email", email);
            SqlParameter inputAddOnMenuID = new SqlParameter("@MenuID", MenuID);

            inputAddOnName.Direction = ParameterDirection.Input;
            inputAddOnName.SqlDbType = SqlDbType.VarChar;
            inputAddOnEmail.Direction = ParameterDirection.Input;
            inputAddOnEmail.SqlDbType = SqlDbType.VarChar;
            inputAddOnMenuID.Direction = ParameterDirection.Input;
            inputAddOnMenuID.SqlDbType = SqlDbType.Int;
            dbCommand.Parameters.Add(inputAddOnName);
            dbCommand.Parameters.Add(inputAddOnEmail);
            dbCommand.Parameters.Add(inputAddOnMenuID);

            int countMenuItem = db.DoUpdateUsingCmdObj(dbCommand);
            LoadAddOns(MenuID);
            if (countMenuItem == 1)
            {
                txtNewAddOn.Visible = false;
                btnAdd.Visible = false;
                btnNewAddOn.Enabled = true;
                btnDeleteAddOn.Visible = true;
                btnDeleteAddOn.Enabled = true;
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Add-On was Added to menu');</script>");
                return;
            }
        }
        protected void btnNewAddOn_Click(object sender, EventArgs e)
        {
            btnDeleteAddOn.Enabled = false;
            btnNewAddOn.Enabled = false;
            txtNewAddOn.Visible = true;
            btnAdd.Visible = true;

        }
        protected void btnDeleteAddOn_Click(object sender, EventArgs e)
        {
            int count = 0;
            string AddOnID = "";
            validate.CheckSelectedMenuItem(gvAddOn, out count, out AddOnID);
            int.TryParse(AddOnID, out int ID);
            if (count == 1)
            {

                dbCommand.Parameters.Clear();
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "TP_DeleteAddOn";

                SqlParameter inputName = new SqlParameter("@AddOnID", ID);

                inputName.Direction = ParameterDirection.Input;
                inputName.SqlDbType = SqlDbType.VarChar;

                dbCommand.Parameters.Add(inputName);
                int delete = db.DoUpdateUsingCmdObj(dbCommand);
                if (delete == 1)
                {
                    LoadAddOns(menuID);
                    Response.Write(@"<script langauge='text/javascript'>alert
                    ('AddOn Deleted');</script>");
                    return;
                }
            }
            else
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                    ('You must select an Add On first');</script>");
                return;
            }
        }
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Session.Remove("MenuID");
            Response.Redirect("CreateMenu.Aspx");
        }
        public void LoadAddOns(int ID)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_GetAddOns";

            SqlParameter inputName = new SqlParameter("@MenuID", ID);

            inputName.Direction = ParameterDirection.Input;
            inputName.SqlDbType = SqlDbType.VarChar;

            dbCommand.Parameters.Add(inputName);
            DataSet ds = db.GetDataSetUsingCmdObj(dbCommand);
            gvAddOn.DataSource = ds;
            gvAddOn.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtItemName.Enabled = true;
            txtItemPrice.Enabled = true;
            fleuplItemImage.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = true;
            btnNewAddOn.Enabled = true;
            ddlType.Enabled = true;
            btnDeleteAddOn.Enabled = true;
        }
    }
}