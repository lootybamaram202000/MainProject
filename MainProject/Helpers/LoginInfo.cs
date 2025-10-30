using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Helpers
{
    public class LoginInfo
    {
        private static LoginInfo _instance;
        public string AccessID { get; private set; } = "ACCESS0001"; // مقدار پیش‌فرض

        public void SetAccessID(string accessID)
        {
            AccessID = accessID;
        }
        public static LoginInfo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LoginInfo();
                return _instance;
            }
        }

        public void Clear()
        {
            this.UserID = null;
            this.FullName = null;
            this.PersianDate = null;
            this.DateValue = default;
            this.DateDig = 0;
            // هر چیز دیگه‌ای که ذخیره شده
        }
        public string Date => PersianDate; // یا هر فیلد معادل داخلی


        // 🟩 این مقادیر در زمان لاگین مقداردهی می‌شن
        public string UserID { get; set; } = "SYSADMIN";
        public string UserName { get; set; } = "Admin";
        public string FullName { get; set; } = "مدیر سیستم";

        // 🟨 مقادیر مرتبط با تاریخ که در کل سیستم استفاده می‌شن
        public string PersianDate { get; set; } = "1404/04/08";      // مثال: "1404/04/08"
        public DateTime DateValue { get; set; } = DateTime.Today;    // تاریخ میلادی معادل
        public int DateDig { get; set; } = 14040408;                 // نسخه عددی برای مرتب‌سازی
    }
}
