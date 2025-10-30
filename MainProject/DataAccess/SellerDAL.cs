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

        public List<SellerModel> GetAllSellers()
        {
            List<SellerModel> sellers;
            string msg;
            if (GetAllSellers(out sellers, out msg)) return sellers;
            return new List<SellerModel>();
        }

        public List<SellerModel> SearchSellers(string text)
        {
            List<SellerModel> sellers;
            string msg;
            if (Search(text, out sellers, out msg)) return sellers;
            return new List<SellerModel>();
        }

        private static SellerModel ReadSeller(IDataRecord r)
        {
            var m = new SellerModel();
            m.SellerID = r["SellerID"].ToString();
            m.SellerName = r["SellerName"].ToString();
            m.CompanyName = r["CompanyName"].ToString();
            m.Addtress = r["Addtress"].ToString();
            m.Phone = r["Phone"].ToString();
            m.Category = r["Category"] == DBNull.Value ? null : r["Category"].ToString();
            m.ACID = r["ACID"].ToString();
            m.Balance = r["Balance"] == DBNull.Value ? 0m : Convert.ToDecimal(r["Balance"]);
            return m;
        }
    }
}
