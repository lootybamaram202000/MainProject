using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MainProject.Core;
using MainProject.Entities;

namespace MainProject.DataAccess
{
    /// <summary>
    /// DAL برای مدیریت حساب‌های بانکی
    /// </summary>
    public class AccountDAL
    {
        private readonly string _connectionString = Config.ConnectionString;

        /// <summary>
        /// ثبت حساب بانکی جدید
        /// </summary>
        public bool InsertAccount(
            AccountModel model,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string newACID,
            out string message)
        {
            newACID = null;
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_InsertAccount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@OWID", model.OWID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACBank", model.ACBank ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACNumber", model.ACNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACshabaNumber", model.ACshabaNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACCardNumber", model.ACCardNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACType", model.ACType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACCategory", model.ACCategory ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@DATE", date);
                    cmd.Parameters.AddWithValue("@DATEVALUE", dateValue);
                    cmd.Parameters.AddWithValue("@DATEDIG", dateDig);

                    // Output Parameters
                    var pNewACID = new SqlParameter("@NewACID", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };
                    var pResult = new SqlParameter("@Result", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    var pMessage = new SqlParameter("@Message", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(pNewACID);
                    cmd.Parameters.Add(pResult);
                    cmd.Parameters.Add(pMessage);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    bool result = pResult.Value != DBNull.Value && Convert.ToBoolean(pResult.Value);
                    message = pMessage.Value as string ?? string.Empty;
                    newACID = pNewACID.Value != DBNull.Value ? pNewACID.Value.ToString() : null;

                    return result;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// ویرایش حساب بانکی
        /// </summary>
        public bool UpdateAccount(
            AccountModel model,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string message)
        {
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_UpdateAccount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ACID", model.ACID);
                    cmd.Parameters.AddWithValue("@ACBank", model.ACBank ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACNumber", model.ACNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACshabaNumber", model.ACshabaNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACCardNumber", model.ACCardNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACType", model.ACType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACCategory", model.ACCategory ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@isActive", model.isActive);

                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@DATE", date);
                    cmd.Parameters.AddWithValue("@DATEVALUE", dateValue);
                    cmd.Parameters.AddWithValue("@DATEDIG", dateDig);

                    var pResult = new SqlParameter("@Result", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    var pMessage = new SqlParameter("@Message", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(pResult);
                    cmd.Parameters.Add(pMessage);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    bool result = pResult.Value != DBNull.Value && Convert.ToBoolean(pResult.Value);
                    message = pMessage.Value as string ?? string.Empty;

                    return result;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// حذف حساب بانکی
        /// </summary>
        public bool DeleteAccount(
            string acid,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string message)
        {
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_DeleteAccount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ACID", acid);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@DATE", date);
                    cmd.Parameters.AddWithValue("@DATEVALUE", dateValue);
                    cmd.Parameters.AddWithValue("@DATEDIG", dateDig);

                    var pResult = new SqlParameter("@Result", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    var pMessage = new SqlParameter("@Message", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(pResult);
                    cmd.Parameters.Add(pMessage);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    bool result = pResult.Value != DBNull.Value && Convert.ToBoolean(pResult.Value);
                    message = pMessage.Value as string ?? string.Empty;

                    return result;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// دریافت حساب‌های یک Owner
        /// </summary>
        public bool GetAccountsByOWID(string owid, out List<AccountModel> accounts, out string message)
        {
            accounts = new List<AccountModel>();
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_GetAccountsByOWID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OWID", owid);

                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accounts.Add(MapReaderToAccount(reader));
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// دریافت یک حساب بر اساس ACID
        /// </summary>
        public bool GetAccountByACID(string acid, out AccountModel account, out string message)
        {
            account = null;
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SELECT * FROM tblAccounts WHERE ACID = @ACID AND isDeleted = 0", con))
                {
                    cmd.Parameters.AddWithValue("@ACID", acid);
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            account = MapReaderToAccount(reader);
                            return true;
                        }
                        else
                        {
                            message = "حساب یافت نشد.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Map کردن SqlDataReader به AccountModel
        /// </summary>
        private AccountModel MapReaderToAccount(SqlDataReader reader)
        {
            return new AccountModel
            {
                ACID = reader["ACID"].ToString(),
                OWID = reader["OWID"] != DBNull.Value ? reader["OWID"].ToString() : null,
                PERID = reader["PERID"] != DBNull.Value ? reader["PERID"].ToString() : null,
                ACOwner = reader["ACOwner"] != DBNull.Value ? reader["ACOwner"].ToString() : null,
                ACBank = reader["ACBank"] != DBNull.Value ? reader["ACBank"].ToString() : null,
                ACNumber = reader["ACNumber"] != DBNull.Value ? reader["ACNumber"].ToString() : null,
                ACshabaNumber = reader["ACshabaNumber"] != DBNull.Value ? reader["ACshabaNumber"].ToString() : null,
                ACCardNumber = reader["ACCardNumber"] != DBNull.Value ? reader["ACCardNumber"].ToString() : null,
                ACType = reader["ACType"] != DBNull.Value ? reader["ACType"].ToString() : null,
                ACCategory = reader["ACCategory"] != DBNull.Value ? reader["ACCategory"].ToString() : null,
                isActive = reader["isActive"] != DBNull.Value && Convert.ToBoolean(reader["isActive"]),
                isPayer = reader["isPayer"] != DBNull.Value && Convert.ToBoolean(reader["isPayer"]),
                isDeleted = reader["isDeleted"] != DBNull.Value && Convert.ToBoolean(reader["isDeleted"]),
                LastUpdate = reader["LastUpdate"] != DBNull.Value ? reader["LastUpdate"].ToString() : null,
                isDefault = reader.GetOrdinal("isDefault") >= 0 && reader["isDefault"] != DBNull.Value && Convert.ToBoolean(reader["isDefault"])
            };
        }
    }
}
