using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProject.Business;
using MainProject.Core.Business;
using MainProject.Core;
using MainProject.Entities;
using MainProject.Helpers;
using MainProject.DataAccess;

namespace MainProject.Forms
{
    public partial class SubmitProductFRM : Form
    {
        private readonly ProductManager _productManager = new ProductManager();
        private readonly SectionManager _sectionManager = new SectionManager();
        private readonly SellerManager _sellerManager = new SellerManager();
        private readonly UnitManager _unitManager = new UnitManager();
        private readonly InformationDAL _infoDal = new InformationDAL();
        private string selectedProductID = "";

        private void LoadSections()
        {
            cmbSections.Items.Clear();
            var sections = _sectionManager.GetAllSections();
            cmbSections.DisplayMember = "SecTitle";
            cmbSections.ValueMember = "SecID";
            foreach (var sec in sections)
                cmbSections.Items.Add(sec);
        }

        private void LoadSellers()
        {
            cmbSeller.Items.Clear();
            var sellers = _sellerManager.GetAllSellers();
            cmbSeller.DisplayMember = "SellerName";
            cmbSeller.ValueMember = "SellerID";
            foreach (var sel in sellers)
                cmbSeller.Items.Add(sel);
        }

        private void LoadMeasurementUnits()
        {
            cmbMU.Items.Clear();
            cmbPU.Items.Clear();

            var units = _unitManager.GetAllUnits()
                .Where(u => u.UnitType == "Purchase")
                .ToList();

            var distinctUnits = units
                .GroupBy(u => u.MeasurmentUnitTitle)
                .Select(g => g.First())
                .ToList();

            cmbMU.DisplayMember = "MeasurmentUnitTitle";
            cmbMU.ValueMember = "UnitID";
            foreach (var unit in distinctUnits)
                cmbMU.Items.Add(unit);
        }

        private void LoadCategories()
        {
            cmbCategories.Items.Clear();
            var cats = _infoDal.GetValuesByContext("ProductCategories");
            cmbCategories.Items.AddRange(cats.ToArray());
        }

        private void LoadTypes()
        {
            cmbType.Items.Clear();
            var types = _infoDal.GetValuesByContext("ProductType");
            cmbType.Items.AddRange(types.ToArray());
            if (cmbType.Items.Count > 0)
                cmbType.SelectedIndex = 0;
        }

        private void LoadIsActive()
        {
            cmbIsActive.Items.Clear();
            cmbIsActive.Items.Add("فعال");
            cmbIsActive.Items.Add("غیرفعال");
            cmbIsActive.SelectedIndex = 0;
        }

        private void LoadComboBoxes()
        {
            LoadSections();
            LoadSellers();
            LoadMeasurementUnits();
            LoadCategories();
            LoadTypes();
            LoadIsActive();
        }

        public SubmitProductFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
            InitializeProductListView();
            LoadComboBoxes();
            LoadProducts();
        }

