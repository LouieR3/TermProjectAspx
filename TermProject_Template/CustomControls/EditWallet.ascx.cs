using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using Utilities;


namespace TermProject_Template.CustomControls
{
    public partial class EditWallet : System.Web.UI.UserControl
    {
        private int MerchantAccountID = 2;
        private string APIKey = "nV17vFTeaH";
        private string email = "";
        string webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug45415/WebAPI/api/service/PaymentProcessor/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                email = Session["AccountID"].ToString();
                DisplayWalletInformation();
            }
        }
        public void DisplayWalletInformation()
        {
            WebRequest request = WebRequest.Create(webApiUrl + "GetAccountInformation/" + email + "/" + MerchantAccountID + "/" + APIKey);
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Wallet customers = js.Deserialize<Wallet>(data);
            txtName.Text = customers.Name.ToString();
            txtAddress.Text = customers.Address.ToString();
            txtEmail.Text = customers.Email.ToString();
            txtBankName.Text = customers.BankName.ToString();
            ddlType.SelectedValue = customers.CardType.ToString();
            txtCardNumber.Text = customers.CardNumber.ToString();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
            btnEdit.Enabled = false;
            btnUpdate.Enabled = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtAddress.Text != "" && txtBankName.Text != "")
            {
                int cardNumber = 0;
                if (int.TryParse(txtCardNumber.Text, out cardNumber))
                {
                    Wallet wallet = new Wallet();
                    wallet.Name = txtName.Text;
                    wallet.Address = txtAddress.Text;
                    wallet.Email = txtEmail.Text;
                    wallet.BankName = txtBankName.Text;
                    wallet.CardType = ddlType.SelectedValue;
                    wallet.CardNumber = int.Parse(txtCardNumber.Text);
                    wallet.MerchantAccountID = MerchantAccountID;

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    String jsonCustomer = js.Serialize(wallet);

                    try
                    {
                        WebRequest request = WebRequest.Create(webApiUrl + "UpdatePaymentAccount/" + APIKey + "/");
                        request.Method = "PUT";
                        request.ContentLength = jsonCustomer.Length;
                        request.ContentType = "application/json";
                        // Write the JSON data to the Web Request
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonCustomer);
                        writer.Flush();
                        writer.Close();
                        // Read the data from the Web Response, which requires working with streams.
                        WebResponse response = request.GetResponse();
                        Stream theDataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(theDataStream);
                        String data = reader.ReadToEnd();
                        if (data == "true")
                        {
                            btnUpdate.Enabled = false;
                            btnEdit.Enabled = true;
                            DisableFields();
                            txtName.Text =wallet.Name;
                            txtAddress.Text = wallet.Address;
                            txtBankName.Text = wallet.BankName;
                            ddlType.SelectedValue = wallet.CardType;
                            txtCardNumber.Text = wallet.CardNumber.ToString() ;
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
        public void EnableFields()
        {
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtBankName.Enabled = true;
            ddlType.Enabled = true;
            txtCardNumber.Enabled = true;
            ddlType.Enabled = true;
        }
        public void DisableFields()
        {
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtBankName.Enabled = false;
            ddlType.Enabled = false;
            txtCardNumber.Enabled = false;
            ddlType.Enabled = false;
        }
    }
}