using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DataAccess
{
    public class MessageDAL
    {
        private readonly string _connectionString = "..."; // یا از app.config

        public bool DeleteMessage(string messageId, string userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_DeleteMessage", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MessageID", messageId);
                cmd.Parameters.AddWithValue("@UserID", userId);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
