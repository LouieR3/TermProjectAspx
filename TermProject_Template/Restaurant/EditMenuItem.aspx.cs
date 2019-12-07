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
            email = "burger@gmail.com";
            menuID = int.Parse(Session["MenuID"].ToString());
            SetForNotNull(menuID);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            string fileName = "";
            string photoPath = "";
            string fileExtension = "";

            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_UpdateMenuItem";

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
        }
        public void SetForNotNull(int menuID)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_GetMenuItem";
            SqlParameter inputMenuID = new SqlParameter("@MenuID", menuID);
            inputMenuID.Direction = ParameterDirection.Input;
            inputMenuID.SqlDbType = SqlDbType.Int;
            dbCommand.Parameters.Add(inputMenuID);
            DataSet ds = db.GetDataSetUsingCmdObj(dbCommand);
            txtItemName.Text = dbCommand.Parameters["Item_Name"].Value.ToString();
            txtItemPrice.Text = dbCommand.Parameters["Item_Price"].Value.ToString();
            ddlType.SelectedValue = dbCommand.Parameters["Item_Type"].Value.ToString();

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
    }
}