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
            outputCount.Direction = ParameterDirection.Input;
            outputCount.SqlDbType = SqlDbType.VarChar;

            dbCommand.Parameters.Add(inputEmail);
            dbCommand.Parameters.Add(outputCount);

            db.GetDataSetUsingCmdObj(dbCommand);
            int count = int.Parse(dbCommand.Parameters["@Count"].Value.ToString());
            return count;
        }
    }
}
