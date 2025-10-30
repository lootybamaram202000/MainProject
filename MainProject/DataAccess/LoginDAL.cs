using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DataAccess
{
    public class LoginDAL
    {
        private readonly string _connectionString;

        public LoginDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataSet Authenticate(string username, string passwordHash, string date, DateTime dateValue, int dateDig)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_AuthenticateUser", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                cmd.Parameters.AddWithValue("@DATE", date);
                cmd.Parameters.AddWithValue("@DateValue", dateValue);
                cmd.Parameters.AddWithValue("@DATEDIG", dateDig);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
    }
}
