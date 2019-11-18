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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNewPassword_Click(object sender, EventArgs e)
        {
            string pass = txtPass.Text.ToString();
            string confirm = txtConfirm.Text.ToString();
            if (validationOBJ.checkReset(pass, confirm))
            {
                Response.Redirect("UserLogin.aspx");
            }
            else
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('These passwords don't match, try again');</script>");
                return;
            }
        }
    }
}