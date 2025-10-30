using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Entities
{
    public class SubFactorModel
    {
        public string SFID { get; set; }
        public string FHID { get; set; }
        public string PID { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice => Quantity * PricePerUnit;
        public string LastUpdate { get; set; }
        public bool isDeleted { get; set; }

        // لاگین
        public string DATE { get; set; }
        public DateTime DATEVALUE { get; set; }
        public int DATEDIG { get; set; }
    }
}
