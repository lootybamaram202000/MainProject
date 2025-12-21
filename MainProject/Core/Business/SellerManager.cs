using System;
using System.Collections.Generic;
using MainProject.Entities;
using MainProject.DataAccess;
using MainProject.Core.Business;

namespace MainProject.Business
{
    /// <summary>
    /// مدیریت فروشندگان
    /// </summary>
    public class SellerManager
    {
        private readonly SellerDAL _sellerDAL = new SellerDAL();
        private readonly AccountOwnerDAL _ownerDAL = new AccountOwnerDAL();
        private readonly AccountManager _accountManager = new AccountManager();

        #region Insert Seller

        /// <summary>
        /// ثبت فروشنده جدید (به همراه Owner)
        /// </summary>
        public bool InsertSeller(
            SellerModel model,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string newSellerID,
            out string newOWID,
            out string message)
        {
            newSellerID = null;
            newOWID = null;
            message = string.Empty;

            // Validation
            if (!ValidateSellerForInsert(model, out message))
            {
                return false;
            }

            // ثبت فروشنده
            bool result = _sellerDAL.InsertSeller(
                model,
                userID,
                date,
                dateValue,
                dateDig,
                out newSellerID,
                out newOWID,
                out message);

            if (result)
            {
                message = $"فروشنده با موفقیت ثبت شد. شناسه:  {newSellerID}";
            }

            return result;
        }

        #endregion

        #region Update Seller

        /// <summary>
        /// ویرایش فروشنده
        /// </summary>
        public bool UpdateSeller(
            SellerModel model,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string message)
        {
            message = string.Empty;

            // Validation
            if (!ValidateSellerForUpdate(model, out message))
            {
                return false;
            }

            // بررسی وجود فروشنده
            if (!_sellerDAL.GetSellerByID(model.SellerID, out SellerModel existingSeller, out string checkMsg))
            {
                message = $"فروشنده با شناسه {model.SellerID} یافت نشد. ";
                return false;
            }

            // ویرایش فروشنده
            bool result = _sellerDAL.UpdateSeller(
                model,
                userID,
                date,
                dateValue,
                dateDig,
                out message);

            if (result)
            {
                message = "فروشنده با موفقیت ویرایش شد.";
            }

            return result;
        }

        #endregion

        #region Delete Seller

