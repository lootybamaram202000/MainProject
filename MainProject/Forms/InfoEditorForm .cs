using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProject.Core.Business;
using MainProject.Entities;
using MainProject.Helpers;

namespace MainProject.Forms
{
    public partial class InfoEditorForm : Form
    {
        private string _context = null;
        private readonly InformationsManager _manager = new InformationsManager();
        public InfoEditorForm(string context = null)
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
            _context = context;
            InitializeListView();
            LoadInfoList();

            if (!string.IsNullOrWhiteSpace(_context))
            {
                txtPersianTitle.Text = _context;
                txtPersianTitle.Enabled = false;
            }
        }

        private void InitializeListView()
        {
            lstInfo.View = View.Details;
            lstInfo.FullRowSelect = true;
            lstInfo.GridLines = true;
            lstInfo.Columns.Clear();

            lstInfo.Columns.Add("ردیف", 40, HorizontalAlignment.Center);
            lstInfo.Columns.Add("کانتکس", 170, HorizontalAlignment.Center);
            lstInfo.Columns.Add("عنوان فارسی", 160, HorizontalAlignment.Left);
            lstInfo.Columns.Add("مقدار انگلیسی", 160, HorizontalAlignment.Left);
            lstInfo.Columns.Add("مقدار فارسی", 190, HorizontalAlignment.Left);
            lstInfo.Columns.Add("مقدار عددی", 80, HorizontalAlignment.Center);
        }

        private void LoadInfoList()
        {

            lstInfo.Items.Clear();
            List<InformationDto> infoList;

            if (!string.IsNullOrWhiteSpace(_context))
                infoList = _manager.GetForComboBox(_context);
            else
            {
                infoList = new List<InformationDto>();
                foreach (var title in new[] {
                    "Banks", "ProductCategories", "ProductType", "VAT", "Tax", "CurentYear", "Months"
                })
                {
                    infoList.AddRange(_manager.GetForComboBox(title));
                }
            }

            int row = 1;
            foreach (var info in infoList)
            {
                var item = new ListViewItem(row.ToString());
                item.SubItems.Add(info.Context);
                item.SubItems.Add(info.PersianTitle);
                item.SubItems.Add(info.StringValueEng);
                item.SubItems.Add(info.StringValuePer);
                item.SubItems.Add(info.DigitalValue.ToString());
                item.Tag = info;
                lstInfo.Items.Add(item);
                row++;
            }
        }




        private void lstInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInfo.SelectedItems.Count == 0) return;

            var info = (InformationDto)lstInfo.SelectedItems[0].Tag;

            txtPersianTitle.Text = info.Context;
            txtPersianContext.Text = info.PersianTitle;
            txtPersianContext.Enabled = false;
            txtStringValueEng.Text = info.StringValueEng;
            txtStringValuePer.Text = info.StringValuePer;
            txtDigitalValue.Text = info.DigitalValue.ToString();
        }

        private void btnSubmitNewInfo_Click(object sender, EventArgs e)
        {
            var info = new InformationDto
            {
                Context = _context ?? txtPersianTitle.Text,
                PersianTitle = txtPersianContext.Text,
                StringValueEng = txtStringValueEng.Text,
                StringValuePer = txtStringValuePer.Text,
                DigitalValue = decimal.TryParse(txtDigitalValue.Text, out var val) ? val : 1
            };

            try
            {
                _manager.AddInformation(info);
                MessageBox.Show("اطلاعات ثبت شد.");
                LoadInfoList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در ثبت: " + ex.Message);
            }
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            if (lstInfo.SelectedItems.Count == 0) return;

            var selected = (InformationDto)lstInfo.SelectedItems[0].Tag;
            selected.StringValueEng = txtStringValueEng.Text;
            selected.StringValuePer = txtStringValuePer.Text;
            selected.DigitalValue = decimal.TryParse(txtDigitalValue.Text, out var val) ? val : 1;

            try
            {
                _manager.EditInformation(selected);
                MessageBox.Show("اطلاعات ویرایش شد.");
                LoadInfoList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در ویرایش: " + ex.Message);
            }
        }

        private void btnDeleteInfo_Click(object sender, EventArgs e)
        {
            if (lstInfo.SelectedItems.Count == 0) return;

            var selected = (InformationDto)lstInfo.SelectedItems[0].Tag;

            try
            {
                _manager.RemoveInformation(selected);
                MessageBox.Show("اطلاعات حذف شد.");
                LoadInfoList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در حذف: " + ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void InfoEditorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
