using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProject.Core.Business;
using MainProject.Entities;
using MainProject.Helpers;

namespace MainProject.Forms
{
    public partial class SubmitMenuRecipieFRM : Form
    {
        private ItemManager _itemManager = new ItemManager();
        private BasicItemManager _basicItemManager = new BasicItemManager();

        private List<ItemModel> allItems = new List<ItemModel>();
        private List<BasicItemModel> allBasicItems = new List<BasicItemModel>();

        private ItemModel currentModel = null;
        private BasicItemModel selectedBasicItem = null;

        public SubmitMenuRecipieFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
            this.Load += SubmitMenuRecipieFRM_Load;
        }

        private void ClearForm()
        {
            txtMenuItemCode.Text = "";
            txtMenuItemName.Text = "";
            txtCategory.Text = "";
            txtSection.Text = "";
            txtFinalPrice.Text = "";
            txtPreferedPrice.Text = "";
            txtBICode.Text = "";
            txtBIName.Text = "";
            txtBICost.Text = "";
            txtBIFinalCost.Text = "";
            txtQuantity.Text = "";
            lblUnit.Text = "واحد";

            lstMenuItemRecipie.Items.Clear();
            currentModel = null;
        }


        private void SubmitMenuRecipieFRM_Load(object sender, EventArgs e)
        {
            LoadItems();
            LoadBasicItems();
            InitializeMenuItemListView();
            InitializeBasicItemListView();
            InitializeRecipieListView();
            txtQuantity.Text = "";
            lblUnit.Text = "واحد";
        }

        private void InitializeMenuItemListView()
        {
            lstMenuItem.View = View.Details;
            lstMenuItem.FullRowSelect = true;
            lstMenuItem.GridLines = true;
            lstMenuItem.RightToLeftLayout = true;
            lstMenuItem.RightToLeft = RightToLeft.Yes;
            lstMenuItem.Columns.Clear();
            lstMenuItem.Columns.Add("ردیف", 50, HorizontalAlignment.Center);
            lstMenuItem.Columns.Add("کد آیتم", 100, HorizontalAlignment.Center);
            lstMenuItem.Columns.Add("نام آیتم", 270, HorizontalAlignment.Right);
        }

        private void InitializeBasicItemListView()
        {
            lstBasicItem.View = View.Details;
            lstBasicItem.FullRowSelect = true;
            lstBasicItem.GridLines = true;
            lstBasicItem.RightToLeftLayout = true;
            lstBasicItem.RightToLeft = RightToLeft.Yes;
            lstBasicItem.Columns.Clear();
            lstBasicItem.Columns.Add("ردیف", 50, HorizontalAlignment.Center);
            lstBasicItem.Columns.Add("کد آماده‌سازی", 100, HorizontalAlignment.Center);
            lstBasicItem.Columns.Add("نام آماده‌سازی", 160, HorizontalAlignment.Right);
        }

        private void InitializeRecipieListView()
        {
            lstMenuItemRecipie.View = View.Details;
            lstMenuItemRecipie.FullRowSelect = true;
            lstMenuItemRecipie.GridLines = true;
            lstMenuItemRecipie.RightToLeftLayout = true;
            lstMenuItemRecipie.RightToLeft = RightToLeft.Yes;
            lstMenuItemRecipie.Columns.Clear();
            lstMenuItemRecipie.Columns.Add("ردیف", 60, HorizontalAlignment.Center);
            lstMenuItemRecipie.Columns.Add("نام آیتم", 130, HorizontalAlignment.Right);
            lstMenuItemRecipie.Columns.Add("مقدار", 60, HorizontalAlignment.Center);
            lstMenuItemRecipie.Columns.Add("واحد اندازه‌گیری", 130, HorizontalAlignment.Right);
            lstMenuItemRecipie.Columns.Add("هزینه", 50, HorizontalAlignment.Center);
        }


        private void LoadItems()
        {
            allItems = _itemManager.GetAll();
            lstMenuItem.Items.Clear();
            int index = 1;
            foreach (var item in allItems)
            {
                var li = new ListViewItem(index.ToString());
                li.UseItemStyleForSubItems = false;
                li.Font = new Font("Tahoma", 10, FontStyle.Regular);

                var sub1 = new ListViewItem.ListViewSubItem(li, item.ItemID) { Font = new Font("Tahoma", 10) };
                var sub2 = new ListViewItem.ListViewSubItem(li, item.ItemName) { Font = new Font("B Nazanin", 10) };

                li.SubItems.Add(sub1);
                li.SubItems.Add(sub2);

                lstMenuItem.Items.Add(li);
                index++;
            }
        }

