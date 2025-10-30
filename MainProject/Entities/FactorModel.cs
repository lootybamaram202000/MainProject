using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Entities
{
    public class FactorModel
    {
        public string FHID { get; set; }
        public string SellerID { get; set; }
        public string FHSellerID { get; set; }
        public string TypeOfPayment { get; set; }
        public string PaymentStatuse { get; set; }
        public string AccountOfPayment { get; set; }
        public string DateOfPayment { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal VAT { get; set; }
        public decimal Shipping { get; set; }
        public decimal FinalTotalPaid { get; set; }
        public string Describtion { get; set; }
        public string LastUpdate { get; set; }
        public byte[] Picture { get; set; }
        public bool isDeleted { get; set; }

        // لاگین
        public string UserID { get; set; }
        public string DATE { get; set; }
        public DateTime DATEVALUE { get; set; }
        public int DATEDIG { get; set; }
    }
}
