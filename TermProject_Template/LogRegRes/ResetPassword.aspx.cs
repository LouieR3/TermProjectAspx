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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Validation validationOBJ = new Validation();
        HttpCookie objCookie;
        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNewPassword_Click(object sender, EventArgs e)
        {
            objCookie = Request.Cookies["theResetEmail"];
            string email = objCookie.ToString();

            string pass = txtPass.Text.ToString();
            string confirm = txtConfirm.Text.ToString();
            if (validationOBJ.checkReset(email, pass, confirm) == 4)
            {
                dbCommand.Parameters.Clear();
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "TP_UpdatePassword";
                SqlParameter inputParameter = new SqlParameter("@theEmail", email);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                dbCommand.Parameters.Add(inputParameter);

                inputParameter = new SqlParameter("@thePassword", pass);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                dbCommand.Parameters.Add(inputParameter);

                // Execute the stored procedure using the DBConnect object and the SQLCommand object
                DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);

                Response.Redirect("Login.aspx");
            }
            else if(validationOBJ.checkReset(email, pass, confirm) == 1)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('These passwords don't match, try again');</script>");
                return;
            }
            else if (validationOBJ.checkReset(email, pass, confirm) == 2)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('One or both of these passwords have not been filled in, please fill in each form and try again');</script>");
                return;
            }
            else if (validationOBJ.checkReset(email, pass, confirm) == 3)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('This password matches your existing password, please make a new password  ');</script>");
                return;
            }
        }
    }
}