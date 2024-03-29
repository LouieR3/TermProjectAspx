﻿using System;
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
    public partial class BuildMenuItem : System.Web.UI.Page
    {
        Validation validate = new Validation();
        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();
        string email = "";
        int MenuID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //email = Session["AccountID"].ToString();
            email = "burger@gmail.com";

            if (!IsPostBack)
            {
                SetForNull();
            }
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
                lblStatus.Text = "Add-On was Added to menu";
                txtNewAddOn.Visible = false;
                btnAdd.Visible = false;
                btnNewAddOn.Enabled = true;
                btnDeleteAddOn.Visible = true;
                btnDeleteAddOn.Enabled = true;
            }
        }

        protected void btnNewAddOn_Click(object sender, EventArgs e)
        {
            btnDeleteAddOn.Enabled = false;
            btnNewAddOn.Enabled = false;
            txtNewAddOn.Visible = true;
            btnAdd.Visible = true;
        }

        public void SetForNull()
        {
            txtItemName.Visible = true;
            txtItemPrice.Visible = true;
            fleuplItemImage.Visible = true;
            gvAddOn.Visible = false;
            lblAddOns.Visible = true;
            lblItemImage.Visible = true;
            lblItemName.Visible = true;
            lblItemPrice.Visible = true;
            lblAddOns.Text = "Create Item and Then you will be able to create Add Ons";
        }

        protected void btnCreateItem_Click(object sender, EventArgs e)
        {
            string name = txtItemName.Text;
            string price = txtItemPrice.Text;
            string image = fleuplItemImage.FileName;
            string type = ddlType.SelectedValue.ToString();
            if (validate.checkBuildItem(name, price, image, type) == 1)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Please fill out all fields');</script>");
                return;
            }
            else if (validate.checkBuildItem(name, price, image, type) == 2)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('The price should only represented with numbers and a '.' inbetween');</script>");
                return;
            }
            else
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                string fileName = "";
                string photoPath = "";
                string fileExtension = "";

                dbCommand.Parameters.Clear();
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "TP_NewMenuItem";

                SqlParameter inputItemName = new SqlParameter("@ItemName", txtItemName.Text);
                SqlParameter inputItemType = new SqlParameter("@ItemType", ddlType.SelectedValue.ToString());
                SqlParameter inputItemPrice = new SqlParameter("@ItemPrice", double.Parse(txtItemPrice.Text));
                SqlParameter inputItemEmail = new SqlParameter("@Email", email);
                SqlParameter inputPhoto = new SqlParameter();
                if (fleuplItemImage.HasFile)
                {
                    fileName = fleuplItemImage.FileName;
                    fileExtension = fileName.Substring(fileName.LastIndexOf("."));
                    if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".bmp" || fileExtension == ".gif" || fileExtension == ".png")
                    {
                        photoPath = "~/images/" + fileName;
                        fleuplItemImage.SaveAs(Server.MapPath(@"~\images\" + fileName));
                        inputPhoto = new SqlParameter("@ItemPhoto", photoPath);
                    }
                }

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
                dbCommand.Parameters.Add(inputPhoto);

                int countMenuItem = db.DoUpdateUsingCmdObj(dbCommand);
                int menuID;
                menuID = GetMenuID(txtItemName.Text, email);
                Session["MenuID"] = menuID;
                if (menuID >= 1)
                {
                    btnCreateItem.Enabled = false;
                    txtItemName.Enabled = false;
                    txtItemPrice.Enabled = false;
                    fleuplItemImage.Enabled = false;
                    gvAddOn.Visible = true;
                    lblAddOns.Visible = true;
                    lblAddOns.Text = "Create Item Add Ons";
                    btnNewAddOn.Visible = true;
                    ddlType.Enabled = false;
                }
            }
        }
        public int GetMenuID(string name, string email)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_GetMenuItemID";
            SqlParameter inputName = new SqlParameter("@ItemName", txtItemName.Text);
            SqlParameter inputEmail = new SqlParameter("@Email", email);
            SqlParameter outputMenuID = new SqlParameter("@MenuID", 0);

            inputName.Direction = ParameterDirection.Input;
            inputName.SqlDbType = SqlDbType.VarChar;
            inputEmail.Direction = ParameterDirection.Input;
            inputEmail.SqlDbType = SqlDbType.VarChar;
            outputMenuID.Direction = ParameterDirection.Output;
            outputMenuID.SqlDbType = SqlDbType.Int;
            dbCommand.Parameters.Add(inputName);
            dbCommand.Parameters.Add(inputEmail);
            dbCommand.Parameters.Add(outputMenuID);
            db.GetDataSetUsingCmdObj(dbCommand);
            Session["MenuID"] = int.Parse(dbCommand.Parameters["@MenuID"].Value.ToString());
            MenuID = int.Parse(Session["MenuID"].ToString());
            return MenuID;
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
                    LoadAddOns(MenuID);
                    lblStatus.Text = "AddOn Deleted";
                }
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
    }

}