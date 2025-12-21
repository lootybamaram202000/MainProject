using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MainProject.Core;
using MainProject.Entities;

namespace MainProject.DataAccess
{
    /// <summary>
    /// DAL برای مدیریت فروشندگان
    /// </summary>
    public class SellerDAL
    {
        private readonly string _connectionString = Config.ConnectionString;
        private readonly AccountOwnerDAL _ownerDAL = new AccountOwnerDAL();
        private readonly AccountDAL _accountDAL = new AccountDAL();

        /// <summary>
        /// ثبت فروشنده جدید (با Owner خام)
        /// </summary>
        public bool InsertSeller(
            SellerModel model,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string newSellerID,
            out string newOWID,
            out string message)
        {
            newSellerID = null;
            newOWID = null;
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_InsertSeller", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // اطلاعات Seller
                    cmd.Parameters.AddWithValue("@SellerName", model.SellerName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompanyName", model.CompanyName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", model.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone1", model.Phone1 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone2", model.Phone2 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone3", model.Phone3 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SellerType", model.SellerType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SellerCategory1", model.SellerCategory1 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SellerCategory2", model.SellerCategory2 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SellerCategory3", model.SellerCategory3 ?? (object)DBNull.Value);

                    // اطلاعات Owner پیش‌فرض
                    cmd.Parameters.AddWithValue("@Balance", model.Balance);
                    cmd.Parameters.AddWithValue("@isPayer", model.AccountOwner?.isPayer ?? false);

                    // Login
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@DATE", date);
                    cmd.Parameters.AddWithValue("@DATEVALUE", dateValue);
                    cmd.Parameters.AddWithValue("@DATEDIG", dateDig);

                    // Output Parameters
                    var pNewSellerID = new SqlParameter("@NewSellerID", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };
                    var pNewOWID = new SqlParameter("@NewOWID", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };
                    var pResult = new SqlParameter("@Result", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    var pMessage = new SqlParameter("@Message", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(pNewSellerID);
                    cmd.Parameters.Add(pNewOWID);
                    cmd.Parameters.Add(pResult);
                    cmd.Parameters.Add(pMessage);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    bool result = pResult.Value != DBNull.Value && Convert.ToBoolean(pResult.Value);
                    message = pMessage.Value as string ?? string.Empty;
                    newSellerID = pNewSellerID.Value != DBNull.Value ? pNewSellerID.Value.ToString() : null;
                    newOWID = pNewOWID.Value != DBNull.Value ? pNewOWID.Value.ToString() : null;

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
        /// ویرایش فروشنده
        /// </summary>
        public bool UpdateSeller(
            SellerModel model,
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
                using (var cmd = new SqlCommand("sp_UpdateSeller", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SellerID", model.SellerID);
                    cmd.Parameters.AddWithValue("@SellerName", model.SellerName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompanyName", model.CompanyName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", model.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone1", model.Phone1 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone2", model.Phone2 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone3", model.Phone3 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SellerType", model.SellerType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SellerCategory1", model.SellerCategory1 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SellerCategory2", model.SellerCategory2 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SellerCategory3", model.SellerCategory3 ?? (object)DBNull.Value);

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
        /// حذف فروشنده
        /// </summary>
        public bool DeleteSeller(
            string sellerID,
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
                using (var cmd = new SqlCommand("sp_DeleteSeller", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SellerID", sellerID);
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
        /// دریافت تمام فروشندگان (با Owner و Accounts)
        /// </summary>
        public bool GetAllSellers(out List<SellerModel> sellers, out string message)
        {
            sellers = new List<SellerModel>();
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(@"SELECT * FROM tblSellers WHERE isDeleted = 0 ORDER BY SellerID", con))
                {
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sellers.Add(MapReaderToSeller(reader));
                        }
                    }
                }

                // Load Owner و Accounts برای هر Seller
                foreach (var seller in sellers)
                {
                    LoadSellerOwnerAndAccounts(seller);
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
        /// جستجوی فروشندگان
        /// </summary>
        public bool Search(string searchText, out List<SellerModel> sellers, out string message)
        {
            sellers = new List<SellerModel>();
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(@"SELECT * FROM tblSellers WHERE isDeleted = 0 AND (
                        SellerID LIKE @Search OR
                        SellerName LIKE @Search OR
                        CompanyName LIKE @Search OR
                        Phone1 LIKE @Search OR
                        Phone2 LIKE @Search OR
                        Phone3 LIKE @Search
                    ) ORDER BY SellerID", con))
                {
                    cmd.Parameters.AddWithValue("@Search", "%" + searchText + "%");
                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sellers.Add(MapReaderToSeller(reader));
                        }
                    }
                }

                // Load Owner و Accounts برای هر Seller
                foreach (var seller in sellers)
                {
                    LoadSellerOwnerAndAccounts(seller);
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
        /// دریافت فروشنده با Owner و Accounts (کامل)
        /// </summary>
        public bool GetSellerWithOwnerAndAccounts(string sellerID, out SellerModel seller, out string message)
        {
            seller = null;
            message = string.Empty;

            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_GetSellerWithOwnerAndAccounts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SellerID", sellerID);

                    con.Open();

                    // ResultSet 1:  Seller
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            seller = MapReaderToSeller(reader);
                        }
                        else
                        {
                            message = "فروشنده یافت نشد.";
                            return false;
                        }

                        // ResultSet 2: Owner
                        if (reader.NextResult() && reader.Read())
                        {
                            seller.AccountOwner = MapReaderToOwner(reader);
                        }

                        // ResultSet 3: Accounts
                        if (reader.NextResult())
                        {
                            seller.AccountOwner.Accounts = new List<AccountModel>();
                            while (reader.Read())
                            {
                                seller.AccountOwner.Accounts.Add(MapReaderToAccount(reader));
                            }
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
        /// دریافت یک فروشنده بر اساس شناسه (با Owner و Accounts)
        /// </summary>
        public bool GetSellerByID(string sellerID, out SellerModel seller, out string message)
        {
            // استفاده از متد موجود GetSellerWithOwnerAndAccounts
            return GetSellerWithOwnerAndAccounts(sellerID, out seller, out message);
        }

        /// <summary>
        /// Load کردن Owner و Accounts برای یک Seller
        /// </summary>
        private void LoadSellerOwnerAndAccounts(SellerModel seller)
        {
            if (string.IsNullOrWhiteSpace(seller.OWID))
                return;

            // Load Owner
            AccountOwnerModel owner;
            string msg;
            if (_ownerDAL.GetOwnerByOWID(seller.OWID, out owner, out msg))
            {
                seller.AccountOwner = owner;

                // Load Accounts
                List<AccountModel> accounts;
                if (_accountDAL.GetAccountsByOWID(seller.OWID, out accounts, out msg))
                {
                    seller.AccountOwner.Accounts = accounts;
                }
            }
        }

        /// <summary>
        /// Map کردن SqlDataReader به SellerModel
        /// </summary>
        private SellerModel MapReaderToSeller(SqlDataReader reader)
        {
            return new SellerModel
            {
                SellerID = reader["SellerID"].ToString(),
                SellerName = reader["SellerName"] != DBNull.Value ? reader["SellerName"].ToString() : null,
                CompanyName = reader["CompanyName"] != DBNull.Value ? reader["CompanyName"].ToString() : null,
                Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : null,
                Phone1 = reader["Phone1"] != DBNull.Value ? reader["Phone1"].ToString() : null,
                Phone2 = reader["Phone2"] != DBNull.Value ? reader["Phone2"].ToString() : null,
                Phone3 = reader["Phone3"] != DBNull.Value ? reader["Phone3"].ToString() : null,
                SellerType = reader["SellerType"] != DBNull.Value ? reader["SellerType"].ToString() : null,
                SellerCategory1 = reader["SellerCategory1"] != DBNull.Value ? reader["SellerCategory1"].ToString() : null,
                SellerCategory2 = reader["SellerCategory2"] != DBNull.Value ? reader["SellerCategory2"].ToString() : null,
                SellerCategory3 = reader["SellerCategory3"] != DBNull.Value ? reader["SellerCategory3"].ToString() : null,
                OWID = reader["OWID"] != DBNull.Value ? reader["OWID"].ToString() : null,
                isDeleted = reader["isDeleted"] != DBNull.Value && Convert.ToBoolean(reader["isDeleted"]),
                LastUpdate = reader["LastUpdate"] != DBNull.Value ? reader["LastUpdate"].ToString() : null,

                // ⚠️ فیلdهای قدیمی (موقتی)
                ACID = readerColumnExists(reader, "ACID") && reader["ACID"] != DBNull.Value ? reader["ACID"].ToString() : null,
                Balance = readerColumnExists(reader, "Balance") && reader["Balance"] != DBNull.Value ? Convert.ToDecimal(reader["Balance"]) : 0m,
                Category = readerColumnExists(reader, "Category") && reader["Category"] != DBNull.Value ? reader["Category"].ToString() : null
            };
        }

        /// <summary>
        /// Map کردن SqlDataReader به AccountOwnerModel
        /// </summary>
        private AccountOwnerModel MapReaderToOwner(SqlDataReader reader)
        {
            return new AccountOwnerModel
            {
                OWID = reader["OWID"] != DBNull.Value ? reader["OWID"].ToString() : null,
                ACOwner = readerColumnExists(reader, "ACOwner") && reader["ACOwner"] != DBNull.Value ? reader["ACOwner"].ToString() : null,
                RefID = readerColumnExists(reader, "RefID") && reader["RefID"] != DBNull.Value ? reader["RefID"].ToString() : null,
                OWType = readerColumnExists(reader, "OWType") && reader["OWType"] != DBNull.Value ? reader["OWType"].ToString() : null,
                Balance = readerColumnExists(reader, "Balance") && reader["Balance"] != DBNull.Value ? Convert.ToDecimal(reader["Balance"]) : 0m,
                DefaultACID = readerColumnExists(reader, "DefaultACID") && reader["DefaultACID"] != DBNull.Value ? reader["DefaultACID"].ToString() : null,
                isPayer = readerColumnExists(reader, "isPayer") && reader["isPayer"] != DBNull.Value && Convert.ToBoolean(reader["isPayer"]),
                isActive = readerColumnExists(reader, "isActive") && reader["isActive"] != DBNull.Value && Convert.ToBoolean(reader["isActive"]),
                isDeleted = readerColumnExists(reader, "isDeleted") && reader["isDeleted"] != DBNull.Value && Convert.ToBoolean(reader["isDeleted"]),
                LastUpdate = readerColumnExists(reader, "LastUpdate") && reader["LastUpdate"] != DBNull.Value ? reader["LastUpdate"].ToString() : null
            };
        }

        /// <summary>
        /// Map کردن SqlDataReader به AccountModel
        /// </summary>
        private AccountModel MapReaderToAccount(SqlDataReader reader)
        {
            var account = new AccountModel
            {
                ACID = reader["ACID"] != DBNull.Value ? reader["ACID"].ToString() : null,
                OWID = readerColumnExists(reader, "OWID") && reader["OWID"] != DBNull.Value ? reader["OWID"].ToString() : null,
                PERID = readerColumnExists(reader, "PERID") && reader["PERID"] != DBNull.Value ? reader["PERID"].ToString() : null,
                ACOwner = readerColumnExists(reader, "ACOwner") && reader["ACOwner"] != DBNull.Value ? reader["ACOwner"].ToString() : null,
                ACBank = readerColumnExists(reader, "ACBank") && reader["ACBank"] != DBNull.Value ? reader["ACBank"].ToString() : null,
                ACNumber = readerColumnExists(reader, "ACNumber") && reader["ACNumber"] != DBNull.Value ? reader["ACNumber"].ToString() : null,
                ACshabaNumber = readerColumnExists(reader, "ACshabaNumber") && reader["ACshabaNumber"] != DBNull.Value ? reader["ACshabaNumber"].ToString() : null,
                ACCardNumber = readerColumnExists(reader, "ACCardNumber") && reader["ACCardNumber"] != DBNull.Value ? reader["ACCardNumber"].ToString() : null,
                ACType = readerColumnExists(reader, "ACType") && reader["ACType"] != DBNull.Value ? reader["ACType"].ToString() : null,
                ACCategory = readerColumnExists(reader, "ACCategory") && reader["ACCategory"] != DBNull.Value ? reader["ACCategory"].ToString() : null,
                isActive = readerColumnExists(reader, "isActive") && reader["isActive"] != DBNull.Value && Convert.ToBoolean(reader["isActive"]),
                isPayer = readerColumnExists(reader, "isPayer") && reader["isPayer"] != DBNull.Value && Convert.ToBoolean(reader["isPayer"]),
                isDeleted = readerColumnExists(reader, "isDeleted") && reader["isDeleted"] != DBNull.Value && Convert.ToBoolean(reader["isDeleted"]),
                LastUpdate = readerColumnExists(reader, "LastUpdate") && reader["LastUpdate"] != DBNull.Value ? reader["LastUpdate"].ToString() : null
            };

            // isDefault optional column
            if (readerColumnExists(reader, "isDefault") && reader["isDefault"] != DBNull.Value)
            {
                account.isDefault = Convert.ToBoolean(reader["isDefault"]);
            }

            return account;
        }

        private static bool readerColumnExists(IDataRecord reader, string columnName)
        {
            try
            {
                return reader.GetOrdinal(columnName) >= 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
