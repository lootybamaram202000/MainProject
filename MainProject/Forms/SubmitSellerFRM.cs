using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MainProject.Business;
using MainProject.Entities;
using MainProject.DataAccess;
using MainProject.Helpers;
using System.Text.RegularExpressions;
using System.Reflection;
using MainProject.Core.Business;
using System.Drawing;  // ← اضافه شد

namespace MainProject.Forms
{
    public partial class SubmitSellerFRM : Form
    {
        private bool _suppressBalanceEvents;
        private ToolTip sellerToolTip;
        // --- Services / Managers ---
        private SellerManager _sellerManager;

        // --- Selection / State ---
        private string _selectedSellerID;
        private bool _suppressRadioEvents;

        // --- Login Info ---
        private string _userID;
        private string _date;          // Persian date (string)
        private DateTime _dateValue;   // Gregorian date
        private int _dateDig;          // Persian date digits (int)

        public SubmitSellerFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();

            InitializeLoginInfo();
            InitializeServices();
            InitializeListViewSellers();
        }

        private void InitializeLoginInfo()
        {
            _userID = LoginInfo.Instance.UserID;
            _date = LoginInfo.Instance.Date;
            _dateValue = LoginInfo.Instance.DateValue;
            _dateDig = LoginInfo.Instance.DateDig;
        }

        private void InitializeServices()
        {
            // اگر DI ندارید، مطابق پروژه‌ی خودتان بسازید
            // نمونه‌ی متداول پروژه:
            // var dal = new SellerDAL(AppConfig.ConnectionString);
            // _sellerManager = new SellerManager(dal);

            // اگر سازنده‌ی بدون پارامتر دارید:
            _sellerManager = new SellerManager();
        }

        private void InitializeListViewSellers()
        {
            lstSeller.View = View.Details;
            lstSeller.FullRowSelect = true;
            lstSeller.GridLines = true;
            lstSeller.HideSelection = false;
            lstSeller.BackColor = Color.FromArgb(255, 255, 192);  // زرد روشن
            lstSeller.Font = new Font("Tahoma", 9F, FontStyle.Regular);  // فونت کوچکتر
            lstSeller.Columns.Clear();

            lstSeller.Columns.Add("کد", 100, HorizontalAlignment.Center);
            lstSeller.Columns.Add("نام فروشنده", 150, HorizontalAlignment.Right);
            lstSeller.Columns.Add("نام شرکت", 150, HorizontalAlignment.Right);
            lstSeller.Columns.Add("تلفن", 110, HorizontalAlignment.Center);
            lstSeller.Columns.Add("دسته‌بندی", 200, HorizontalAlignment.Right);
            lstSeller.Columns.Add("مانده (ریال)", 130, HorizontalAlignment.Right);

            ResizeListViewColumns();
        }

        private void ResizeListViewColumns()
        {
            if (lstSeller.Columns.Count != 6) return;

            int totalWidth = lstSeller.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 4;
            if (totalWidth <= 0) return;

            int colWidth1 = (int)(totalWidth * 0.10); // کد
            int colWidth2 = (int)(totalWidth * 0.18); // نام
            int colWidth3 = (int)(totalWidth * 0.18); // شرکت
            int colWidth4 = (int)(totalWidth * 0.13); // تلفن
            int colWidth5 = (int)(totalWidth * 0.25); // دسته
            int colWidth6 = totalWidth - (colWidth1 + colWidth2 + colWidth3 + colWidth4 + colWidth5);

            lstSeller.Columns[0].Width = colWidth1;
            lstSeller.Columns[1].Width = colWidth2;
            lstSeller.Columns[2].Width = colWidth3;
            lstSeller.Columns[3].Width = colWidth4;
            lstSeller.Columns[4].Width = colWidth5;
            lstSeller.Columns[5].Width = colWidth6;
        }

        // === Form Events ===
        private void SubmitSellerFRM_Load(object sender, EventArgs e)
        {
            // Columns are defined in InitializeListViewSellers
            LoadCategories();
            LoadSellerTypes();
            LoadSellers();
            UpdateAccountButtonState();

            txtPhone1.TextChanged += txtPhone_TextChanged;
            txtPhone2.TextChanged += txtPhone_TextChanged;
            txtPhone3.TextChanged += txtPhone_TextChanged;
            txtBalance.TextChanged += txtBalance_TextChanged;
            txtBalance.Leave += txtBalance_Leave;

            InitializeToolTips();

            this.KeyPreview = true;
            this.KeyDown += SubmitSellerFRM_KeyDown;

            // Handle resize
            lstSeller.SizeChanged += (s, ev) => ResizeListViewColumns();
            ResizeListViewColumns();

            // آپدیت متن دکمه‌ها با میانبرها
            btnSubmitNewSeller.Text = "ثبت (F2)";
            btnUpdateSeller.Text = "ویرایش (F3)";
            btnDeletSeller.Text = "حذف (F4)";
        }

