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
        private ErrorProvider errorProvider;


        public SubmitUnitFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
            InitializeListViewUnits();
            InitializeToolTips();
            InitializeErrorProvider();
            SetTabIndexes();
            SetupKeyboardShortcuts();
            SetupTextBoxBehavior();

            LoadUnits();
            ClearForm();

            // Update button captions with shortcuts
            btnSubmitNewUnit.Text = "ثبت (F2)";
            btnUpdateUnit.Text = "ویرایش (F3)";
            btnDeletUnit.Text = "حذف (F4)";
            btnNew.Text = "جدید (Esc)";

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
            // RadioButtons
            unitToolTip.SetToolTip(rdbPurchaseUnit,
                "نوع واحد کاربردی: خرید\n" +
                "برای کالاهای خریداری‌شده (مثال: کیلوگرم برنج، لیتر روغن)\n" 
               );

            unitToolTip.SetToolTip(rdbProductUnit,
                "نوع واحد کاربردی: تولید\n" +
                "برای محصولات تولیدی (مثال: پرس پیتزا، فنجان قهوه)\n");

            // TextBoxes
            unitToolTip.SetToolTip(txtMeasurmentUnitTitle,
                "عنوان واحد اندازه‌گیری پایه\n" +
                "مثال: گرم، میلی‌لیتر، عدد\n" +
                "نوشتار راست‌به‌چپ\n");

            unitToolTip.SetToolTip(txtMeasurmentUnitQuantity,
                "مقدار عددی واحد اندازه‌گیری\n" +
                "مثال: 1000 (برای 1000 گرم)\n" +
                "فقط اعداد مثبت؛ ورود فارسی/انگلیسی مجاز\n");

            unitToolTip.SetToolTip(txtPUnitTitle,
                "عنوان واحد کاربردی\n" +
                "مثال: کیلوگرم، لیتر، بسته\n" +
                "نوشتار راست‌به‌چپ\n");

            unitToolTip.SetToolTip(txtPUnitQuantity,
                "مقدار عددی واحد کاربردی\n" +
                "مثال: 1 (برای 1 کیلوگرم)\n" +
                "معمولاً عدد کوچک‌تر از مقدار پایه است\n");

            // CheckBox
            unitToolTip.SetToolTip(chkIsActive,
                "وضعیت فعال/غیرفعال واحد\n" +
                "✓ فعال: قابل استفاده در سیستم\n" +
                "✗ غیرفعال: مخفی/غیرقابل استفاده\n");

            // Buttons
            unitToolTip.SetToolTip(btnSubmitNewUnit,
                "ثبت واحد جدید در سیستم\n" +
                "میانبر: F2\n" +
                "در حالت ویرایش غیرفعال می‌شود");

            unitToolTip.SetToolTip(btnUpdateUnit,
                "ویرایش واحد انتخاب‌شده\n" +
                "میانبر: F3\n" +
                "ابتدا یک واحد از لیست انتخاب کنید");

            unitToolTip.SetToolTip(btnDeletUnit,
                "حذف واحد انتخاب‌شده (Soft Delete)\n" +
                "میانبر: F4\n" +
                "نیاز به تأیید دارد");

            unitToolTip.SetToolTip(btnNew,
                "پاک‌سازی فرم و شروع ثبت جدید\n" +
                "میانبر: Escape\n" +
                "تمام فیلدها خالی می‌شوند");

            // Search
            unitToolTip.SetToolTip(txtSearch,
                "جستجو در واحدها\n" +
                "فیلتر براساس: نوع، عنوان پایه، عنوان کاربردی\n" +
                "به‌صورت لحظه‌ای");

            // ListView
            unitToolTip.SetToolTip(lstUnits,
                "لیست واحدهای ثبت‌شده\n" +
                "کلیک برای انتخاب و ویرایش\n" +
                "واحدهای غیرفعال با رنگ خاکستری");
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

        private void LoadUnits(string searchText = "")
        {
            lstUnits.Items.Clear();

            List<UnitModel> units;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                units = _unitManager.SearchUnits(searchText);
            }
            else
            {
                units = _unitManager.GetAllUnits().Where(u => !u.IsDeleted).ToList();
            }

            int index = 1;
            foreach (var unit in units)
            {
                var item = new ListViewItem(index.ToString());
                item.SubItems.Add(unit.UnitTypeFa);
                item.SubItems.Add(unit.MeasurmentUnitTitle);
                item.SubItems.Add(unit.MesurmentUnitQuantity.ToString("N0"));
                item.SubItems.Add(unit.PunitTitle);
                item.SubItems.Add(unit.PunitQuantity.ToString("N0"));
                item.SubItems.Add(unit.IsActive ? "فعال" : "غیرفعال");
                item.Tag = unit;

                if (!unit.IsActive)
                {
                    item.ForeColor = Color.Gray;
                    item.Font = new Font(lstUnits.Font, FontStyle.Italic);
                }

                lstUnits.Items.Add(item);
                index++;
            }

            this.Text = $"تعریف و ثبت واحد‌های اندازه‌گیری - {units.Count} واحد";
        }



        private void btnSubmitNewUnit_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            string unitType = rdbPurchaseUnit.Checked ? "Purchase" : "Product";


            var unit = new UnitModel
            {

                UnitType = unitType,
                MeasurmentUnitTitle = txtMeasurmentUnitTitle.Text.Trim(),
                MesurmentUnitQuantity = Convert.ToInt32(CommonFunctions.ConvertPersianDigitsToEnglish(txtMeasurmentUnitQuantity.Text.Trim())),
                PunitTitle = txtPUnitTitle.Text.Trim(),
                PunitQuantity = Convert.ToInt32(CommonFunctions.ConvertPersianDigitsToEnglish(txtPUnitQuantity.Text.Trim())),
                IsActive = chkIsActive != null ? chkIsActive.Checked : true,
                IsDeleted = false,

            };



            if (_unitManager.IsDuplicateUnit(unit.UnitType, unit.MeasurmentUnitTitle, unit.PunitTitle))
            {
                MessageBox.Show("واحدی با این ترکیب قبلاً ثبت شده است.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_unitManager.InsertUnit(unit, out string generatedCode, out string errorMessage))
            {
                MessageBox.Show($"واحد جدید با موفقیت ثبت شد.\nکد: {generatedCode}", "ثبت موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUnits();
                ClearForm();
            }
            else
            {
                MessageBox.Show($"خطا در ثبت واحد.\n{errorMessage}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdateUnit_Click(object sender, EventArgs e)
        {
            if (_selectedUnitID == null)
            {
                MessageBox.Show("لطفاً ابتدا یک واحد را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInputs()) return;

            string unitType = rdbPurchaseUnit.Checked ? "Purchase" : "Product";

            var unit = new UnitModel
            {
                UnitID = _selectedUnitID,
                UnitType = unitType,
                MeasurmentUnitTitle = txtMeasurmentUnitTitle.Text.Trim(),
                MesurmentUnitQuantity = Convert.ToInt32(CommonFunctions.ConvertPersianDigitsToEnglish(txtMeasurmentUnitQuantity.Text.Trim())),
                PunitTitle = txtPUnitTitle.Text.Trim(),
                PunitQuantity = Convert.ToInt32(CommonFunctions.ConvertPersianDigitsToEnglish(txtPUnitQuantity.Text.Trim())),
                IsActive = chkIsActive != null ? chkIsActive.Checked : true,

            };

            if (_unitManager.IsDuplicateUnit(unit.UnitType, unit.MeasurmentUnitTitle, unit.PunitTitle, unit.UnitID))
            {
                MessageBox.Show("واحدی با این ترکیب قبلاً ثبت شده است.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_unitManager.UpdateUnit(unit, out string updateError))
            {
                MessageBox.Show("اطلاعات واحد با موفقیت به‌روزرسانی شد.");
                LoadUnits();
                ClearForm();
            }
            else
            {
                MessageBox.Show($"خطا در ویرایش واحد.\n{updateError}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletUnit_Click(object sender, EventArgs e)
        {
            if (_selectedUnitID == null)
            {
                MessageBox.Show("لطفاً ابتدا یک واحد را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUnit = lstUnits.SelectedItems.Count > 0 ? lstUnits.SelectedItems[0].Tag as UnitModel : null;
            var result = MessageBox.Show(
                selectedUnit != null ?
                $"آیا از حذف واحد زیر اطمینان دارید؟\n\nنوع: {selectedUnit.UnitTypeFa}\nواحد پایه: {selectedUnit.MeasurmentUnitTitle}\nواحد کاربردی: {selectedUnit.PunitTitle}\n\n⚠️ این عملیات قابل بازگشت نیست." :
                "آیا از حذف این واحد اطمینان دارید؟",
                "تأیید حذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes) return;

            if (_unitManager.DeleteUnit(_selectedUnitID, out string delError))
            {
                MessageBox.Show("واحد حذف شد.");
                LoadUnits();
                ClearForm();
            }
            else
            {
                MessageBox.Show($"خطا در حذف واحد.\n{delError}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (chkIsActive != null) chkIsActive.Checked = unit.IsActive;

            // Edit mode feedback
            btnSubmitNewUnit.Enabled = false;
            btnUpdateUnit.Enabled = true;
            btnDeletUnit.Enabled = true;
            this.BackColor = Color.LightYellow;
        }


        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("مثال: \n 1000 Gram == 1 KiloGram  \n 20 Gram Grined Coffee == 1 Cup Espreeso(40gr)   ");
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            LoadUnits(txtSearch.Text.Trim());
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        // New helpers
        private void SetTabIndexes()
        {
            // Inputs
            txtPUnitQuantity.TabIndex = 0;
            txtPUnitTitle.TabIndex = 1;
            txtMeasurmentUnitQuantity.TabIndex = 2;
            txtMeasurmentUnitTitle.TabIndex = 3;
            rdbPurchaseUnit.TabIndex = 4;
            rdbProductUnit.TabIndex = 5;
            chkIsActive.TabIndex = 6;

            // Actions
            btnSubmitNewUnit.TabIndex = 7;
            btnUpdateUnit.TabIndex = 8;
            btnDeletUnit.TabIndex = 9;
            btnNew.TabIndex = 10;

            // Search & list
            txtSearch.TabIndex = 11;
            lstUnits.TabIndex = 12;

            // Remove labels and images from tab navigation
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label || ctrl is PictureBox)
                {
                    ctrl.TabStop = false;
                }
            }
        }

        private void SetupKeyboardShortcuts()
        {
            this.KeyPreview = true;
            this.KeyDown += SubmitUnitFRM_KeyDown;
        }

        private void SetupTextBoxBehavior()
        {
            // Enter key navigation
            txtPUnitQuantity.KeyDown += TextBox_KeyDown_EnterToNext;
            txtPUnitTitle.KeyDown += TextBox_KeyDown_EnterToNext;
            txtMeasurmentUnitQuantity.KeyDown += TextBox_KeyDown_EnterToNext;
            txtMeasurmentUnitTitle.KeyDown += TextBox_KeyDown_EnterToNext;

            // Numeric-only
            txtPUnitQuantity.KeyPress += NumericTextBox_KeyPress;
            txtMeasurmentUnitQuantity.KeyPress += NumericTextBox_KeyPress;

            // Focus highlighting
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.Enter += TextBox_Enter_Highlight;
                    txt.Leave += TextBox_Leave_Normal;
                }
            }

            // Alignment
            txtPUnitQuantity.TextAlign = HorizontalAlignment.Center;
            txtMeasurmentUnitQuantity.TextAlign = HorizontalAlignment.Center;
            txtPUnitTitle.RightToLeft = RightToLeft.Yes;
            txtMeasurmentUnitTitle.RightToLeft = RightToLeft.Yes;
        }
        private void InitializeErrorProvider()
        {
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void SetupNumericTextBoxes()
        {
            txtMeasurmentUnitQuantity.KeyPress += NumericTextBox_KeyPress;
            txtPUnitQuantity.KeyPress += NumericTextBox_KeyPress;
            txtMeasurmentUnitQuantity.RightToLeft = RightToLeft.No;
            txtMeasurmentUnitQuantity.TextAlign = HorizontalAlignment.Center;
            txtPUnitQuantity.RightToLeft = RightToLeft.No;
            txtPUnitQuantity.TextAlign = HorizontalAlignment.Center;
        }

        private void ApplyEnterKeyNavigation()
        {
            txtMeasurmentUnitTitle.KeyDown += TextBox_KeyDown_EnterToNext;
            txtMeasurmentUnitQuantity.KeyDown += TextBox_KeyDown_EnterToNext;
            txtPUnitTitle.KeyDown += TextBox_KeyDown_EnterToNext;
            txtPUnitQuantity.KeyDown += TextBox_KeyDown_EnterToNext;
        }

        private void ApplyFocusHighlighting()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.Enter += TextBox_Enter_Highlight;
                    txt.Leave += TextBox_Leave_Normal;
                }
            }
        }

        private void TextBox_KeyDown_EnterToNext(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TextBox_Enter_Highlight(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BackColor = Color.LightYellow;
                txt.SelectAll();
            }
        }

        private void TextBox_Leave_Normal(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.BackColor = Color.White;
            }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !"۰۱۲۳۴۵۶۷۸۹".Contains(e.KeyChar))
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            errorProvider?.Clear();

            if (string.IsNullOrWhiteSpace(txtMeasurmentUnitTitle.Text))
            {
                errorProvider?.SetError(txtMeasurmentUnitTitle, "عنوان واحد پایه الزامی است");
                isValid = false;
            }

            int muQty = 0;
            if (!TryParseQuantity(txtMeasurmentUnitQuantity.Text, out muQty))
            {
                errorProvider?.SetError(txtMeasurmentUnitQuantity, "مقدار باید عدد مثبت باشد");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPUnitTitle.Text))
            {
                errorProvider?.SetError(txtPUnitTitle, "عنوان واحد کاربردی الزامی است");
                isValid = false;
            }

            int puQty = 0;
            if (!TryParseQuantity(txtPUnitQuantity.Text, out puQty))
            {
                errorProvider?.SetError(txtPUnitQuantity, "مقدار باید عدد مثبت باشد");
                isValid = false;
            }

            if (!rdbPurchaseUnit.Checked && !rdbProductUnit.Checked)
            {
                MessageBox.Show("لطفاً نوع واحد را انتخاب کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }

            if (isValid && muQty <= puQty)
            {
                var result = MessageBox.Show(
                    "⚠️ مقدار واحد اندازه‌گیری کمتر یا مساوی مقدار کاربردی است.\n\nآیا می‌خواهید ادامه دهید؟",
                    "هشدار",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    isValid = false;
            }

            return isValid;
        }

        private bool TryParseQuantity(string text, out int result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(text)) return false;
            string normalized = CommonFunctions.ConvertPersianDigitsToEnglish(text.Trim());
            return int.TryParse(normalized, out result) && result > 0;
        }

        private void SubmitUnitFRM_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (btnSubmitNewUnit.Enabled) btnSubmitNewUnit_Click(null, null);
                    break;
                case Keys.F3:
                    if (btnUpdateUnit.Enabled) btnUpdateUnit_Click(null, null);
                    break;
                case Keys.F4:
                    if (btnDeletUnit.Enabled) btnDeletUnit_Click(null, null);
                    break;
                case Keys.F5:
                    LoadUnits();
                    break;
                case Keys.Escape:
                    ClearForm();
                    break;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtMeasurmentUnitTitle.Text = string.Empty;
            txtMeasurmentUnitQuantity.Text = string.Empty;
            txtPUnitTitle.Text = string.Empty;
            txtPUnitQuantity.Text = string.Empty;
            txtSearch.Text = string.Empty;

            rdbPurchaseUnit.Checked = true;
            rdbProductUnit.Checked = false;
            if (chkIsActive != null) chkIsActive.Checked = true;

            _selectedUnitID = null;
            lstUnits.SelectedItems.Clear();
            errorProvider?.Clear();

            btnSubmitNewUnit.Enabled = true;
            btnUpdateUnit.Enabled = false;
            btnDeletUnit.Enabled = false;
            this.BackColor = SystemColors.ControlDark;
            txtMeasurmentUnitTitle.Focus();
        }
    }
}
