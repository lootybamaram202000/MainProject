using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Entities
{
    public class UnitModel
    {
        public string UnitID { get; set; }
        public string UnitType { get; set; }

        // REVERT to original (with typo) to match existing DB and SPs
        public string MeasurmentUnitTitle { get; set; }
        public int MesurmentUnitQuantity { get; set; }

        public string PunitTitle { get; set; }
        public int PunitQuantity { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        // Helper property for Persian display
        public string UnitTypeFa => UnitType == "Purchase" ? "خرید" : "تولید";
    }

}
