using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProject.Helpers;
using MainProject.Core.Business;
using MainProject.DataAccess;
using MainProject.Entities;

namespace MainProject.Forms
{
    public partial class DefineBankAccountFRM : Form
    {
        private ToolTip accountToolTip;

        // Managers & DAL
        private AccountManager _accountManager;
        private AccountOwnerDAL _ownerDAL;

        private InformationDAL _infoDal;

        // Owner info (برای حالت محدود)
        private string _ownerType;
        private string _ownerID;
        private string _ownerName;
        private string _currentOwnerOWID;

        private bool _isRestrictedMode;

        // Login info
        private string _userID;
        private string _date;
        private DateTime _dateValue;
        private int _dateDig;

        public DefineBankAccountFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();

            _accountManager = new AccountManager();
            _ownerDAL = new AccountOwnerDAL();
            _infoDal = new InformationDAL();
            _isRestrictedMode = false;

            InitializeLoginInfo();
            InitializeForm();
            LoadAllOwners();
        }

        public DefineBankAccountFRM(string ownerType, string ownerID, string ownerName)
        {
            if (string.IsNullOrWhiteSpace(ownerType))
                throw new ArgumentException("نوع صاحب حساب نمی‌تواند خالی باشد.", nameof(ownerType));
            if (string.IsNullOrWhiteSpace(ownerID))
                throw new ArgumentException("کد صاحب حساب نمی‌تواند خالی باشد.", nameof(ownerID));

            CommonFunctions.ScaleForm(this);
            InitializeComponent();

            _accountManager = new AccountManager();
            _ownerDAL = new AccountOwnerDAL();
            _infoDal = new InformationDAL();

            _isRestrictedMode = true;
            _ownerType = ownerType;
            _ownerID = ownerID;
            _ownerName = ownerName ?? ownerID;

            InitializeLoginInfo();
            InitializeForm();
            LoadOwnerInfo();
            LoadOwnersFiltered(ownerType);
            DisableOwnerSearch();

            // بارگذاری حساب‌های این Owner
            if (!string.IsNullOrWhiteSpace(_currentOwnerOWID))
            {
                LoadAccountsForOwner(_currentOwnerOWID);
            }
        }

        private void InitializeLoginInfo()
        {
            _userID = LoginInfo.Instance.UserID;
            _date = LoginInfo.Instance.Date;
            _dateValue = LoginInfo.Instance.DateValue;
            _dateDig = LoginInfo.Instance.DateDig;
        }

        private void InitializeForm()
        {
            this.Text = _isRestrictedMode
                ? $"مدیریت حساب‌های بانکی - {_ownerName}"
                : "مدیریت حساب‌های بانکی";

            // Setup ListViews
            InitializeListViewOwners();
            InitializeListViewAccounts();

            // Load ComboBoxes
            LoadBanks();
            LoadAccountCategories();

            // Event handlers
            lstOwners.SelectedIndexChanged += lstOwners_SelectedIndexChanged;
            lstBankAccount.SelectedIndexChanged += lstBankAccount_SelectedIndexChanged;
            txtAccountOwnerSearch.TextChanged += txtAccountOwnerSearch_TextChanged;

            // Handle resize
            lstOwners.SizeChanged += (s, ev) => ResizeListViewOwners();
            lstBankAccount.SizeChanged += (s, ev) => ResizeListViewAccounts();
            ResizeListViewOwners();
            ResizeListViewAccounts();

            // آپدیت متن دکمه‌ها
            if (btnSubmitNewBankAccount != null)
                btnSubmitNewBankAccount.Text = "ثبت (F2)";

            if (btnUpdateBankAccount != null)
                btnUpdateBankAccount.Text = "ویرایش (F3)";

            if (btnDeletBankAccount != null)
                btnDeletBankAccount.Text = "حذف (F4)";

            InitializeToolTips();

            // حالت پیش‌فرض فرم
            ClearAccountForm();
        }

        private void InitializeToolTips()
        {
            accountToolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 300,
                ReshowDelay = 200,
                ShowAlways = true
            };

