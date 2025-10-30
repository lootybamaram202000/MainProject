using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Entities
{
    public class OverHeadModel
    {
        public string OHID { get; set; }                       // کد یکتای سربار
        public string OHTitle { get; set; }                    // عنوان سربار
        public int FinancialYear { get; set; }                 // سال مالی
        public int? FinancialMounth { get; set; }              // ماه مالی (nullable فقط برای سربار متغیر)
        public decimal? YearlyCost { get; set; }               // هزینه سالیانه
        public decimal? MonthlyCost { get; set; }              // هزینه ماهیانه
        public string OHType { get; set; }                     // نوع سربار (ثابت یا متغیر)
        public string OHCategory { get; set; }                 // دسته‌بندی سربار
        public string LastUpdate { get; set; }                 // آخرین بروزرسانی
        public DateTime? DATEVALUE { get; set; }               // تاریخ میلادی
        public string DATE { get; set; }                       // تاریخ شمسی
        public int DATEDIG { get; set; }                       // تاریخ عددی شمسی
        public string Describtion { get; set; }                // توضیحات
        public bool isDeleted { get; set; }                    // حذف منطقی
    }
}
