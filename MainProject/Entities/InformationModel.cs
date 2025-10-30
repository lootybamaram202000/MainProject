using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Entities
{
    public class InformationModel
    {
        public int InfID { get; set; }              // کلید اصلی
        public string TableName { get; set; }       // فقط در DAL استفاده شود
        public string Category { get; set; }        // فقط در DAL استفاده شود
        public string Title { get; set; }           // به عنوان Context در لایه بالا
        public string PersianTitle { get; set; }
        public string StringValueEng { get; set; }
        public string StringValuePer { get; set; }
        public decimal DigitalValue { get; set; }
    }
}
