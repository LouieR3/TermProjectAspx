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
using System.Web.Script.Serialization;

namespace TermProject_Template.LogRegRes
{
    public partial class WebForm1 : System.Web.UI.Page
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

        protected void btnCreateRestuarant_Click(object sender, EventArgs e)
        {
            string name = txtRName.Text;
            string email = txtContactEmail.Text;
            string pass = txtRPass.Text;
            string address = txtRAddress.Text;
            string phone = txtRPhone.Text;
            string image = fuImage.ToString();

            if (validationOBJ.checkRestuarant(name, email, address, phone, image) == 1)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Please fill out all the fields before creating an account');</script>");
                return;
            }
            else if (validationOBJ.checkRestuarant(name, email, address, phone, image) == 2)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Please fill out the email in the correct format. Emails must contain an '@' symbol and a '.'');</script>");
                return;
            }
            else if (validationOBJ.checkRestuarant(name, email, address, phone, image) == 3)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('This Email or Restaurant Name already belongs to an existing account, please try another Email or Restaurant Name');</script>");
                return;
            }
            else
            {
                dbCommand.Parameters.Clear();
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = "TP_AddRestaurant";
                SqlParameter inputParameter = new SqlParameter("@theName", name);
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

                inputParameter = new SqlParameter("@theAddress", address);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 100;                                // 50-bytes ~ varchar(50)
                dbCommand.Parameters.Add(inputParameter);

                inputParameter = new SqlParameter("@thePhone", phone);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                dbCommand.Parameters.Add(inputParameter);

                inputParameter = new SqlParameter("@theImage", image);
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.SqlDbType = SqlDbType.VarChar;
                inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
                dbCommand.Parameters.Add(inputParameter);

                //Execute the stored procedure using the DBConnect object and the SQLCommand object
                int count = db.DoUpdateUsingCmdObj(dbCommand);
                
                if(count == 1)
                {
                    wall = new Wallet();
                    wall.Name = txtRName.Text;
                    wall.Address = txtRAddress.Text;
                    wall.Email = txtContactEmail.Text;
                    wall.BankName = "Wells";
                    wall.CardType = "Debit";
                    wall.CardNumber = 12345555;
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
                }

                Response.Redirect("Login.aspx");
            }
        }
    }
}