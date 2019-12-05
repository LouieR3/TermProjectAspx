using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;



namespace TermProject_Template.CustomControls
{
    public partial class WalletBalance : System.Web.UI.UserControl
    {
        string webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug45415/WebAPI/api/service/PaymentProcessor/";
        Validation validate = new Validation();
        string email = "";
        private int MerchantAccountID = 2;
        private string APIKey = "nV17vFTeaH";
        protected void Page_Load(object sender, EventArgs e)
        {
            //email = Session["AccountID"].ToString();
            email = "gav@gmail.com";
            string Balance = validate.GetUserBalance(email);
            lblBalance.Text = Balance;
        }

        protected void btnAddFunds_Click(object sender, EventArgs e)
        {
            btnAddFunds.Enabled = false;
            btnAdd.Visible = true;
            txtAddFunds.Visible = true;
            btnCancel.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnCancel.Visible = false;
            txtAddFunds.Visible = false;
            txtAddFunds.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAddFunds.Text.Contains(".") && txtAddFunds.Text != "")
            {
                Fund fund = new Fund();
                double amount = 0;
                double.TryParse(txtAddFunds.Text,out amount);
                fund.Amount = amount;
                fund.Email = email;
                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonCustomer = js.Serialize(fund);

                WebRequest request = WebRequest.Create(webApiUrl + "FundAccount/"+MerchantAccountID +"/" +APIKey);
                request.Method = "PUT";
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
                string Balance = validate.GetUserBalance(email);
                lblBalance.Text = Balance;
                txtAddFunds.Text = "";
            }
            else
            {
                
            }
        }
    }
}