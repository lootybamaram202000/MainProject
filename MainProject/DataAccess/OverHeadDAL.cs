using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.Entities;
using System.Windows.Forms;

namespace MainProject.DataAccess
{
    internal class OverHeadDAL
    {
        private readonly string _connectionString = Config.ConnectionString;
        public void CalculateOverHeadSummary(int financialYear, out decimal fixedTotal, out decimal variableTotal)
        {
            fixedTotal = 0;
            variableTotal = 0;

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_CalculateOverHeadSummary", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FinancialYear", financialYear);

                var fixedParam = new SqlParameter("@FixedTotal", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Direction = ParameterDirection.Output
                };

                var variableParam = new SqlParameter("@VariableTotal", SqlDbType.Decimal)
                {
                    Precision = 18,
                    Scale = 2,
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(fixedParam);
                cmd.Parameters.Add(variableParam);

                con.Open();
                cmd.ExecuteNonQuery();

                fixedTotal = fixedParam.Value != DBNull.Value ? Convert.ToDecimal(fixedParam.Value) : 0;
                variableTotal = variableParam.Value != DBNull.Value ? Convert.ToDecimal(variableParam.Value) : 0;
            }
        }


        public void CalculateOverHeadSummary(
          int? financialYear,
          string ohType,
          int? financialMonth,
          string ohCategory,
          string ohTitle,
          out decimal fixedTotal,
          out decimal variableTotal)
        {
            fixedTotal = 0;
            variableTotal = 0;

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_CalculateOverHeadSummary", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FinancialYear", (object)financialYear ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OHType", string.IsNullOrWhiteSpace(ohType) ? DBNull.Value : (object)ohType);
                cmd.Parameters.AddWithValue("@FinancialMounth", (object)financialMonth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OHCategory", string.IsNullOrWhiteSpace(ohCategory) ? DBNull.Value : (object)ohCategory);
                cmd.Parameters.AddWithValue("@OHTitle", string.IsNullOrWhiteSpace(ohTitle) ? DBNull.Value : (object)ohTitle);

                var fixedParam = new SqlParameter("@FixedTotal", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output,
                    Precision = 18,
                    Scale = 2
                };
                var variableParam = new SqlParameter("@VariableTotal", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output,
                    Precision = 18,
                    Scale = 2
                };

                cmd.Parameters.Add(fixedParam);
                cmd.Parameters.Add(variableParam);

                con.Open();
                cmd.ExecuteNonQuery();

                fixedTotal = fixedParam.Value != DBNull.Value ? Convert.ToDecimal(fixedParam.Value) : 0;
                variableTotal = variableParam.Value != DBNull.Value ? Convert.ToDecimal(variableParam.Value) : 0;
            }
        }


