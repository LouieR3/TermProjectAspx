using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace TermProject_Template
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Validation validationOBJ = new Validation();
        HttpCookie objCookie;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNewPassword_Click(object sender, EventArgs e)
        {
            objCookie = Request.Cookies["theResetEmail"];
            string email = objCookie.ToString();

            string pass = txtPass.Text.ToString();
            string confirm = txtConfirm.Text.ToString();
            if (validationOBJ.checkReset(pass, confirm) == 4)
            {
                Response.Redirect("UserLogin.aspx");
            }
            else if(validationOBJ.checkReset(pass, confirm) == 1)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('These passwords don't match, try again');</script>");
                return;
            }
            else if (validationOBJ.checkReset(pass, confirm) == 2)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('One or both of these passwords have not been filled in, please fill in each form and try again');</script>");
                return;
            }
            else if (validationOBJ.checkReset(pass, confirm) == 3)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('This password matches your existing password, please make a new password  ');</script>");
                return;
            }
        }
    }
}