using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MainProject.Core;
using MainProject.Core.Business;
using MainProject.Entities;
using MainProject.Helpers;

namespace MainProject.Forms
{
    public partial class SubmitBasicRecipieFRM : Form
    {
        private readonly BasicItemManager _manager = new BasicItemManager();
        private List<BasicItemModel> allBasicItems = new List<BasicItemModel>();
        private List<ProductModel> allProducts = new List<ProductModel>();
        private BasicItemModel currentModel;
        public SubmitBasicRecipieFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            InitializeListViews();
            LoadBasicItems();
            LoadProducts();
        }
        private void NormalizeRecipieList()
        {
            if (currentModel?.Recipies == null) return;
            var valid = currentModel.Recipies.Where(x => x.Quantity > 0 && !string.IsNullOrWhiteSpace(x.PID)).ToList();
            currentModel.Recipies = new List<BasicRecipieModel>();
            for (int i = 0; i < valid.Count; i++)
            {
                valid[i].RowIndex = i + 1;
                currentModel.Recipies.Add(valid[i]);
            }
            for (int i = valid.Count; i < 20; i++)
            {
                currentModel.Recipies.Add(new BasicRecipieModel { RowIndex = i + 1 });
            }
        }
        private void LoadBasicItems()
        {
            allBasicItems = _manager.GetAll();
            lstBasicItem.Items.Clear();
            foreach (var item in allBasicItems)
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

        private void LoadProducts()
        {
            allProducts = new ProductManager().GetAllProducts();
            lstProduct.Items.Clear();
            foreach (var p in allProducts)
            {
                var li = new ListViewItem(p.ProductID);
                li.SubItems.Add(p.ProductName);
                li.SubItems.Add(p.PricePerUnit.ToString());
                li.SubItems.Add(p.Seller?.SellerName);
                li.SubItems.Add(p.Unit?.PunitTitle);
                lstProduct.Items.Add(li);
            }
        }

        private void InitializeListViews()

        {
            // lstBasicItem: فقط کد و نام آیتم
            lstBasicItem.View = View.Details;
            lstBasicItem.FullRowSelect = true;
            lstBasicItem.GridLines = true;
            lstBasicItem.Columns.Clear();
            lstBasicItem.Columns.Add("کد آیتم", 80);
            lstBasicItem.Columns.Add("نام آیتم", 260);
            // lstProduct: فقط کد و نام کالا
            lstProduct.View = View.Details;
            lstProduct.FullRowSelect = true;
            lstProduct.GridLines = true;
            lstProduct.Columns.Clear();
            lstProduct.Columns.Add("کد کالا", 70);
            lstProduct.Columns.Add("نام کالا", 190);
            // lstBIRecipie: فقط ۵ ستون مشخص‌شده
            lstBIRecipie.View = View.Details;
            lstBIRecipie.FullRowSelect = true;
            lstBIRecipie.GridLines = true;
            lstBIRecipie.Columns.Clear();
            lstBIRecipie.Columns.Add("ردیف", 50);
            lstBIRecipie.Columns.Add("نام کالا", 190);
            lstBIRecipie.Columns.Add("مقدار مصرف", 100, HorizontalAlignment.Center);
            lstBIRecipie.Columns.Add("واحد", 80);
            lstBIRecipie.Columns.Add("قیمت کل", 100, HorizontalAlignment.Center);
        }
        private void LoadRecipieList(List<BasicRecipieModel> recipies)
        {
            lstBIRecipie.Items.Clear();
            foreach (var r in recipies.Where(x => x.RowIndex > 0 && x.Quantity > 0))
            {
                var li = new ListViewItem(r.RowIndex.ToString());
                li.SubItems.Add(r.Product?.ProductName ?? r.PName ?? "-");
                li.SubItems.Add(r.Quantity.ToString("0"));
                li.SubItems.Add(r.Product?.Unit?.MeasurmentUnitTitle ?? "-");
                li.SubItems.Add(r.Cost.ToString("0"));
                lstBIRecipie.Items.Add(li);
            }
        }
        private void SubmitBasicRecipieFRM_Load(object sender, EventArgs e)
        {

        }

        private void btnNewBI_Click(object sender, EventArgs e)
        {
            var frm = new DefineBasicItemsFRM();
            frm.FormClosed += (s, args) => LoadBasicItems();
            frm.ShowDialog();

        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            var frmp = new SubmitProductFRM();
            frmp.FormClosed += (s, args) => LoadProducts();
            frmp.ShowDialog();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
           
            if (lstProduct.SelectedItems.Count == 0 || currentModel == null) return;
            var selectedProductID = lstProduct.SelectedItems[0].SubItems[0].Text;
            var product = allProducts.FirstOrDefault(p => p.ProductID == selectedProductID);
            if (product == null) return;

            string quantityText = CommonFunctions.ConvertPersianDigitsToEnglish(txtQuantity.Text.Trim());
            if (!int.TryParse(quantityText, out int quantity) || quantity <= 0) return;

            var nextEmpty = currentModel.Recipies.FirstOrDefault(r => r.RowIndex > 0 && (r.Product == null || r.Quantity == 0));
            if (nextEmpty == null)
            {
                MessageBox.Show("ظرفیت هر رسپی، ۲۰ سطر است و مجاز به اضافه کردن سطر جدید نیستید.", "خطا");
                return;
            }

            if (currentModel.Recipies == null || currentModel.Recipies.Count != 20)
            {
                currentModel.Recipies = new List<BasicRecipieModel>();
                for (int i = 0; i < 20; i++)
                    currentModel.Recipies.Add(new BasicRecipieModel { RowIndex = i });
            }

            var existing = currentModel.Recipies.FirstOrDefault(x => x.RowIndex > 0 && x.Product?.ProductID == selectedProductID);
            if (existing != null)
            {
                existing.Quantity += quantity;
                existing.Cost = existing.Quantity * (product.PricePerUnit ?? 0);
            }
            else
            {
                int emptyIndex = currentModel.Recipies.FindIndex(x => x.RowIndex > 0 && (x.Product == null || x.Quantity == 0));
                if (emptyIndex == -1) return;

                var target = currentModel.Recipies[emptyIndex];
                target.RowIndex = emptyIndex;
                target.Product = product;
                target.PName = product.ProductName;
                target.PID = product.ProductID;
                target.Quantity = quantity;
                target.Cost = quantity * (product.PricePerUnit ?? 0);
            }

            NormalizeRecipieList();
            LoadRecipieList(currentModel.Recipies);
            CommonFunctions.CalculateCosts(currentModel, txtWastage.Text, out decimal gross, out decimal final);
            txtBICost.Text = gross.ToString("0");
            txtBIFinalCost.Text = final.ToString("0");
            txtQuantity.Text = "0";
        }  

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (lstBIRecipie.SelectedItems.Count == 0 || currentModel == null) return;

            int rowIndex = int.Parse(lstBIRecipie.SelectedItems[0].SubItems[0].Text);
            if (rowIndex < 1 || rowIndex > 20) return;

            var recipe = currentModel.Recipies.FirstOrDefault(r => r.RowIndex == rowIndex);
            if (recipe == null || recipe.Product == null) return;

            string quantityText = CommonFunctions.ConvertPersianDigitsToEnglish(txtQuantity.Text.Trim());
            if (!int.TryParse(quantityText, out int newQty) || newQty <= 0) return;

            recipe.Quantity = newQty;
            recipe.Cost = newQty * (recipe.Product.PricePerUnit ?? 0);

            NormalizeRecipieList();
            LoadRecipieList(currentModel.Recipies);
            CommonFunctions.CalculateCosts(currentModel, txtWastage.Text, out decimal gross, out decimal final);
            txtBICost.Text = gross.ToString("0");
            txtBIFinalCost.Text = final.ToString("0");
            txtQuantity.Text = "0";
        }

