using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.Helpers;

namespace MainProject.DataAccess
{
    internal class UserPanelDAL
    {
        private readonly string _connectionString = Config.ConnectionString;

        // حذف پیام
        public bool DeleteMessageByID(string messageID)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_DeleteMessageByID", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MessageID", messageID);
                cmd.Parameters.AddWithValue("@USERID", LoginInfo.Instance.UserID);
                cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null;
            }
        }

        // حذف اعلان
        public bool DeleteNotificationByID(string notificationID)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_DeleteNotificationByID", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NotificationID", notificationID);
                cmd.Parameters.AddWithValue("@USERID", LoginInfo.Instance.UserID);
                cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null;
            }
        }

        // بازیابی لیست پیام‌ها
        public DataTable GetUserMessages(string userID)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetUserMessages", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReceiverUserID", userID);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // بازیابی لیست اعلان‌ها
        public DataTable GetUserNotifications(string userID)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetUserNotifications", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // بازیابی لیست Pending
        public DataTable GetUserPendingList(string userID)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetUserPendingList", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // ثبت به عنوان رسیدگی‌شده
        public bool MarkPendingResolved(string pendingID)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_MarkPendingResolved", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PendingID", pendingID);
                cmd.Parameters.AddWithValue("@USERID", LoginInfo.Instance.UserID);
                cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null;
            }
        }
    }
}
