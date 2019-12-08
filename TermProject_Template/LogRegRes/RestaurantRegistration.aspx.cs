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
            string cardNum = txtCardNum.Text;
            string bankName = txtBankName.Text;
            string cardType = ddlCardType.Text;
            string image = fuImage.FileName;

            if (validationOBJ.checkRestuarant(name, email, address, phone, image, pass, cardNum, cardType, bankName) == 1)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Please fill out all the fields before creating an account');</script>");
                return;
            }
            else if (validationOBJ.checkRestuarant(name, email, address, phone, image, pass, cardNum, cardType, bankName) == 2)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Please fill out the email in the correct format. Emails must contain an '@' symbol and a '.'');</script>");
                return;
            }
            else if (validationOBJ.checkRestuarant(name, email, address, phone, image, pass, cardNum, cardType, bankName) == 3)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('This Email or Restaurant Name already belongs to an existing account, please try another Email or Restaurant Name');</script>");
                return;
            }
            else if (validationOBJ.checkRestuarant(name, email, address, phone, image, pass, cardNum, cardType, bankName) == 4)
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('The card number can only contain numbers');</script>");
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

                string fileName = "";
                string photoPath = "";
                string fileExtension = "";
                SqlParameter inputPhoto = new SqlParameter();
                if (fuImage.HasFile)
                {
                    fileName = fuImage.FileName;
                    fileExtension = fileName.Substring(fileName.LastIndexOf("."));
                    if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".bmp" || fileExtension == ".gif" || fileExtension == ".png")
                    {
                        photoPath = "~/images/" + fileName;
                        fuImage.SaveAs(Server.MapPath(@"~\images\" + fileName));
                        inputPhoto = new SqlParameter("@theImage", photoPath);
                    }
                }
                
                dbCommand.Parameters.Add(inputPhoto);

                //Execute the stored procedure using the DBConnect object and the SQLCommand object
                DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);
                wall = new Wallet();
                wall.Name = txtRName.Text;
                wall.Address = txtRAddress.Text;
                wall.Email = txtContactEmail.Text;
                wall.BankName = txtBankName.Text;
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