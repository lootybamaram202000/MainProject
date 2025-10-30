using System;

namespace MainProject.Entities
{
    /// <summary>
    /// مدل حساب بانکی
    /// </summary>
    public class AccountModel
    {
        public string ACID { get; set; }
        public string PERID { get; set; }                 // شناسه مالک (SellerID/...)
        public string ACOwner { get; set; }               // ترکیب نام/شرکت
        public string ACshabaNumber { get; set; }
        public string ACCardNumber { get; set; }
        public string ACNumber { get; set; }
        public string ACBank { get; set; }
        public string ACType { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public bool isPayer { get; set; }

    }
}
