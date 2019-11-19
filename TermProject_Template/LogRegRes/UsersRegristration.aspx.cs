using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace TermProject_Template
{
    public partial class UsersRegristration : System.Web.UI.Page
    {
        HttpCookie myCookie = new HttpCookie("theCookie");
        Validation validationOBJ = new Validation();
        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string first = txtFirstName.Text;
            string last = txtLastName.Text;
            string email = txtCreateEmail.Text;
            string pass = txtCreatePW.Text;
            string billing = txtBillingAddress.Text;
            string delivery = txtDeliveryAddress.Text;
            string loginID = txtLoginID.Text;

            if(validationOBJ.checkCreateAccount(first, last, email, billing, delivery, pass) == 1)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Please fill out all the fields before creating an account');</script>");
                return;
            }
            else if (validationOBJ.checkCreateAccount(first, last, email, billing, delivery, pass) == 2)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Please make sure your email is in proper format (Using both an '@' and '.')');</script>");
                return;
            }
            else if (validationOBJ.checkCreateAccount(first, last, email, billing, delivery, pass) == 3)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('An account with this email already exists, try another email');</script>");
                return;
            }
            else if (validationOBJ.checkCreateAccount(first, last, email, billing, delivery, pass) == 4)
            {
                dbCommand.Parameters.Clear();
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "TP_AddUser";
                SqlParameter inputParameter = new SqlParameter("@theLoginID", loginID);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                dbCommand.Parameters.Add(inputParameter);

                inputParameter = new SqlParameter("@theEmail", email);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                dbCommand.Parameters.Add(inputParameter);

                inputParameter = new SqlParameter("@thePassword", pass);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                dbCommand.Parameters.Add(inputParameter);

                inputParameter = new SqlParameter("@theFirstName", first);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                dbCommand.Parameters.Add(inputParameter);

                inputParameter = new SqlParameter("@theLastName", last);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                dbCommand.Parameters.Add(inputParameter);

                inputParameter = new SqlParameter("@theBilling", billing);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 100;                                // 100-bytes ~ varchar(100)
                dbCommand.Parameters.Add(inputParameter);

                inputParameter = new SqlParameter("@theDelivery", delivery);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 100;                                // 100-bytes ~ varchar(100)
                dbCommand.Parameters.Add(inputParameter);

                // Execute the stored procedure using the DBConnect object and the SQLCommand object
                DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);
                Response.Redirect("UserLogin.aspx");
            }
        }
    }
}