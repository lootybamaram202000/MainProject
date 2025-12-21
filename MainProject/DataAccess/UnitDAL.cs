using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MainProject.Core;
using MainProject.Entities;
using MainProject.Helpers;

namespace MainProject.DataAccess
{
    internal class UnitDAL
    {
        private readonly string _connectionString = Config.ConnectionString;
        public bool InsertUnit(UnitModel unit, out string newUnitID)
        {
            // Backward-compatible wrapper
            return InsertUnit(unit, out newUnitID, out _);
        }

        public bool InsertUnit(UnitModel unit, out string newUnitID, out string errorMessage)
        {
            newUnitID = null;
            errorMessage = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertUnit", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Use legacy parameter names to match existing SPs/DB
                    cmd.Parameters.AddWithValue("@UnitType", unit.UnitType);
                    cmd.Parameters.AddWithValue("@MeasurmentUnitTitle", unit.MeasurmentUnitTitle);
                    cmd.Parameters.AddWithValue("@MesurmentUnitQuantity", unit.MesurmentUnitQuantity);
                    cmd.Parameters.AddWithValue("@PUnitTitle", unit.PunitTitle);
                    cmd.Parameters.AddWithValue("@PUnitQuantity", unit.PunitQuantity);
                    cmd.Parameters.AddWithValue("@isActive", unit.IsActive);

                    cmd.Parameters.AddWithValue("@CreatedBy", LoginInfo.Instance.UserID);
                    cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                    cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                    cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                    var outParam = new SqlParameter("@NewUnitID", SqlDbType.NVarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outParam);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    newUnitID = outParam.Value?.ToString();
                    return !string.IsNullOrEmpty(newUnitID);
                }
            }
            catch (SqlException ex)
            {
                errorMessage = $"خطای دیتابیس: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"خطای سیستم: {ex.Message}";
                return false;
            }
        }

        public bool UpdateUnit(UnitModel unit)
        {
            return UpdateUnit(unit, out _);
        }

        public bool UpdateUnit(UnitModel unit, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateUnit", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UnitID", unit.UnitID);
                    cmd.Parameters.AddWithValue("@MeasurmentUnitTitle", unit.MeasurmentUnitTitle);
                    cmd.Parameters.AddWithValue("@MesurmentUnitQuantity", unit.MesurmentUnitQuantity);
                    cmd.Parameters.AddWithValue("@PUnitTitle", unit.PunitTitle);
                    cmd.Parameters.AddWithValue("@PUnitQuantity", unit.PunitQuantity);
                    cmd.Parameters.AddWithValue("@isActive", unit.IsActive);
                    cmd.Parameters.AddWithValue("@UpdatedBy", LoginInfo.Instance.UserID);
                    cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                    cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                    cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);
                    cmd.Parameters.AddWithValue("@UnitType", unit.UnitType);

                    con.Open();
                    var result = cmd.ExecuteScalar();
                    return result != null && result.ToString() == "1";
                }
            }
            catch (SqlException ex)
            {
                errorMessage = $"خطای دیتابیس: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"خطای سیستم: {ex.Message}";
                return false;
            }
        }

        public bool IsDuplicateUnit(string unitType, string muTitle, string puTitle, string excludeUnitID = null)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"
            SELECT COUNT(*) 
            FROM tblUnits
            WHERE UnitType = @UnitType
              AND MeasurmentUnitTitle = @MeasurmentUnitTitle
              AND PUnitTitle = @PUnitTitle
              AND isDeleted = 0";

                if (!string.IsNullOrEmpty(excludeUnitID))
                {
                    cmd.CommandText += " AND UnitID != @ExcludeUnitID";
                    cmd.Parameters.AddWithValue("@ExcludeUnitID", excludeUnitID);
                }

                cmd.Parameters.AddWithValue("@UnitType", unitType);
                cmd.Parameters.AddWithValue("@MeasurmentUnitTitle", muTitle);
                cmd.Parameters.AddWithValue("@PUnitTitle", puTitle);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool DeleteUnit(string unitID)
        {
            return DeleteUnit(unitID, out _);
        }

        public bool DeleteUnit(string unitID, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteUnit", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UnitID", unitID);
                    cmd.Parameters.AddWithValue("@DeletedBy", LoginInfo.Instance.UserID);
                    cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                    cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                    cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                errorMessage = $"خطای دیتابیس: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"خطای سیستم: {ex.Message}";
                return false;
            }
        }

        public List<UnitModel> GetAllUnits()
        {
            return GetAllUnits(out _);
        }

        public List<UnitModel> GetAllUnits(out string errorMessage)
        {
            errorMessage = string.Empty;
            List<UnitModel> list = new List<UnitModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_ReturnAllUnits", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapUnit(reader));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                errorMessage = $"خطای دیتابیس: {ex.Message}";
            }
            catch (Exception ex)
            {
                errorMessage = $"خطای سیستم: {ex.Message}";
            }

            return list;
        }

        public List<UnitModel> SearchUnits(string keyword)
        {
            return SearchUnits(keyword, out _);
        }

        public List<UnitModel> SearchUnits(string keyword, out string errorMessage)
        {
            errorMessage = string.Empty;
            List<UnitModel> list = new List<UnitModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_SearchUnits", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Keyword", keyword);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapUnit(reader));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                errorMessage = $"خطای دیتابیس: {ex.Message}";
            }
            catch (Exception ex)
            {
                errorMessage = $"خطای سیستم: {ex.Message}";
            }

            return list;
        }

        private UnitModel MapUnit(SqlDataReader reader)
        {
            string muTitle;
            int muQty;
            // Legacy schema mapping
            muTitle = reader["MeasurmentUnitTitle"].ToString();
            muQty = Convert.ToInt32(reader["MesurmentUnitQuantity"]);

            return new UnitModel
            {
                UnitID = reader["UnitID"].ToString(),
                UnitType = reader["UnitType"].ToString(),
                MeasurmentUnitTitle = muTitle,
                MesurmentUnitQuantity = muQty,
                PunitTitle = reader["PUnitTitle"].ToString(),
                PunitQuantity = Convert.ToInt32(reader["PUnitQuantity"]),
                IsActive = Convert.ToBoolean(reader["isActive"]),
                IsDeleted = Convert.ToBoolean(reader["isDeleted"])
            };
        }

        public string GenerateCode(string tableName, string columnName, string prefix)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GenerateNewCode", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TableName", tableName);
                cmd.Parameters.AddWithValue("@ColumnName", columnName);
                cmd.Parameters.AddWithValue("@Prefix", prefix);

                SqlParameter output = new SqlParameter("@NewCode", SqlDbType.NVarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(output);

                con.Open();
                cmd.ExecuteNonQuery();

                return output.Value.ToString();
            }
        }
    }
}
