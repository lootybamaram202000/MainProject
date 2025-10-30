using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Entities
{
    public class InformationDto
    {
        public int InfID { get; set; }                  // ← افزوده شد
        public string Context { get; set; }
        public string PersianTitle { get; set; }
        public string StringValueEng { get; set; }
        public string StringValuePer { get; set; }
        public decimal DigitalValue { get; set; }
    }

}
