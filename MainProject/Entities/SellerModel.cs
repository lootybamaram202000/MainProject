using System;

namespace MainProject.Entities
{
    /// <summary>
    /// مدل فروشنده
    /// </summary>

    public class SellerModel
    {
        public string SellerID { get; set; }
        public string SellerName { get; set; }
        public string CompanyName { get; set; }
        public string Addtress { get; set; }   // مطابق نام ستون جدول
        public string Phone { get; set; }
        public string Category { get; set; }   // از tblINFORMATIONS لود می‌شود
        public string ACID { get; set; }       // فعلاً فقط نمایش/نگهداری
        public decimal Balance { get; set; }   // نمایشی
        public AccountModel Account { get; set; }
    }

}
