using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Entities
{
    public class BasicItemModel
    {
        public string BIID { get; set; }
        public string BIName { get; set; }

        public SectionModel Section { get; set; }
        public UnitModel Unit { get; set; }

        public decimal ProductPrice { get; set; } = 0; // هزینه تولید نهایی آیتم
        public decimal PricePerUnit { get; set; } = 0;
        public string Category { get; set; }
        public int Wastage { get; set; } = 0;

        public bool isActive { get; set; } = true;

        public string LastUpdate { get; set; }
        public int DATEDIG { get; set; }

        public List<BasicRecipieModel> Recipies { get; set; } = new List<BasicRecipieModel>();
    }
}
