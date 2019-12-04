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

using Utilities;

namespace TermProject_Template.Restaurant
{
    public partial class BuildMenuItem : System.Web.UI.Page
    {
        Validation validate = new Validation();
        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();
        string email = "";
        int MenuID = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Session["MenuID"].ToString(), out MenuID);
            email = Session["AccountID"].ToString();

            if(ID == null)
            {
                SetForNull();
            }
            if(ID != null)
            {
                SetForNotNull();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
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
            inputAddOnMenuID.SqlDbType = SqlDbType.Float;
            dbCommand.Parameters.Add(inputAddOnName);
            dbCommand.Parameters.Add(inputAddOnEmail);
            dbCommand.Parameters.Add(inputAddOnMenuID);

            int countMenuItem = db.DoUpdateUsingCmdObj(dbCommand);
            gvAddOn.DataBind();
            if(countMenuItem == 1)
            {
                lblStatus.Text = "Add-On was Added to menu";
            }
        }

        protected void btnNewAddOn_Click(object sender, EventArgs e)
        {
            btnNewAddOn.Enabled = false;
            txtNewAddOn.Visible = true;
            btnAdd.Visible = true;

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_NewMenuItem";

            SqlParameter inputItemName = new SqlParameter("@ItemName", txtItemName.Text);
            SqlParameter inputItemType = new SqlParameter("@ItemType", ddlType.SelectedValue.ToString());
            SqlParameter inputItemPrice = new SqlParameter("@ItemPrice", double.Parse(txtItemPrice.Text));
            SqlParameter inputItemEmail = new SqlParameter("@Email",email );

            inputItemName.Direction = ParameterDirection.Input;
            inputItemName.SqlDbType = SqlDbType.VarChar;
            inputItemType.Direction = ParameterDirection.Input;
            inputItemType.SqlDbType = SqlDbType.VarChar;
            inputItemPrice.Direction = ParameterDirection.Input;
            inputItemPrice.SqlDbType = SqlDbType.Float;
            inputItemEmail.Direction = ParameterDirection.Input;
            inputItemEmail.SqlDbType = SqlDbType.VarChar;
            dbCommand.Parameters.Add(inputItemName);
            dbCommand.Parameters.Add(inputItemType);
            dbCommand.Parameters.Add(inputItemPrice);
            dbCommand.Parameters.Add(inputItemEmail);

            int countMenuItem = db.DoUpdateUsingCmdObj(dbCommand);

            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_GetMenuID";
            SqlParameter inputName = new SqlParameter("@ItemName", txtItemName.Text);
            SqlParameter inputEmail = new SqlParameter("@Email", email);
            SqlParameter outputMenuID = new SqlParameter("@MenuID", 0);

            inputName.Direction = ParameterDirection.Input;
            inputName.SqlDbType = SqlDbType.VarChar;
            inputEmail.Direction = ParameterDirection.Input;
            inputEmail.SqlDbType = SqlDbType.VarChar;
            outputMenuID.Direction = ParameterDirection.Input;
            outputMenuID.SqlDbType = SqlDbType.Float;
            dbCommand.Parameters.Add(inputName);
            dbCommand.Parameters.Add(inputEmail);
            dbCommand.Parameters.Add(outputMenuID);
            db.GetDataSetUsingCmdObj(dbCommand);
            int menuID = int.Parse(dbCommand.Parameters["@MenuID"].Value.ToString());
            Session["MenuID"] = menuID;

            if (countMenuItem == 1)
            {             
                    int result = 0, imageSize;
                    string fileExtension, imageType, imageName, imageTitle, strSQL;

                    try
                    {
                        // Use the FileUpload control to get the uploaded data
                        if (fleuplItemImage.HasFile)
                        {
                            imageSize = fleuplItemImage.PostedFile.ContentLength;

                            byte[] imageData = new byte[imageSize];
                            fleuplItemImage.PostedFile.InputStream.Read(imageData, 0, imageSize);
                            imageName = fleuplItemImage.PostedFile.FileName;

                            imageType = fleuplItemImage.PostedFile.ContentType;
                            imageTitle = txtItemName.Text;
                            fileExtension = imageName.Substring(imageName.LastIndexOf("."));
                            fileExtension = fileExtension.ToLower();

                            if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".bmp" || fileExtension == ".gif")
                            {
                                dbCommand.Parameters.Clear();
                                dbCommand.CommandType = CommandType.StoredProcedure;
                                dbCommand.CommandText = "TP_AddMenuImage";

                                objCommand.Parameters.AddWithValue("@ImageTitle", imageTitle);
                                objCommand.Parameters.AddWithValue("@ImageData", imageData);
                                objCommand.Parameters.AddWithValue("@ImageType", imageType);
                                objCommand.Parameters.AddWithValue("@ImageLength", imageData.Length);
                                objCommand.Parameters.AddWithValue("@MenuID", MenuID);
                                result = objDB.DoUpdateUsingCmdObj(objCommand);
                                if (result == 1)
                                {
                                    lblStatus.Text = "Image was successully uploaded.";
                                }
                            }
                            else
                            {
                                lblStatus.Text = "Only jpg, bmp, and gif file formats supported.";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = "Error ocurred: [" + ex.Message + "] cmd=" + result;
                    }
                
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        public void SetForNull()
        {

        }
        public void SetForNotNull()
        {            
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_GetMenuItem";
            SqlParameter inputMenuID = new SqlParameter("@MenuID",MenuID);
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
            SqlParameter inputID = new SqlParameter("@MenuID", MenuID);
            inputMenuID.Direction = ParameterDirection.Input;
            inputMenuID.SqlDbType = SqlDbType.Int;
            dbCommand.Parameters.Add(inputMenuID);
            DataSet Ds = db.GetDataSetUsingCmdObj(dbCommand);
            gvAddOn.DataSource = Ds;
            gvAddOn.DataBind();

        }

        protected void btnCreateItem_Click(object sender, EventArgs e)
        {

        }
        public int GetMenuID()
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_GetMenuID";
            SqlParameter inputName = new SqlParameter("@ItemName", txtItemName.Text);
            SqlParameter inputEmail = new SqlParameter("@Email", email);
            SqlParameter outputMenuID = new SqlParameter("@MenuID", 0);

            inputName.Direction = ParameterDirection.Input;
            inputName.SqlDbType = SqlDbType.VarChar;
            inputEmail.Direction = ParameterDirection.Input;
            inputEmail.SqlDbType = SqlDbType.VarChar;
            outputMenuID.Direction = ParameterDirection.Input;
            outputMenuID.SqlDbType = SqlDbType.Float;
            dbCommand.Parameters.Add(inputName);
            dbCommand.Parameters.Add(inputEmail);
            dbCommand.Parameters.Add(outputMenuID);
            db.GetDataSetUsingCmdObj(dbCommand);
            int menuID = int.Parse(dbCommand.Parameters["@MenuID"].Value.ToString());
            Session["MenuID"] = menuID;
            return menuID;
        }

        protected void btnDeleteAddOn_Click(object sender, EventArgs e)
        {
            int count = 0;
            string AddOnID = "";
            validate.CheckSelectedMenuItem(gvAddOn, out count, out AddOnID);
            int.TryParse(AddOnID, out int ID);
            if(count ==1)
            {

                dbCommand.Parameters.Clear();
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "TP_DeleteAddOn";

                SqlParameter inputName = new SqlParameter("@AddOnID", ID);

                inputName.Direction = ParameterDirection.Input;
                inputName.SqlDbType = SqlDbType.VarChar;

                dbCommand.Parameters.Add(inputName);
                int delete = db.DoUpdateUsingCmdObj(dbCommand);
                if(delete == 1)
                {

                }
            }
        }
    }
    
}