        // === UI Setup ===
        private void LoadCategories()
        {
            cmbCategory1.Items.Clear();
            cmbCategory2.Items.Clear();
            cmbCategory3.Items.Clear();
            try
            {
                var infoDal = new InformationDAL();
                List<string> cats = infoDal.GetValuesByContext("SellerCategories");
                if (cats != null && cats.Count > 0)
                {
                    cmbCategory1.Items.AddRange(cats.ToArray());
                    cmbCategory2.Items.AddRange(cats.ToArray());
                    cmbCategory3.Items.AddRange(cats.ToArray());
                }
                cmbCategory1.SelectedIndex = -1;
                cmbCategory2.SelectedIndex = -1;
                cmbCategory3.SelectedIndex = -1;
            }
            catch
            {
                // نذار فرم کرش کنه
            }
        }

        private void LoadSellerTypes()
        {
            cmbSellerType.Items.Clear();

            try
            {
                var infoDal = new InformationDAL();
                List<string> types = infoDal.GetValuesByContext("SellerTypes");
                if (types != null && types.Count > 0)
                {
                    cmbSellerType.Items.AddRange(types.ToArray());
                }
                cmbSellerType.SelectedIndex = -1;
            }
            catch
            {
                // نذار فرم کرش کنه
            }
        }

        private void LoadSellers()
        {
            lstSeller.Items.Clear();
            List<SellerModel> sellerList;
            string msg;
            if (!_sellerManager.GetAllSellers(out sellerList, out msg))
            {
                MessageBox.Show(msg);
                return;
            }

            foreach (var s in sellerList)
            {
                var it = new ListViewItem(s.SellerID ?? "");
                it.SubItems.Add(s.SellerName ?? "");
                it.SubItems.Add(s.CompanyName ?? "");
                // فقط تلفن اصلی
                it.SubItems.Add(s.Phone1 ?? "");
                // دسته‌بندی ترکیبی
                var categories = new List<string>();
                if (!string.IsNullOrWhiteSpace(s.SellerCategory1)) categories.Add(s.SellerCategory1);
                if (!string.IsNullOrWhiteSpace(s.SellerCategory2)) categories.Add(s.SellerCategory2);
                if (!string.IsNullOrWhiteSpace(s.SellerCategory3)) categories.Add(s.SellerCategory3);
                string categoryDisplay = categories.Count > 0 ? string.Join(", ", categories) : "—";
                it.SubItems.Add(categoryDisplay);
                // مانده با فرمت و رنگ
                it.SubItems.Add(s.CurrentBalance.ToString("N0"));
                if (s.CurrentBalance < 0)
                    it.SubItems[5].ForeColor = Color.Red;
                else if (s.CurrentBalance > 0)
                    it.SubItems[5].ForeColor = Color.Green;
                it.Tag = s;
                lstSeller.Items.Add(it);
            }

            this.Text = $"اطلاعات فروشندگان - {sellerList.Count} فروشنده";
        }


        private void ClearForm()
        {
            _selectedSellerID = null;

            txtISellerCode.Text = string.Empty;
            txtSellerName.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone1.Text = string.Empty;
            txtPhone2.Text = string.Empty;
            txtPhone3.Text = string.Empty;
            cmbCategory1.SelectedIndex = -1;
            cmbCategory2.SelectedIndex = -1;
            cmbCategory3.SelectedIndex = -1;
            cmbSellerType.SelectedIndex = -1;

            txtBalance.Text = "0";
            CommonFunctions.FormatTextBoxAsThousandSeparated(txtBalance);
            SetRadiosFromBalance(0m);

            UpdateAccountButtonState();
        }

