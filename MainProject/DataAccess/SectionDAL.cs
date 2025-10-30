using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.Entities;
using MainProject.Core;
using System.Windows.Forms;
using MainProject.Helpers;

namespace MainProject.DataAccess
{
    internal class SectionDAL
    {
        private readonly string _connectionString = Config.ConnectionString;

        public bool InsertSection(SectionModel section, out string newSecID)
        {
            newSecID = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertSection", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SecTitle", section.SecTitle);
                    cmd.Parameters.Add("@OverHead", SqlDbType.Decimal).Value = section.OverHead;
                    cmd.Parameters.AddWithValue("@PerCentage", section.PerCentage);
                    cmd.Parameters.AddWithValue("@CountOfSell", section.CountOfSell);
                    cmd.Parameters.AddWithValue("@USERID", LoginInfo.Instance.UserID);
                    cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                    cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                    cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                    SqlParameter outputParam = new SqlParameter("@NewSecID", SqlDbType.NVarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        newSecID = outputParam.Value.ToString();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ خطا در اجرای InsertSection:\n" + ex.Message);
                return false;
            }
        }

        public bool UpdateSection(SectionModel section)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateSection", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SecID", section.SecID);
                    cmd.Parameters.AddWithValue("@SecTitle", section.SecTitle);
                    cmd.Parameters.AddWithValue("@PerCentage", section.PerCentage);
                    cmd.Parameters.AddWithValue("@CountOfSell", section.CountOfSell);
                    cmd.Parameters.AddWithValue("@USERID", LoginInfo.Instance.UserID);
                    cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                    cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                    cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ خطا در اجرای UpdateSection:\n" + ex.Message);
                return false;
            }
        }

        public bool DeleteSection(string sectionId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteSection", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SecID", sectionId);
                    cmd.Parameters.AddWithValue("@USERID", LoginInfo.Instance.UserID);
                    cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                    cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                    cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ خطا در اجرای DeleteSection:\n" + ex.Message);
                return false;
            }
        }

        public List<SectionModel> GetAllSections()
        {
            List<SectionModel> list = new List<SectionModel>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_ReturnAllSections", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new SectionModel
                            {
                                SecID = reader["SecID"].ToString(),
                                SecTitle = reader["SecTitle"].ToString(),
                                OverHead = Convert.ToDecimal(reader["OverHead"]),
                                PerCentage = Convert.ToByte(reader["PerCentage"]),
                                CountOfSell = Convert.ToInt16(reader["CountOfSell"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ خطا در بارگذاری لیست سکشن‌ها:\n" + ex.Message);
            }

            return list;
        }
    }
}
