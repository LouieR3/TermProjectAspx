using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace TermProject_Template
{
    public partial class UserLogin : System.Web.UI.Page
    {
        HttpCookie myCookie = new HttpCookie("theCookie");
        Validation validationOBJ = new Validation();
        int BoxChecked = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(myCookie != null)
                {
                    txtEmail.Text = myCookie.Values["AccountID"].ToString();
                    txtPassword.Text = myCookie.Values["AccountPass"].ToString();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtEmail.Text.ToString();
            string pass = txtPassword.Text.ToString();
            if (validationOBJ.checkLogin(login, pass) == false)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Please fill out the fields correctly');</script>");
                return;
            }
            else if (validationOBJ.CheckUserLogin(login, pass) == false)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Your login info is incorrect, try again');</script>");
                return;
            }
            else
            {
                if (chkRememberMe.Checked == true)
                {
                    myCookie.Expires = new DateTime(2025, 1, 1);
                    myCookie.Values["AccountID"] = login;
                    myCookie.Values["AccountPass"] = pass;
                    Response.Cookies.Add(myCookie);
                }
                Response.Redirect("../Users/UserDashboard.aspx");
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