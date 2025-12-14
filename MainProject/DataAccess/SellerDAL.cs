using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using MainProject.Core;
using MainProject.Entities;
using MainProject.Helpers;

namespace MainProject.DataAccess
{
    public class SellerDAL
    {

        private readonly string _connectionString = Config.ConnectionString;

        public bool InsertSeller(SellerModel model, string userID, string date, DateTime dateValue, int dateDig, out string message)
        {
            message = string.Empty;
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_InsertSeller", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SellerName", model.SellerName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompanyName", model.CompanyName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Addtress", model.Addtress ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", model.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Category", (object)model.Category ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACID", string.IsNullOrWhiteSpace(model.ACID) ? (object)DBNull.Value : model.ACID);
                    cmd.Parameters.AddWithValue("@Balance", model.Balance);

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

                    var ok = (pResult.Value != DBNull.Value) && Convert.ToBoolean(pResult.Value);
                    message = pMessage.Value as string ?? string.Empty;
                    return ok;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public bool UpdateSeller(SellerModel model, string userID, string date, DateTime dateValue, int dateDig, out string message)
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
                    cmd.Parameters.AddWithValue("@Addtress", model.Addtress ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", model.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Category", (object)model.Category ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACID", string.IsNullOrWhiteSpace(model.ACID) ? (object)DBNull.Value : model.ACID);
                    if (model.Balance >= 0m || model.Balance < 0m) // allow zero too
                        cmd.Parameters.AddWithValue("@Balance", model.Balance);
                    else
                        cmd.Parameters.AddWithValue("@Balance", DBNull.Value);

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

                    var ok = (pResult.Value != DBNull.Value) && Convert.ToBoolean(pResult.Value);
                    message = pMessage.Value as string ?? string.Empty;
                    return ok;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public bool DeleteSeller(string sellerID, string userID, string date, DateTime dateValue, int dateDig, out string message)
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

                    var ok = (pResult.Value != DBNull.Value) && Convert.ToBoolean(pResult.Value);
                    message = pMessage.Value as string ?? string.Empty;
                    return ok;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }



        public bool InsertSellerAndAccount(SellerModel model, string userID, string date, DateTime dateValue, int dateDig, out string message)
        {
            message = string.Empty;
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_InsertSellerAndAccount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SellerName", model.SellerName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompanyName", model.CompanyName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Addtress", model.Addtress ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", model.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Category", (object)model.Category ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Balance", model.Balance);

                    // پارامترهای حساب بانکی
                    cmd.Parameters.AddWithValue("@ACshabaNumber", (object)model.Account.ACshabaNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACCardNumber", (object)model.Account.ACCardNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACNumber", (object)model.Account.ACNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACBank", (object)model.Account.ACBank ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACType", (object)model.Account.ACType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@isActive", model.Account.isActive);
                    cmd.Parameters.AddWithValue("@isPayer", model.Account.isPayer);
                    cmd.Parameters.AddWithValue("@isDeleted", model.Account.isDeleted);

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

                    var ok = (pResult.Value != DBNull.Value) && Convert.ToBoolean(pResult.Value);
                    message = pMessage.Value as string ?? string.Empty;
                    return ok;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }


        public bool UpdateSellerAndAccount(SellerModel model, string userID, string date, DateTime dateValue, int dateDig, out string message)
        {
            message = string.Empty;
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_UpdateSellerAndAccount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SellerID", model.SellerID);
                    cmd.Parameters.AddWithValue("@SellerName", model.SellerName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompanyName", model.CompanyName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Addtress", model.Addtress ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", model.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Category", (object)model.Category ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Balance", model.Balance);
                    cmd.Parameters.AddWithValue("@ACID", model.ACID ?? (object)DBNull.Value);

                    // حساب بانکی
                    cmd.Parameters.AddWithValue("@ACshabaNumber", (object)model.Account.ACshabaNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACCardNumber", (object)model.Account.ACCardNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACNumber", (object)model.Account.ACNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACBank", (object)model.Account.ACBank ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ACType", (object)model.Account.ACType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@isActive", model.Account.isActive);
                    cmd.Parameters.AddWithValue("@isPayer", model.Account.isPayer);
                    cmd.Parameters.AddWithValue("@isDeleted", model.Account.isDeleted);

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

                    var ok = (pResult.Value != DBNull.Value) && Convert.ToBoolean(pResult.Value);
                    message = pMessage.Value as string ?? string.Empty;
                    return ok;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public bool GetAllSellers(out List<SellerModel> sellers, out string message)
        {
            sellers = new List<SellerModel>();
            message = string.Empty;
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_ReturnAllSellers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            sellers.Add(ReadSeller(r));
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

        public bool Search(string text, out List<SellerModel> sellers, out string message)
        {
            sellers = new List<SellerModel>();
            message = string.Empty;
            try
            {
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_SearchSellers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Text", text ?? string.Empty);
                    con.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            sellers.Add(ReadSeller(r));
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

        private static SellerModel ReadSeller(IDataRecord r)
        {
            var m = new SellerModel
            {
                SellerID = r["SellerID"].ToString(),
                SellerName = r["SellerName"].ToString(),
                CompanyName = r["CompanyName"].ToString(),
                Addtress = r["Addtress"].ToString(),
                Phone = r["Phone"].ToString(),
                Category = r["Category"] is DBNull ? null : r["Category"].ToString(),
                ACID = r["ACID"].ToString(),
                Balance = r["Balance"] is DBNull ? 0 : Convert.ToDecimal(r["Balance"]),
               // isDeleted = r["isDeleted"].ToString(),
                Account = new AccountModel
                {
                    ACID = r["ACID"].ToString(),
                    PERID = r["PERID"]?.ToString(),
                    ACOwner = r["ACOwner"]?.ToString(),
                    ACshabaNumber = r["ACshabaNumber"]?.ToString(),
                    ACCardNumber = r["ACCardNumber"]?.ToString(),
                    ACNumber = r["ACNumber"]?.ToString(),
                    ACBank = r["ACBank"]?.ToString(),
                    ACType = r["ACType"]?.ToString(),
                    isActive = r["AccountIsActive"] is DBNull ? false : Convert.ToBoolean(r["AccountIsActive"]),
                    isDeleted = r["AccountIsDeleted"] is DBNull ? false : Convert.ToBoolean(r["AccountIsDeleted"]),
                    isPayer = r["AccountIsPayer"] is DBNull ? false : Convert.ToBoolean(r["AccountIsPayer"])
                }
            };
            return m;
        }


    }
}