        // === Validation ===
        private bool ValidateInputs(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(txtSellerName.Text))
            {
                errorMessage = "نام فروشنده نباید خالی باشد.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                errorMessage = "نام شرکت نباید خالی باشد.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone1.Text))
            {
                errorMessage = "شماره تماس نباید خالی باشد.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        private SellerModel ReadFormToModel(bool forUpdate)
        {
            var model = new SellerModel();
            if (forUpdate) model.SellerID = txtISellerCode.Text.Trim();

            model.SellerName = txtSellerName.Text.Trim();
            model.CompanyName = txtCompanyName.Text.Trim();
            model.Address = txtAddress.Text.Trim();
            model.Phone1 = CommonFunctions.ConvertPersianDigitsToEnglish(txtPhone1.Text.Trim());
            model.Phone2 = CommonFunctions.ConvertPersianDigitsToEnglish(txtPhone2.Text.Trim());
            model.Phone3 = CommonFunctions.ConvertPersianDigitsToEnglish(txtPhone3.Text.Trim());

            model.SellerCategory1 = cmbCategory1.SelectedItem == null ? null : cmbCategory1.SelectedItem.ToString();
            model.SellerCategory2 = cmbCategory2.SelectedItem == null ? null : cmbCategory2.SelectedItem.ToString();
            model.SellerCategory3 = cmbCategory3.SelectedItem == null ? null : cmbCategory3.SelectedItem.ToString();
            model.SellerType = cmbSellerType.SelectedItem == null ? null : cmbSellerType.SelectedItem.ToString();

            // محاسبه Balance
            decimal bal;
            var balRaw = CommonFunctions.ConvertPersianDigitsToEnglish(txtBalance.Text.Trim()).Replace(",", "");
            balRaw = System.Text.RegularExpressions.Regex.Replace(balRaw, "[^0-9]", "");
            if (!decimal.TryParse(balRaw, out bal)) bal = 0m;

            bal = ApplyBalanceSignFromRadios(bal);
            model.Balance = bal;

            // ❌ حذف:  بخش Account - چون حساب بانکی در DefineBankAccountFRM مدیریت میشه
            // مدل فروشنده فقط Owner خام می‌سازه

            return model;
        }


        private void btnSubmitNewSeller_Click(object sender, EventArgs e)
        {

            if (!ValidateInputs(out var error))
            {
                MessageBox.Show(error);
                return;
            }

            var model = ReadFormToModel(false);
            if (model == null) return;

            string msg;
            bool result = _sellerManager.InsertSeller(
                model,
                _userID,
                _date,
                _dateValue,
                _dateDig,
                out string newSellerID,
                out string newOWID,
                out msg);

            if (result)
            {
                MessageBox.Show($"فروشنده با موفقیت ثبت شد.\nکد فروشنده: {newSellerID}\n\n💡 برای افزودن حساب بانکی، از فرم 'مدیریت حساب‌ها' استفاده کنید.");
                LoadSellers();
                ClearForm();
            }
            else
            {
                MessageBox.Show(!string.IsNullOrWhiteSpace(msg) ? msg : "خطا در ثبت فروشنده!");
            }
        }

        private void btnUpdateSeller_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtISellerCode.Text))
            {
                MessageBox.Show("ابتدا فروشنده را از لیست انتخاب کنید.");
                return;
            }
            if (!ValidateInputs(out var error))
            {
                MessageBox.Show(error);
                return;
            }

            var model = ReadFormToModel(true);
            if (model == null) return;

            string msg;
            bool ok = _sellerManager.UpdateSeller(
                model,
                _userID,
                _date,
                _dateValue,
                _dateDig,
                out msg);

            if (ok)
            {
                MessageBox.Show("ویرایش با موفقیت انجام شد.");
                LoadSellers();
                ClearForm();
            }
            else
            {
                MessageBox.Show(!string.IsNullOrWhiteSpace(msg) ? msg : "خطا در ویرایش فروشنده!");
            }
        }

        private void btnDeletSeller_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtISellerCode.Text))
            {
                MessageBox.Show("ابتدا یک فروشنده را از لیست انتخاب کنید.");
                return;
            }
            if (MessageBox.Show("حذف این فروشنده؟", "تأیید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string message;
            if (_sellerManager.DeleteSeller(txtISellerCode.Text.Trim(), _userID, _date, _dateValue, _dateDig, out message))
            {
                MessageBox.Show("حذف شد.");
                LoadSellers();
            }
            else
            {
                MessageBox.Show(string.IsNullOrWhiteSpace(message) ? "خطا در حذف." : message);
            }
        }

        private void lstSeller_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstSeller.SelectedItems.Count == 0)
            {
                ClearForm();
                return;
            }

            var seller = lstSeller.SelectedItems[0].Tag as SellerModel;
            if (seller == null)
            {
                ClearForm();
                return;
            }

            txtISellerCode.Text = seller.SellerID;
            txtSellerName.Text = seller.SellerName;
            txtCompanyName.Text = seller.CompanyName;
            txtAddress.Text = seller.Address ??  "";
            txtPhone1.Text = seller.Phone1 ?? "";
            txtPhone2.Text = seller.Phone2 ?? "";
            txtPhone3.Text = seller.Phone3 ?? "";
            txtBalance.Text = Math.Abs(seller.Balance).ToString("0");
            CommonFunctions.FormatTextBoxAsThousandSeparated(txtBalance);
            SetRadiosFromBalance(seller.Balance);
            cmbCategory1.SelectedItem = string.IsNullOrWhiteSpace(seller.SellerCategory1) ? null : seller.SellerCategory1;
            cmbCategory2.SelectedItem = string.IsNullOrWhiteSpace(seller.SellerCategory2) ? null : seller.SellerCategory2;
            cmbCategory3.SelectedItem = string.IsNullOrWhiteSpace(seller.SellerCategory3) ? null : seller.SellerCategory3;
            cmbSellerType.SelectedItem = string.IsNullOrWhiteSpace(seller.SellerType) ? null : seller.SellerType;

            UpdateAccountButtonState();
        }

        private void txtSearchSeller_TextChanged(object sender, EventArgs e)
        {
            lstSeller.Items.Clear();
            List<SellerModel> sellers;
            string msg;
            if (_sellerManager.Search(txtSearchSeller.Text.Trim(), out sellers, out msg))
            {
                foreach (var s in sellers)
                {
                    var it = new ListViewItem(s.SellerID ?? "");
                    it.SubItems.Add(s.SellerName ?? "");
                    it.SubItems.Add(s.CompanyName ?? "");
                    // فقط تلفن اصلی
                    it.SubItems.Add(s.Phone1 ?? "");
                    // دسته‌بندی ترکیبی
                    var categories = new List<string>();
                    if (!string.IsNullOrWhiteSpace(s.SellerCategory1)) categories.Add(s.SellerCategory1);
                    if (!string.IsNullOrWhiteSpace(s.SellerCategory2)) categories.Add(s.SellerCategory2);
                    if (!string.IsNullOrWhiteSpace(s.SellerCategory3)) categories.Add(s.SellerCategory3);
                    string categoryDisplay = categories.Count > 0 ? string.Join(", ", categories) : "—";
                    it.SubItems.Add(categoryDisplay);
                    // مانده با فرمت و رنگ
                    it.SubItems.Add(s.CurrentBalance.ToString("N0"));
                    if (s.CurrentBalance < 0)
                        it.SubItems[5].ForeColor = Color.Red;
                    else if (s.CurrentBalance > 0)
                        it.SubItems[5].ForeColor = Color.Green;
                    it.Tag = s;
                    lstSeller.Items.Add(it);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtSellerName.Focus();
        }

        private void SubmitSellerFRM_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (btnSubmitNewSeller.Enabled)
                        btnSubmitNewSeller_Click(sender, e);
                    break;
                case Keys.F3:
                    if (btnUpdateSeller.Enabled)
                        btnUpdateSeller_Click(sender, e);
                    break;
                case Keys.F4:
                    if (btnDeletSeller.Enabled)
                        btnDeletSeller_Click(sender, e);
                    break;
                case Keys.Escape:
                    ClearForm();
                    break;
            }
        }

        private void InitializeToolTips()
        {
            sellerToolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 300,
                ReshowDelay = 200,
                ShowAlways = true
            };

            sellerToolTip.SetToolTip(txtSellerName, "نام فروشنده (اجباری)");
            sellerToolTip.SetToolTip(txtCompanyName, "نام شرکت (اجباری)");
            sellerToolTip.SetToolTip(txtPhone1, "شماره تماس اصلی (اجباری) - 11 رقم");
            sellerToolTip.SetToolTip(txtPhone2, "شماره تماس دوم (اختیاری)");
            sellerToolTip.SetToolTip(txtPhone3, "شماره تماس سوم (اختیاری)");
            sellerToolTip.SetToolTip(txtBalance, "مانده اولیه حساب فروشنده");
            sellerToolTip.SetToolTip(rdbdebtor, "بدهکار: فروشنده به ما پول بدهکار است");
            sellerToolTip.SetToolTip(rdbcreditor, "بستانکار: ما به فروشنده پول بدهکاریم");
            sellerToolTip.SetToolTip(btnDefineBankAccouant,
                "مدیریت حساب‌های بانکی فروشنده\n" +
                "ابتدا یک فروشنده را از لیست انتخاب کنید\n" +
                "می‌توانید حساب جدید اضافه یا حساب‌های موجود را ویرایش کنید");
        }

        private void UpdateAccountButtonState()
        {
            btnDefineBankAccouant.Enabled = !string.IsNullOrWhiteSpace(txtISellerCode.Text);
        }

        private void btnDefineBankAccouant_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtISellerCode.Text))
            {
                MessageBox.Show("ابتدا یک فروشنده را از لیست انتخاب کنید.",
                    "هشدار",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (lstSeller.SelectedItems.Count == 0)
                {
                    MessageBox.Show("ابتدا یک فروشنده را از لیست انتخاب کنید.",
                        "هشدار",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var seller = lstSeller.SelectedItems[0].Tag as SellerModel;
                if (seller == null)
                {
                    MessageBox.Show("خطا در بارگذاری اطلاعات فروشنده.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var frm = new DefineBankAccountFRM("Seller", txtISellerCode.Text.Trim(), seller.SellerName);
                frm.ShowDialog();

                string selectedId = txtISellerCode.Text.Trim();
                LoadSellers();

                if (!string.IsNullOrWhiteSpace(selectedId))
                {
                    foreach (ListViewItem item in lstSeller.Items)
                    {
                        if (item.Text == selectedId)
                        {
                            item.Selected = true;
                            lstSeller.EnsureVisible(item.Index);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در باز کردن فرم حساب بانکی:\n{ex.Message}",
                    "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new InfoEditorForm("SellerCategories");
                frm.ShowDialog();
                LoadCategories();
            }
            catch
            {
                MessageBox.Show("فرم تعریف دسته‌بندی در این فاز در دسترس نیست.");
            }
        }

        private void rdbdebtor_CheckedChanged(object sender, EventArgs e)
        {
            if (_suppressRadioEvents) return;
            if (!rdbdebtor.Checked) return;

            decimal bal;
            if (!decimal.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtBalance.Text.Replace(",", "").Trim()), out bal))
                bal = 0m;

            SetBalanceFormattedFromDecimal(Math.Abs(bal));
        }

        private void rdbcreditor_CheckedChanged(object sender, EventArgs e)
        {
            if (_suppressRadioEvents) return;
            if (!rdbcreditor.Checked) return;

            decimal bal;
            if (!decimal.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtBalance.Text.Replace(",", "").Trim()), out bal))
                bal = 0m;

            SetBalanceFormattedFromDecimal(Math.Abs(bal));
        }

        private void SetRadiosFromBalance(decimal balance)
        {
            try
            {
                _suppressRadioEvents = true;
                rdbdebtor.Checked = balance < 0m;
                rdbcreditor.Checked = balance > 0m;
                if (balance == 0m)
                {
                    rdbdebtor.Checked = false;
                    rdbcreditor.Checked = false;
                }
            }
            finally
            {
                _suppressRadioEvents = false;
            }
        }

        private decimal ApplyBalanceSignFromRadios(decimal balanceAbs)
        {
            var abs = Math.Abs(balanceAbs);
            if (rdbdebtor.Checked) return -abs;
            if (rdbcreditor.Checked) return abs;
            return 0m;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null) return;

            // 1) تبدیل اعداد فارسی → انگلیسی
            string t = CommonFunctions.ConvertPersianDigitsToEnglish(tb.Text);

            // 2) حذف هر چیزی جز 0-9
            string cleaned = Regex.Replace(t, "[^0-9]", "");

            if (tb.Text != cleaned)
            {
                int oldSel = tb.SelectionStart;
                tb.Text = cleaned;
                // حفظ تقریبی موقعیت کرسر
                tb.SelectionStart = Math.Min(oldSel, tb.Text.Length);
            }
        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            if (_suppressBalanceEvents) return;

            // فارسی → انگلیسی + حذف کاما + حذف غیررقم
            string raw = CommonFunctions.ConvertPersianDigitsToEnglish(txtBalance.Text ?? "");
            raw = raw.Replace(",", "");
            string digitsOnly = System.Text.RegularExpressions.Regex.Replace(raw, "[^0-9]", "");

            if (txtBalance.Text != digitsOnly)
            {
                int caret = txtBalance.SelectionStart;
                _suppressBalanceEvents = true;
                txtBalance.Text = digitsOnly;
                txtBalance.SelectionStart = System.Math.Min(caret, txtBalance.Text.Length);
                _suppressBalanceEvents = false;
            }
        }

        private void txtBalance_Leave(object sender, EventArgs e)
        {
            _suppressBalanceEvents = true;
            CommonFunctions.FormatTextBoxAsThousandSeparated(txtBalance); // فرمت با جداکننده ۳رقم
            _suppressBalanceEvents = false;
        }
        private void SetBalanceFormattedFromDecimal(decimal value)
        {
            _suppressBalanceEvents = true;
            txtBalance.Text = System.Math.Abs(value).ToString("0");
            CommonFunctions.FormatTextBoxAsThousandSeparated(txtBalance);
            _suppressBalanceEvents = false;
        }


    }
}
