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
    public partial class DefineMenuItemsFRM : Form
    {
        private ItemModel currentItemModel = null;
        private readonly ItemManager _manager = new ItemManager();
        private List<SectionModel> _sections = new List<SectionModel>();
        private List<string> _categories = new List<string>();
        public DefineMenuItemsFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
            InitializeMenuItemListView();
            LoadSections();
            LoadCategories();
            LoadItems();
        }
        private void InitializeMenuItemListView()
        {
            lstMenuItem.View = View.Details;
            lstMenuItem.FullRowSelect = true;
            lstMenuItem.GridLines = true;
            lstMenuItem.Font = new Font("Tahoma", 8.25F);
            lstMenuItem.Columns.Clear();

            lstMenuItem.Columns.Add("کد آیتم", 100, HorizontalAlignment.Center);
            lstMenuItem.Columns.Add("نام آیتم", 150, HorizontalAlignment.Left);
            lstMenuItem.Columns.Add("دسته‌بندی", 100, HorizontalAlignment.Center);
            lstMenuItem.Columns.Add("سکشن", 120, HorizontalAlignment.Center);
            lstMenuItem.Columns.Add("قیمت نهایی", 100, HorizontalAlignment.Center);
            lstMenuItem.Columns.Add("قیمت پیشنهادی", 100, HorizontalAlignment.Center);
            lstMenuItem.Columns.Add("وضعیت", 80, HorizontalAlignment.Center);
        }

        private void LoadSections()
        {
            var dal = new SectionDAL();
            _sections = dal.GetAllSections();
            cmbSections.DataSource = null;
            cmbSections.DataSource = _sections;
            cmbSections.DisplayMember = "SecTitle";
            cmbSections.ValueMember = "SecID";
            cmbSections.SelectedIndex = -1;
        }

        private void LoadCategories()
        {
            var dal = new InformationDAL();
            _categories = dal.GetValuesByContext("ItemCategories");
            cmbItemCategory.DataSource = null;
            cmbItemCategory.DataSource = _categories;
            cmbItemCategory.SelectedIndex = -1;
        }

        private void LoadItems()
        {
            lstMenuItem.Items.Clear();
            var list = _manager.GetAll().OrderBy(x => x.ItemName).ToList();

            foreach (var item in list)
            {
                var li = new ListViewItem(item.ItemID);
                li.SubItems.Add(item.ItemName);
                li.SubItems.Add(item.Category);
                li.SubItems.Add(item.Section?.SecTitle);
                li.SubItems.Add(item.SellPrice.ToString("0"));
                li.SubItems.Add(item.PreferredPrice.ToString("0"));
                li.SubItems.Add(item.isActive ? "فعال" : "غیرفعال");
                lstMenuItem.Items.Add(li);
            }
        }

        private void ClearForm()
        {
            txtMenuItemCode.Text = string.Empty;
            txtMenuItemName.Text = string.Empty;
            cmbItemCategory.SelectedIndex = -1;
            cmbSections.SelectedIndex = -1;
            lstMenuItem.SelectedItems.Clear();
        }

        private void DefineMenuItemsFRM_Load(object sender, EventArgs e)
        {

        }

        private void txtSearchMenuItem_TextChanged(object sender, EventArgs e)
        {
            lstMenuItem.Items.Clear();
            var list = _manager.Search(txtSearchMenuItem.Text).OrderBy(x => x.ItemName).ToList();

            foreach (var item in list)
            {
                var li = new ListViewItem(item.ItemID);
                li.SubItems.Add(item.ItemName);
                li.SubItems.Add(item.Category);
                li.SubItems.Add(item.Section?.SecTitle);
                li.SubItems.Add(item.SellPrice.ToString("0"));
                li.SubItems.Add(item.PreferredPrice.ToString("0"));
                li.SubItems.Add(item.isActive ? "فعال" : "غیرفعال");
                lstMenuItem.Items.Add(li);
            }
        }

        private void btnSubmitNewSection_Click(object sender, EventArgs e)
        {
            var frm = new DefineSectionsFRM();
            frm.FormClosed += (s, args) => LoadSections();
            frm.ShowDialog();
        }

        private void btnDefineNewCategory_Click(object sender, EventArgs e)
        {
            InfoEditorForm frm = new InfoEditorForm("ItemCategories");
            frm.ShowDialog();
            LoadCategories();
        }

        private void btnSubmitNewMenuItem_Click(object sender, EventArgs e)
        {
            if (!CommonFunctions.ValidateMenuItemFormInputs(txtMenuItemName, cmbSections, cmbItemCategory, out string msg))
            {
                MessageBox.Show(msg, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var model = new ItemModel
            {
                ItemName = txtMenuItemName.Text.Trim(),
                Section = cmbSections.SelectedItem as SectionModel,
                Category = cmbItemCategory.Text,
                isActive = true,
                LastUpdate = LoginInfo.Instance.PersianDate,
                DATEDIG = LoginInfo.Instance.DateDig,
                SellPrice = 0  // اگر مقدار پیش‌فرض یا قابل تنظیمی نیاز است
            };

            if (_manager.AddItem(model, out string newID))
            {
                txtMenuItemCode.Text = newID; // نمایش کد جدید در فرم
                MessageBox.Show("آیتم با کد " + newID + " ثبت شد.", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadItems();
                ClearForm();
            }
            else
            {
                MessageBox.Show("ثبت آیتم با خطا مواجه شد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMenuItemCode.Text)) return;

            if (!CommonFunctions.ValidateMenuItemFormInputs(txtMenuItemName, cmbSections, cmbItemCategory, out string msg))
            {
                MessageBox.Show(msg, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // به‌روزرسانی فقط روی currentItemModel انجام می‌گیره
            currentItemModel.ItemName = txtMenuItemName.Text.Trim();
            currentItemModel.Section = cmbSections.SelectedItem as SectionModel;
            currentItemModel.Category = cmbItemCategory.Text;
            currentItemModel.LastUpdate = LoginInfo.Instance.PersianDate;
            currentItemModel.DATEDIG = LoginInfo.Instance.DateDig;
            currentItemModel.isActive = true;

            if (_manager.EditItem(currentItemModel, currentItemModel.Recipies, null))
            {
                MessageBox.Show("آیتم ویرایش شد.", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadItems();
                ClearForm();
            }
            else
            {
                MessageBox.Show("خطا در ویرایش آیتم", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMenuItemCode.Text)) return;

            var result = MessageBox.Show("آیا از حذف این آیتم مطمئن هستید؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            if (_manager.RemoveItem(txtMenuItemCode.Text))
            {
                MessageBox.Show("آیتم حذف شد.", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadItems();
                ClearForm();
            }
        }

        private void lstMenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMenuItem.SelectedItems.Count == 0)
            {
                currentItemModel = null;
                return;
            }

            var selected = lstMenuItem.SelectedItems[0];
            string selectedItemID = selected.SubItems[0].Text;

            currentItemModel = _manager.GetAll().FirstOrDefault(x => x.ItemID == selectedItemID);
            if (currentItemModel == null) return;

            // ✅ بارگذاری رسپی از دیتابیس (دقیقاً مثل فاز بیسیک)
            currentItemModel.Recipies = _manager.GetRecipiesByItemID(currentItemModel.ItemID);

            txtMenuItemCode.Text = currentItemModel.ItemID;
            txtMenuItemName.Text = currentItemModel.ItemName;
            cmbItemCategory.Text = currentItemModel.Category;
            cmbSections.SelectedValue = currentItemModel.Section?.SecID;
        }
    }
}
