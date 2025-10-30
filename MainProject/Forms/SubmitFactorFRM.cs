using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MainProject.DataAccess;
using MainProject.Entities;
using MainProject.Helpers;

namespace MainProject.Forms
{
    public partial class SubmitFactorFRM : Form
    {
        public SubmitFactorFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
            InitializeLoginInfo();
            LoadFormData();
            SetupListViews();
            AttachHandlers();
        }


            private List<SellerModel> sellers;
            private List<AccountModel> accounts;
            private string userID;
            private string date;
            private DateTime dateValue;
            private int dateDig;



            private void InitializeLoginInfo()
            {
                userID = LoginInfo.Instance.UserID;
                date = LoginInfo.Instance.Date;
                dateValue = LoginInfo.Instance.DateValue;
                dateDig = LoginInfo.Instance.DateDig;
            }

            private void LoadFormData()
            {
                LoadSellers();
                LoadAccounts();
                LoadPaymentTypes();
                LoadPaymentStatuses();
            }

            private void LoadSellers()
            {
                var sellerDAL = new SellerDAL();
                sellers = sellerDAL.GetAllSellers();
                cmbSellers.Items.Clear();
                foreach (var s in sellers)
                    cmbSellers.Items.Add(s.SellerName);
            }


            private void LoadAccounts()
            {
                var accountDAL = new AccountDAL();
                accounts = accountDAL.GetAllAccounts("SE");
                cmbPaymentAccount.Items.Clear();
                foreach (var a in accounts)
                    cmbPaymentAccount.Items.Add(a.ACOwner + " - " + a.ACNumber);
            }

            private void LoadPaymentTypes()
            {
                var infoDAL = new InformationDAL();
                var types = infoDAL.GetAllPaymentTypes();
                cmbPaymentType.Items.Clear();
                foreach (var t in types)
                    cmbPaymentType.Items.Add(t);
            }

            private void LoadPaymentStatuses()
            {
                var infoDAL = new InformationDAL();
                var statuses = infoDAL.GetAllPaymentStatuses();
                cmbPaymentStatus.Items.Clear();
                foreach (var s in statuses)
                    cmbPaymentStatus.Items.Add(s);
            }

            private void SetupListViews()
            {
            lstSubFactor.View = View.Details;
            lstSubFactor.Columns.Clear();
            lstSubFactor.Columns.Add("ردیف", 50);
            lstSubFactor.Columns.Add("کد کالا", 100);
            lstSubFactor.Columns.Add("نام کالا", 200);
            lstSubFactor.Columns.Add("تعداد", 80);
            lstSubFactor.Columns.Add("قیمت واحد", 120);
            lstSubFactor.Columns.Add("قیمت کل", 120);
            }

            private void AttachHandlers()
            {
                CommonFunctions.AssignThousandSeparatorHandler(txtTotalPrice);
                CommonFunctions.AssignThousandSeparatorHandler(txtVAT);
                CommonFunctions.AssignThousandSeparatorHandler(txtShipping);
                CommonFunctions.AssignThousandSeparatorHandler(txtFinalPaid);

            txtTotalPrice.TextChanged += OnFactorPriceTextChanged;
                txtVAT.TextChanged += OnFactorPriceTextChanged;
                txtShipping.TextChanged += OnFactorPriceTextChanged;
            }

            private void OnFactorPriceTextChanged(object sender, EventArgs e)
            {
                CalculateFinalTotal();
            }

            private void CalculateFinalTotal()
            {
                int total = CommonFunctions.SafeParseInt(CommonFunctions.ConvertPersianDigitsToEnglish(txtTotalPrice.Text));
                int vat = CommonFunctions.SafeParseInt(CommonFunctions.ConvertPersianDigitsToEnglish(txtVAT.Text));
                int shipping = CommonFunctions.SafeParseInt(CommonFunctions.ConvertPersianDigitsToEnglish(txtShipping.Text));

                int result = total + vat + shipping;
            txtFinalPaid.Text = CommonFunctions.FormatWithThousandsSeparator(result);
            }

            private void txtSellerFactorCode_TextChanged(object sender, EventArgs e) { }
            private void txtQuantity_TextChanged(object sender, EventArgs e) { }
            private void label20_Click(object sender, EventArgs e) { }
            private void txtVAT_TextChanged(object sender, EventArgs e) { }
            private void label16_Click(object sender, EventArgs e) { }
            private void label24_Click(object sender, EventArgs e) { }
            private void label25_Click(object sender, EventArgs e) { }
            private void btnSubmitSubFactor_Click(object sender, EventArgs e) { }
            private void btnSubmitFinalFactor_Click(object sender, EventArgs e) { }
    


        private void SubmitFactorFRM_Load(object sender, EventArgs e)
        {

        }
    }
}
