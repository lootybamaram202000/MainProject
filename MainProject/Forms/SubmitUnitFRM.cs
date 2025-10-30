using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MainProject.Entities;
using MainProject.Core;
using MainProject.Helpers;
using System.Drawing;

namespace MainProject.Forms
{

    public partial class SubmitUnitFRM : Form
    {

        private readonly UnitManager _unitManager = new UnitManager();
        private string _selectedUnitID = null;
        private ToolTip unitToolTip;


        public SubmitUnitFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
            InitializeListViewUnits();
            InitializeToolTips();
            LoadUnits();

        }

        private void SubmitUnitFRM_Load(object sender, EventArgs e)
        {

        }
        private void InitializeToolTips()
        {
            unitToolTip = new ToolTip
            {
                AutoPopDelay = 15000,
                InitialDelay = 300,
                ReshowDelay = 200,
                ShowAlways = true,
                IsBalloon = true
            };

            unitToolTip.SetToolTip(pictureBoxInfo,
                "📘 راهنمای ثبت واحد:\n\n" +
                "مثال: ۱۰۰۰ گرم = ۱ کیلوگرم\n" +
                "عدد پایه = ۱۰۰۰ | عنوان پایه = گرم\n" +
                "عدد کاربردی = ۱ | عنوان کاربردی = کیلوگرم\n\n" +
                "این ساختار برای تبدیل و گزارش‌گیری صحیح الزامی‌ست."
            );

            // اگر خواستی بعداً برای کمبوها یا لیبل‌ها هم اضافه کن:
            // unitToolTip.SetToolTip(cmbMU, "واحد پایه را انتخاب کنید (مثلاً گرم)");
            // unitToolTip.SetToolTip(cmbPU, "واحد کاربردی را انتخاب کنید (مثلاً کیلوگرم)");
        }
        private void InitializeListViewUnits()
        {
            lstUnits.View = View.Details;
            lstUnits.FullRowSelect = true;
            lstUnits.GridLines = true;
            lstUnits.HideSelection = false;
            lstUnits.BackColor = Color.FromArgb(240, 255, 255);
            lstUnits.Font = new Font("Tahoma", 10F, FontStyle.Regular);
            lstUnits.Columns.Clear();

            // هدرها با فونت بزرگ‌تر و بولد باید از طریق خاصیت ListView امکان‌پذیر باشه
            // ولی چون ویندوز فرم خودش این اجازه رو نمیده، ما با فونت کل لیست کار می‌کنیم و به‌صورت بصری هماهنگ‌سازی انجام می‌دیم.

            lstUnits.Columns.Add("ردیف", 45, HorizontalAlignment.Center);
            lstUnits.Columns.Add("نوع واحد", 70,HorizontalAlignment.Center);
            lstUnits.Columns.Add("واحد پایه", 140, HorizontalAlignment.Right);
            lstUnits.Columns.Add("مقدار پایه", 70,HorizontalAlignment.Center);
            lstUnits.Columns.Add("واحد کاربردی", 140, HorizontalAlignment.Right);
            lstUnits.Columns.Add("مقدار کاربردی", 90,HorizontalAlignment.Center);
            lstUnits.Columns.Add("وضعیت",65,HorizontalAlignment.Center);
        }


        private void LoadUnits()
        {
            lstUnits.Items.Clear();
            var units = _unitManager.GetAllUnits()
                                    .Where(u => !u.IsDeleted)
                                    .ToList();

            int index = 1;
            foreach (var unit in units)
            {
                var item = new ListViewItem(index.ToString()); // ردیف
                item.SubItems.Add(unit.UnitType);
                item.SubItems.Add(unit.MeasurmentUnitTitle);
                item.SubItems.Add(unit.MesurmentUnitQuantity.ToString());
                item.SubItems.Add(unit.PunitTitle);
                item.SubItems.Add(unit.PunitQuantity.ToString());
                item.SubItems.Add(unit.IsActive ? "فعال" : "غیرفعال");
                item.Tag = unit;
                lstUnits.Items.Add(item);
                index++;
            }
        }


        private void LoadUnitsToList(string searchText = "")
        {
            lstUnits.Items.Clear();
            List<UnitModel> allUnits = _unitManager.GetAllUnits()
                                                   .Where(u => !u.IsDeleted)
                                                   .ToList();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                allUnits = allUnits.Where(u =>
                    u.UnitID.ToLower().Contains(searchText.ToLower()) ||
                    u.UnitType.ToLower().Contains(searchText.ToLower()) ||
                    u.MeasurmentUnitTitle.ToLower().Contains(searchText.ToLower()) ||
                    u.PunitTitle.ToLower().Contains(searchText.ToLower())
                ).ToList();
            }

