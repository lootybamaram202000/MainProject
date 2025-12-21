using System;
using System.Collections.Generic;
using System.Linq;

namespace MainProject.Entities
{
    /// <summary>
    /// مدل صاحب حساب - زیرمجموعه Seller/Employee/Customer
    /// </summary>
    public class AccountOwnerModel
    {
        // شناسه
        public string OWID { get; set; }

        // اطلاعات پایه
        public string ACOwner { get; set; }
        public string RefID { get; set; }
        public string OWType { get; set; }

        // مالی
        public decimal Balance { get; set; }
        public string DefaultACID { get; set; }

        // وضعیت
        public bool isPayer { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }

        // Audit
        public string LastUpdate { get; set; }

        // Navigation Property
        public List<AccountModel> Accounts { get; set; } = new List<AccountModel>();

        // Helper Properties
        public AccountModel DefaultAccount =>
            Accounts?.FirstOrDefault(a => a.ACID == DefaultACID);

        public int TotalAccounts => Accounts?.Count ?? 0;

        public int ActiveAccountsCount =>
            Accounts?.Count(a => !a.isDeleted) ?? 0;

        public string BalanceFormatted =>
            Balance.ToString("N0") + " ریال";

        public string DisplayName =>
            !string.IsNullOrWhiteSpace(ACOwner) ? ACOwner : $"صاحب حساب {OWID}";
    }
}
