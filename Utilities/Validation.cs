using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Data.OleDb;
using Utilities;
using System.Collections;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;


namespace Utilities
{
    public class Validation
    {
        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();
        private int MerchantAccountID = 2;
        private string APIKey = "nV17vFTeaH";
        string webApiUrl = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug45415/WebAPI/api/service/PaymentProcessor/";
        public int CheckUserExists(string AccountEmail)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_CheckUserExists";
            SqlParameter inputEmail = new SqlParameter("@Account_Email", AccountEmail.ToString());
            SqlParameter outputCount = new SqlParameter("@Count", 0);

            inputEmail.Direction = ParameterDirection.Input;
            inputEmail.SqlDbType = SqlDbType.VarChar;
            outputCount.Direction = ParameterDirection.Output;
            outputCount.SqlDbType = SqlDbType.Int;

            dbCommand.Parameters.Add(inputEmail);
            dbCommand.Parameters.Add(outputCount);

            db.GetDataSetUsingCmdObj(dbCommand);
            int count = int.Parse(dbCommand.Parameters["@Count"].Value.ToString());
            return count;
        }
        public int CheckMerchantExists(string AccountEmail)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_CheckMerchantExists";
            SqlParameter inputEmail = new SqlParameter("@Account_Email", AccountEmail.ToString());
            SqlParameter outputCount = new SqlParameter("@Count", 0);

            inputEmail.Direction = ParameterDirection.Input;
            inputEmail.SqlDbType = SqlDbType.VarChar;
            inputEmail.Size = 50;
            outputCount.Direction = ParameterDirection.Output;
            outputCount.SqlDbType = SqlDbType.VarChar;
            outputCount.Size = 50;

            dbCommand.Parameters.Add(inputEmail);
            dbCommand.Parameters.Add(outputCount);

            db.GetDataSetUsingCmdObj(dbCommand);
            int count = int.Parse(dbCommand.Parameters["@Count"].Value.ToString());
            return count;
        }

        public bool CheckUserLogin(string email, string password)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_CheckUser";
            SqlParameter inputParameter = new SqlParameter("@theEmail", email);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@thePassword", password);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
            dbCommand.Parameters.Add(inputParameter);

            // Execute the stored procedure using the DBConnect object and the SQLCommand object
            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);

            int size = myDS.Tables[0].Rows.Count;

            if (size == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckRestaurantLogin(string email, string password)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_CheckRestaurantLogin";
            SqlParameter inputParameter = new SqlParameter("@theEmail", email);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@thePassword", password);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
            dbCommand.Parameters.Add(inputParameter);

            // Execute the stored procedure using the DBConnect object and the SQLCommand object
            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);

            int size = myDS.Tables[0].Rows.Count;

            if (size == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckRestaurantExists(string name, string email)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_CheckRestaurantExists";
            SqlParameter inputParameter = new SqlParameter("@theEmail", email);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@theName", name);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;                                // 50-bytes ~ varchar(50)
            dbCommand.Parameters.Add(inputParameter);

            // Execute the stored procedure using the DBConnect object and the SQLCommand object
            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);

            int size = myDS.Tables[0].Rows.Count;

            if (size == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int checkReset(string email, string password, string confirm)
        {
            if (password != confirm)
            {
                return 1;
            }
            else if (password == "" || confirm == "")
            {
                return 2;
            }
            else
            {
                if (CheckUserLogin(email, password))
                {
                    return 3;
                }
                else
                {
                    return 4;
                }
            }
        }

        public int checkCreateAccount(string first, string last, string email, string password, string billing, string delivery)
        {
            if (first == "" || last == "" || email == "" || password == "" || billing == "" || delivery == "")
            {
                return 1;
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                return 2;
            }
            else if (CheckUserExists(email) == 1)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        public int checkRestuarant(string name, string email, string address, string phone, string image, string pass, string cardNum, string bankName, string cardType)
        {
            if (name == "" || email == "" || address == "" || phone == "" || image == "" || pass == "" || cardNum == "" || cardType == "" || bankName == "")
            {
                return 1;
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                return 2;
            }
            else if (CheckRestaurantExists(name, email))
            {
                return 3;
            }
            else if (cardNum.Contains("qwertyuiop[]\asdfghjkl;'zxcvbnm,/_~`!@#$%^&*()+"))
            {
                return 4;
            }
            else
            {
                return 5;
            }
        }

        public bool checkLogin(string email, string password)
        {
            if (password == "" || email == "")
            {
                return false;
            }
            return true;
        }
        public int getAccountInfo(string name, string email)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "TP_CheckAccountInfo";
            SqlParameter inputEmail = new SqlParameter("@Account_Email","");
            SqlParameter outputCount = new SqlParameter("@Count", 0);

            inputEmail.Direction = ParameterDirection.Input;
            inputEmail.SqlDbType = SqlDbType.VarChar;
            inputEmail.Size = 50;
            outputCount.Direction = ParameterDirection.Output;
            outputCount.SqlDbType = SqlDbType.VarChar;
            outputCount.Size = 50;

            dbCommand.Parameters.Add(inputEmail);
            dbCommand.Parameters.Add(outputCount);

            db.GetDataSetUsingCmdObj(dbCommand);
            int count = int.Parse(dbCommand.Parameters["@Count"].Value.ToString());
            return count;
        }
        public void CheckSelectedMenuItem(GridView gvCurrent, out int count, out string emailId)
        {
            count = 0;
            emailId = "";
            for (int row = 0; row < gvCurrent.Rows.Count; row++)
            {
                CheckBox CBox;
                CBox = (CheckBox)gvCurrent.Rows[row].FindControl("chkSelect");
                if (CBox.Checked)
                {
                    emailId = gvCurrent.Rows[row].Cells[6].Text;
                    count = count + 1;
                }

            }
        }
        public string GetUserBalance(string email)
        {
            string balance = "";

            WebRequest request = WebRequest.Create(webApiUrl + "GetBalance/" + email + "/" + MerchantAccountID + "/" + APIKey);
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            balance = js.Deserialize<string>(data);
            
            return balance;
        }
        public void checkChecks(GridView gvInput, out int checkCount)
        {
            checkCount = 0;                              // used to count the number of selected products
            for (int row = 0; row < gvInput.Rows.Count; row++)
            {
                CheckBox CBox;
                CBox = (CheckBox)gvInput.Rows[row].FindControl("chkSelect");
                if (CBox.Checked)
                {
                    checkCount = checkCount + 1;
                }
            }
        }
        public int GetCardNumber(string email)
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
            int number = customers.CardNumber;
            return number;
        }
    }
}
