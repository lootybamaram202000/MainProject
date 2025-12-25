using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MainProject.DataAccess
{
    internal class SubSectionDAL
    {
        private readonly string _connectionString = Config.ConnectionString;

        public DataTable GetSubSectionsBySectionId(string secId)
        {
            var dt = new DataTable();

            if (string.IsNullOrWhiteSpace(secId))
                return dt;

            try
            {
                // Note: using direct query to avoid depending on a stored procedure name.
                // Adjust table/column names if your schema differs.
                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(@"
SELECT SSID, SecID, SSTitle
FROM dbo.tblSubSections
WHERE isDeleted = 0 AND SecID = @SecID
ORDER BY SSTitle;", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@SecID", secId);

                    con.Open();
                    using (var r = cmd.ExecuteReader())
                        dt.Load(r);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ خطا در بارگذاری زیرسکشن‌ها:\n" + ex.Message);
            }

            return dt;
        }
    }
}
