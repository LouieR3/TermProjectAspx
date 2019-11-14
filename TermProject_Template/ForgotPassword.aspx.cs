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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnterEmail_Click(object sender, EventArgs e)
        {
            if(validate.CheckUserExists(txtEnterEmail.Text) == 1)
            {

            }
        }
    }
}