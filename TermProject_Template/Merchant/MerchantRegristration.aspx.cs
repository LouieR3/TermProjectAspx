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
namespace TermProject_Template
{

    public partial class MerchantRegristration : System.Web.UI.Page
    {
        Validation validate = new Validation();
        private string APIKey = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnterMerchant_Click(object sender, EventArgs e)
        {
            int count = validate.CheckMerchantExists(txtContactEmail.Text);
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
                    String url = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug45415/Project4API/CreateMerchant/"
                    + txtMerchantsName.Text + "/" + txtContactEmail.Text;
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create(url);
                    WebResponse response = request.GetResponse();
                    // Read the data from the Web Response, which requires working with streams.
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    // Deserialize a JSON string into a double.
                    JavaScriptSerializer js = new JavaScriptSerializer();
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