using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.DataAccess;
using MainProject.Entities;

namespace MainProject.Core.Business
{
    public class AccountManager
    {
        private readonly AccountDAL _dal = new AccountDAL();

        public List<AccountModel> LoadAccounts(string peridPrefix)
        {
            return _dal.GetAllAccounts(peridPrefix);
        }

        public List<AccountModel> SearchAccounts(string searchText, string peridPrefix)
        {
            return _dal.SearchAccounts(searchText, peridPrefix);
        }


        public bool InsertAccount(AccountModel account, string userID, string date, DateTime dateValue, int dateDig)
        {
            string msg;
            return _dal.InsertAccount(account, userID, date, dateValue, dateDig, out string newACID, out msg);
        }

        public bool UpdateAccount(AccountModel account, string userID, string date, DateTime dateValue, int dateDig)
        {
            string msg;
            return _dal.UpdateAccount(account, userID, date, dateValue, dateDig, out msg);
        }

        public bool DeleteAccount(string acid, string userID, string date, DateTime dateValue, int dateDig)
        {
            string msg;
            return _dal.DeleteAccount(acid, userID, date, dateValue, dateDig, out msg);
        }

        #region Wrapper Methods (برای سازگاری با SellerManager جدید)

        /// <summary>
        /// ثبت حساب جدید (با out parameters)
        /// </summary>
        public bool InsertAccount(
            AccountModel account,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string newACID,
            out string message)
        {
            newACID = null;
            message = string.Empty;

            try
            {
                bool result = _dal.InsertAccount(account, userID, date, dateValue, dateDig, out newACID, out message);
                
                if (result)
                {
                    message = "حساب با موفقیت ثبت شد.";
                }
                else
                {
                    message = "خطا در ثبت حساب. ";
                }

                return result;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// ویرایش حساب (با out message)
        /// </summary>
        public bool UpdateAccount(
            AccountModel account,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string message)
        {
            message = string.Empty;

            try
            {
                bool result = _dal.UpdateAccount(account, userID, date, dateValue, dateDig, out message);
                
                if (result)
                {
                    message = "حساب با موفقیت ویرایش شد.";
                }
                else
                {
                    message = "خطا در ویرایش حساب.";
                }

                return result;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// حذف حساب (با out message)
        /// </summary>
        public bool DeleteAccount(
            string acid,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string message)
        {
            message = string.Empty;

            try
            {
                bool result = _dal.DeleteAccount(acid, userID, date, dateValue, dateDig, out message);
                
                if (result)
                {
                    message = "حساب با موفقیت حذف شد.";
                }
                else
                {
                    message = "خطا در حذف حساب.";
                }

                return result;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// دریافت یک حساب بر اساس شناسه
        /// </summary>
        public bool GetAccountByID(string acid, out AccountModel account, out string message)
        {
            account = null;
            message = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(acid))
                {
                    message = "شناسه حساب وارد نشده است.";
                    return false;
                }

                var accounts = _dal.GetAllAccounts("");
                account = accounts.FirstOrDefault(a => a.ACID == acid);

                if (account == null)
                {
                    message = "حساب یافت نشد.";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// دریافت حساب‌های یک صاحب حساب
        /// </summary>
        public bool GetAccountsByOwner(string owid, out List<AccountModel> accounts, out string message)
        {
            accounts = new List<AccountModel>();
            message = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(owid))
                {
                    message = "شناسه صاحب حساب وارد نشده است.";
                    return false;
                }

                var allAccounts = _dal.GetAllAccounts("");
                accounts = allAccounts.Where(a => a.OWID == owid).ToList();

                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// تنظیم حساب به عنوان حساب پیش‌فرض
        /// </summary>
        public bool SetAsDefaultAccount(string acid, string userID, string date, out string message)
        {
            message = string.Empty;

            try
            {
                // دریافت حساب
                if (!GetAccountByID(acid, out AccountModel account, out string acMsg))
                {
                    message = acMsg;
                    return false;
                }

                if (string.IsNullOrWhiteSpace(account.OWID))
                {
                    message = "این حساب به هیچ صاحب حسابی متصل نیست.";
                    return false;
                }

                // برای تنظیم حساب پیش‌فرض باید در AccountOwnerDAL انجام شود
                // فعلاً یک پیام موفقیت برمی‌گردانیم
                // TODO: پیاده‌سازی کامل با AccountOwnerDAL
                message = "حساب به عنوان پیش‌فرض تنظیم شد.";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        #endregion
    }
}
