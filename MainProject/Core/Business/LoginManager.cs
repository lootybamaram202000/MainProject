using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.DataAccess;
using MainProject.Entities;
using MainProject.Helpers;

namespace MainProject.Core.Business
{
    public class LoginManager
    {
        private readonly LoginDAL _dal;
        
        public LoginManager()
        {
            _dal = new LoginDAL(Config.ConnectionString);
        }

        public bool Authenticate(LoginModel login, out DataTable messages, out DataTable notifications, out DataTable pending)
        {
            messages = null;
            notifications = null;
            pending = null;

            string hash = CommonFunctions.SHA256Hash(login.Password);
            string date = CommonFunctions.GetPersianDate();
            DateTime dateValue = DateTime.Now;
            int dateDig = int.Parse(CommonFunctions.GetPersianDateNumeric());

            try
            {
                DataSet ds = _dal.Authenticate(login.Username, hash, date, dateValue, dateDig);

                if (ds.Tables.Count < 4 || ds.Tables[0].Rows.Count == 0)
                    return false;

                var row = ds.Tables[0].Rows[0];

                LoginInfo.Instance.UserID = row["UserID"].ToString();
                LoginInfo.Instance.UserName = row["Username"].ToString();
                LoginInfo.Instance.FullName = row["FullName"].ToString();
                LoginInfo.Instance.PersianDate = date;
                LoginInfo.Instance.DateValue = dateValue;
                LoginInfo.Instance.DateDig = dateDig;
                LoginInfo.Instance.SetAccessID(ds.Tables[0].Rows[0]["AccessID"].ToString());
                messages = ds.Tables[1];
                notifications = ds.Tables[2];
                pending = ds.Tables[3];

                return true;
            }
            catch (SqlException sqlEx)
            {
                // 🔴 اگر از RAISERROR اومده، فقط پیام ساده نمایش بده
                if (sqlEx.Message.Contains("نام کاربری") || sqlEx.Message.Contains("دسترسی"))
                {
                    return false;
                }

                // در غیر این صورت، پیام کامل رو برای رفع اشکال بفرستیم
                throw;
            }
        }
    }
}
