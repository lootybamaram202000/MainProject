using System;

namespace MainProject.Entities
{
    /// <summary>
    /// مدل حساب بانکی - زیرمجموعه AccountOwner
    /// </summary>
    public class AccountModel
    {
        // شناسه
        public string ACID { get; set; }
        public string OWID { get; set; }
        public string PERID { get; set; }

        // اطلاعات Owner
        public string ACOwner { get; set; }

        // اطلاعات حساب
        public string ACBank { get; set; }
        public string ACNumber { get; set; }
        public string ACshabaNumber { get; set; }
        public string ACCardNumber { get; set; }
        public string ACType { get; set; }
        public string ACCategory { get; set; }

        // وضعیت
        public bool isActive { get; set; }
        public bool isPayer { get; set; }
        public bool isDeleted { get; set; }

        // Audit
        public string LastUpdate { get; set; }

        // Helper Property
        public bool isDefault { get; set; }

        // Display Helpers
        public string DisplayName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ACBank) && !string.IsNullOrWhiteSpace(ACNumber))
                    return $"{ACBank} - {ACNumber}";

                if (!string.IsNullOrWhiteSpace(ACBank))
                    return ACBank;

                return $"حساب {ACID}";
            }
        }

        public string ShabaFormatted
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ACshabaNumber) || ACshabaNumber.Length != 26)
                    return ACshabaNumber;

                // فرمت:  IR12-3456-7890-1234-5678-9012-34
                return $"IR{ACshabaNumber.Substring(2, 2)}-{ACshabaNumber.Substring(4, 4)}-" +
                       $"{ACshabaNumber.Substring(8, 4)}-{ACshabaNumber.Substring(12, 4)}-" +
                       $"{ACshabaNumber.Substring(16, 4)}-{ACshabaNumber.Substring(20, 4)}-" +
                       $"{ACshabaNumber.Substring(24, 2)}";
            }
        }

        public string CardFormatted
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ACCardNumber) || ACCardNumber.Length != 16)
                    return ACCardNumber;

                // فرمت: 6037-9912-3456-7890
                return $"{ACCardNumber.Substring(0, 4)}-{ACCardNumber.Substring(4, 4)}-" +
                       $"{ACCardNumber.Substring(8, 4)}-{ACCardNumber.Substring(12, 4)}";
            }
        }

        public string StatusDisplay => isActive ? "فعال" : "غیرفعال";

        public string DefaultBadge => isDefault ? "پیش‌فرض" : "";
    }
}
