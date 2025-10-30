using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Entities
{
    public class ProductModel
    {
        public string ProductID { get; set; }                    // PID
        public string ProductName { get; set; }                  // Pname
        public UnitModel Unit { get; set; }                      // UnitID ← شی واحد
        public decimal? PurchasePriceUnit { get; set; }          // PurchasePriceUnit
        public decimal? PricePerUnit { get; set; }               // PricePerUnit
        public int? Wastage { get; set; }                        // Wastage
        public SectionModel Section { get; set; }                // SecID ← شی سکشن
        public string LastUpdate { get; set; }                   // LastUpdate (تاریخ یا توضیح)
        public int? CriticalInventory { get; set; }              // CriticalInventory
        public SellerModel Seller { get; set; }                  // SellerID ← شی فروشنده
        public string Type { get; set; }                         // Type (مثل: "ماده اولیه" یا "محصول نهایی")
        public string Category { get; set; }                     // Category
        public bool IsDeleted { get; set; }                      // isDeleted
        public bool IsActive { get; set; }                       // isActive
        public int DateDig { get; set; }                         // DATEDIG
        public bool IsDirectUse { get; set; } // ← در ProductModel.cs اضافه شود
    }
}
