using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace TermProject_Template
{
    public partial class UserLogin : System.Web.UI.Page
    {
        HttpCookie myCookie = new HttpCookie("theCookie");
        Validation validationOBJ = new Validation();
        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["theCookie"] != null)
                {
                    txtEmail.Text = Request.Cookies["theCookie"]["AccountID"].ToString();
                    txtPassword.Text = Request.Cookies["theCookie"]["AccountPass"].ToString();
                    chkRememberMe.Checked = true;
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
            else if (validationOBJ.CheckUserLogin(login, pass) == false && validationOBJ.CheckRestaurantLogin(login, pass) == false)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Your login info is incorrect, try again');</script>");
                return;
            }
            else
            {
                if (chkRememberMe.Checked == true)
                {
                    myCookie.Values["AccountID"] = login;
                    myCookie.Values["AccountPass"] = pass;
                    myCookie.Expires = new DateTime(2025, 1, 1);
                    Response.Cookies.Add(myCookie);
                }
                else
                {
                    Response.Cookies["theCookie"].Expires = DateTime.Now.AddDays(-1);
                }
                if (txtEmail.Text.Contains("@"))
                {
                    Session["AccountID"] = txtEmail.Text;
                }
                else
                {
                    string loginID = txtEmail.Text;
                    dbCommand.Parameters.Clear();
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "TP_GetEmail";
                    SqlParameter inputParameter = new SqlParameter("@theID", loginID);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                    dbCommand.Parameters.Add(inputParameter);
                    
                    DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);
                    string email = Convert.ToString(myDS.Tables[0].Rows[0]["UserEmail"]);

                    Session["AccountID"] = email;
                }
                if (validationOBJ.CheckUserLogin(login, pass) == true)
                {
                    Response.Redirect("../Users/UserDashboard.aspx");
                }
                else if (validationOBJ.CheckRestaurantLogin(login, pass) == true)
                {
                    Response.Redirect("../Restaurant/RestaurantDashboard.aspx");
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsersRegistration.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RestaurantRegistration.aspx");
        }
    }
}