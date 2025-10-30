using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProject.Core;
using MainProject.Core.Business;
using MainProject.DataAccess;
using MainProject.Entities;
using MainProject.Helpers;

namespace MainProject.Forms
{
    public partial class DefineBasicItemsFRM : Form
    {
        private List<UnitModel> allProductUnits = new List<UnitModel>();
        private List<BasicRecipieModel> basicRec  = new List<BasicRecipieModel>();
        private readonly BasicItemManager _manager = new BasicItemManager();

        public DefineBasicItemsFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
            InitializeBasicItemListView();
            LoadSections();
            LoadUnits();
            LoadBasicItems();
            LoadCategories();

            cmbMU.SelectedIndexChanged += cmbMU_SelectedIndexChanged;

        }
        private void InitializeBasicItemListView()
        {
            lstBasicItem.View = View.Details;
            lstBasicItem.FullRowSelect = true;
            lstBasicItem.GridLines = true;
            lstBasicItem.Font = new Font("Tahoma", 8.25F);
            lstBasicItem.Columns.Clear();

            lstBasicItem.Columns.Add("کد آیتم", 70, HorizontalAlignment.Center);
            lstBasicItem.Columns.Add("نام آیتم", 170, HorizontalAlignment.Left);
            lstBasicItem.Columns.Add("هزینه تولید", 70, HorizontalAlignment.Center);
            lstBasicItem.Columns.Add("واحد پایه", 130, HorizontalAlignment.Center);
            lstBasicItem.Columns.Add("واحد توصیفی", 110, HorizontalAlignment.Center);
            lstBasicItem.Columns.Add("سکشن", 80, HorizontalAlignment.Center);
            lstBasicItem.Columns.Add("دسته‌بندی", 110, HorizontalAlignment.Center);
            lstBasicItem.Columns.Add("دورریز", 40, HorizontalAlignment.Center);
            lstBasicItem.Columns.Add("وضعیت", 60, HorizontalAlignment.Center);
        }

        private void LoadSections()
        {
            var dal = new SectionDAL();
            var list = dal.GetAllSections();

            cmbSections.DataSource = null;
            cmbSections.DataSource = list;
            cmbSections.DisplayMember = "SecTitle";
            cmbSections.ValueMember = "SecID";
            cmbSections.SelectedIndex = -1;
        }

        private void LoadUnits()
        {
            var dal = new UnitDAL();
            allProductUnits = dal.GetAllUnits()
                .Where(u => u.UnitType == "Product")
                .ToList();

            cmbMU.Items.Clear();
            cmbMU.DisplayMember = "MeasurmentUnitTitle";
            cmbMU.ValueMember = "UnitID";

            // فقط عناوین یکتا
            var uniqueBaseTitles = allProductUnits
                .Select(u => u.MeasurmentUnitTitle)
                .Distinct()
                .ToList();

            foreach (var title in uniqueBaseTitles)
                cmbMU.Items.Add(title);

            cmbMU.SelectedIndex = -1;
            cmbPU.Items.Clear();
        }

        private void LoadCategories()
        {
            var infoDal = new InformationDAL();
            var list = infoDal.GetValuesByContext("BasicItemCategories");

            cmbBICategories.Items.Clear();
            cmbBICategories.Items.AddRange(list.ToArray());
            cmbBICategories.SelectedIndex = -1;
        }

        private void ClearForm()
        {
            txtBasicItemCode.Text = string.Empty;
            txtBasicItemName.Text = string.Empty;
            cmbSections.SelectedIndex = -1;
            cmbMU.SelectedIndex = -1;
            cmbPU.SelectedIndex = -1;
            lstBasicItem.SelectedItems.Clear();
        }

        private void LoadBasicItems()
        {
            lstBasicItem.Items.Clear();
            var list = _manager.GetAll()
                .OrderBy(x => x.BIName)
                .ToList();

            foreach (var item in list)
            {
                var li = new ListViewItem(item.BIID);
                li.SubItems.Add(item.BIName);
                li.SubItems.Add(item.ProductPrice.ToString("0"));
                li.SubItems.Add(item.Unit?.MeasurmentUnitTitle);
                li.SubItems.Add(item.Unit?.PunitTitle);
                li.SubItems.Add(item.Section?.SecTitle);
                li.SubItems.Add(item.Category ?? "-");
                li.SubItems.Add(item.Wastage.ToString());
                li.SubItems.Add(item.isActive ? "فعال" : "غیرفعال");
                lstBasicItem.Items.Add(li);
            }
        }


        private void btnSubmitNewUnit_Click(object sender, EventArgs e)
        {
            var frm = new SubmitUnitFRM();
            frm.FormClosed += (s, args) => LoadUnits();
            frm.ShowDialog();
        }

