using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Utilities;
using System.Collections;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;

namespace TermProject_Template.Users
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ArrayList previousOrders = new ArrayList();
        int total = 0;
        DataSet dsRest = new DataSet();
        SqlCommand objCommand = new SqlCommand();
        DBConnect db = new DBConnect();
        private string APIKey ="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string accountID = Session["AccountID"].ToString();
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetRestaurants";
                dsRest = db.GetDataSetUsingCmdObj(objCommand);
                rptRest.DataSource = dsRest;
                rptRest.DataBind();
                displayPreviousOrders(accountID);
            }
        }

        protected void lnkBtnNext_Click(object sender, EventArgs e)
        {
            txtHidden.Value = Convert.ToString(Convert.ToInt16(txtHidden.Value) + 5);
            bindData();
        }

        protected void lnkBtnPrev_Click(object sender, EventArgs e)
        {
            txtHidden.Value = Convert.ToString(Convert.ToInt16(txtHidden.Value) - 5);
            bindData();
        }
        public void bindData()
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Tp_GetRestaurants";
            dsRest = db.GetDataSetUsingCmdObj(objCommand);
            int countValue = Convert.ToInt16(txtHidden.Value);
            if (countValue <= 0)
            {
                countValue = 0;
            } 
            rptRest.DataSource = dsRest;
            rptRest.DataBind();

            if (countValue <= 0)
            {
                lnkBtnPrev.Visible = false;
                lnkBtnNext.Visible = true;
            }

            if (countValue >= 5)
            {
                lnkBtnPrev.Visible = true;
                lnkBtnNext.Visible = true;
            }

            if ((countValue + 5) >= total)
            {
                lnkBtnNext.Visible = false;
            }
        }

        protected void repeaterRest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int rowIndex = e.Item.ItemIndex;
            Label myLabel = (Label)rptRest.Items[rowIndex].FindControl("lblProductID");
            String productNumber = myLabel.Text;
        }
        public void displayPreviousOrders(string ID)
        {
            String url = "http://cis-iis2.temple.edu/users/pascucci/CIS3342/CoreWebAPI/api/Calculator/";

            url = url + "/" + ID;
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
            double result = js.Deserialize<double>(data);
            
        }
    }
}