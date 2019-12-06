using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Utilities;

namespace TermProject_Template.Restaurant
{
    public partial class ViewTransactions : System.Web.UI.Page
    {
        private int MerchantAccountID = 2;
        private string APIKey = "nV17vFTeaH";
        string webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug45415/WebAPI/api/service/PaymentProcessor/";
        string email = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            email = "gav@gmail.com";
            DisplayTransactions(email);
        }
        public void DisplayTransactions(string email)
        {
            WebRequest request = WebRequest.Create(webApiUrl + "GetTransactions/" + email + "/" + MerchantAccountID + "/" + APIKey);
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Transaction> transactions = js.Deserialize<List<Transaction>>(data);
            gvTransactions.DataSource = transactions;
            gvTransactions.DataBind();
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("RestaurantDashboard.aspx");
        }
    }
}