        private void btnSubmitNewSection_Click(object sender, EventArgs e)
        {
            var frm = new DefineSectionsFRM();
            frm.FormClosed += (s, args) => LoadSections();
            frm.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstBasicItem.Items.Clear();
            var list = _manager.Search(txtSearch.Text)
                .OrderBy(x => x.BIName)
                .ToList();

            foreach (var item in list)
            {
                var li = new ListViewItem(item.BIID);
                li.SubItems.Add(item.BIName);
                li.SubItems.Add(item.ProductPrice.ToString("0"));
                li.SubItems.Add(item.Unit?.MeasurmentUnitTitle);
                li.SubItems.Add(item.Unit?.PunitTitle);
                li.SubItems.Add(item.Section?.SecTitle);
                li.SubItems.Add(item.Wastage.ToString());
                li.SubItems.Add(item.isActive ? "فعال" : "غیرفعال");
                lstBasicItem.Items.Add(li);
            }
        }

        private void cmbMU_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBaseTitle = cmbMU.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedBaseTitle)) return;

            cmbPU.Items.Clear();
            cmbPU.DisplayMember = "PunitTitle";
            cmbPU.ValueMember = "UnitID";

            var filteredUnits = allProductUnits
                .Where(u => u.MeasurmentUnitTitle == selectedBaseTitle)
                .ToList();

            foreach (var unit in filteredUnits)
                cmbPU.Items.Add(unit);

            cmbPU.SelectedIndex = -1;
        }




        private void btnSubmitNewBasicItem_Click_1(object sender, EventArgs e)
        {
            if (!CommonFunctions.ValidateBasicItemFormInputs(txtBasicItemName, cmbSections, cmbMU, cmbPU, out string msg))
            {
                MessageBox.Show(msg, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var unitID = CommonFunctions.FindUnitIDByTitles(allProductUnits, cmbMU.Text, cmbPU.Text);
            var unit = allProductUnits.FirstOrDefault(u => u.UnitID == unitID);

            if (unit == null)
            {
                MessageBox.Show("واحد انتخاب‌شده معتبر نیست.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var model = new BasicItemModel
            {
                BIName = txtBasicItemName.Text.Trim(),
                Section = cmbSections.SelectedItem as SectionModel,
                Unit = unit,
                ProductPrice = 0,
                PricePerUnit = 0,
                Category = cmbBICategories.Text.Trim(),
                Wastage = 0,
                isActive = true,
                LastUpdate = LoginInfo.Instance.PersianDate,
                DATEDIG = LoginInfo.Instance.DateDig
            };

            if (_manager.AddBasicItem(model, out string newID))
            {
                MessageBox.Show("آیتم ثبت شد.", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBasicItems();
                ClearForm();
            }
        }

        private void btnUpdateBasicItem_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBasicItemCode.Text)) return;

            if (!CommonFunctions.ValidateBasicItemFormInputs(txtBasicItemName, cmbSections, cmbMU, cmbPU, out string msg))
            {
                MessageBox.Show(msg, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var unitID = CommonFunctions.FindUnitIDByTitles(allProductUnits, cmbMU.Text, cmbPU.Text);
            var unit = allProductUnits.FirstOrDefault(u => u.UnitID == unitID);
            var section = cmbSections.SelectedItem as SectionModel;

            var model = new BasicItemModel
            {
                BIID = txtBasicItemCode.Text,
                BIName = txtBasicItemName.Text.Trim(),
                Section = section,
                Unit = unit,
                Category = cmbBICategories.Text.Trim(),
                ProductPrice = 0,
                PricePerUnit = 0,
                Wastage = 0,
                isActive = true,
                LastUpdate = LoginInfo.Instance.PersianDate,
                DATEDIG = LoginInfo.Instance.DateDig



            };


            model.Recipies = _manager.GetRecipiesByBIID(model.BIID);

            if (model.Recipies == null || model.Recipies.Count != 20)
            {
                model.Recipies = new List<BasicRecipieModel>();
                for (int i = 0; i < 20; i++)
                {
                    model.Recipies.Add(new BasicRecipieModel { RowIndex = i + 1 });

                }
            }

            if (_manager.EditBasicItem(model))
            {
                MessageBox.Show("آیتم ویرایش شد.", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBasicItems();
                ClearForm();
            }
        }

        private void btnDeletBasicItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBasicItemCode.Text)) return;

            var result = MessageBox.Show("آیا از حذف این آیتم مطمئن هستید؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            if (_manager.RemoveBasicItem(txtBasicItemCode.Text))
            {
                MessageBox.Show("آیتم حذف شد.", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBasicItems();
                ClearForm();
            }
        }

        private void lstBasicItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBasicItem.SelectedItems.Count == 0) return;

            var selected = lstBasicItem.SelectedItems[0];

            var model = _manager.GetById(selected.SubItems[0].Text);
            if (model == null) return;


            txtBasicItemCode.Text = selected.SubItems[0].Text;
            txtBasicItemName.Text = selected.SubItems[1].Text;
            cmbMU.Text = selected.SubItems[3].Text;
            cmbPU.Text = selected.SubItems[4].Text;
            cmbSections.Text = selected.SubItems[5].Text;
            cmbBICategories.Text = selected.SubItems[6].Text;

        }

        private void DefineBasicItemsFRM_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmitNewCategory_Click(object sender, EventArgs e)
        {
            InfoEditorForm frm = new InfoEditorForm("BasicItemCategories"); 
            frm.ShowDialog();
            LoadCategories();
        }

        private void cmbPU_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
