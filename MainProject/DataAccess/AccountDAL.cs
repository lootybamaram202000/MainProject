using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.Entities;

namespace MainProject.DataAccess
{
    public class AccountDAL
    {
        private readonly string _connectionString = Config.ConnectionString;

        public List<AccountModel> GetAllAccounts(string peridPrefix)
        {
            List<AccountModel> accounts = new List<AccountModel>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ReturnAllAccount", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PERIDPrefix", peridPrefix);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    accounts.Add(new AccountModel
                    {
                        ACID = reader["ACID"].ToString(),
                        PERID = reader["PERID"].ToString(),
                        ACOwner = reader["ACOwner"].ToString(),
                        ACshabaNumber = reader["ACshabaNumber"].ToString(),
                        ACCardNumber = reader["ACCardNumber"].ToString(),
                        ACNumber = reader["ACNumber"].ToString(),
                        ACBank = reader["ACBank"].ToString(),
                        ACType = reader["ACType"].ToString(),
                        isActive = Convert.ToBoolean(reader["isActive"]),
                        isPayer = Convert.ToBoolean(reader["isPayer"]),
                        isDeleted = Convert.ToBoolean(reader["isDeleted"])
                    });
                }
            }

            return accounts;
        }

        public bool GetAccountByACID(string acid, out AccountModel account)
        {
            account = null;
            if (string.IsNullOrWhiteSpace(acid)) return false;

            // از جستجو استفاده می‌کنیم و با ACID فیلتر می‌کنیم
            var list = SearchAccounts(acid, ""); // اگر لازم شد Prefix بده
            foreach (var a in list)
                if (string.Equals(a.ACID, acid, StringComparison.OrdinalIgnoreCase))
                { account = a; return true; }

            return false;
        }

        // اورلود سازگار با کدهای قدیمی که پیام می‌خواهند
        public bool GetAccountByACID(string acid, out AccountModel account, out string message)
        {
            var ok = GetAccountByACID(acid, out account);
            message = ok ? string.Empty : "Account not found.";
            return ok;
        }

        public List<AccountModel> SearchAccounts(string searchText, string peridPrefix)
        {
            List<AccountModel> accounts = new List<AccountModel>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_SearchAccount", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchText", searchText);
                cmd.Parameters.AddWithValue("@PERIDPrefix", peridPrefix);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    accounts.Add(new AccountModel
                    {
                        ACID = reader["ACID"].ToString(),
                        PERID = reader["PERID"].ToString(),
                        ACOwner = reader["ACOwner"].ToString(),
                        ACshabaNumber = reader["ACshabaNumber"].ToString(),
                        ACCardNumber = reader["ACCardNumber"].ToString(),
                        ACNumber = reader["ACNumber"].ToString(),
                        ACBank = reader["ACBank"].ToString(),
                        ACType = reader["ACType"].ToString(),
                        isActive = Convert.ToBoolean(reader["isActive"]),
                        isPayer = Convert.ToBoolean(reader["isPayer"]),
                        isDeleted = Convert.ToBoolean(reader["isDeleted"])
                    });
                }
            }

            return accounts;
        }

        public bool UpdateAccount(AccountModel account, string userID, string date, DateTime dateValue, int dateDig)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_UpdateAccount", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ACID", account.ACID);
                cmd.Parameters.AddWithValue("@ACshabaNumber", account.ACshabaNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ACCardNumber", account.ACCardNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ACNumber", account.ACNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ACBank", account.ACBank ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ACType", account.ACType ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@isActive", account.isActive);
                cmd.Parameters.AddWithValue("@isDeleted", account.isDeleted);
                cmd.Parameters.AddWithValue("@isPayer", account.isPayer);
                cmd.Parameters.AddWithValue("@USERID", userID);
                cmd.Parameters.AddWithValue("@DATE", date);
                cmd.Parameters.AddWithValue("@DateValue", dateValue);
                cmd.Parameters.AddWithValue("@DATEDIG", dateDig);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public bool DeleteAccount(string acid, string userID, string date, DateTime dateValue, int dateDig)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_DeleteAccount", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ACID", acid);
                cmd.Parameters.AddWithValue("@USERID", userID);
                cmd.Parameters.AddWithValue("@DATE", date);
                cmd.Parameters.AddWithValue("@DateValue", dateValue);
                cmd.Parameters.AddWithValue("@DATEDIG", dateDig);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}