        /// <summary>
        /// حذف فروشنده (Soft Delete)
        /// </summary>
        public bool DeleteSeller(
            string sellerID,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string message)
        {
            message = string.Empty;

            // Validation
            if (string.IsNullOrWhiteSpace(sellerID))
            {
                message = "شناسه فروشنده وارد نشده است. ";
                return false;
            }

            // بررسی وجود فروشنده
            if (!_sellerDAL.GetSellerByID(sellerID, out SellerModel seller, out string checkMsg))
            {
                message = $"فروشنده با شناسه {sellerID} یافت نشد.";
                return false;
            }

            // TODO: بررسی عدم وجود تراکنش مالی
            // اگر فروشنده دارای تراکنش باشد، نباید حذف شود

            // حذف فروشنده
            bool result = _sellerDAL.DeleteSeller(
                sellerID,
                userID,
                date,
                dateValue,
                dateDig,
                out message);

            if (result)
            {
                message = "فروشنده با موفقیت حذف شد.";
            }

            return result;
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// دریافت یک فروشنده بر اساس شناسه (با Owner و Accounts)
        /// </summary>
        public bool GetSellerByID(string sellerID, out SellerModel seller, out string message)
        {
            seller = null;
            message = string.Empty;

            if (string.IsNullOrWhiteSpace(sellerID))
            {
                message = "شناسه فروشنده وارد نشده است.";
                return false;
            }

            return _sellerDAL.GetSellerByID(sellerID, out seller, out message);
        }

        /// <summary>
        /// دریافت تمام فروشندگان (با Owner و Accounts)
        /// </summary>
        public bool GetAllSellers(out List<SellerModel> sellers, out string message)
        {
            return _sellerDAL.GetAllSellers(out sellers, out message);
        }

        /// <summary>
        /// جستجو در فروشندگان (با Owner و Accounts)
        /// </summary>
        public bool Search(string searchText, out List<SellerModel> sellers, out string message)
        {
            return _sellerDAL.Search(searchText ?? string.Empty, out sellers, out message);
        }

        /// <summary>
        /// دریافت فروشندگان فعال
        /// </summary>
        public bool GetActiveSellers(out List<SellerModel> sellers, out string message)
        {
            bool result = GetAllSellers(out List<SellerModel> allSellers, out message);

            sellers = new List<SellerModel>();

            if (result)
            {
                sellers = allSellers.FindAll(s => !s.isDeleted);
            }

            return result;
        }

        /// <summary>
        /// دریافت فروشندگان بر اساس نوع
        /// </summary>
        public bool GetSellersByType(string sellerType, out List<SellerModel> sellers, out string message)
        {
            bool result = GetAllSellers(out List<SellerModel> allSellers, out message);

            sellers = new List<SellerModel>();

            if (result)
            {
                sellers = allSellers.FindAll(s =>
                    !s.isDeleted &&
                    !string.IsNullOrWhiteSpace(s.SellerType) &&
                    s.SellerType.Equals(sellerType, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

        /// <summary>
        /// دریافت فروشندگان بر اساس دسته‌بندی
        /// </summary>
        public bool GetSellersByCategory(string category, out List<SellerModel> sellers, out string message)
        {
            bool result = GetAllSellers(out List<SellerModel> allSellers, out message);

            sellers = new List<SellerModel>();

            if (result)
            {
                sellers = allSellers.FindAll(s =>
                    !s.isDeleted &&
                    (s.SellerCategory1 == category ||
                     s.SellerCategory2 == category ||
                     s.SellerCategory3 == category));
            }

            return result;
        }

        #endregion

        #region Account Management for Seller

        /// <summary>
        /// اضافه کردن حساب بانکی به فروشنده
        /// </summary>
        public bool AddAccountToSeller(
            string sellerID,
            AccountModel accountModel,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string newACID,
            out string message)
        {
            newACID = null;
            message = string.Empty;

            // بررسی وجود فروشنده
            if (!_sellerDAL.GetSellerByID(sellerID, out SellerModel seller, out string checkMsg))
            {
                message = $"فروشنده با شناسه {sellerID} یافت نشد.";
                return false;
            }

            // بررسی وجود Owner
            if (string.IsNullOrWhiteSpace(seller.OWID))
            {
                message = "این فروشنده فاقد Owner است.";
                return false;
            }

            // تنظیم OWID حساب
            accountModel.OWID = seller.OWID;

            // ثبت حساب
            return _accountManager.InsertAccount(
                accountModel,
                userID,
                date,
                dateValue,
                dateDig,
                out newACID,
                out message);
        }

        /// <summary>
        /// ویرایش حساب بانکی فروشنده
        /// </summary>
        public bool UpdateSellerAccount(
            AccountModel accountModel,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string message)
        {
            return _accountManager.UpdateAccount(
                accountModel,
                userID,
                date,
                dateValue,
                dateDig,
                out message);
        }

        /// <summary>
        /// حذف حساب بانکی فروشنده
        /// </summary>
        public bool DeleteSellerAccount(
            string acid,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string message)
        {
            return _accountManager.DeleteAccount(
                acid,
                userID,
                date,
                dateValue,
                dateDig,
                out message);
        }

        /// <summary>
        /// تنظیم حساب پیش‌فرض فروشنده
        /// </summary>
        public bool SetSellerDefaultAccount(
            string sellerID,
            string acid,
            string userID,
            string date,
            out string message)
        {
            message = string.Empty;

            // بررسی وجود فروشنده
            if (!_sellerDAL.GetSellerByID(sellerID, out SellerModel seller, out string checkMsg))
            {
                message = $"فروشنده با شناسه {sellerID} یافت نشد.";
                return false;
            }

            // بررسی اینکه حساب متعلق به همین فروشنده است
            if (!_accountManager.GetAccountByID(acid, out AccountModel account, out string acMsg))
            {
                message = acMsg;
                return false;
            }

            if (account.OWID != seller.OWID)
            {
                message = "این حساب متعلق به این فروشنده نیست.";
                return false;
            }

            // تنظیم به عنوان پیش‌فرض
            return _accountManager.SetAsDefaultAccount(acid, userID, date, out message);
        }

        /// <summary>
        /// دریافت حساب‌های فروشنده
        /// </summary>
        public bool GetSellerAccounts(string sellerID, out List<AccountModel> accounts, out string message)
        {
            accounts = new List<AccountModel>();
            message = string.Empty;

            // بررسی وجود فروشنده
            if (!_sellerDAL.GetSellerByID(sellerID, out SellerModel seller, out string checkMsg))
            {
                message = $"فروشنده با شناسه {sellerID} یافت نشد.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(seller.OWID))
            {
                message = "این فروشنده فاقد Owner است.";
                return true; // لیست خالی برمی‌گردد
            }

            return _accountManager.GetAccountsByOwner(seller.OWID, out accounts, out message);
        }

        #endregion

        #region Validation

        /// <summary>
        /// اعتبارسنجی برای Insert
        /// </summary>
        private bool ValidateSellerForInsert(SellerModel model, out string message)
        {
            message = string.Empty;

            if (model == null)
            {
                message = "اطلاعات فروشنده وارد نشده است.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(model.SellerName))
            {
                message = "نام فروشنده وارد نشده است. ";
                return false;
            }

            if (string.IsNullOrWhiteSpace(model.CompanyName))
            {
                message = "نام شرکت وارد نشده است.";
                return false;
            }

            // حداقل یک شماره تماس باید وارد شود
            if (string.IsNullOrWhiteSpace(model.Phone1) &&
                string.IsNullOrWhiteSpace(model.Phone2) &&
                string.IsNullOrWhiteSpace(model.Phone3))
            {
                message = "حداقل یک شماره تماس باید وارد شود.";
                return false;
            }

            // اعتبارسنجی شماره تماس (باید عدد باشد و 11 رقم)
            if (!string.IsNullOrWhiteSpace(model.Phone1) && !IsValidPhoneNumber(model.Phone1))
            {
                message = "شماره تماس 1 معتبر نیست.  (باید 11 رقم باشد)";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(model.Phone2) && !IsValidPhoneNumber(model.Phone2))
            {
                message = "شماره تماس 2 معتبر نیست. (باید 11 رقم باشد)";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(model.Phone3) && !IsValidPhoneNumber(model.Phone3))
            {
                message = "شماره تماس 3 معتبر نیست. (باید 11 رقم باشد)";
                return false;
            }

            return true;
        }

        /// <summary>
        /// اعتبارسنجی برای Update
        /// </summary>
        private bool ValidateSellerForUpdate(SellerModel model, out string message)
        {
            message = string.Empty;

            if (model == null)
            {
                message = "اطلاعات فروشنده وارد نشده است.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(model.SellerID))
            {
                message = "شناسه فروشنده وارد نشده است.";
                return false;
            }

            // همان Validation های Insert
            return ValidateSellerForInsert(model, out message);
        }

        /// <summary>
        /// بررسی اعتبار شماره تماس
        /// </summary>
        private bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // حذف فاصله‌ها و خط تیره
            phone = phone.Replace(" ", "").Replace("-", "");

            // باید 11 رقم باشد و فقط عدد
            if (phone.Length != 11)
                return false;

            if (!long.TryParse(phone, out _))
                return false;

            // باید با 09 شروع شود
            if (!phone.StartsWith("09"))
                return false;

            return true;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// دریافت موجودی فروشنده
        /// </summary>
        public bool GetSellerBalance(string sellerID, out decimal balance, out string message)
        {
            balance = 0;
            message = string.Empty;

            if (!_sellerDAL.GetSellerByID(sellerID, out SellerModel seller, out message))
            {
                return false;
            }

            balance = seller.CurrentBalance;
            return true;
        }

        /// <summary>
        /// تعداد حساب‌های فروشنده
        /// </summary>
        public bool GetSellerAccountsCount(string sellerID, out int count, out string message)
        {
            count = 0;

            bool result = GetSellerAccounts(sellerID, out List<AccountModel> accounts, out message);

            if (result)
            {
                count = accounts.Count;
            }

            return result;
        }

        /// <summary>
        /// بررسی وجود فروشنده با شماره تماس
        /// </summary>
        public bool CheckSellerExistsByPhone(string phone, out bool exists, out string message)
        {
            exists = false;
            message = string.Empty;

            if (string.IsNullOrWhiteSpace(phone))
            {
                message = "شماره تماس وارد نشده است.";
                return false;
            }

            bool result = Search(phone, out List<SellerModel> sellers, out message);

            if (result)
            {
                exists = sellers.Count > 0;
            }

            return result;
        }

        #endregion

        #region Legacy Methods (برای سازگاری با کد قدیمی)

        /// <summary>
        /// ثبت فروشنده و حساب (متد قدیمی - برای سازگاری)
        /// </summary>
        [Obsolete("از InsertSeller و AddAccountToSeller به صورت جداگانه استفاده کنید.")]
        public bool InsertSellerAndAccount(
            SellerModel model,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string message)
        {
            message = string.Empty;

            // ثبت فروشنده
            bool result = InsertSeller(
                model,
                userID,
                date,
                dateValue,
                dateDig,
                out string newSellerID,
                out string newOWID,
                out message);

            if (!result)
            {
                return false;
            }

            // اگر حساب وارد شده باشد، ثبت حساب
            if (model.Accounts != null && model.Accounts.Count > 0)
            {
                foreach (var account in model.Accounts)
                {
                    AddAccountToSeller(
                        newSellerID,
                        account,
                        userID,
                        date,
                        dateValue,
                        dateDig,
                        out string newACID,
                        out string accMsg);
                }
            }

            return true;
        }

        /// <summary>
        /// ویرایش فروشنده و حساب (متد قدیمی - برای سازگاری)
        /// </summary>
        [Obsolete("از UpdateSeller و UpdateSellerAccount به صورت جداگانه استفاده کنید.")]
        public bool UpdateSellerAndAccount(
            SellerModel model,
            string userID,
            string date,
            DateTime dateValue,
            int dateDig,
            out string message)
        {
            return UpdateSeller(model, userID, date, dateValue, dateDig, out message);
        }

        #endregion
    }
}
