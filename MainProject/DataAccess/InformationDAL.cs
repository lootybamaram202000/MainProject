using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProject.Entities;

namespace MainProject.DataAccess
{
    internal class InformationDAL
    {
        private readonly string connectionString = Config.ConnectionString;

        public List<InformationDto> GetInformationByContext(string context)
        {
            var result = new List<InformationDto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetInformation", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Context", context);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new InformationDto
                        {
                            Context = context,
                            InfID = Convert.ToInt32(reader["InfID"]),
                            PersianTitle = reader["PersianTitle"].ToString(),
                            StringValueEng = reader["StringValueEng"].ToString(),
                            StringValuePer = reader["StringValuePer"].ToString(),
                            DigitalValue = reader["DigitalValue"] != DBNull.Value
                                ? Convert.ToDecimal(reader["DigitalValue"])
                                : 0
                        };

                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public void InsertInformation(InformationDto info)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_InsertInformation", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Context", info.Context);
                cmd.Parameters.AddWithValue("@PersianTitle", (object)info.PersianTitle ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StringValueEng", (object)info.StringValueEng ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StringValuePer", (object)info.StringValuePer ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DigitalValue", info.DigitalValue);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateInformation(InformationDto info)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_UpdateInformation", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InfID", info.InfID);
                cmd.Parameters.AddWithValue("@PersianTitle", info.PersianTitle);
                cmd.Parameters.AddWithValue("@StringValueEng", info.StringValueEng);
                cmd.Parameters.AddWithValue("@StringValuePer", info.StringValuePer);
                cmd.Parameters.AddWithValue("@DigitalValue", info.DigitalValue);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteInformation(InformationDto info)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_DeleteInformation", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InfID", info.InfID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public List<string> GetValuesByContext(string context)
        {
            

            var result = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetInformation", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Context", context);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string value = reader["StringValuePer"]?.ToString();
                        if (!string.IsNullOrWhiteSpace(value))
                            result.Add(value);
                    }
                }
            }
            return result;
        }
        public List<string> GetAllPaymentTypes()
        {
            return GetValuesByContext("TypeOfPayment");
        }

        public List<string> GetAllPaymentStatuses()
        {
            return GetValuesByContext("PaymentStatuse");
        }
    }
}

