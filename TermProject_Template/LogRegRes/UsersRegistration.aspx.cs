using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;

namespace TermProject_Template
{
    public partial class UsersRegristration : System.Web.UI.Page
    {
        Validation validationOBJ = new Validation();
        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();
        Wallet wall;
        string webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug45415/WebAPI/api/service/PaymentProcessor/";
        private int MerchantAccountID = 2;
        private string APIKey = "nV17vFTeaH";
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

            if (validationOBJ.checkCreateAccount(first, last, email, pass, billing, delivery) == 1)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Please fill out all the fields before creating an account');</script>");
                return;
            }
            else if (validationOBJ.checkCreateAccount(first, last, email, pass, billing, delivery) == 2)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Please fill out the email in the correct format. Emails must contain an '@' symbol and a '.'');</script>");
                return;
            }
            else if (validationOBJ.checkCreateAccount(first, last, email, pass, billing, delivery) == 3)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('This email already belongs to an existing account, please try another email');</script>");
                return;
            }
            else if (validationOBJ.checkCreateAccount(first, last, email, pass, billing, delivery) == 4)
            {
                if (loginID == "")
                {
                    dbCommand.Parameters.Clear();
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "TP_AddUserNoLoginID";
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
                    inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                    dbCommand.Parameters.Add(inputParameter);

                    inputParameter = new SqlParameter("@theDelivery", delivery);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                    dbCommand.Parameters.Add(inputParameter);

                    // Execute the stored procedure using the DBConnect object and the SQLCommand object
                    DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);
                }
                else
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
                    inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                    dbCommand.Parameters.Add(inputParameter);

                    inputParameter = new SqlParameter("@theDelivery", delivery);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                    dbCommand.Parameters.Add(inputParameter);

                    // Execute the stored procedure using the DBConnect object and the SQLCommand object
                    DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);
                    
                        wall = new Wallet();
                        wall.Name = txtFirstName.Text + " " + txtLastName.Text;
                        wall.Address = txtBilling.Text;
                        wall.Email = txtCreateEmail.Text;
                        wall.BankName = txt;
                        wall.CardType = ddlCardType.Text;
                        wall.CardNumber = int.Parse(txtCardNum.Text);
                        wall.MerchantAccountID = MerchantAccountID;

                        JavaScriptSerializer js = new JavaScriptSerializer();
                        String jsonCustomer = js.Serialize(wall);

                        WebRequest request = WebRequest.Create(webApiUrl + "CreateVirtualWallet/" + APIKey);
                        request.Method = "POST";
                        request.ContentType = "application/json";

                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonCustomer);
                        writer.Flush();
                        writer.Close();
                        WebResponse response = request.GetResponse();
                        Stream theDataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(theDataStream);
                        String data = reader.ReadToEnd();
                        reader.Close();
                        response.Close();
                    

                Response.Redirect("Login.aspx");
            }
        }
    }
}