            if (txtOwnnerCode != null)
                accountToolTip.SetToolTip(txtOwnnerCode, "کد صاحب حساب");

            if (txtAccountOwnerSearch != null)
                accountToolTip.SetToolTip(txtAccountOwnerSearch,
                    _isRestrictedMode
                        ? "نام صاحب حساب (غیرقابل تغییر)"
                        : "جستجو در صاحبان حساب - بر اساس نام یا کد");

            if (txtAccountNumber != null)
                accountToolTip.SetToolTip(txtAccountNumber, "شماره حساب بانکی (اجباری)");

            if (txtAccountCard != null)
                accountToolTip.SetToolTip(txtAccountCard, "شماره کارت 16 رقمی (اختیاری)");

            if (textBox1 != null)
                accountToolTip.SetToolTip(textBox1, "شماره شبا 24 رقمی بدون IR (اختیاری)");

            if (cmbBankName != null)
                accountToolTip.SetToolTip(cmbBankName, "نام بانک (اجباری)");

            if (cmbAccCategory != null)
                accountToolTip.SetToolTip(cmbAccCategory, "دسته‌بندی: کارتخوان، حساب بانکی، حساب شخصی، حساب اصلی");

            if (chbDefault != null)
                accountToolTip.SetToolTip(chbDefault, "تنظیم به عنوان حساب پیش‌فرض این صاحب حساب");

            if (chbPayer != null)
                accountToolTip.SetToolTip(chbPayer,
                    "حساب تنخواه (پرداخت کننده)\n" +
                    "اگه علامت نخورد، حساب دریافت کننده است");

            if (btnSubmitNewBankAccount != null)
                accountToolTip.SetToolTip(btnSubmitNewBankAccount, "ثبت حساب بانکی جدید");

            if (btnUpdateBankAccount != null)
                accountToolTip.SetToolTip(btnUpdateBankAccount, "ویرایش حساب انتخاب‌شده");

            if (btnDeletBankAccount != null)
                accountToolTip.SetToolTip(btnDeletBankAccount, "حذف حساب انتخاب‌شده");

            if (lstOwners != null)
                accountToolTip.SetToolTip(lstOwners, "لیست صاحبان حساب - کلیک برای مشاهده حساب‌های بانکی");

