using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.Entities;

namespace MainProject.Core.Business
{
    internal class MainMenuManager
    {
        public MainMenuInfo LoadInfo()
        {
            return new MainMenuInfo
            {
                CurrentUser = "System Manager", // در فاز تست ثابت است
                CurrentDate = GetPersianDate(),
                SystemDate = GetPersianDate()
            };
        }

        private string GetPersianDate()
        {
            var pc = new System.Globalization.PersianCalendar();
            var now = DateTime.Now;
            return $"{pc.GetYear(now)}/{pc.GetMonth(now):00}/{pc.GetDayOfMonth(now):00}";
        }
    }
}
