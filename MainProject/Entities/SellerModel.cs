using System;
using System.Collections.Generic;
using System.Linq;

namespace MainProject.Entities
{
    /// <summary>
    /// مدل فروشنده
    /// </summary>
    public class SellerModel
    {
        // شناسه
        public string SellerID { get; set; }

        // اطلاعات پایه
        public string SellerName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }

        // تماس
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }

        // دسته‌بندی
        public string SellerType { get; set; }
        public string SellerCategory1 { get; set; }
        public string SellerCategory2 { get; set; }
        public string SellerCategory3 { get; set; }

        // ارتباط با Owner
        public string OWID { get; set; }

        // وضعیت
        public bool isDeleted { get; set; }

        // Audit
        public string LastUpdate { get; set; }

        // ⚠️ ستون‌های قدیمی (بعداً حذف می‌شوند)
        public string ACID { get; set; }
        public decimal Balance { get; set; }
        public string Category { get; set; }

        // ✅ Navigation Property - داده‌ها به صورت Nested
        public AccountOwnerModel AccountOwner { get; set; }

        // ✅ Helper Properties
        public decimal CurrentBalance => AccountOwner?.Balance ?? Balance;

        public List<AccountModel> Accounts => AccountOwner?.Accounts ?? new List<AccountModel>();

        public AccountModel DefaultAccount => AccountOwner?.DefaultAccount;

        public int TotalAccounts => Accounts.Count;

        public string DisplayName
        {
            get
            {
                var name = SellerName ?? "";
                if (!string.IsNullOrWhiteSpace(CompanyName))
                    name += $" - {CompanyName}";
                return name;
            }
        }

        public string PhoneDisplay
        {
            get
            {
                var phones = new List<string>();
                if (!string.IsNullOrWhiteSpace(Phone1)) phones.Add(Phone1);
                if (!string.IsNullOrWhiteSpace(Phone2)) phones.Add(Phone2);
                if (!string.IsNullOrWhiteSpace(Phone3)) phones.Add(Phone3);
                return string.Join(" - ", phones);
            }
        }

        public string CategoryDisplay
        {
            get
            {
                var cats = new List<string>();
                if (!string.IsNullOrWhiteSpace(SellerCategory1)) cats.Add(SellerCategory1);
                if (!string.IsNullOrWhiteSpace(SellerCategory2)) cats.Add(SellerCategory2);
                if (!string.IsNullOrWhiteSpace(SellerCategory3)) cats.Add(SellerCategory3);
                return cats.Count > 0 ? string.Join(", ", cats) : "بدون دسته‌بندی";
            }
        }

        public string BalanceFormatted => CurrentBalance.ToString("N0") + " ریال";

        public string BalanceColor => CurrentBalance >= 0 ? "Green" : "Red";
    }
}
