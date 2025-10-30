using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Entities
{
    public class ItemRecipieModel
    {
        public int RowIndex { get; set; }
        public string ItemID { get; set; }
        public string BIID { get; set; }
        public string BIName { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public BasicItemModel BasicItem { get; set; }
    }
}