        private ProductModel GetProductModel()
        {
            return new ProductModel
            {
                ProductName = txtSName.Text.Trim(),
                Unit = (UnitModel)cmbPU.SelectedItem,
                PurchasePriceUnit = decimal.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtPrice.Text), out var buy) ? buy : 0,
                Wastage = int.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtWastage.Text), out var was) ? was : 0,
                Section = (SectionModel)cmbSections.SelectedItem,
                LastUpdate = LoginInfo.Instance.PersianDate,
                CriticalInventory = int.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtCriticalInventory.Text), out var crit) ? crit : 0,
                Seller = (SellerModel)cmbSeller.SelectedItem,
                Type = cmbType?.Text ?? "-",
                Category = cmbCategories?.Text ?? "-",
                IsActive = cmbIsActive?.SelectedIndex == 0,
                IsDeleted = false,
                DateDig = LoginInfo.Instance.DateDig,
                IsDirectUse = chkIsDirectUse.Checked,
            };
        }

        private void InitializeProductListView()
        {
            lstProduct.View = View.Details;
            lstProduct.FullRowSelect = true;
            lstProduct.GridLines = true;
            lstProduct.Font = new Font("Tahoma", 8.25F);
            lstProduct.Columns.Clear();

            lstProduct.Columns.Add("کد کالا", 130, HorizontalAlignment.Center);
            lstProduct.Columns.Add("نام کالا", 150, HorizontalAlignment.Left);
            lstProduct.Columns.Add("واحد خرید", 100, HorizontalAlignment.Center);
            lstProduct.Columns.Add("قیمت خرید", 100, HorizontalAlignment.Center);
            lstProduct.Columns.Add("قیمت مصرف", 100, HorizontalAlignment.Center);
            lstProduct.Columns.Add("نوع", 100, HorizontalAlignment.Center);
            lstProduct.Columns.Add("دسته‌بندی", 90, HorizontalAlignment.Left);
            lstProduct.Columns.Add("سکشن", 90, HorizontalAlignment.Left);
            lstProduct.Columns.Add("موجودی بحرانی", 100, HorizontalAlignment.Center);
        }




        private void LoadProducts()
        {
            lstProduct.Items.Clear();
            var list = _productManager.GetAllProducts();

            foreach (var p in list)
            {
                var item = new ListViewItem(p.ProductID); // ستون اول: کد کالا

                item.SubItems.Add(p.ProductName); // نام کالا
                item.SubItems.Add(p.Unit?.PunitTitle ?? "-"); // واحد خرید ← باید در UnitModel مقداردهی بشه
                item.SubItems.Add(p.PurchasePriceUnit?.ToString("N0") ?? "0"); // قیمت خرید
                item.SubItems.Add(p.PricePerUnit?.ToString("N0") ?? "0"); // قیمت مصرف (قبلاً محاسبه شده)
                item.SubItems.Add(p.Type ?? "-"); // نوع (مثلاً ماده اولیه، نظافت، ...)
                item.SubItems.Add(p.Category ?? "-"); // دسته‌بندی
                item.SubItems.Add(p.Section?.SecTitle ?? "-"); // سکشن
                item.SubItems.Add(p.CriticalInventory?.ToString() ?? "0"); // موجودی بحرانی

                lstProduct.Items.Add(item);
            }
        }

        private bool ValidateForm()
        {
            if (!CommonFunctions.IsTextBoxValid(txtSName))
            {
                MessageBox.Show("نام کالا وارد نشده است.");
                return false;
            }

            if (!CommonFunctions.IsComboBoxValid(cmbMU))
            {
                MessageBox.Show("واحد اندازه‌گیری انتخاب نشده است.");
                return false;
            }

            if (!CommonFunctions.IsComboBoxValid(cmbPU))
            {
                MessageBox.Show("واحد خرید انتخاب نشده است.");
                return false;
            }

            if (!CommonFunctions.IsComboBoxValid(cmbSections))
            {
                MessageBox.Show("سکشن انتخاب نشده است.");
                return false;
            }

            if (!CommonFunctions.IsComboBoxValid(cmbSeller))
            {
                MessageBox.Show("فروشنده انتخاب نشده است.");
                return false;
            }

            // 🔍 بررسی عددی بودن قیمت
            if (!decimal.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtPrice.Text.Trim()), out var _))
            {
                MessageBox.Show("قیمت خرید باید یک عدد معتبر باشد.");
                return false;
            }

            if (!int.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtWastage.Text.Trim()), out var _) || txtWastage.Text.Trim().Contains("-"))
            {
                MessageBox.Show("مقدار پرت باید یک عدد صحیح غیر منفی باشد.");
                return false;
            }

            if (!int.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtCriticalInventory.Text.Trim()), out var _) || txtCriticalInventory.Text.Trim().Contains("-"))
            {
                MessageBox.Show("مقدار موجودی بحرانی باید یک عدد صحیح غیر منفی باشد.");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtSCode.Clear();
            txtSName.Clear();
            txtPrice.Clear();
            txtWastage.Clear();
            txtCriticalInventory.Clear();
            cmbCategories.SelectedIndex = -1;
            cmbMU.SelectedIndex = -1;
            cmbPU.SelectedIndex = -1;
            cmbSeller.SelectedIndex = -1;
            cmbSections.SelectedIndex = -1;
            cmbType.SelectedIndex = -1;
            cmbIsActive.SelectedIndex = 0;
            selectedProductID = "";
        }
        private void btnSubmitNewUnit_Click(object sender, EventArgs e)
        {
            var frm = new SubmitUnitFRM();
            frm.ShowDialog();
            LoadMeasurementUnits();
        }

        private void btnSubmitNewSection_Click(object sender, EventArgs e)
        {
            var frm = new DefineSectionsFRM();
            frm.ShowDialog();
            LoadSections();
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
          InfoEditorForm frm = new InfoEditorForm("ProductCategories");
            frm.ShowDialog();
            LoadCategories();
        }

        private void SubmitProductFRM_Load(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSubmitNewSeller_Click(object sender, EventArgs e)
        {
            var frm = new SubmitSellerFRM();
            frm.ShowDialog();
            LoadSellers();
        }

        private void cmbMU_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPU.Items.Clear();
            cmbPU.DisplayMember = "PunitTitle";
            cmbPU.ValueMember = "UnitID";

            var selectedUnit = cmbMU.SelectedItem as UnitModel;
            if (selectedUnit == null) return;

            foreach (var u in _unitManager.GetAllUnits())
            {
                if (u.MeasurmentUnitTitle == selectedUnit.MeasurmentUnitTitle)
                    cmbPU.Items.Add(u);
            }
        }

        private void btnSubmitNewProduct_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var model = GetProductModel();
            var userID = LoginInfo.Instance.UserID;
            var persianDate = LoginInfo.Instance.PersianDate;
            var dateValue = LoginInfo.Instance.DateValue;
            var dateDig = LoginInfo.Instance.DateDig;

            if (_productManager.InsertProduct(model, userID, persianDate, dateValue, dateDig, out string newID))
            {
                MessageBox.Show("کالا با موفقیت ثبت شد.");
                ClearForm();
                LoadProducts();
            }
            else
            {
                MessageBox.Show("ثبت کالا انجام نشد.");
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedProductID)) return;
            if (!ValidateForm()) return;

            var model = GetProductModel();
            model.ProductID = selectedProductID;
            if (_productManager.UpdateProduct(model))
            {
                MessageBox.Show("ویرایش با موفقیت انجام شد.");
                ClearForm();
                LoadProducts();
            }
        }

        private void btnDeletProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedProductID)) return;

            if (_productManager.DeleteProduct(selectedProductID))
            {
                MessageBox.Show("کالا حذف شد.");
                ClearForm();
                LoadProducts();
            }
        }

        private void lstProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProduct.SelectedItems.Count > 0)
                selectedProductID = lstProduct.SelectedItems[0].Text;
        }

        private void lstProduct_Click(object sender, EventArgs e)
        {

            if (lstProduct.SelectedItems.Count == 0) return;

            selectedProductID = lstProduct.SelectedItems[0].Text;

            var model = _productManager.GetAllProducts().Find(p => p.ProductID == selectedProductID);
            if (model == null) return;

            txtSCode.Text = model.ProductID;
            txtSName.Text = model.ProductName;
            txtPrice.Text = Convert.ToDecimal(model.PurchasePriceUnit ?? 0).ToString("N0");
            txtWastage.Text = model.Wastage?.ToString();
            txtCriticalInventory.Text = model.CriticalInventory?.ToString();
            chkIsDirectUse.Checked = model.IsDirectUse;

            if (model.Unit != null)
            {
                // اگه واحد موردنظر در cmbMU نیست، اضافه کن
                if (!cmbMU.Items.OfType<UnitModel>().Any(u => u.UnitID == model.Unit.UnitID))
                    cmbMU.Items.Add(model.Unit);

                cmbMU.SelectedItem = cmbMU.Items
                    .OfType<UnitModel>()
                    .FirstOrDefault(u => u.UnitID == model.Unit.UnitID);

                // cmbPU فقط همون واحد خاص رو نشون بده
                cmbPU.Items.Clear();
                cmbPU.Items.Add(model.Unit);
                cmbPU.SelectedItem = model.Unit;
            }

            cmbSections.SelectedItem = cmbSections.Items
                .OfType<SectionModel>()
                .FirstOrDefault(s => s.SecID == model.Section?.SecID);

            cmbSeller.SelectedItem = cmbSeller.Items
                .OfType<SellerModel>()
                .FirstOrDefault(s => s.SellerID == model.Seller?.SellerID);

            cmbCategories.SelectedItem = model.Category;
            cmbType.SelectedItem = model.Type;
            cmbIsActive.SelectedIndex = model.IsActive ? 0 : 1;
        }

        private void cmbPU_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var list = _productManager.SearchProducts(keyword);

            lstProduct.Items.Clear();

            foreach (var p in list)
            {
                var item = new ListViewItem(p.ProductID); // ستون اول: کد کالا

                item.SubItems.Add(p.ProductName); // نام کالا
                item.SubItems.Add(p.Unit?.PunitTitle ?? "-"); // واحد خرید
                item.SubItems.Add(p.PurchasePriceUnit?.ToString("N0") ?? "0"); // قیمت خرید
                item.SubItems.Add(p.PricePerUnit?.ToString("N0") ?? "0"); // قیمت مصرف
                item.SubItems.Add(p.Type ?? "-"); // نوع
                item.SubItems.Add(p.Category ?? "-"); // دسته‌بندی
                item.SubItems.Add(p.Section?.SecTitle ?? "-"); // سکشن
                item.SubItems.Add(p.CriticalInventory?.ToString() ?? "0"); // موجودی بحرانی

                lstProduct.Items.Add(item);
            }
        }

        private void btnSubmitNewType_Click(object sender, EventArgs e)
        {
            InfoEditorForm form = new InfoEditorForm("ProductType");
            form.ShowDialog();
            LoadTypes();
        }
    }
}
