using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.DataAccess;

namespace MainProject.Core.Business
{
    internal class UserPanelManager
    {
        private readonly UserPanelDAL _dal = new UserPanelDAL();

        // دریافت پیام‌های کاربر جاری
        public DataTable GetMessages(string userId)
        {
            return _dal.GetUserMessages(userId);
        }

        // دریافت اعلان‌های کاربر جاری
        public DataTable GetNotifications(string userId)
        {
            return _dal.GetUserNotifications(userId);
        }

        // دریافت لیست موارد در انتظار رسیدگی
        public DataTable GetPendingItems(string userId)
        {
            return _dal.GetUserPendingList(userId);
        }

        // حذف پیام بر اساس ID
        public bool DeleteMessage(string messageId)
        {
            return _dal.DeleteMessageByID(messageId);
        }

        // حذف اعلان بر اساس ID
        public bool DeleteNotification(string notificationId)
        {
            return _dal.DeleteNotificationByID(notificationId);
        }
    }
}
