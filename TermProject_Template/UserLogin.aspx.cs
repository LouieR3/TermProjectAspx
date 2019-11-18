using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace TermProject_Template
{
    public partial class UserLogin : System.Web.UI.Page
    {
        Validation validationOBJ = new Validation();
        int BoxChecked = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.ToString();
            string pass = txtPassword.Text.ToString();
            if (validationOBJ.checkLogin(email, pass) == false)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Please fill out the fields correctly');</script>");
                return;
            }
            else if (validationOBJ.CheckUserLogin(email, pass) == false)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Your login info is incorrect, try again');</script>");
                return;
            }
            else
            {
                if (chkRememberMe.Checked == true)
                {

                }
                Response.Redirect("ForgotPassword.aspx");
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            BoxChecked = 1;
        }
    }
}