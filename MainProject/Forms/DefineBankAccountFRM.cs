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
        private AccountManager _accountManager;
        private AccountOwnerDAL _ownerDAL;

        private string _ownerType;
        private string _ownerID;
        private string _ownerName;
        private bool _isRestrictedMode;

        private string _currentOwnerOWID;

        public DefineBankAccountFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();

            _accountManager = new AccountManager();
            _ownerDAL = new AccountOwnerDAL();
            _isRestrictedMode = false;

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

            _isRestrictedMode = true;
            _ownerType = ownerType;
            _ownerID = ownerID;
            _ownerName = ownerName ?? ownerID;

            InitializeForm();
            LoadOwnerInfo();
            DisableOwnerSearch();
            LoadAccountsForOwner();
        }

        private void InitializeForm()
        {
            this.Text = _isRestrictedMode
                ? $"مدیریت حساب‌های بانکی - {_ownerName}"
                : "مدیریت حساب‌های بانکی";

            // اگر در Designer این کنترل‌ها وجود داشته باشند، این متدها باید تکمیل شوند.
            // فعلاً برای جلوگیری از خطاهای کامپایل/اجرا در حالت فعلی پروژه، حداقل نگه داشته شده‌اند.
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بارگذاری اطلاعات صاحب حساب:\n{ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisableOwnerSearch()
        {
            // این پروژه ممکن است کنترل‌های زیر را در Designer نداشته باشد.
            // فعلاً این متد بدون تغییر UI می‌ماند.
        }

        private void LoadAccountsForOwner()
        {
            // TODO: در صورت موجود بودن ListView مربوطه (مثلاً lstAccounts) این بخش تکمیل شود.
            // فعلاً فقط عنوان فرم را بر اساس Owner تنظیم می‌کنیم.
            if (_isRestrictedMode)
                this.Text = $"مدیریت حساب‌های بانکی - {_ownerName}";
        }

        private void LoadAllOwners()
        {
            // TODO: برای حالت غیرمحدود، لیست Owners را در UI لود کنید.
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

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmbAccCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmitNewBankAccount_Click(object sender, EventArgs e)
        {

        }

        private void txtAccountOwner_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDeletBankAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateBankAccount_Click(object sender, EventArgs e)
        {

        }
    }
}