        private void btnDeletProduct_Click(object sender, EventArgs e)
        {
            if (lstBIRecipie.SelectedItems.Count == 0 || currentModel == null) return;

            int rowIndex = int.Parse(lstBIRecipie.SelectedItems[0].SubItems[0].Text);
            if (rowIndex < 1 || rowIndex > 20) return;

            int index = currentModel.Recipies.FindIndex(r => r.RowIndex == rowIndex);
            if (index == -1) return;

            currentModel.Recipies[index] = new BasicRecipieModel { RowIndex = rowIndex };

            NormalizeRecipieList();
            LoadRecipieList(currentModel.Recipies);
            CommonFunctions.CalculateCosts(currentModel, txtWastage.Text, out decimal gross, out decimal final);
            txtBICost.Text = gross.ToString("0");
            txtBIFinalCost.Text = final.ToString("0");
            txtQuantity.Text = "0";
        }

        private void lstBasicItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBasicItem.SelectedItems.Count == 0) return;

            string selectedBIID = lstBasicItem.SelectedItems[0].SubItems[0].Text;

            var model = _manager.GetById(selectedBIID);
            if (model == null) return;

            model.Recipies = _manager.GetRecipiesByBIID(model.BIID);
            
            if (model.Recipies == null || model.Recipies.Count != 20)
            {
                model.Recipies = new List<BasicRecipieModel>();
                for (int i = 0; i < 20; i++)
                {
                    model.Recipies.Add(new BasicRecipieModel { RowIndex = i+1 });
                    
                }
            }
            // 🔧 رفع هشدار: مقداردهی currentModel
            currentModel = model;
            txtBICode.Text = model.BIID;
            txtBIName.Text = model.BIName;
            txtBIMUnit.Text = model.Unit?.MeasurmentUnitTitle;
            txtBIPUnit.Text = model.Unit?.PunitTitle;
            txtSection.Text = model.Section?.SecTitle;
            txtCategory.Text = model.Category;
            txtWastage.Text = model.Wastage.ToString();
            txtBICost.Text = model.ProductPrice.ToString("0");
            txtBIFinalCost.Text = model.PricePerUnit.ToString("0");
            LoadRecipieList(model.Recipies);
            CommonFunctions.CalculateCosts(model, txtWastage.Text, out decimal gross, out decimal final);
            txtBICost.Text = gross.ToString("0");
            txtBIFinalCost.Text = final.ToString("0");


            int index = allBasicItems.FindIndex(x => x.BIID == model.BIID);
            if (index != -1)
                allBasicItems[index] = model;
        }

        private void lstProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProduct.SelectedItems.Count == 0) return;
            var item = lstProduct.SelectedItems[0];
            txtSCode.Text = item.SubItems[0].Text;
            txtSName.Text = item.SubItems[1].Text;
            var selectedProduct = allProducts.FirstOrDefault(p => p.ProductID == txtSCode.Text);
            if (selectedProduct?.Unit != null)
            {
                lblUnit.Text = selectedProduct.Unit.MeasurmentUnitTitle;
            }
            else
            {
                lblUnit.Text = "-";
            }
            txtQuantity.Text = "0";
        }

        private void lstBIRecipie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBIRecipie.SelectedItems.Count == 0) return;
            var row = lstBIRecipie.SelectedItems[0];
            txtQuantity.Text = row.SubItems[2].Text;
            txtSName.Text = row.SubItems[1].Text;
            // میشه مقادیر بیشتر هم اینجا لود کرد در صورت نیاز
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchProduct.Text.Trim();
            allProducts = new ProductManager().SearchProducts(keyword);
            lstProduct.Items.Clear();

            foreach (var p in allProducts)
            {
                var li = new ListViewItem(p.ProductID);
                li.SubItems.Add(p.ProductName);
                lstProduct.Items.Add(li);
            }
        }

        private void txtSearchBasicItem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchBasicItem.Text.Trim();
            allBasicItems = new BasicItemManager().Search(keyword);
            lstBasicItem.Items.Clear();

            foreach (var item in allBasicItems)
            {
                var li = new ListViewItem(item.BIID);
                li.SubItems.Add(item.BIName);
                lstBasicItem.Items.Add(li);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtBICost_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmitBIRecipie_Click_1(object sender, EventArgs e)
        {
            if (currentModel == null || currentModel.Recipies == null) return;

            if (!currentModel.Recipies.Any(x => x.RowIndex > 0 && x.Quantity > 0 && x.Cost > 0))
            {
                MessageBox.Show("حداقل یک ردیف رسپی معتبر لازم است.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔧 اطمینان از عدد انگلیسی و مقداردهی به Wastage
            string cleanedWastage = CommonFunctions.ConvertPersianDigitsToEnglish(txtWastage.Text);
            currentModel.Wastage = Convert.ToInt32(cleanedWastage);

            CommonFunctions.CalculateCosts(currentModel, cleanedWastage, out decimal gross, out decimal final);
            /*
            bool updated = _manager.EditBasicItem(new BasicItemModel
            {
                BIID = currentModel.BIID,
                BIName = currentModel.BIName,
                Unit = currentModel.Unit,
                Section = currentModel.Section,
                ProductPrice = gross,
                PricePerUnit = final,
                Wastage = currentModel.Wastage,
                isActive = currentModel.isActive,
                LastUpdate = loginInfo.CurrentDatePersian,
                DATEDIG = loginInfo.CurrentDateNumeric,
                Recipies = currentModel.Recipies
            });
            */
            bool updated = _manager.SubmitRecipie(currentModel.BIID, currentModel.BIName, currentModel.Recipies);

            if (!updated)
            {
                MessageBox.Show("خطا در ثبت اطلاعات آیتم.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentModel.Recipies = _manager.GetRecipiesByBIID(currentModel.BIID);
            NormalizeRecipieList();
            LoadRecipieList(currentModel.Recipies);
            MessageBox.Show("رسپی با موفقیت ثبت شد.", "تأیید", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