            foreach (var unit in allUnits)
            {
                var item = new ListViewItem(unit.UnitID);
                item.SubItems.Add(unit.UnitType);
                item.SubItems.Add(unit.MeasurmentUnitTitle);
                item.SubItems.Add(unit.MesurmentUnitQuantity.ToString());
                item.SubItems.Add(unit.PunitTitle);
                item.SubItems.Add(unit.PunitQuantity.ToString());
                item.SubItems.Add(unit.IsActive ? "فعال" : "غیرفعال");
                item.Tag = unit;
                lstUnits.Items.Add(item);
            }
        }



        private void btnSubmitNewUnit_Click(object sender, EventArgs e)
        {
            if (!CommonFunctions.ValidateUnitFormInputs(txtMeasurmentUnitTitle, txtMeasurmentUnitQuantity,
                                                        txtPUnitTitle, txtPUnitQuantity, rdbPurchaseUnit, rdbProductUnit,
                                                        out string errorMessage, showWarningIfQtyMismatch: true))

            {
                MessageBox.Show(errorMessage);
                return;
            }

            string unitType = rdbPurchaseUnit.Checked ? "Purchase" : "Product";


            var unit = new UnitModel
            {

                UnitType = unitType,
                MeasurmentUnitTitle = txtMeasurmentUnitTitle.Text.Trim(),
                MesurmentUnitQuantity = Convert.ToInt32(CommonFunctions.ConvertPersianDigitsToEnglish(txtMeasurmentUnitQuantity.Text.Trim())),
                PunitTitle = txtPUnitTitle.Text.Trim(),
                PunitQuantity = Convert.ToInt32(CommonFunctions.ConvertPersianDigitsToEnglish(txtPUnitQuantity.Text.Trim())),
                IsActive = true,
                IsDeleted = false,

            };



            if (_unitManager.IsDuplicateUnit(unit.UnitType, unit.MeasurmentUnitTitle, unit.PunitTitle))
            {
                MessageBox.Show("واحدی با این ترکیب قبلاً ثبت شده است.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_unitManager.InsertUnit(unit, out string generatedCode))
            {
                MessageBox.Show("واحد جدید با موفقیت ثبت شد.", "ثبت موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUnits();
                CommonFunctions.ClearTextBoxes(this);
                _selectedUnitID = null;
            }
            else
            {
                MessageBox.Show("خطا در ثبت واحد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdateUnit_Click(object sender, EventArgs e)
        {
            if (_selectedUnitID == null)
                return;
            if (!CommonFunctions.ValidateUnitFormInputs(txtMeasurmentUnitTitle, txtMeasurmentUnitQuantity,
                                                        txtPUnitTitle, txtPUnitQuantity, rdbPurchaseUnit, rdbProductUnit,
                                                        out string errorMessage, showWarningIfQtyMismatch: true))

            {
                MessageBox.Show(errorMessage);
                return;
            }

            string unitType = rdbPurchaseUnit.Checked ? "Purchase" : "Product";

            var unit = new UnitModel
            {
                UnitID = _selectedUnitID,
                UnitType = unitType,
                MeasurmentUnitTitle = txtMeasurmentUnitTitle.Text.Trim(),
                MesurmentUnitQuantity = Convert.ToInt32(CommonFunctions.ConvertPersianDigitsToEnglish(txtMeasurmentUnitQuantity.Text.Trim())),
                PunitTitle = txtPUnitTitle.Text.Trim(),
                PunitQuantity = Convert.ToInt32(CommonFunctions.ConvertPersianDigitsToEnglish(txtPUnitQuantity.Text.Trim())),
                IsActive = true,

            };

            if (_unitManager.IsDuplicateUnit(unit.UnitType, unit.MeasurmentUnitTitle, unit.PunitTitle, unit.UnitID))
            {
                MessageBox.Show("واحدی با این ترکیب قبلاً ثبت شده است.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (_unitManager.UpdateUnit(unit))
            {
                MessageBox.Show("اطلاعات واحد با موفقیت به‌روزرسانی شد.");
                LoadUnits();
                CommonFunctions.ClearTextBoxes(this);
                _selectedUnitID = null;
            }
        }

        private void btnDeletUnit_Click(object sender, EventArgs e)
        {
            if (_selectedUnitID == null)
                return;

            if (_unitManager.DeleteUnit(_selectedUnitID))
            {
                MessageBox.Show("واحد حذف شد.");
                LoadUnits();
                CommonFunctions.ClearTextBoxes(this);
                _selectedUnitID = null;
            }
        }


        private void lstUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUnits.SelectedItems.Count == 0)
                return;

            var unit = lstUnits.SelectedItems[0].Tag as UnitModel;
            if (unit == null)
                return;

            _selectedUnitID = unit.UnitID;
            txtMeasurmentUnitTitle.Text = unit.MeasurmentUnitTitle;
            txtMeasurmentUnitQuantity.Text = unit.MesurmentUnitQuantity.ToString();
            txtPUnitTitle.Text = unit.PunitTitle;
            txtPUnitQuantity.Text = unit.PunitQuantity.ToString();
            rdbPurchaseUnit.Checked = unit.UnitType == "Purchase";
            rdbProductUnit.Checked = unit.UnitType == "Product";
        }


        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("مثال: \n 1000 Gram == 1 KiloGram  \n 20 Gram Grined Coffee == 1 Cup Espreeso(40gr)   ");
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            LoadUnitsToList(txtSearch.Text.Trim());
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