        public bool SubmitSectionOverHeads(List<SectionModel> sections, out string errorMessage)
        {
            errorMessage = null;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_SubmitSectionOverHeads", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    var table = new DataTable();
                    table.Columns.Add("SecID", typeof(string));
                    table.Columns.Add("SecTitle", typeof(string));
                    table.Columns.Add("OverHead", typeof(decimal));
                    table.Columns.Add("PerCentage", typeof(byte));
                    table.Columns.Add("CountOfSell", typeof(short));
                    table.Columns.Add("isDeleted", typeof(bool));

                    foreach (var s in sections)
                    {
                        table.Rows.Add(s.SecID, s.SecTitle, s.OverHead, s.PerCentage, s.CountOfSell, s.isDeleted);
                        MessageBox.Show(s.SecID.ToString(), s.SecTitle.ToString() );
                    }

                    var param = cmd.Parameters.AddWithValue("@Sections", table);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "SectionOverHeadTVP";

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public string InsertOverHead(OverHeadModel model, string userName)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_InsertOverHead", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OHTitle", model.OHTitle ?? "-");
                cmd.Parameters.AddWithValue("@FinancialYear", model.FinancialYear);
                cmd.Parameters.AddWithValue("@FinancialMounth", (object)model.FinancialMounth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@YearlyCost", (object)model.YearlyCost ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MonthlyCost", (object)model.MonthlyCost ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OHType", model.OHType ?? "-");
                cmd.Parameters.AddWithValue("@OHCategory", model.OHCategory ?? "-");
                cmd.Parameters.AddWithValue("@Describtion", model.Describtion ?? "-");
                cmd.Parameters.AddWithValue("@DATE", model.DATE ?? "-");
                cmd.Parameters.AddWithValue("@DATEVALUE", model.DATEVALUE ?? DateTime.Now);
                cmd.Parameters.AddWithValue("@DATEDIG", model.DATEDIG);
                cmd.Parameters.AddWithValue("@UserID", userName);

                SqlParameter outputId = new SqlParameter("@NewOHID", SqlDbType.NVarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputId);

                con.Open();
                cmd.ExecuteNonQuery();

                return outputId.Value?.ToString();
            }
        }

        public List<OverHeadModel> GetOverHeadsByFilter(string ohType, int? year, int? month, string category)
        {
            var list = new List<OverHeadModel>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetOverHeadsByFilter", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OHType", (object)ohType ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Year", (object)year ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Month", (object)month ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OHCategory", (object)category ?? DBNull.Value);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new OverHeadModel
                        {
                            OHID = reader["OHID"].ToString(),
                            OHTitle = reader["OHTitle"].ToString(),
                            FinancialYear = Convert.ToInt32(reader["FinancialYear"]),
                            FinancialMounth = reader["FinancialMounth"] as int?,
                            YearlyCost = reader["YearlyCost"] as decimal?,
                            MonthlyCost = reader["MonthlyCost"] as decimal?,
                            OHType = reader["OHType"].ToString(),
                            OHCategory = reader["OHCategory"].ToString(),
                            Describtion = reader["Describtion"].ToString(),
                            DATE = reader["DATE"].ToString(),
                            DATEVALUE = reader["DATEVALUE"] as DateTime?,
                            DATEDIG = Convert.ToInt32(reader["DATEDIG"]),
                            LastUpdate = reader["LastUpdate"].ToString(),
                            isDeleted = Convert.ToBoolean(reader["isDeleted"])
                        });
                    }
                }
            }

            return list;
        }

        public bool UpdateOverHead(OverHeadModel model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_UpdateOverHead", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OHID", model.OHID);
                cmd.Parameters.AddWithValue("@OHTitle", model.OHTitle ?? "-");
                cmd.Parameters.AddWithValue("@FinancialYear", model.FinancialYear);
                cmd.Parameters.AddWithValue("@FinancialMounth", (object)model.FinancialMounth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@YearlyCost", (object)model.YearlyCost ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MonthlyCost", (object)model.MonthlyCost ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OHType", model.OHType ?? "-");
                cmd.Parameters.AddWithValue("@OHCategory", model.OHCategory ?? "-");
                cmd.Parameters.AddWithValue("@Describtion", model.Describtion ?? "-");
                cmd.Parameters.AddWithValue("@LastUpdate", model.LastUpdate ?? "-");

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteOverHead(string ohid)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_DeleteOverHead", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OHID", ohid);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<OverHeadModel> GetOverHeadsByYear(int year)
        {
            var list = new List<OverHeadModel>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetOverHeadsByYear", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Year", year);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new OverHeadModel
                        {
                            OHID = reader["OHID"].ToString(),
                            OHTitle = reader["OHTitle"].ToString(),
                            FinancialYear = Convert.ToInt32(reader["FinancialYear"]),
                            FinancialMounth = reader["FinancialMounth"] as int?,
                            YearlyCost = reader["YearlyCost"] as decimal?,
                            MonthlyCost = reader["MonthlyCost"] as decimal?,
                            OHType = reader["OHType"].ToString(),
                            OHCategory = reader["OHCategory"].ToString(),
                            Describtion = reader["Describtion"].ToString(),
                            DATE = reader["DATE"].ToString(),
                            DATEVALUE = reader["DATEVALUE"] as DateTime?,
                            DATEDIG = Convert.ToInt32(reader["DATEDIG"]),
                            LastUpdate = reader["LastUpdate"].ToString(),
                            isDeleted = Convert.ToBoolean(reader["isDeleted"])
                        });
                    }
                }
            }

            return list;
        }

        public bool SubmitOHSectionInputDraft(DataTable sectionInputs, out string errorMessage)
        {
            errorMessage = null;

            if (sectionInputs == null)
            {
                errorMessage = "داده‌های ورودی سکشن نامعتبر است.";
                return false;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("dbo.sp_SubmitOHSectionInputDraft", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    var param = cmd.Parameters.AddWithValue("@SectionInputs", sectionInputs);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.OHSectionInputTVP";

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool SubmitOHSubSectionInputDraft(DataTable subSectionInputs, out string errorMessage)
        {
            errorMessage = null;

            if (subSectionInputs == null)
            {
                errorMessage = "داده‌های ورودی زیرسکشن نامعتبر است.";
                return false;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("dbo.sp_SubmitOHSubSectionInputDraft", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    var param = cmd.Parameters.AddWithValue("@SubSectionInputs", subSectionInputs);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.OHSubSectionInputTVP";

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public DataTable CalcOverheadAllocation(out string errorMessage)
        {
            errorMessage = null;
            DataTable results = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("dbo.sp_CalcOverheadAllocation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        results.Load(reader);
                    }
                    return results;
                }
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return results;
            }
        }

        public DataTable GetOHPerItemBySSID(string ssid, out string errorMessage)
        {
            errorMessage = null;
            DataTable results = new DataTable();

            if (string.IsNullOrWhiteSpace(ssid))
            {
                errorMessage = "شناسه زیرسکشن نامعتبر است.";
                return results;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("dbo.sp_GetOHPerItemBySSID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SSID", ssid);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        results.Load(reader);
                    }
                    return results;
                }
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return results;
            }
        }
    }
}

