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
    public partial class AccountSettings : System.Web.UI.UserControl
    {
        private string email = "";
        Validation validate = new Validation();
        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["AccountID"].ToString();
            DisplayAccountInformation();
        }
        public void DisplayAccountInformation()
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_GetAccountInformation";

            SqlParameter inputVirtualWalletID = new SqlParameter("@Email", email);

            inputVirtualWalletID.Direction = ParameterDirection.Input;
            inputVirtualWalletID.SqlDbType = SqlDbType.VarChar;

            dbCommand.Parameters.Add(inputVirtualWalletID);

            db.GetDataSetUsingCmdObj(dbCommand);

            txtLoginID.Text = db.GetField("LoginID",0).ToString();
            txtPassword.Text = db.GetField("UserPassword", 0).ToString();
            txtUserFirstName.Text = db.GetField("UserFirstName", 0).ToString();
            txtUserLastName.Text = db.GetField("UserLastName", 0).ToString();
            txtBillingAddress.Text = db.GetField("UserPassword", 0).ToString();
            txtDeliveryAddress.Text = db.GetField("UserPassword", 0).ToString();
            txtEmail.Text = db.GetField("UserEmail", 0).ToString();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "" && txtUserFirstName.Text != "" && txtUserLastName.Text != "" && txtBillingAddress.Text != "" && txtDeliveryAddress.Text != "")
            {
                DisableFields();
                dbCommand.Parameters.Clear();
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "TP_UpdateAccountInformation";

                SqlParameter inputEmail = new SqlParameter("@Email", email);
                SqlParameter inputLoginID = new SqlParameter("@LoginID", email);
                SqlParameter inputPassword = new SqlParameter("@Password", email);
                SqlParameter inputFirstName = new SqlParameter("@FirstName", email);
                SqlParameter inputLastName = new SqlParameter("@LastName", email);
                SqlParameter inputBillingAddress = new SqlParameter("@BillingAddress", email);
                SqlParameter inputDeliveryAddress = new SqlParameter("@DeliveryAddress", email);

                inputEmail.Direction = ParameterDirection.Input;
                inputEmail.SqlDbType = SqlDbType.VarChar;
                inputLoginID.Direction = ParameterDirection.Input;
                inputLoginID.SqlDbType = SqlDbType.VarChar;
                inputPassword.Direction = ParameterDirection.Input;
                inputPassword.SqlDbType = SqlDbType.VarChar;
                inputFirstName.Direction = ParameterDirection.Input;
                inputFirstName.SqlDbType = SqlDbType.VarChar;
                inputLastName.Direction = ParameterDirection.Input;
                inputLastName.SqlDbType = SqlDbType.VarChar;
                inputBillingAddress.Direction = ParameterDirection.Input;
                inputBillingAddress.SqlDbType = SqlDbType.VarChar;
                inputDeliveryAddress.Direction = ParameterDirection.Input;
                inputDeliveryAddress.SqlDbType = SqlDbType.VarChar;

                dbCommand.Parameters.Add(inputEmail);
                dbCommand.Parameters.Add(inputLoginID);
                dbCommand.Parameters.Add(inputPassword);
                dbCommand.Parameters.Add(inputFirstName);
                dbCommand.Parameters.Add(inputLastName);
                dbCommand.Parameters.Add(inputBillingAddress);
                dbCommand.Parameters.Add(inputDeliveryAddress);

                int count = db.DoUpdateUsingCmdObj(dbCommand);
                if(count == 1)
                {
                    DisableFields();
                }
            }
        }
        public void EnableFields()
        {
            txtLoginID.Enabled = true;
            txtEmail.Enabled = true;
            txtPassword.Enabled = true;
            txtUserFirstName.Enabled = true;
            txtUserLastName.Enabled = true;
            txtBillingAddress.Enabled = true;
            txtDeliveryAddress.Enabled = true;
        }
        public void DisableFields()
        {
            txtLoginID.Enabled = false;
            txtEmail.Enabled = false;
            txtPassword.Enabled = false;
            txtUserFirstName.Enabled = false;
            txtUserLastName.Enabled = false;
            txtBillingAddress.Enabled = false;
            txtDeliveryAddress.Enabled = false;
        }
    }
}