using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using Utilities;

namespace Utilities
{
    public class Validation
    {
        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();
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

        public int checkRestuarant(string name, string email, string address, string phone, string image)
        {
            if (name == "" || email == "" || address == "" || phone == "" || image == "")
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
            else
            {
                return 4;
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
        public void getAccountInfo(string name, string email)
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
    }
}
