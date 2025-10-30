
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Entities
{
    public class ItemModel
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; } = "عمومی";
        public SectionModel Section { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal CostAndOH { get; set; }
        public decimal PreferredPrice { get; set; }
        public decimal SellPrice { get; set; }
        public string LastUpdate { get; set; }
        public bool isDeleted { get; set; }
        public bool isActive { get; set; }
        public int DATEDIG { get; set; }

        public List<ItemRecipieModel> Recipies { get; set; } = new List<ItemRecipieModel>();
    }
}