            if (lstBankAccount != null)
                accountToolTip.SetToolTip(lstBankAccount, "لیست حساب‌های بانکی - کلیک برای ویرایش یا حذف");
        }

        private void ResizeListViewOwners()
        {
            if (lstOwners.Columns.Count != 5) return;

            int totalWidth = lstOwners.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 4;
            if (totalWidth <= 0) return;

            lstOwners.Columns[0].Width = (int)(totalWidth * 0.08);
            lstOwners.Columns[1].Width = (int)(totalWidth * 0.15);
            lstOwners.Columns[2].Width = (int)(totalWidth * 0.40);
            lstOwners.Columns[3].Width = (int)(totalWidth * 0.15);
            lstOwners.Columns[4].Width = totalWidth - lstOwners.Columns[0].Width
                                                    - lstOwners.Columns[1].Width
                                                    - lstOwners.Columns[2].Width
                                                    - lstOwners.Columns[3].Width;
        }

        private void ResizeListViewAccounts()
        {
            if (lstBankAccount.Columns.Count != 9) return;

            int totalWidth = lstBankAccount.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 4;
            if (totalWidth <= 0) return;

            lstBankAccount.Columns[0].Width = (int)(totalWidth * 0.05);
            lstBankAccount.Columns[1].Width = (int)(totalWidth * 0.07);
            lstBankAccount.Columns[2].Width = (int)(totalWidth * 0.12);
            lstBankAccount.Columns[3].Width = (int)(totalWidth * 0.14);
            lstBankAccount.Columns[4].Width = (int)(totalWidth * 0.18);
            lstBankAccount.Columns[5].Width = (int)(totalWidth * 0.15);
            lstBankAccount.Columns[6].Width = (int)(totalWidth * 0.10);
            lstBankAccount.Columns[7].Width = (int)(totalWidth * 0.12);
            lstBankAccount.Columns[8].Width = totalWidth - lstBankAccount.Columns[0].Width
                                                     - lstBankAccount.Columns[1].Width
                                                     - lstBankAccount.Columns[2].Width
                                                     - lstBankAccount.Columns[3].Width
                                                     - lstBankAccount.Columns[4].Width
                                                     - lstBankAccount.Columns[5].Width
                                                     - lstBankAccount.Columns[6].Width
                                                     - lstBankAccount.Columns[7].Width;
        }

        private void lstBankAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBankAccount.SelectedItems.Count == 0)
            {
                ClearAccountForm();
                return;
            }

            var account = lstBankAccount.SelectedItems[0].Tag as AccountModel;
            if (account == null)
            {
                ClearAccountForm();
                return;
            }

            if (txtAccountNumber != null)
                txtAccountNumber.Text = account.ACNumber ?? "";

            // در Designer این فرم نام TextBox کارت `txtAccountCard` است.
            if (txtAccountCard != null)
                txtAccountCard.Text = account.ACCardNumber ?? "";

            // در Designer این فرم TextBox شبا `textBox1` است.
            if (textBox1 != null)
                textBox1.Text = account.ACshabaNumber ?? "";

            if (cmbBankName != null)
                cmbBankName.SelectedItem = account.ACBank;

            if (cmbAccCategory != null)
                cmbAccCategory.SelectedItem = account.ACCategory;

            // CheckBox ها
            // در Designer این فرم نام چک‌باکس پیش‌فرض `chbDefault` است.
            if (chbDefault != null)
                chbDefault.Checked = account.isDefault;

            if (chbPayer != null)
                chbPayer.Checked = account.isPayer;

            if (btnUpdateBankAccount != null)
                btnUpdateBankAccount.Enabled = true;

            if (btnDeletBankAccount != null)
                btnDeletBankAccount.Enabled = true;

            if (btnSubmitNewBankAccount != null)
                btnSubmitNewBankAccount.Enabled = false;
        }

        private void ClearAccountForm()
        {
            if (txtAccountNumber != null)
                txtAccountNumber.Text = string.Empty;

            if (txtAccountCard != null)
                txtAccountCard.Text = string.Empty;

            if (textBox1 != null)
                textBox1.Text = string.Empty;

            if (cmbBankName != null)
                cmbBankName.SelectedIndex = -1;

            if (cmbAccountType != null)
                cmbAccountType.SelectedIndex = -1;

            if (cmbAccCategory != null)
                cmbAccCategory.SelectedIndex = -1;

            if (chbDefault != null)
                chbDefault.Checked = false;

            if (chbPayer != null)
                chbPayer.Checked = false;

            if (btnSubmitNewBankAccount != null)
                btnSubmitNewBankAccount.Enabled = true;

            if (btnUpdateBankAccount != null)
                btnUpdateBankAccount.Enabled = false;

            if (btnDeletBankAccount != null)
                btnDeletBankAccount.Enabled = false;

            if (lstBankAccount != null && lstBankAccount.SelectedItems.Count > 0)
            {
                lstBankAccount.SelectedItems.Clear();
            }
        }

        private bool ValidateAccountInputs(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(_currentOwnerOWID))
            {
                errorMessage = "ابتدا یک صاحب حساب را انتخاب کنید.";
                return false;
            }

            if (cmbBankName == null || cmbBankName.SelectedIndex == -1)
            {
                errorMessage = "بانک را انتخاب کنید. ";
                return false;
            }

            if (txtAccountNumber != null && string.IsNullOrWhiteSpace(txtAccountNumber.Text))
            {
                errorMessage = "شماره حساب نباید خالی باشد.";
                return false;
            }

            if (textBox1 != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                string shaba = textBox1.Text.Trim();
                shaba = shaba.Replace("ir", "").Replace("IR", "");
                if (shaba.Length != 24)
                {
                    errorMessage = "شماره شبا باید 24 رقم باشد (بدون IR).";
                    return false;
                }
            }

            if (txtAccountCard != null && !string.IsNullOrWhiteSpace(txtAccountCard.Text))
            {
                string card = txtAccountCard.Text.Trim().Replace("-", "").Replace(" ", "");
                if (card.Length != 16)
                {
                    errorMessage = "شماره کارت باید 16 رقم باشد. ";
                    return false;
                }
            }

            errorMessage = string.Empty;
            return true;
        }

        private AccountModel ReadAccountFromForm()
        {
            var account = new AccountModel
            {
                OWID = _currentOwnerOWID,
                PERID = _ownerID ?? "SE00000000",
                ACOwner = _ownerName ?? "پیش‌فرض",
                ACBank = cmbBankName?.SelectedItem?.ToString() ?? "بانک پیش‌فرض",
                ACCategory = cmbAccCategory?.SelectedItem?.ToString() ?? "دسته‌بندی پیش‌فرض",
                isDefault = chbDefault?.Checked ?? false,
                isPayer = chbPayer?.Checked ?? false,
                isActive = true
            };

            // ✅ پر کردن فیلدهای خالی با مقادیر پیش‌فرض
            string accountNumber = txtAccountNumber?.Text.Trim();
            string cardNumber = txtAccountCard?.Text.Trim();
            string shabaNumber = textBox1?.Text.Trim();

            // اگه شماره حساب خالی باشه
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                account.ACNumber = "000000000000000000000000000";
            }
            else
            {
                account.ACNumber = accountNumber;
            }

            // اگه شماره کارت خالی باشه
            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                account.ACCardNumber = "0000000000000000";
            }
            else
            {
                account.ACCardNumber = cardNumber;
            }

            // اگه شماره شبا خالی باشه
            if (string.IsNullOrWhiteSpace(shabaNumber))
            {
                account.ACshabaNumber = "IR000000000000000000000000";
            }
            else
            {
                account.ACshabaNumber = shabaNumber;

                // اگه IR نداره، اضافه کن
                if (!account.ACshabaNumber.StartsWith("IR") &&
                    !account.ACshabaNumber.StartsWith("ir"))
                {
                    account.ACshabaNumber = "IR" + account.ACshabaNumber;
                }
            }

            // ✅ ACType با گزینه‌های پیش‌فرض ۱ و ۲
            if (account.isPayer)
            {
                account.ACType = "پیش‌فرض ۱"; // تنخواه
            }
            else
            {
                account.ACType = "پیش‌فرض ۲"; // عادی
            }

            return account;
        }

        private void InitializeListViewOwners()
        {
            lstOwners.View = View.Details;
            lstOwners.FullRowSelect = true;
            lstOwners.GridLines = true;
            lstOwners.HideSelection = false;
            lstOwners.BackColor = Color.FromArgb(255, 255, 192);
            lstOwners.Font = new Font("Tahoma", 9F, FontStyle.Regular);
            lstOwners.Columns.Clear();
            lstOwners.Items.Clear();

            // ستون‌ها:  ردیف، کد، نام، نوع، بالانس
            lstOwners.Columns.Add("ردیف", 50, HorizontalAlignment.Center);
            lstOwners.Columns.Add("کد صاحب حساب", 100, HorizontalAlignment.Center);
            lstOwners.Columns.Add("نام صاحب حساب", 200, HorizontalAlignment.Right);
            lstOwners.Columns.Add("نوع", 100, HorizontalAlignment.Center);
            lstOwners.Columns.Add("بالانس (ریال)", 130, HorizontalAlignment.Right);
        }

        private void InitializeListViewAccounts()
        {
            lstBankAccount.View = View.Details;
            lstBankAccount.FullRowSelect = true;
            lstBankAccount.GridLines = true;
            lstBankAccount.HideSelection = false;
            lstBankAccount.BackColor = Color.FromArgb(255, 255, 192);
            lstBankAccount.Font = new Font("Tahoma", 9F, FontStyle.Regular);
            lstBankAccount.Columns.Clear();
            lstBankAccount.Items.Clear();

            // ستون‌ها: ردیف، پیش‌فرض، شماره حساب، کارت، شبا، بانک، نوع، دسته‌بندی، تنخواه
            lstBankAccount.Columns.Add("ردیف", 50, HorizontalAlignment.Center);
            lstBankAccount.Columns.Add("پیش‌فرض", 70, HorizontalAlignment.Center);
            lstBankAccount.Columns.Add("شماره حساب", 120, HorizontalAlignment.Center);
            lstBankAccount.Columns.Add("شماره کارت", 140, HorizontalAlignment.Center);
            lstBankAccount.Columns.Add("شماره شبا", 180, HorizontalAlignment.Center);
            lstBankAccount.Columns.Add("بانک", 120, HorizontalAlignment.Right);
            lstBankAccount.Columns.Add("نوع حساب", 100, HorizontalAlignment.Center);
            lstBankAccount.Columns.Add("دسته‌بندی", 100, HorizontalAlignment.Center);
            lstBankAccount.Columns.Add("تنخواه", 70, HorizontalAlignment.Center);
        }

        private void LoadBanks()
        {
            // در Designer نام کنترل بانک `cmbBankName` است (نه `cmbBank`).
            if (cmbBankName == null) return;

            cmbBankName.Items.Clear();

            try
            {
                var banks = _infoDal.GetValuesByContext("Banks");
                if (banks != null && banks.Count > 0)
                {
                    cmbBankName.Items.AddRange(banks.ToArray());
                }

                cmbBankName.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بارگذاری لیست بانک‌ها:\n{ex.Message}",
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAccountTypes()
        {
            if (cmbAccountType == null) return;

            cmbAccountType.Items.Clear();

            try
            {
                var types = _infoDal.GetValuesByContext("TypeOfAccount");
                if (types != null && types.Count > 0)
                {
                    cmbAccountType.Items.AddRange(types.ToArray());
                }
                cmbAccountType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بارگذاری انواع حساب:\n{ex.Message}",
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAccountCategories()
        {
            if (cmbAccCategory == null) return;

            cmbAccCategory.Items.Clear();

            try
            {
                var categories = _infoDal.GetValuesByContext("AccountCategories");
                if (categories != null && categories.Count > 0)
                {
                    cmbAccCategory.Items.AddRange(categories.ToArray());
                }
                cmbAccCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بارگذاری دسته‌بندی حساب‌ها:\n{ex.Message}",
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOwnerInfo()
        {
            try
            {
                AccountOwnerModel owner;
                string msg;

                if (!_ownerDAL.GetOwnerByRefID(_ownerID, _ownerType, out owner, out msg))
                {
                    MessageBox.Show($"خطا در بارگذاری اطلاعات صاحب حساب:\n{msg}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (owner != null)
                {
                    _currentOwnerOWID = owner.OWID;

                    // پر کردن فیلدها
                    if (txtOwnnerCode != null)
                    {
                        txtOwnnerCode.Text = owner.RefID;
                        txtOwnnerCode.Enabled = false;
                        txtOwnnerCode.BackColor = Color.LightGray;
                    }

                    if (txtAccountOwnerSearch != null)
                    {
                        txtAccountOwnerSearch.Text = owner.ACOwner;
                    }

                    // نمایش اطلاعات در Label (اگر وجود داشته باشد)
                    var lbl = this.Controls.Find("lblOwnerInfo", true).FirstOrDefault() as Label;
                    if (lbl != null)
                    {
                        lbl.Text = $"صاحب حساب: {owner.ACOwner}\n" +
                                   $"کد: {owner.RefID}\n" +
                                   $"نوع: {GetOwnerTypeFa(owner.OWType)}\n" +
                                   $"بالانس: {owner.Balance:N0} ریال";
                        lbl.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بارگذاری اطلاعات صاحب حساب:\n{ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisableOwnerSearch()
        {
            // غیرفعال کردن جستجو در حالت محدود
            if (txtAccountOwnerSearch != null)
            {
                txtAccountOwnerSearch.Enabled = false;
                txtAccountOwnerSearch.BackColor = Color.LightGray;
                txtAccountOwnerSearch.ReadOnly = true;
            }

            if (txtOwnnerCode != null)
            {
                txtOwnnerCode.Enabled = false;
                txtOwnnerCode.BackColor = Color.LightGray;
                txtOwnnerCode.ReadOnly = true;
            }

            // قفل کردن لیست Owners - فقط نمایش، بدون امکان تغییر
            if (lstOwners != null)
            {
                lstOwners.Enabled = false;
                lstOwners.BackColor = Color.LightGray;
            }
        }

        private void LoadAccountsForOwner(string ownerOWID)
        {
            if (lstBankAccount == null) return;

            lstBankAccount.Items.Clear();

            if (string.IsNullOrWhiteSpace(ownerOWID))
            {
                return;
            }

            try
            {
                List<AccountModel> accounts;
                string msg;

                bool result = _accountManager.GetAccountsByOwner(ownerOWID, out accounts, out msg);

                if (!result)
                {
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        MessageBox.Show($"خطا در بارگذاری حساب‌ها:\n{msg}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }

                if (accounts == null || accounts.Count == 0)
                {
                    return;
                }

                int index = 1;
                foreach (var account in accounts)
                {
                    var item = new ListViewItem(index.ToString());
                    item.SubItems.Add(account.isDefault ? "✓" : "");
                    item.SubItems.Add(account.ACNumber ?? "");
                    item.SubItems.Add(account.ACCardNumber ?? "");
                    item.SubItems.Add(account.ACshabaNumber ?? "");
                    item.SubItems.Add(account.ACBank ?? "");
                    item.SubItems.Add(account.ACType ?? "");
                    item.SubItems.Add(account.ACCategory ?? "");
                    item.SubItems.Add(account.isPayer ? "✓" : "");
                    item.Tag = account;

                    if (!account.isActive)
                    {
                        item.ForeColor = Color.Gray;
                    }

                    lstBankAccount.Items.Add(item);
                    index++;
                }

                if (_isRestrictedMode)
                {
                    this.Text = $"مدیریت حساب‌های بانکی - {_ownerName} ({accounts.Count} حساب)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بارگذاری حساب‌ها:\n{ex.Message}",
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllOwners()
        {
            lstOwners.Items.Clear();

            try
            {
                List<AccountOwnerModel> owners;
                string msg;

                if (!_ownerDAL.GetAllOwners(out owners, out msg))
                {
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        MessageBox.Show(msg, "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }

                int index = 1;
                foreach (var owner in owners)
                {
                    var item = new ListViewItem(index.ToString());
                    item.SubItems.Add(owner.RefID ?? "");
                    item.SubItems.Add(owner.ACOwner ?? "");
                    item.SubItems.Add(GetOwnerTypeFa(owner.OWType));
                    item.SubItems.Add(owner.Balance.ToString("N0"));
                    item.Tag = owner;

                    if (owner.Balance < 0)
                        item.SubItems[4].ForeColor = Color.Red;
                    else if (owner.Balance > 0)
                        item.SubItems[4].ForeColor = Color.Green;

                    lstOwners.Items.Add(item);
                    index++;
                }

                this.Text = $"مدیریت حساب‌های بانکی - {owners.Count} صاحب حساب";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بارگذاری صاحبان حساب:\n{ex.Message}",
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOwnersFiltered(string ownerType)
        {
            lstOwners.Items.Clear();

            try
            {
                List<AccountOwnerModel> owners;
                string msg;

                if (!_ownerDAL.GetAllOwners(out owners, out msg))
                {
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        MessageBox.Show(msg, "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }

                var filteredOwners = owners.Where(o =>
                    o.OWType != null &&
                    o.OWType.Equals(ownerType, StringComparison.OrdinalIgnoreCase)
                ).ToList();

                int index = 1;
                foreach (var owner in filteredOwners)
                {
                    var item = new ListViewItem(index.ToString());
                    item.SubItems.Add(owner.RefID ?? "");
                    item.SubItems.Add(owner.ACOwner ?? "");
                    item.SubItems.Add(GetOwnerTypeFa(owner.OWType));
                    item.SubItems.Add(owner.Balance.ToString("N0"));
                    item.Tag = owner;

                    if (owner.Balance < 0)
                        item.SubItems[4].ForeColor = Color.Red;
                    else if (owner.Balance > 0)
                        item.SubItems[4].ForeColor = Color.Green;

                    lstOwners.Items.Add(item);

                    if (_isRestrictedMode && owner.RefID == _ownerID)
                    {
                        item.Selected = true;
                        item.Focused = true;
                    }

                    index++;
                }

                this.Text = $"مدیریت حساب‌های بانکی - {_ownerName} ({filteredOwners.Count} {GetOwnerTypeFa(ownerType)})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بارگذاری صاحبان حساب:\n{ex.Message}",
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstOwners_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOwners.SelectedItems.Count == 0)
            {
                _currentOwnerOWID = null;
                lstBankAccount.Items.Clear();
                return;
            }

            var owner = lstOwners.SelectedItems[0].Tag as AccountOwnerModel;
            if (owner == null)
            {
                _currentOwnerOWID = null;
                lstBankAccount.Items.Clear();
                return;
            }

            _currentOwnerOWID = owner.OWID;

            if (txtOwnnerCode != null)
            {
                txtOwnnerCode.Text = owner.RefID;
            }

            if (txtAccountOwnerSearch != null && !_isRestrictedMode)
            {
                txtAccountOwnerSearch.Text = owner.ACOwner;
            }

            LoadAccountsForOwner(owner.OWID);
        }

        private void txtAccountOwnerSearch_TextChanged(object sender, EventArgs e)
        {
            if (_isRestrictedMode) return;

            string searchText = (txtAccountOwnerSearch.Text ?? string.Empty).Trim().ToLower();

            lstOwners.Items.Clear();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadAllOwners();
                return;
            }

            try
            {
                List<AccountOwnerModel> owners;
                string msg;

                if (!_ownerDAL.GetAllOwners(out owners, out msg))
                {
                    return;
                }

                var filteredOwners = owners.Where(o =>
                    (o.ACOwner != null && o.ACOwner.ToLower().Contains(searchText)) ||
                    (o.RefID != null && o.RefID.ToLower().Contains(searchText))
                ).ToList();

                int index = 1;
                foreach (var owner in filteredOwners)
                {
                    var item = new ListViewItem(index.ToString());
                    item.SubItems.Add(owner.RefID ?? "");
                    item.SubItems.Add(owner.ACOwner ?? "");
                    item.SubItems.Add(GetOwnerTypeFa(owner.OWType));
                    item.SubItems.Add(owner.Balance.ToString("N0"));
                    item.Tag = owner;

                    if (owner.Balance < 0)
                        item.SubItems[4].ForeColor = Color.Red;
                    else if (owner.Balance > 0)
                        item.SubItems[4].ForeColor = Color.Green;

                    lstOwners.Items.Add(item);
                    index++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در جستجو:\n{ex.Message}",
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetOwnerTypeFa(string ownerType)
        {
            switch (ownerType?.ToLower())
            {
                case "seller":
                    return "فروشنده";
                case "customer":
                    return "مشتری";
                case "employee":
                    return "کارمند";
                case "partner":
                    return "شریک";
                default:
                    return ownerType;
            }
        }

        private void cmbAccountState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void DefineBankAccountFRM_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += DefineBankAccountFRM_KeyDown;
        }

        private void DefineBankAccountFRM_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (btnSubmitNewBankAccount != null && btnSubmitNewBankAccount.Enabled)
                        btnSubmitNewBankAccount_Click(sender, e);
                    break;
                case Keys.F3:
                    if (btnUpdateBankAccount != null && btnUpdateBankAccount.Enabled)
                        btnUpdateBankAccount_Click(sender, e);
                    break;
                case Keys.F4:
                    if (btnDeletBankAccount != null && btnDeletBankAccount.Enabled)
                        btnDeletBankAccount_Click(sender, e);
                    break;
                case Keys.Escape:
                    ClearAccountForm();
                    break;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmbAccCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmitNewBankAccount_Click(object sender, EventArgs e)
        {
            string errorMsg;
            if (!ValidateAccountInputs(out errorMsg))
            {
                MessageBox.Show(errorMsg, "خطای اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var account = ReadAccountFromForm();

            try
            {
                string newACID, msg;
                bool result = _accountManager.InsertAccount(
                    account,
                    _userID,
                    _date,
                    _dateValue,
                    _dateDig,
                    out newACID,
                    out msg
                );

                if (result)
                {
                    MessageBox.Show($"حساب با موفقیت ثبت شد.\nکد حساب: {newACID}",
                        "موفق",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadAccountsForOwner(_currentOwnerOWID);
                    ClearAccountForm();
                }
                else
                {
                    MessageBox.Show(!string.IsNullOrWhiteSpace(msg) ? msg : "خطا در ثبت حساب!",
                        "خطا",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در ثبت حساب:\n{ex.Message}",
                    "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtAccountOwner_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDeletBankAccount_Click(object sender, EventArgs e)
        {

            if (lstBankAccount.SelectedItems.Count == 0)
            {
                MessageBox.Show("ابتدا یک حساب را از لیست انتخاب کنید.",
                    "هشدار",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var selectedAccount = lstBankAccount.SelectedItems[0].Tag as AccountModel;
            if (selectedAccount == null)
            {
                MessageBox.Show("خطا در دریافت اطلاعات حساب انتخاب‌شده.",
                    "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"آیا از حذف این حساب مطمئن هستید?\n\nبانک: {selectedAccount.ACBank}\nشماره حساب: {selectedAccount.ACNumber}",
                "تایید حذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                string msg;
                bool result = _accountManager.DeleteAccount(
                    selectedAccount.ACID,
                    _userID,
                    _date,
                    _dateValue,
                    _dateDig,
                    out msg
                );

                if (result)
                {
                    MessageBox.Show("حساب با موفقیت حذف شد.",
                        "موفق",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadAccountsForOwner(_currentOwnerOWID);
                    ClearAccountForm();
                }
                else
                {
                    MessageBox.Show(!string.IsNullOrWhiteSpace(msg) ? msg : "خطا در حذف حساب!",
                        "خطا",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در حذف حساب:\n{ex.Message}",
                    "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnUpdateBankAccount_Click(object sender, EventArgs e)
        {

            if (lstBankAccount.SelectedItems.Count == 0)
            {
                MessageBox.Show("ابتدا یک حساب را از لیست انتخاب کنید.",
                    "هشدار",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string errorMsg;
            if (!ValidateAccountInputs(out errorMsg))
            {
                MessageBox.Show(errorMsg, "خطای اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedAccount = lstBankAccount.SelectedItems[0].Tag as AccountModel;
            if (selectedAccount == null)
            {
                MessageBox.Show("خطا در دریافت اطلاعات حساب انتخاب‌شده.",
                    "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var account = ReadAccountFromForm();
            account.ACID = selectedAccount.ACID;

            try
            {
                string msg;
                bool result = _accountManager.UpdateAccount(
                    account,
                    _userID,
                    _date,
                    _dateValue,
                    _dateDig,
                    out msg
                );

                if (result)
                {
                    MessageBox.Show("حساب با موفقیت ویرایش شد.",
                        "موفق",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadAccountsForOwner(_currentOwnerOWID);
                    ClearAccountForm();
                }
                else
                {
                    MessageBox.Show(!string.IsNullOrWhiteSpace(msg) ? msg : "خطا در ویرایش حساب!",
                        "خطا",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در ویرایش حساب:\n{ex.Message}",
                    "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
