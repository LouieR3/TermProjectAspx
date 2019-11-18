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
            outputCount.SqlDbType = SqlDbType.VarChar;

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

        public int checkReset(string password, string confirm)
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
                CheckNewPassword
                return 3;
            }
            
        }

        public bool CheckNewPassword(string email, string password)
        {
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

            if (size != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkLogin(string email, string password)
        {
            if (password == "" || email == "")
            {
                return false;
            }
            //check if it is the same as old password or not
            return true;
        }
    }
}
