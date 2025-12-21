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

namespace MainProject.Forms
{
    public partial class SubmitSellerFRM : Form
    {
        private bool _suppressBalanceEvents;
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

        // === Form Events ===
        private void SubmitSellerFRM_Load(object sender, EventArgs e)
        {
            SetupSellerListView();
            LoadCategories();
            LoadSellers();
            UpdateAccountButtonState();
            txtPhone1.TextChanged += txtPhone_TextChanged;
            txtBalance.TextChanged += txtBalance_TextChanged;
            txtBalance.Leave += txtBalance_Leave;
        }

        // === UI Setup ===
        private void SetupSellerListView()
        {
            lstSeller.View = View.Details;
            lstSeller.FullRowSelect = true;
            lstSeller.GridLines = true;
            lstSeller.Columns.Clear();

            lstSeller.Columns.Add("کد", 110, HorizontalAlignment.Center);
            lstSeller.Columns.Add("نام فروشنده", 160, HorizontalAlignment.Left);
            lstSeller.Columns.Add("نام شرکت", 160, HorizontalAlignment.Left);
            lstSeller.Columns.Add("شماره تماس", 120, HorizontalAlignment.Center);
            lstSeller.Columns.Add("دسته‌بندی", 120, HorizontalAlignment.Center);
            lstSeller.Columns.Add("مانده", 110, HorizontalAlignment.Right);
        }
        private void LoadCategories()
        {
            cmbCategory1.Items.Clear();
            try
            {
                var infoDal = new InformationDAL();
                List<string> cats = infoDal.GetValuesByContext("SellerCategories");
                if (cats != null && cats.Count > 0)
                    cmbCategory1.Items.AddRange(cats.ToArray());
                cmbCategory1.SelectedIndex = -1;
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
                var it = new ListViewItem(s.SellerID);
                it.SubItems.Add(s.SellerName);
                it.SubItems.Add(s.CompanyName);
                it.SubItems.Add(s.PhoneDisplay ?? "");
                it.SubItems.Add(string.IsNullOrWhiteSpace(s.SellerCategory1) ? "—" : s.SellerCategory1);
                it.SubItems.Add(s.Balance.ToString("0"));
                it.Tag = s;
                lstSeller.Items.Add(it);
            }
            ClearForm();
        }


        private void ClearForm()
        {
            _selectedSellerID = null;

            txtISellerCode.Text = string.Empty;
            txtSellerName.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone1.Text = string.Empty;
            cmbCategory1.SelectedIndex = -1;

            txtBalance.Text = "0";
            CommonFunctions.FormatTextBoxAsThousandSeparated(txtBalance);
            SetRadiosFromBalance(0m);
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
            // اگر فیلدهای Phone2 و Phone3 وجود دارن، اینا رو uncomment کن:
            // model.Phone2 = CommonFunctions.ConvertPersianDigitsToEnglish(txtPhone2.Text.Trim());
            // model.Phone3 = CommonFunctions.ConvertPersianDigitsToEnglish(txtPhone3.Text.Trim());

            model.SellerCategory1 = cmbCategory1.SelectedItem == null ? null : cmbCategory1.SelectedItem.ToString();
            // اگر فیلدهای Category2 و Category3 وجود دارن، اینا رو uncomment کن:
            // model.SellerCategory2 = cmbCategory2.SelectedItem == null ? null : cmbCategory2.SelectedItem.ToString();
            // model.SellerCategory3 = cmbCategory3.SelectedItem == null ? null : cmbCategory3.SelectedItem.ToString();

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
            txtBalance.Text = seller.Balance.ToString("0");
            cmbCategory1.SelectedItem = string.IsNullOrWhiteSpace(seller.SellerCategory1) ? null : seller.SellerCategory1;
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
                    var it = new ListViewItem(s.SellerID);
                    it.SubItems.Add(s.SellerName);
                    it.SubItems.Add(s.CompanyName);
                    it.SubItems.Add(s.PhoneDisplay);
                    it.SubItems.Add(string.IsNullOrWhiteSpace(s.CategoryDisplay) ? "—" : s.CategoryDisplay);
                    it.SubItems.Add(s.Balance.ToString("0"));
                    it.Tag = s;
                    lstSeller.Items.Add(it);
                }
            }
        }
        private void UpdateAccountButtonState()
        {
            btnDefineBankAccouant.Enabled = !string.IsNullOrWhiteSpace(txtISellerCode.Text);
        }

        private void btnDefineBankAccouant_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtISellerCode.Text)) return;

            try
            {
                // OwnerType = "Seller"
         //       var frm = new DefineBankAccountFRM("Seller", txtISellerCode.Text.Trim());
           //     frm.ShowDialog();

                // بعد از بستن فرم حساب، اگر فروشنده انتخاب است، اطلاعات حساب را مجدد بخوان
                if (lstSeller.SelectedItems.Count > 0)
                {
                    var s = lstSeller.SelectedItems[0].Tag as SellerModel;
                    if (s != null) ;
                }
            }
            catch
            {
                MessageBox.Show("فرم حساب بانکی در این فاز در دسترس نیست.");
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
            if (!decimal.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtBalance.Text.Replace(",", "").Trim()), out bal)) bal = 0m;
            if (bal < 0m) bal = -bal;
            SetBalanceFormattedFromDecimal(bal);
        }

        private void rdbcreditor_CheckedChanged(object sender, EventArgs e)
        {
          
            if (!rdbcreditor.Checked) return;

            decimal bal;
            if (!decimal.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtBalance.Text.Trim()), out bal))
                bal = 0m;

            if (_suppressBalanceEvents) return;
            if (!decimal.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtBalance.Text.Replace(",", "").Trim()), out bal)) bal = 0m;
            if (bal > 0m) bal = -bal;
            SetBalanceFormattedFromDecimal(System.Math.Abs(bal));
        }

        private void SetRadiosFromBalance(decimal balance)
        {
            try
            {
                _suppressRadioEvents = true;
                rdbdebtor.Checked = balance > 0m;
                rdbcreditor.Checked = balance < 0m;
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
            if (rdbcreditor.Checked) return -abs; // بستانکار = منفی
            if (rdbdebtor.Checked) return abs; // بدهکار = مثبت
            return abs; // اگر هیچ‌کدام، مثبت در نظر می‌گیریم
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            // 1) تبدیل اعداد فارسی → انگلیسی
            string t = CommonFunctions.ConvertPersianDigitsToEnglish(txtPhone1.Text);

            // 2) حذف هر چیزی جز 0-9
            string cleaned = Regex.Replace(t, "[^0-9]", "");

            if (txtPhone1.Text != cleaned)
            {
                int oldSel = txtPhone1.SelectionStart;
                txtPhone1.Text = cleaned;
                // حفظ تقریبی موقعیت کرسر
                txtPhone1.SelectionStart = Math.Min(oldSel, txtPhone1.Text.Length);
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
