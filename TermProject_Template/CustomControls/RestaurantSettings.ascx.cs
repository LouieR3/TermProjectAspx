using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using Utilities;

namespace TermProject_Template.CustomControls
{
    public partial class RestaurantSettings : System.Web.UI.UserControl
    {
        string email = "";
        Validation validate = new Validation();
        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                email = Session["AccountID"].ToString();
                DisplayAccountInformation(email);
            }
        }

        public void DisplayAccountInformation(string email)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_GetRestaurantInformation";

            SqlParameter inputEmailID = new SqlParameter("@theEmail", email);

            inputEmailID.Direction = ParameterDirection.Input;
            inputEmailID.SqlDbType = SqlDbType.VarChar;

            dbCommand.Parameters.Add(inputEmailID);

            DataSet ds = db.GetDataSetUsingCmdObj(dbCommand);

            txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["RestName"]);
            txtEmail.Text = email;
            txtPassword.Text = Convert.ToString(ds.Tables[0].Rows[0]["RestPass"]);
            txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["RestAddress"]);
            txtPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["RestPhone"]);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
            btnUpdate.Enabled = true;
            btnEdit.Enabled = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "" && txtAddress.Text != "" && txtEmail.Text != "" && txtName.Text != "" && txtPhone.Text != "")
            {
                dbCommand.Parameters.Clear();
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "TP_UpdateRestaurantInformation";

                SqlParameter inputEmail = new SqlParameter("@Email", txtEmail.Text);
                SqlParameter inputName = new SqlParameter("@Name", txtName.Text);
                SqlParameter inputPassword = new SqlParameter("@Password", txtPassword.Text);
                SqlParameter inputAddress = new SqlParameter("@Address", txtAddress.Text);
                SqlParameter inputPhone = new SqlParameter("@Phone", txtPhone.Text);

                inputEmail.Direction = ParameterDirection.Input;
                inputEmail.SqlDbType = SqlDbType.VarChar;
                inputName.Direction = ParameterDirection.Input;
                inputName.SqlDbType = SqlDbType.VarChar;
                inputPassword.Direction = ParameterDirection.Input;
                inputPassword.SqlDbType = SqlDbType.VarChar;
                inputAddress.Direction = ParameterDirection.Input;
                inputAddress.SqlDbType = SqlDbType.VarChar;
                inputPhone.Direction = ParameterDirection.Input;
                inputPhone.SqlDbType = SqlDbType.VarChar;

                dbCommand.Parameters.Add(inputEmail);
                dbCommand.Parameters.Add(inputName);
                dbCommand.Parameters.Add(inputPassword);
                dbCommand.Parameters.Add(inputAddress);
                dbCommand.Parameters.Add(inputPhone);

                int count = db.DoUpdateUsingCmdObj(dbCommand);
                if (count >= 1)
                {
                    DisableFields();
                    btnEdit.Enabled = true;
                    btnUpdate.Enabled = false;
                }
            }
        }

        public void EnableFields()
        {
            txtName.Enabled = true;
            txtPassword.Enabled = true;
            txtAddress.Enabled = true;
            txtPhone.Enabled = true;

        }
        public void DisableFields()
        {
            txtName.Enabled = false;
            txtPassword.Enabled = false;
            txtAddress.Enabled = false;
            txtPhone.Enabled = false;
        }
    }
}