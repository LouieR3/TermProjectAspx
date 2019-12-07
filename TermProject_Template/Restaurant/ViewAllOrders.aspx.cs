using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject_Template.Restaurant
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string orderID = "";
            if (!IsPostBack)
            {
                orderID = Session["OrderID"].ToString();
            }
        }
    }
}