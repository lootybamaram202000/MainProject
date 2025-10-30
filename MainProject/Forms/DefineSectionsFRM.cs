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
using MainProject.Entities;
using MainProject.Helpers;

namespace MainProject.Forms
{

    public partial class DefineSectionsFRM : Form
    {

        private readonly SectionManager _sectionManager = new SectionManager();
        private string _selectedSectionID = null;
        public DefineSectionsFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
        }

        private void DefineSectionsFRM_Load(object sender, EventArgs e)
        {
            lstSection.View = View.Details;
            lstSection.FullRowSelect = true;
            lstSection.GridLines = true;
            lstSection.Columns.Clear();
            lstSection.Columns.Add("کد سکشن", 100);
            lstSection.Columns.Add("عنوان", 200);
            lstSection.Columns.Add("درصد", 80);
            lstSection.Columns.Add("تعداد فروش", 100);
            LoadSections();

        }

        private void LoadSections()
        {
            lstSection.Items.Clear();
            var sections = _sectionManager.GetAllSections();
            foreach (var section in sections)
            {
                var item = new ListViewItem(section.SecID);
                item.SubItems.Add(section.SecTitle);
                item.SubItems.Add(section.PerCentage.ToString());
                item.SubItems.Add(section.CountOfSell.ToString());
                item.Tag = section;
                lstSection.Items.Add(item);
            }
            lstSection.SelectedItems.Clear();
            _selectedSectionID = null;
            ClearForm();
        }

        private void ClearForm()
        {
            CommonFunctions.ClearTextBoxes(this);
            _selectedSectionID = null;
        }

        private bool ValidateInputs(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(txtSectionName.Text))
            {
                errorMessage = "عنوان سکشن را وارد کنید.";
                return false;
            }

            string percentText = CommonFunctions.ConvertPersianDigitsToEnglish(txtPercentage.Text);
            if (!byte.TryParse(percentText, out byte percent) || percent > 100)
            {
                errorMessage = "درصد فروش باید بین ۰ تا ۱۰۰ باشد.";
                return false;
            }

            string countText = CommonFunctions.ConvertPersianDigitsToEnglish(txtCountOfSell.Text);
            if (!short.TryParse(countText, out short count) || count > 3000)
            {
                errorMessage = "تعداد فروش باید یک عدد معتبر کمتر از ۳۰۰۰ باشد.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }


        private void btnSubmitNewSection_Click(object sender, EventArgs e)
        {
             if (!ValidateInputs(out string error))
                {
                    MessageBox.Show(error);
                    return;
                }

            var section = new SectionModel
            {
                SecTitle = txtSectionName.Text.Trim(),
                OverHead = 0,
                PerCentage = byte.Parse(CommonFunctions.ConvertPersianDigitsToEnglish(txtPercentage.Text)),
                CountOfSell = short.Parse(CommonFunctions.ConvertPersianDigitsToEnglish(txtCountOfSell.Text))
            };

            if (_sectionManager.InsertSection(section, out string newSecID))
            {
                MessageBox.Show($"✅ سکشن جدید با کد {newSecID} ثبت شد.");
                LoadSections();
            }
            else
            {
                MessageBox.Show("❌ خطا در ثبت سکشن.");
            }
        }

        private void btnUpdateSection_Click(object sender, EventArgs e)
        {
            if (_selectedSectionID == null) return;
            if (!ValidateInputs(out string error))
            {
                MessageBox.Show(error);
                return;
            }

            var section = new SectionModel
            {
                SecID = _selectedSectionID,
                SecTitle = txtSectionName.Text.Trim(),
                OverHead = 0,
                PerCentage = byte.Parse(CommonFunctions.ConvertPersianDigitsToEnglish(txtPercentage.Text)),
                CountOfSell = short.Parse(CommonFunctions.ConvertPersianDigitsToEnglish(txtCountOfSell.Text))
            };

            if (_sectionManager.UpdateSection(section))
            {
                MessageBox.Show("سکشن بروزرسانی شد.");
                LoadSections();
            }
        }

        private void btnDeletSection_Click(object sender, EventArgs e)
        {
            if (_selectedSectionID == null) return;
            if (_sectionManager.DeleteSection(_selectedSectionID))
            {
                MessageBox.Show("سکشن حذف شد.");
                LoadSections();
            }
        }

        private void lstSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSection.SelectedItems.Count == 0) return;
            var section = lstSection.SelectedItems[0].Tag as SectionModel;
            if (section == null) return;

            _selectedSectionID = section.SecID;
            txtSectionName.Text = section.SecTitle;
            txtPercentage.Text = section.PerCentage.ToString();
            txtCountOfSell.Text = section.CountOfSell.ToString();
        }

    }
}
