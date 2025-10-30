using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProject.Helpers;

namespace MainProject.Forms
{
    public partial class WareHouseManagementFRM : Form
    {
        public WareHouseManagementFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
        }
        private void LoadWareHousee()
        { 
        
        }

        private void btnEditWareHouse_Click(object sender, EventArgs e)
        {
            var EditEditWareHouseFRM = new EditWareHouseFRM();
            EditEditWareHouseFRM.ShowDialog();
            LoadWareHousee();
        }

        private void WareHouseManagementFRM_Load(object sender, EventArgs e)
        {

        }
    }
}
