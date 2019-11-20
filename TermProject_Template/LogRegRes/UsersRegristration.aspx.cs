using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject_Template
{
    public partial class UsersRegristration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string loginID = txtLoginID.Text;
            string email = txtCreateEmail.Text;
            string first = txtFirstName.Text;
            string last = txtLastName.Text;
            string pass = txtCreatePW.Text;
            string billing = txtBilling.Text;
            string delivery = txtDelivery.Text;
        }
    }
}