        private void LoadBasicItems()
        {
            allBasicItems = _basicItemManager.GetAll();
            lstBasicItem.Items.Clear();
            int index = 1;
            foreach (var bi in allBasicItems)
            {
                var li = new ListViewItem(index.ToString());
                li.UseItemStyleForSubItems = false;
                li.Font = new Font("Tahoma", 10, FontStyle.Regular);

                var sub1 = new ListViewItem.ListViewSubItem(li, bi.BIID) { Font = new Font("Tahoma", 10) };
                var sub2 = new ListViewItem.ListViewSubItem(li, bi.BIName) { Font = new Font("B Nazanin", 10) };

                li.SubItems.Add(sub1);
                li.SubItems.Add(sub2);

                lstBasicItem.Items.Add(li);
                index++;
            }
        }


        private void NormalizeRecipieList()
        {
            if (currentModel?.Recipies == null) return;
            var valid = currentModel.Recipies.Where(x => x.Quantity > 0).ToList();
            currentModel.Recipies = new List<ItemRecipieModel>();
            for (int i = 0; i < valid.Count; i++)
            {
                valid[i].RowIndex = i + 1;
                currentModel.Recipies.Add(valid[i]);
            }
            for (int i = valid.Count; i < 20; i++)
            {
                currentModel.Recipies.Add(new ItemRecipieModel { RowIndex = i + 1 });
            }
        }

        private void LoadRecipieList(List<ItemRecipieModel> recipies)
        {
            lstMenuItemRecipie.Items.Clear();
            foreach (var r in recipies.Where(x => x.Quantity > 0))
            {
                var li = new ListViewItem(r.RowIndex.ToString());
                li.UseItemStyleForSubItems = false;
                li.Font = new Font("Tahoma", 10, FontStyle.Regular);

                var nameSub = new ListViewItem.ListViewSubItem(li, r.BIName ?? "-");
                nameSub.Font = new Font("B Nazanin", 10, FontStyle.Regular);

                var quantitySub = new ListViewItem.ListViewSubItem(li, r.Quantity.ToString("0"));
                quantitySub.Font = new Font("Tahoma", 10, FontStyle.Regular);

                var unitSub = new ListViewItem.ListViewSubItem(li,
                    allBasicItems.FirstOrDefault(x => x.BIID == r.BIID)?.Unit?.MeasurmentUnitTitle ?? "-");
                unitSub.Font = new Font("B Nazanin", 10, FontStyle.Regular);

                var costSub = new ListViewItem.ListViewSubItem(li, r.Cost.ToString("0"));
                costSub.Font = new Font("Tahoma", 10, FontStyle.Regular);

                li.SubItems.Add(nameSub);
                li.SubItems.Add(quantitySub);
                li.SubItems.Add(unitSub);
                li.SubItems.Add(costSub);

                lstMenuItemRecipie.Items.Add(li);
            }
        }


