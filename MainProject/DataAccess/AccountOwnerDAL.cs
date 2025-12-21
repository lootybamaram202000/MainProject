using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MainProject.Core;
using MainProject.Entities;

namespace MainProject.DataAccess
{
    /// <summary>
    /// DAL برای مدیریت صاحبان حساب (AccountOwner)
    /// </summary>
    public class AccountOwnerDAL
    {
        private readonly string _connectionString = Config.ConnectionString;

        /// <summary>
        /// دریافت Owner بر اساس OWID
        /// </summary>
        public bool GetOwnerByOWID(string owid, out AccountOwnerModel owner, out string message)
        {
            owner = null;
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SELECT * FROM tblAccountOwners WHERE OWID = @OWID AND isDeleted = 0", con))
                {
                    cmd.Parameters.AddWithValue("@OWID", owid);
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            owner = MapReaderToOwner(reader);
                            return true;
                        }
                        else
                        {
                            message = "صاحب حساب یافت نشد.";
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
        /// دریافت Owner بر اساس RefID (مثلاً SellerID)
        /// </summary>
        public bool GetOwnerByRefID(string refID, string owType, out AccountOwnerModel owner, out string message)
        {
            owner = null;
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SELECT * FROM tblAccountOwners WHERE RefID = @RefID AND OWType = @OWType AND isDeleted = 0", con))
                {
                    cmd.Parameters.AddWithValue("@RefID", refID);
                    cmd.Parameters.AddWithValue("@OWType", owType);
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            owner = MapReaderToOwner(reader);
                            return true;
                        }
                        else
                        {
                            message = "صاحب حساب یافت نشد.";
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
        /// دریافت تمام Owners بر اساس نوع
        /// </summary>
        public bool GetOwnersByType(string owType, out List<AccountOwnerModel> owners, out string message)
        {
            owners = new List<AccountOwnerModel>();
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SELECT * FROM tblAccountOwners WHERE OWType = @OWType AND isDeleted = 0 ORDER BY OWID", con))
                {
                    cmd.Parameters.AddWithValue("@OWType", owType);
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            owners.Add(MapReaderToOwner(reader));
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
        /// آپدیت Balance یک Owner
        /// </summary>
        public bool UpdateOwnerBalance(string owid, decimal newBalance, string lastUpdate, out string message)
        {
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(@"
                    UPDATE tblAccountOwners 
                    SET Balance = @Balance, LastUpdate = @LastUpdate 
                    WHERE OWID = @OWID", con))
                {
                    cmd.Parameters.AddWithValue("@OWID", owid);
                    cmd.Parameters.AddWithValue("@Balance", newBalance);
                    cmd.Parameters.AddWithValue("@LastUpdate", lastUpdate);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        message = "صاحب حساب یافت نشد.";
                        return false;
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
        /// تنظیم DefaultACID برای یک Owner
        /// </summary>
        public bool SetDefaultAccount(string owid, string acid, string lastUpdate, out string message)
        {
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(@"
                    UPDATE tblAccountOwners 
                    SET DefaultACID = @ACID, LastUpdate = @LastUpdate 
                    WHERE OWID = @OWID", con))
                {
                    cmd.Parameters.AddWithValue("@OWID", owid);
                    cmd.Parameters.AddWithValue("@ACID", string.IsNullOrWhiteSpace(acid) ? (object)DBNull.Value : acid);
                    cmd.Parameters.AddWithValue("@LastUpdate", lastUpdate);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        message = "صاحب حساب یافت نشد.";
                        return false;
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
        /// Map کردن SqlDataReader به AccountOwnerModel
        /// </summary>
        private AccountOwnerModel MapReaderToOwner(SqlDataReader reader)
        {
            return new AccountOwnerModel
            {
                OWID = reader["OWID"].ToString(),
                ACOwner = reader["ACOwner"] != DBNull.Value ? reader["ACOwner"].ToString() : null,
                RefID = reader["RefID"] != DBNull.Value ? reader["RefID"].ToString() : null,
                OWType = reader["OWType"] != DBNull.Value ? reader["OWType"].ToString() : null,
                Balance = reader["Balance"] != DBNull.Value ? Convert.ToDecimal(reader["Balance"]) : 0m,
                DefaultACID = reader["DefaultACID"] != DBNull.Value ? reader["DefaultACID"].ToString() : null,
                isPayer = reader["isPayer"] != DBNull.Value && Convert.ToBoolean(reader["isPayer"]),
                isActive = reader["isActive"] != DBNull.Value && Convert.ToBoolean(reader["isActive"]),
                isDeleted = reader["isDeleted"] != DBNull.Value && Convert.ToBoolean(reader["isDeleted"]),
                LastUpdate = reader["LastUpdate"] != DBNull.Value ? reader["LastUpdate"].ToString() : null
            };
        }
    }
}
