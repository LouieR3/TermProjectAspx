using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;


namespace TermProject_Template
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();
        Validation validate = new Validation();
        HttpCookie restEmail = new HttpCookie("theResetEmail");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnterEmail_Click1(object sender, EventArgs e)
        {
            if (validate.CheckUserExists(txtEnterEmail.Text) == 1)
            {
                Email objEmail = new Email();
                String strTO = txtEnterEmail.Text;
                String strFROM = "passwordrequest@quickeats.com";
                String strSubject = "QuickEats Account Password Reset";
                String strMessage = "Please copy and paste the link below in your browser to reset your password";
                try
                {
                    objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                    txtEnterEmail.Visible = false;
                    btnEnterEmail.Visible = false;
                    lblError.Text = "Email was sent! Follow instructions to reset password";
                    restEmail.Expires = new DateTime(2025, 1, 1);
                    restEmail.Values["ResetEmail"] = txtEnterEmail.Text;
                    Response.Cookies.Add(restEmail);
                }
                catch
                {
                    lblError.Text = "Email could not be sent try again";
                }
            }
            else
            {
                lblError.Text = "Email could not be found in System. Please make sure you are entering a valid email";
            }
        }
    }
}