        private void RefreshCosts()
        {
            if (currentModel == null || currentModel.Recipies == null) return;

            // جمع هزینه متریال
            decimal totalMaterialCost = currentModel.Recipies
                .Where(r => r.Quantity > 0)
                .Sum(r => r.Cost);

            // هزینه سربار از سکشن
            decimal overhead = currentModel.Section?.OverHead ?? 0;

            // جمع نهایی هزینه تولید
            decimal finalCost = totalMaterialCost + overhead;

            // قیمت پیشنهادی سیستم = 150% هزینه نهایی
            decimal suggestedPrice = finalCost + (finalCost / 2);

            // ست کردن در فرم
            txtBICost.Text = totalMaterialCost.ToString("0");
            txtBIFinalCost.Text = finalCost.ToString("0");
            txtPreferedPrice.Text = suggestedPrice.ToString("0");

            // اگر کاربر هنوز عددی برای قیمت نهایی تعیین نکرده
            if (!decimal.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtFinalPrice.Text.Trim()), out decimal userPrice) || userPrice <= 0)
            {
                txtFinalPrice.Text = txtPreferedPrice.Text;
            }
        }


        private void btnNewMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new DefineMenuItemsFRM();
            frm.FormClosed += (s, args) => LoadItems();
            frm.ShowDialog();
        }

        private void lstMenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMenuItem.SelectedItems.Count == 0)
            {
                currentModel = null;
                return;
            }

            var selectedID = lstMenuItem.SelectedItems[0].SubItems[1].Text; // ← اصلاح شد
            currentModel = allItems.FirstOrDefault(x => x.ItemID == selectedID);
            if (currentModel == null) return;

            currentModel.Recipies = _itemManager.GetRecipiesByItemID(currentModel.ItemID);

            txtMenuItemCode.Text = currentModel.ItemID;
            txtMenuItemName.Text = currentModel.ItemName;
            txtCategory.Text = currentModel.Category;
            txtSection.Text = currentModel.Section?.SecTitle;
            txtPreferedPrice.Text = currentModel.PreferredPrice.ToString("0");
            txtFinalPrice.Text = currentModel.SellPrice.ToString("0");

            NormalizeRecipieList();
            LoadRecipieList(currentModel.Recipies); // ← اضافه شد تا لیست بارگذاری شود
            RefreshCosts();
        }

        private void txtSearchMenuItem_TextChanged(object sender, EventArgs e)
        {
            allItems = _itemManager.Search(txtSearchMenuItem.Text);
            lstMenuItem.Items.Clear();
            int index = 1;

            foreach (var item in allItems)
            {
                var li = new ListViewItem(index.ToString());
                li.UseItemStyleForSubItems = false;
                li.Font = new Font("Tahoma", 10, FontStyle.Regular);

                var sub1 = new ListViewItem.ListViewSubItem(li, item.ItemID) { Font = new Font("Tahoma", 10) };
                var sub2 = new ListViewItem.ListViewSubItem(li, item.ItemName) { Font = new Font("B Nazanin", 10) };

                li.SubItems.Add(sub1);
                li.SubItems.Add(sub2);

                lstMenuItem.Items.Add(li);
                index++;
            }
        }

        private void txtSearchBasicItem_TextChanged(object sender, EventArgs e)
        {
            {
                allBasicItems = _basicItemManager.Search(txtSearchBasicItem.Text);
                lstBasicItem.Items.Clear();
                int index = 1;

                foreach (var bi in allBasicItems)
                {
                    var li = new ListViewItem(index.ToString());
                    li.UseItemStyleForSubItems = false;
                    li.Font = new Font("Tahoma", 10, FontStyle.Regular);

                    var sub1 = new ListViewItem.ListViewSubItem(li, bi.BIID) { Font = new Font("Tahoma", 10) };
                    var sub2 = new ListViewItem.ListViewSubItem(li, bi.BIName) { Font = new Font("B Nazanin", 10) };

                    li.SubItems.Add(sub1);
                    li.SubItems.Add(sub2);

                    lstBasicItem.Items.Add(li);
                    index++;
                }
            }
        }

        private void lstBasicItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBasicItem.SelectedItems.Count == 0)
            {
                selectedBasicItem = null;
                return;
            }

            var selectedID = lstBasicItem.SelectedItems[0].SubItems[1].Text;
            selectedBasicItem = allBasicItems.FirstOrDefault(x => x.BIID == selectedID);
            if (selectedBasicItem == null) return;

            txtBICode.Text = selectedBasicItem.BIID;
            txtBIName.Text = selectedBasicItem.BIName;
            lblUnit.Text = selectedBasicItem.Unit?.MeasurmentUnitTitle; // ✅ این خط اصلاح شد
            txtBICost.Text = selectedBasicItem.ProductPrice.ToString("0");
            txtBIFinalCost.Text = selectedBasicItem.PricePerUnit.ToString("0");
            txtQuantity.Text = "1";
        }



        private void btnAddBasicItem_Click(object sender, EventArgs e)
        {
            if (lstBasicItem.SelectedItems.Count == 0 || currentModel == null) return;

            var selectedID = lstBasicItem.SelectedItems[0].SubItems[1].Text;
            var bi = allBasicItems.FirstOrDefault(x => x.BIID == selectedID);
            if (bi == null) return;

            string qText = CommonFunctions.ConvertPersianDigitsToEnglish(txtQuantity.Text.Trim());
            if (!int.TryParse(qText, out int quantity) || quantity <= 0) return;

            if (currentModel.Recipies == null || currentModel.Recipies.Count != 20)
                NormalizeRecipieList(); // ← اطمینان از آماده بودن لیست

            var existing = currentModel.Recipies.FirstOrDefault(x => x.RowIndex > 0 && x.BIID == bi.BIID);
            if (existing != null)
            {
                existing.Quantity += quantity;
                existing.Cost = existing.Quantity * bi.PricePerUnit;
            }
            else
            {
                var nextEmpty = currentModel.Recipies.FirstOrDefault(r => r.RowIndex > 0 && string.IsNullOrEmpty(r.BIID));
                if (nextEmpty == null)
                {
                    MessageBox.Show("رسپی نمی‌تواند بیش از ۲۰ ردیف داشته باشد.");
                    return;
                }

                int emptyIndex = currentModel.Recipies.IndexOf(nextEmpty);
                currentModel.Recipies[emptyIndex] = new ItemRecipieModel
                {
                    RowIndex = emptyIndex + 1, // ← اصلاح شد
                    BIID = bi.BIID,
                    BIName = bi.BIName,
                    Quantity = quantity,
                    Cost = quantity * bi.PricePerUnit,
                    BasicItem = bi // ← اضافه شد
                };
            }

            NormalizeRecipieList();
            LoadRecipieList(currentModel.Recipies);
            RefreshCosts();
            txtQuantity.Text = "";
        }

        private void btnEditBasicItem_Click(object sender, EventArgs e)
        {
            if (lstMenuItemRecipie.SelectedItems.Count == 0 || currentModel == null) return;

            int index = int.Parse(lstMenuItemRecipie.SelectedItems[0].SubItems[0].Text);

            string qText = CommonFunctions.ConvertPersianDigitsToEnglish(txtQuantity.Text.Trim());
            if (!int.TryParse(qText, out int quantity) || quantity <= 0) return;

            var recipe = currentModel.Recipies.FirstOrDefault(x => x.RowIndex == index);
            if (recipe == null) return;

            var bi = allBasicItems.FirstOrDefault(x => x.BIID == recipe.BIID);
            if (bi == null) return;

            recipe.Quantity = quantity;
            recipe.Cost = quantity * bi.PricePerUnit;

            LoadRecipieList(currentModel.Recipies);
            RefreshCosts();
            txtQuantity.Text = "";
        }

        private void btnDeletBasicItem_Click(object sender, EventArgs e)
        {
            if (lstMenuItemRecipie.SelectedItems.Count == 0 || currentModel == null) return;

            int index = int.Parse(lstMenuItemRecipie.SelectedItems[0].SubItems[0].Text);

            var recipe = currentModel.Recipies.FirstOrDefault(x => x.RowIndex == index);
            if (recipe == null) return;

            recipe.BIID = null;
            recipe.BIName = null;
            recipe.Quantity = 0;
            recipe.Cost = 0;

            LoadRecipieList(currentModel.Recipies);
            RefreshCosts();
            txtQuantity.Text = "";
        }

        private void lstMenuItemRecipie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMenuItemRecipie.SelectedItems.Count == 0) return;

            int index = lstMenuItemRecipie.SelectedItems[0].Index;
            var r = currentModel.Recipies[index];
            if (r?.BasicItem == null) return;

            txtBICode.Text = r.BIID;
            txtBIName.Text = r.BIName;
            txtQuantity.Text = r.Quantity.ToString("0");
            lblUnit.Text = r.BasicItem.Unit?.MeasurmentUnitTitle;
            txtBICost.Text = r.BasicItem.ProductPrice.ToString("0");
            txtBIFinalCost.Text = r.BasicItem.PricePerUnit.ToString("0");
        }

        private void lstMenuItemRecipie_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lstMenuItemRecipie.SelectedItems.Count == 0 || currentModel == null) return;

            int index = lstMenuItemRecipie.SelectedItems[0].Index;
            var r = currentModel.Recipies[index];
            if (r == null) return;

            if (r.BasicItem == null)
                r.BasicItem = allBasicItems.FirstOrDefault(x => x.BIID == r.BIID); // ← اصلاح شد

            txtBICode.Text = r.BIID;
            txtBIName.Text = r.BIName;
            txtQuantity.Text = r.Quantity.ToString("0");
            lblUnit.Text = r.BasicItem?.Unit?.MeasurmentUnitTitle ?? "-";
            txtBICost.Text = r.BasicItem?.ProductPrice.ToString("0") ?? "0";
            txtBIFinalCost.Text = r.BasicItem?.PricePerUnit.ToString("0") ?? "0";
        }

        private void btnSubmitItemRecipie_Click(object sender, EventArgs e)
        {
            if (currentModel == null)
            {
                MessageBox.Show("❌ هیچ آیتمی انتخاب نشده است.");
                return;
            }

            NormalizeRecipieList();

            currentModel.Recipies = currentModel.Recipies
                .Where(x => !string.IsNullOrWhiteSpace(x.BIID) && x.Quantity > 0)
                .ToList();

            decimal? sellPrice = null;
            string priceText = CommonFunctions.ConvertPersianDigitsToEnglish(txtFinalPrice.Text.Trim());
            if (decimal.TryParse(priceText, out decimal priceVal) && priceVal > 0)
                sellPrice = priceVal;

            bool success = _itemManager.EditItem(currentModel, currentModel.Recipies, sellPrice);

            if (success)
            {
                MessageBox.Show("✅ رسپی آیتم با موفقیت ثبت شد.");
                LoadItems();
                ClearForm();
            }
            else
            {
                MessageBox.Show("❌ خطا در ثبت رسپی آیتم.");
            }
        }

        private void btnNewBasicItem_Click(object sender, EventArgs e)
        {
            var frm = new SubmitBasicRecipieFRM();
            frm.FormClosed += (s, args) => LoadBasicItems();
            frm.ShowDialog();
        }

        private void SubmitMenuRecipieFRM_Load_1(object sender, EventArgs e)
        {

        }
    }
}
