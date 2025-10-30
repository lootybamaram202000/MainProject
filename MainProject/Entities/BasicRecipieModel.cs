using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Entities
{
    public class BasicRecipieModel
    {
        public int RowIndex { get; set; }           // شماره ردیف (۱ تا ۲۰)
        public string BIID { get; set; }            // کد آیتم آماده‌سازی
        public string PID { get; set; }             // کد کالای مصرفی
        public string PName { get; set; }           // نام کالای مصرفی (برای نمایش)
        public int Quantity { get; set; }           // مقدار مصرف کالا
        public decimal Cost { get; set; }           // هزینه = Quantity * PricePerUnit

        public ProductModel Product { get; set; }   // مدل کامل کالا برای نمایش در فرم
    }
}
