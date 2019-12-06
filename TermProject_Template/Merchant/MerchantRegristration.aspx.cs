using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using System.Collections;
using Utilities;
namespace TermProject_Template
{

    public partial class MerchantRegristration : System.Web.UI.Page
    {
        string webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug45415/WebAPI/api/service/PaymentProcessor/";
        Validation validate = new Validation();
        private string APIKey = "";
        Merchant merch = new Merchant();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnterMerchant_Click(object sender, EventArgs e)
        {
            //int count = validate.CheckMerchantExists(txtContactEmail.Text);
            int count = 1;
            if (txtContactEmail.Text == "" || txtMerchantsName.Text == "")
            {
                Response.Write(@"<script langauge='text/javascript'>alert
                ('Please fill out both fields and try again');</script>");
                return;
            }
            else
            {
                if (count == 1)
                {
                    merch.Name = txtMerchantsName.Text;
                    merch.Email = txtContactEmail.Text;
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    String jsonCustomer = js.Serialize(merch);
                    WebRequest request = WebRequest.Create(webApiUrl + "CreateMerchant/");
                    request.Method = "POST";
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

                    string result = js.Deserialize<string>(data);
                    Response.Write(@"<script langauge='text/javascript'>alert
                ('" + result + "');</script>");
                    return;
                }
                else
                {
                    Response.Write(@"<script langauge='text/javascript'>alert
                    ('This merchant info is incorrect, try again');</script>");
                    return;
                }
            }
        }
    }
}