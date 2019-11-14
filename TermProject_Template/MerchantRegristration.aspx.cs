using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
namespace TermProject_Template
{
 
    public partial class MerchantRegristration : System.Web.UI.Page
    {
        Validation validate = new Validation();
        private string APIKey = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnterMerchant_Click(object sender, EventArgs e)
        {
            int count = validate.CheckMerchantExists(txtContactEmail.Text);
            if(count == 1)
            {
                String url = "http://cis-iis2.temple.edu/users/pascucci/CIS3342/CoreWebAPI/api/Calculator/" + APIKey;
            }
        }
    }
}