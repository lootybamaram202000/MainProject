using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MainProject.Core.Business;
using MainProject.DataAccess;
using MainProject.Entities;
using MainProject.Helpers;

namespace MainProject.Forms
{
    public partial class OverHeadFRM : Form
    {
        private string _userName;
        private string _userID;
        private List<OverHeadModel> allOverHeads = new List<OverHeadModel>();
        private List<OverHeadModel> currentOverHeads = new List<OverHeadModel>();
        private List<SectionModel> sectionList = new List<SectionModel>();

        private List<OverHeadModel> overheadList = new List<OverHeadModel>();
        private readonly OverHeadManager _manager = new OverHeadManager();

        private bool _isFillingFromList = false;
        private decimal _currentFixedOverhead = 0;
        private decimal _currentVariableOverhead = 0;
        public OverHeadFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
            ReloadOverHeadFormData();
            _userName = LoginInfo.Instance.UserName;
            _userID = LoginInfo.Instance.UserID;
        }

        private void OverHeadFRM_Load(object sender, EventArgs e)
        {
            ReloadOverHeadFormData();
        }

        private void ReloadOverHeadFormData()
        {
            var dal = new OverHeadDAL();
            allOverHeads = dal.GetOverHeadsByFilter(null, null, null, null);
            currentOverHeads = new List<OverHeadModel>(allOverHeads);

            LoadOHCategories();
            LoadFinancialYears();
            LoadFinancialMonths();
            LoadSectionsToCombo();
            LoadOHTypes();
            LoadSectionsToList();
            LoadOHCategoriesToList();
            SetupLstOverHeadColumns();
            SetupLstSectionColumns();
            SetupLstOHCategoryColumns();
            LoadTotalSellCount();
            LoadCurrentYearSource();
            LoadVAT();
            LoadTax();
            txtAVGTotalSell.Text = txtTotalSellsCount.Text;
            cmbOHType.SelectedIndexChanged += FilterAndShowOverHeads;
            cmbCurrentYear1.SelectedIndexChanged += FilterAndShowOverHeads;
            cmbCurrentMounth.SelectedIndexChanged += FilterAndShowOverHeads;
            cmbOHCategory1.SelectedIndexChanged += FilterAndShowOverHeads;

            FilterAndShowOverHeads(this, EventArgs.Empty);
            CalculateFilteredTotals();
            LoadCurrentOverheadSummary();
            FillOverHeadPanels();
        }


        private void FillOverHeadPanels()
        {
            // سربار ثابت
            txtYearlyOverHeadS.Text = _currentFixedOverhead.ToString("0");
            txtMonthlyOverHeadS.Text = (_currentFixedOverhead / 12).ToString("0");
            txtDailyOverHeadS.Text = (_currentFixedOverhead / 365).ToString("0");

            // سربار متغیر
            txtYearlyOverHeadD.Text = _currentVariableOverhead.ToString("0");
            txtMonthlyOverHeadD.Text = (_currentVariableOverhead / 12).ToString("0");
            txtDailyOverHeadD.Text = (_currentVariableOverhead / 365).ToString("0");

            // فرمت سه‌رقمی
            CommonFunctions.FormatTextBoxAsThousandSeparated(txtYearlyOverHeadS);
            CommonFunctions.FormatTextBoxAsThousandSeparated(txtMonthlyOverHeadS);
            CommonFunctions.FormatTextBoxAsThousandSeparated(txtDailyOverHeadS);
            CommonFunctions.FormatTextBoxAsThousandSeparated(txtYearlyOverHeadD);
            CommonFunctions.FormatTextBoxAsThousandSeparated(txtMonthlyOverHeadD);
            CommonFunctions.FormatTextBoxAsThousandSeparated(txtDailyOverHeadD);
        }


        private void LoadCurrentOverheadSummary()
        {
            var infoDAL = new InformationDAL();
            var currentYearStr = infoDAL.GetValuesByContext("CurentYear").FirstOrDefault();

            if (int.TryParse(currentYearStr, out int currentYear))
            {
                var manager = new OverHeadManager();
                manager.CalculateOverHeadSummary(currentYear, out _currentFixedOverhead, out _currentVariableOverhead);

            }
            else
            {
                _currentFixedOverhead = 0;
                _currentVariableOverhead = 0;
            }
        }

        private void FilterAndShowOverHeads(object sender, EventArgs e)
        {
            string ohType = cmbOHType.SelectedIndex >= 0 ? cmbOHType.SelectedItem.ToString().Trim() : null;
            int? year = cmbCurrentYear1.SelectedIndex >= 0 ? int.Parse(cmbCurrentYear1.SelectedItem.ToString()) : (int?)null;

            int? month = null;
            if (cmbCurrentMounth.SelectedItem != null)
            {
                var monthText = CommonFunctions.ConvertPersianDigitsToEnglish(cmbCurrentMounth.SelectedItem.ToString());
                if (int.TryParse(monthText, out int monthValue))
                    month = monthValue;
            }

            string category = cmbOHCategory1.SelectedIndex >= 0 ? cmbOHCategory1.SelectedItem.ToString().Trim() : null;

            currentOverHeads = allOverHeads
                .Where(x =>
                    !x.isDeleted &&
                    (string.IsNullOrEmpty(ohType) || x.OHType?.Trim() == ohType) &&
                    (!year.HasValue || x.FinancialYear == year.Value) &&
                    (!month.HasValue ||
                        (month == 13
                            ? x.FinancialMounth == 13
                            : x.FinancialMounth == month)
                    ) &&
                    (string.IsNullOrEmpty(category) || x.OHCategory?.Trim() == category)
                )
                .ToList();

            lstOverHead1.Items.Clear();
            int row = 1;
            foreach (var item in currentOverHeads)
            {
                var lvi = new ListViewItem(row.ToString());
                lvi.SubItems.Add(item.OHID);
                lvi.SubItems.Add(item.OHTitle);
                lvi.SubItems.Add(item.FinancialYear.ToString());
                lvi.SubItems.Add(item.FinancialMounth?.ToString() ?? "-");
                lvi.SubItems.Add(item.OHType);
                lvi.SubItems.Add(item.OHCategory);
                lvi.SubItems.Add(item.YearlyCost?.ToString("0") ?? "0");
                lvi.SubItems.Add(item.MonthlyCost?.ToString("0") ?? "0");
                lvi.SubItems.Add(item.DATE);
                lvi.SubItems.Add(item.Describtion);
                lvi.SubItems.Add(item.Describtion);
                lstOverHead1.Items.Add(lvi);
                row++;
            }
        }




        private void ResetOverHeadEntryAndRefreshList()
        {
            // 1. ریست کردن فیلدهای ورودی
            txtTitleSOH.Text = "";
            cmbOHType.SelectedIndex = -1;
            cmbCurrentYear1.SelectedIndex = -1;
            cmbCurrentMounth.SelectedIndex = -1;
            cmbOHCategory1.SelectedIndex = -1;
            txtYearlyCostSOH.Text = "";
            txtMonthlyCostSOH.Text = "";
            textBox1.Text = "";
            txtYearlyCostSOH.Enabled = true;
            txtMonthlyCostSOH.Enabled = true;

            // 2. لود مجدد لیست از دیتابیس
            var dal = new OverHeadDAL();
            allOverHeads = dal.GetOverHeadsByFilter(null, null, null, null);
            currentOverHeads = new List<OverHeadModel>(allOverHeads);

            // 3. فیلتر و بروزرسانی نمایش
            FilterAndShowOverHeads(this, EventArgs.Empty);
            CalculateFilteredTotals();
        }
        private void CalculateFilteredTotals()
        {
            decimal fixedYearly = 0;
            decimal variableYearly = 0;

            foreach (ListViewItem item in lstOverHead1.Items)
            {
                string type = item.SubItems[5].Text;
                decimal yearly = decimal.TryParse(item.SubItems[7].Text, out var y) ? y : 0;

                if (type == "ثابت")
                    fixedYearly += yearly;
                else if (type == "متغیر")
                    variableYearly += yearly;
            }
        }



        private void SetupLstOverHeadColumns()
        {
            lstOverHead1.Columns.Clear();
            lstOverHead1.View = View.Details;
            lstOverHead1.Columns.Add("ردیف", 50);
            lstOverHead1.Columns.Add("کد", 100);
            lstOverHead1.Columns.Add("عنوان", 180);
            lstOverHead1.Columns.Add("سال مالی", 80);
            lstOverHead1.Columns.Add("ماه مالی", 80);
            lstOverHead1.Columns.Add("نوع", 90);
            lstOverHead1.Columns.Add("دسته‌بندی", 140);
            lstOverHead1.Columns.Add("سالیانه", 120);
            lstOverHead1.Columns.Add("ماهانه", 120);
            lstOverHead1.Columns.Add("تاریخ", 100);
            lstOverHead1.Columns.Add("توضیحات", 220);
        }
        private void SetupLstSectionColumns()
        {
            lstSection.Columns.Clear();
            lstSection.View = View.Details;
            lstSection.FullRowSelect = true;

            lstSection.Columns.Add("ردیف", 50);
            lstSection.Columns.Add("کد سکشن", 100);
            lstSection.Columns.Add("نام سکشن", 180);
            lstSection.Columns.Add("درصد اختصاص‌یافته", 110);
            lstSection.Columns.Add("فروش سکشن", 100);
            lstSection.Columns.Add("کل فروش", 100);
            lstSection.Columns.Add("سربار هر آیتم", 120);
        }



        private void SetupLstOHCategoryColumns()
        {
            lstOHCategory.Columns.Clear();
            lstOHCategory.View = View.Details;
            lstOHCategory.Columns.Add("ردیف", 50);
            lstOHCategory.Columns.Add("عنوان دسته‌بندی", 200);
        }

        private void LoadTax()
        {
            var infoDAL = new InformationDAL();
            var taxInfo = infoDAL.GetInformationByContext("Tax").FirstOrDefault();

            if (taxInfo != null)
                txtTax.Text = taxInfo.DigitalValue.ToString("0");
            else
                txtTax.Text = "0";
        }

        private void LoadVAT()
        {
            var infoDAL = new InformationDAL();
            var vatInfo = infoDAL.GetInformationByContext("VAT").FirstOrDefault();

            if (vatInfo != null)
                txtVAT.Text = vatInfo.DigitalValue.ToString("0");
            else
                txtVAT.Text = "0";
        }

        private void LoadCurrentYearSource()
        {
            var infoDAL = new InformationDAL();

            // لود همه سال‌های مالی
            var years = infoDAL.GetInformationByContext("FinancialYears");
            cmbCurrentYearSource.Items.Clear();
            foreach (var year in years)
                cmbCurrentYearSource.Items.Add(year.DigitalValue.ToString());

            // انتخاب مقدار پیش‌فرض از CurentYear
            var currentYear = infoDAL.GetValuesByContext("CurentYear").FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(currentYear))
            {
                int index = cmbCurrentYearSource.Items.IndexOf(currentYear);
                if (index >= 0)
                    cmbCurrentYearSource.SelectedIndex = index;
            }
        }

        private void LoadTotalSellCount()
        {
            var infoDAL = new InformationDAL();
            var infoList = infoDAL.GetInformationByContext("TotalCountOfSellOfItems");

            if (infoList.Any())
            {
                var value = infoList.First().DigitalValue;
                txtTotalSellsCount.Text = value.ToString("0");
            }
            else
            {
                txtTotalSellsCount.Text = "0";
            }
        }
        private void LoadSectionsToList()
        {
            lstSection.Items.Clear();
            var sectionDAL = new SectionDAL();
            sectionList = sectionDAL.GetAllSections();

            if (!int.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtTotalSellsCount.Text), out int totalSell))
                totalSell = 0;

            // 👇 محاسبه سربار هر سکشن با مقدار _currentFixedOverhead
            CommonFunctions.RecalculateOverHeadPerItemForAllSections(sectionList, _currentFixedOverhead);

            int row = 1;
            foreach (var sec in sectionList)
            {
                var item = new ListViewItem(row.ToString());
                item.SubItems.Add(sec.SecID);
                item.SubItems.Add(sec.SecTitle);
                item.SubItems.Add(sec.PerCentage.ToString());
                item.SubItems.Add(sec.CountOfSell.ToString());
                item.SubItems.Add(totalSell.ToString());
                item.SubItems.Add(sec.OverHead.ToString("0"));

                lstSection.Items.Add(item);
                row++;
            }
        }


        private void LoadOHCategoriesToList()
        {
            lstOHCategory.Items.Clear();
            var infoDAL = new InformationDAL();
            var categories = infoDAL.GetValuesByContext("OHCategories");

            int row = 1;
            foreach (var cat in categories)
            {
                var item = new ListViewItem(row.ToString()); // ردیف
                item.SubItems.Add(cat);                      // عنوان دسته‌بندی
                lstOHCategory.Items.Add(item);
                row++;
            }
        }

        private void LoadOHTypes()
        {
            var infoDAL = new InformationDAL();
            var ohTypes = infoDAL.GetValuesByContext("OHType");
            cmbOHType.Items.Clear();
            cmbOHType.Items.AddRange(ohTypes.ToArray());
            cmbOHType.SelectedIndexChanged += cmbOHType_SelectedIndexChanged;
            txtMonthlyCostSOH.Enabled = true;
            txtYearlyCostSOH.Enabled = true;

        }

        private void LoadOHCategories()
        {
            var infoDAL = new InformationDAL();
            var categories = infoDAL.GetValuesByContext("OHCategories");
            cmbOHCategory1.Items.Clear();
            cmbOHCategory1.Items.AddRange(categories.ToArray());
        }


        private void LoadFinancialYears()
        {
            var infoDAL = new InformationDAL();
            var years = infoDAL.GetInformationByContext("FinancialYears");
            cmbCurrentYear1.Items.Clear();
            foreach (var item in years)
                cmbCurrentYear1.Items.Add(item.DigitalValue.ToString());

            var curYear = infoDAL.GetValuesByContext("CurentYear").FirstOrDefault();
            if (!string.IsNullOrEmpty(curYear))
                cmbCurrentYear1.SelectedItem = curYear;
        }

        private void LoadFinancialMonths()
        {
            var infoDAL = new InformationDAL();
            var months = infoDAL.GetValuesByContext("Months");
            cmbCurrentMounth.Items.Clear();
            cmbCurrentMounth.Items.AddRange(months.ToArray());
        }


        private void LoadSectionsToCombo()
        {
            var sectionDAL = new SectionDAL();
            var sections = sectionDAL.GetAllSections();
            cmbSection.Items.Clear();
            foreach (var sec in sections)
                cmbSection.Items.Add(sec.SecTitle);
        }

        private void DisplaySectionsInListView(List<SectionModel> sections)
        {
            lstSection.Items.Clear();

            int totalSell = int.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtTotalSellsCount.Text), out int tsc) ? tsc : 0;

            int row = 1;
            foreach (var sec in sections)
            {
                var item = new ListViewItem(row.ToString());
                item.SubItems.Add(sec.SecID);
                item.SubItems.Add(sec.SecTitle);
                item.SubItems.Add(sec.PerCentage.ToString());
                item.SubItems.Add(sec.CountOfSell.ToString());
                item.SubItems.Add(totalSell.ToString());
                item.SubItems.Add(sec.OverHead.ToString("0"));

                lstSection.Items.Add(item);
                row++;
            }
        }



        private void btnEditBasicItem_Click(object sender, EventArgs e)
        {
            ResetOverHeadEntryAndRefreshList();

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void btnAddSOH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitleSOH.Text) ||
                           cmbOHType.SelectedIndex == -1 ||
                           cmbCurrentYear1.SelectedIndex == -1 ||
                           cmbOHCategory1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفاً تمام فیلدهای ضروری را تکمیل کنید.");
                return;
            }

            string costYearStr = CommonFunctions.ConvertPersianDigitsToEnglish(txtYearlyCostSOH.Text.Trim());
            string costMonthStr = CommonFunctions.ConvertPersianDigitsToEnglish(txtMonthlyCostSOH.Text.Trim());

            var model = new OverHeadModel
            {
                OHTitle = txtTitleSOH.Text.Trim(),
                OHType = cmbOHType.SelectedItem.ToString(),
                FinancialYear = int.Parse(cmbCurrentYear1.SelectedItem.ToString()),
                FinancialMounth = cmbCurrentMounth.SelectedIndex >= 0 ? cmbCurrentMounth.SelectedIndex + 1 : 0,
                OHCategory = cmbOHCategory1.SelectedItem.ToString(),
                Describtion = textBox1.Text.Trim(),
                DATE = CommonFunctions.GetPersianDate(),
                DATEVALUE = DateTime.Now,
                DATEDIG = int.Parse(CommonFunctions.GetPersianDateNumeric()),
                LastUpdate = $"Inserted by '{_userName}' : {CommonFunctions.GetPersianDate()}",
                isDeleted = false
            };

            if (model.OHType == "ثابت")
            {
                if (!decimal.TryParse(costYearStr, out decimal ycost))
                {
                    MessageBox.Show("هزینه سالیانه نامعتبر است.");
                    return;
                }
                model.YearlyCost = ycost;
                model.MonthlyCost = ycost / 12;
            }
            else if (model.OHType == "متغیر")
            {
                if (!decimal.TryParse(costMonthStr, out decimal mcost))
                {
                    MessageBox.Show("هزینه ماهیانه نامعتبر است.");
                    return;
                }
                model.MonthlyCost = mcost;
                model.YearlyCost = 0;
            }

            var dal = new OverHeadDAL();
            string newOHID = dal.InsertOverHead(model, _userName);

            MessageBox.Show($"سربار با موفقیت ثبت شد. کد ثبت: {newOHID}");
            FilterAndShowOverHeads(this, EventArgs.Empty);
            CalculateFilteredTotals();
            ResetOverHeadEntryAndRefreshList();

        }

        private void btnSubmitSectionOVERHEAD_Click(object sender, EventArgs e)
        {
            if (sectionList == null || sectionList.Count == 0)
            {
                MessageBox.Show("لیست سکشن‌ها خالی است.");
                return;
            }

            if (!int.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtTotalSellsCount.Text.Trim()), out int totalSell) || totalSell <= 0)
            {
                MessageBox.Show("تعداد کل فروش معتبر نیست.");
                return;
            }

            if (!CommonFunctions.ValidateSectionList(sectionList, totalSell, out string errorMsg))
            {
                MessageBox.Show(errorMsg);
                return;
            }

            var manager = new OverHeadManager();
            bool success = manager.SubmitSectionOverHeads(sectionList, out string dbError);

            if (success)
            {
                MessageBox.Show("اطلاعات سربار سکشن‌ها با موفقیت ثبت شد.");
            }
            else
            {
                MessageBox.Show("خطا در ثبت اطلاعات: " + dbError);
            }
            ReloadOverHeadFormData();
            DisplaySectionsInListView(sectionList);
            CommonFunctions.RecalculateOverHeadPerItemForAllSections(sectionList, _currentFixedOverhead);


        }

        private void btnSubmitTotalSellsCount_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTotalSellsCount.Text, out decimal count) || count < 0)
            {
                MessageBox.Show("تعداد فروش باید عددی مثبت باشد.");
                return;
            }

            var manager = new InformationsManager();
            var info = manager.GetForComboBox("TotalCountOfSellOfItems").FirstOrDefault();
            if (info == null)
            {
                MessageBox.Show("مقدار اولیه TotalCountOfSellOfItems پیدا نشد.");
                return;
            }

            info.DigitalValue = count;
            manager.EditInformation(info);
            MessageBox.Show("تعداد فروش روزانه با موفقیت ثبت شد.");
            ReloadOverHeadFormData();
        }

        private void btnSetFinancialYear_Click(object sender, EventArgs e)
        {
            if (cmbCurrentYearSource.SelectedItem == null)
            {
                MessageBox.Show("لطفاً یک سال مالی انتخاب کنید.");
                return;
            }

            string selectedYear = cmbCurrentYearSource.SelectedItem.ToString();
            var manager = new InformationsManager();
            var info = manager.GetForComboBox("CurentYear").FirstOrDefault();
            if (info == null)
            {
                MessageBox.Show("مقدار اولیه CurentYear پیدا نشد.");
                return;
            }

            info.StringValuePer = selectedYear;
            manager.EditInformation(info);
            MessageBox.Show("سال مالی جاری با موفقیت تنظیم شد.");
            ReloadOverHeadFormData();
        }

        private void btnAddNewYear_Click(object sender, EventArgs e)
        {
            InfoEditorForm infoEditorForm = new InfoEditorForm("FinancialYears");
            infoEditorForm.ShowDialog();
            ReloadOverHeadFormData();
        }

        private void btnSubmitVAT_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtVAT.Text, out decimal vat) || vat < 0 || vat > 40)
            {
                MessageBox.Show("مقدار مالیات بر ارزش افزوده باید بین ۰ تا ۴۰ باشد.");
                return;
            }

            var manager = new InformationsManager();
            var info = manager.GetForComboBox("VAT").FirstOrDefault();
            if (info == null)
            {
                MessageBox.Show("مقدار اولیه VAT پیدا نشد.");
                return;
            }

            info.DigitalValue = vat;
            manager.EditInformation(info);
            MessageBox.Show("مقدار VAT با موفقیت به‌روزرسانی شد.");
            LoadVAT();
        }

        private void btnSubmitTAX_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTax.Text, out decimal tax) || tax < 0 || tax > 40)
            {
                MessageBox.Show("مقدار مالیات باید بین ۰ تا ۴۰ باشد.");
                return;
            }

            var manager = new InformationsManager();
            var info = manager.GetForComboBox("Tax").FirstOrDefault();
            if (info == null)
            {
                MessageBox.Show("مقدار اولیه Tax پیدا نشد.");
                return;
            }

            info.DigitalValue = tax;
            manager.EditInformation(info);
            MessageBox.Show("مقدار Tax با موفقیت به‌روزرسانی شد.");
            LoadTax();
        }

        private void btnAddNewOHCategory_Click(object sender, EventArgs e)
        {
            InfoEditorForm infoEditorForm = new InfoEditorForm("OHCategories");  
            infoEditorForm.ShowDialog();
            ReloadOverHeadFormData();

        }

        private void btnSubmitNewSection_Click(object sender, EventArgs e)
        {
            DefineSectionsFRM defineSectionsFRM = new DefineSectionsFRM();
            defineSectionsFRM.ShowDialog();
            ReloadOverHeadFormData();
        }

        private void txtAVGSectionSell_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPercentage_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDeleteSOH_Click(object sender, EventArgs e)
        {
            if (lstOverHead1.SelectedItems.Count == 0)
            {
                MessageBox.Show("لطفاً یک آیتم برای حذف انتخاب کنید.");
                return;
            }

            var result = MessageBox.Show("آیا از حذف این سربار مطمئن هستید؟", "تأیید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;

            string ohid = lstOverHead1.SelectedItems[0].SubItems[1].Text;
            var dal = new OverHeadDAL();
            bool success = dal.DeleteOverHead(ohid);

            if (success)
            {
                MessageBox.Show("سربار با موفقیت حذف شد.");
                ResetOverHeadEntryAndRefreshList();
            }
            else
            {
                MessageBox.Show("خطا در حذف اطلاعات.");
            }
            ReloadOverHeadFormData();
        }

        private void lstOverHead1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isFillingFromList = true;
            if (lstOverHead1.SelectedItems.Count == 0) return;

            // غیرفعال‌سازی ایونت‌ها
            cmbOHType.SelectedIndexChanged -= FilterAndShowOverHeads;
            cmbCurrentYear1.SelectedIndexChanged -= FilterAndShowOverHeads;
            cmbCurrentMounth.SelectedIndexChanged -= FilterAndShowOverHeads;
            cmbOHCategory1.SelectedIndexChanged -= FilterAndShowOverHeads;
            cmbOHType.SelectedIndexChanged -= cmbOHType_SelectedIndexChanged;

            var selected = lstOverHead1.SelectedItems[0];
            string ohid = selected.SubItems[1].Text;
            var model = allOverHeads.FirstOrDefault(x => x.OHID == ohid);
            if (model == null) return;

            txtTitleSOH.Text = model.OHTitle;
            cmbOHType.SelectedItem = model.OHType;
            cmbCurrentYear1.SelectedItem = model.FinancialYear.ToString();
            cmbCurrentMounth.SelectedIndex = model.FinancialMounth.HasValue ? model.FinancialMounth.Value - 1 : -1;
            textBox1.Text = model.Describtion;

            // دسته‌بندی
            cmbOHCategory1.SelectedItem = cmbOHCategory1.Items
                .Cast<object>()
                .FirstOrDefault(item => item.ToString().Trim() == (model.OHCategory ?? "").Trim());

            // فعال‌سازی دستی TextBoxها و مقداردهی دقیق
            if (model.OHType == "ثابت")
            {
                txtYearlyCostSOH.Enabled = true;
                txtMonthlyCostSOH.Enabled = false;
                txtYearlyCostSOH.Text = model.YearlyCost?.ToString("0") ?? "0";
                txtMonthlyCostSOH.Text = model.MonthlyCost?.ToString("0") ?? "0";  // برای نمایش دقیق
            }
            else if (model.OHType == "متغیر")
            {
                txtYearlyCostSOH.Enabled = false;
                txtMonthlyCostSOH.Enabled = true;
                txtYearlyCostSOH.Text = model.YearlyCost?.ToString("0") ?? "0";
                txtMonthlyCostSOH.Text = model.MonthlyCost?.ToString("0") ?? "0";
            }
            else
            {
                txtYearlyCostSOH.Enabled = true;
                txtMonthlyCostSOH.Enabled = true;
                txtYearlyCostSOH.Text = model.YearlyCost?.ToString("0") ?? "0";
                txtMonthlyCostSOH.Text = model.MonthlyCost?.ToString("0") ?? "0";
            }

            // بازگردانی ایونت‌ها
            cmbOHType.SelectedIndexChanged += cmbOHType_SelectedIndexChanged;
            cmbOHType.SelectedIndexChanged += FilterAndShowOverHeads;
            cmbCurrentYear1.SelectedIndexChanged += FilterAndShowOverHeads;
            cmbCurrentMounth.SelectedIndexChanged += FilterAndShowOverHeads;
            cmbOHCategory1.SelectedIndexChanged += FilterAndShowOverHeads;

            _isFillingFromList = false;
        }

        private void cmbOHType_SelectedIndexChanged(object sender, EventArgs e)
       
        {
            if (_isFillingFromList) return;

            string selected = cmbOHType.SelectedItem?.ToString();

            if (selected == "ثابت")
            {
                txtMonthlyCostSOH.Enabled = false;
                txtYearlyCostSOH.Enabled = true;

                cmbCurrentMounth.Enabled = false;
                if (cmbCurrentMounth.Items.Count > 0)
                    cmbCurrentMounth.Enabled = false;
                cmbCurrentMounth.SelectedIndex = cmbCurrentMounth.Items.Cast<object>()
                    .ToList()
                    .FindIndex(x => x.ToString().Trim() == "13"); // یا عنوان «همه ماه‌ها» به‌جای عدد ۱۳

            }
            else if (selected == "متغیر")
            {
                txtMonthlyCostSOH.Enabled = true;
                txtYearlyCostSOH.Enabled = false;

                cmbCurrentMounth.Enabled = true;
                cmbCurrentMounth.SelectedIndex = -1;
            }
            else
            {
                txtMonthlyCostSOH.Enabled = true;
                txtYearlyCostSOH.Enabled = true;

                cmbCurrentMounth.Enabled = true;
                cmbCurrentMounth.SelectedIndex = -1;
            }

            txtMonthlyCostSOH.Text = "";
            txtYearlyCostSOH.Text = "";

            // اعمال فیلتر روی لیست
            FilterAndShowOverHeads(this, EventArgs.Empty);
        }

        private void tpgSubmitOH_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateSOH_Click(object sender, EventArgs e)
        {
            if (lstOverHead1.SelectedItems.Count == 0)
            {
                MessageBox.Show("لطفاً یک آیتم برای ویرایش انتخاب کنید.");
                return;
            }

            var selected = lstOverHead1.SelectedItems[0];
            string ohid = selected.SubItems[1].Text;
            var oldModel = allOverHeads.FirstOrDefault(x => x.OHID == ohid);
            if (oldModel == null)
            {
                MessageBox.Show("اطلاعات انتخاب‌شده نامعتبر است.");
                return;
            }

            // بررسی اعتبارسنجی
            if (string.IsNullOrWhiteSpace(txtTitleSOH.Text) ||
                cmbOHType.SelectedIndex == -1 ||
                cmbCurrentYear1.SelectedIndex == -1 ||
                cmbOHCategory1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفاً تمام فیلدهای ضروری را تکمیل کنید.");
                return;
            }

            string costYearStr = CommonFunctions.ConvertPersianDigitsToEnglish(txtYearlyCostSOH.Text.Trim());
            string costMonthStr = CommonFunctions.ConvertPersianDigitsToEnglish(txtMonthlyCostSOH.Text.Trim());
            string yearStr = CommonFunctions.ConvertPersianDigitsToEnglish(cmbCurrentYear1.SelectedItem.ToString());
            int monthValue = 13; // پیش‌فرض برای همه ماه‌ها
            if (cmbCurrentMounth.SelectedItem != null)
            {
                var raw = cmbCurrentMounth.SelectedItem.ToString().Trim();
                raw = CommonFunctions.ConvertPersianDigitsToEnglish(raw);
                int.TryParse(raw, out monthValue); // اگر نشد، همون 13 باقی می‌مونه
            }


            var model = new OverHeadModel
            {
                OHID = ohid,
                OHTitle = txtTitleSOH.Text.Trim(),
                OHType = cmbOHType.SelectedItem.ToString(),
                FinancialYear = int.Parse(yearStr),
                FinancialMounth = monthValue,
                OHCategory = cmbOHCategory1.SelectedItem.ToString(),
                Describtion = textBox1.Text.Trim(),
                LastUpdate = $"Updated by '{_userName}' : {CommonFunctions.GetPersianDate()}",
                isDeleted = false
            };

            if (model.OHType == "ثابت")
            {
                if (!decimal.TryParse(costYearStr, out decimal ycost))
                {
                    MessageBox.Show("هزینه سالیانه نامعتبر است.");
                    return;
                }
                model.YearlyCost = ycost;
                model.MonthlyCost = ycost / 12;
                model.FinancialMounth = 13;
            }
            else if (model.OHType == "متغیر")
            {
                if (!decimal.TryParse(costMonthStr, out decimal mcost))
                {
                    MessageBox.Show("هزینه ماهیانه نامعتبر است.");
                    return;
                }
                model.MonthlyCost = mcost;
                model.YearlyCost = 0;
            }

            var dal = new OverHeadDAL();
            bool success = dal.UpdateOverHead(model);

            if (success)
            {
                MessageBox.Show("ویرایش با موفقیت انجام شد.");
                ResetOverHeadEntryAndRefreshList();
            }
            else
            {
                MessageBox.Show("خطا در هنگام بروزرسانی اطلاعات.");
            }
            ReloadOverHeadFormData();
        }

        private void btnRefreshForm_Click(object sender, EventArgs e)
        {
            ReloadOverHeadFormData();
        }

        private void tpgDefineCalculation_Click(object sender, EventArgs e)
        {

        }

        private void lstSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSection.SelectedItems.Count == 0)
                return;

            var selected = lstSection.SelectedItems[0];

            string secID = selected.SubItems[1].Text;
            string secTitle = selected.SubItems[2].Text;
            string countOfSell = selected.SubItems[4].Text;
            string percentage = selected.SubItems[3].Text;

            cmbSection.SelectedItem = secTitle;
            txtAVGSectionSell.Text = countOfSell;
            txtPercentage.Text = percentage;

            // مقداردهی به سربار هر آیتم
            var section = sectionList.FirstOrDefault(x => x.SecID == secID);
            if (section != null)
            {
                txtOverHeadPerItem.Text = section.OverHead.ToString("0");
                CommonFunctions.FormatTextBoxAsThousandSeparated(txtOverHeadPerItem);
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (cmbSection.SelectedIndex < 0)
            {
                MessageBox.Show("لطفاً یک سکشن را انتخاب کنید.");
                return;
            }

            string selectedSection = cmbSection.SelectedItem.ToString().Trim();
            var section = sectionList.FirstOrDefault(s => s.SecTitle == selectedSection);
            if (section == null)
            {
                MessageBox.Show("سکشن انتخاب‌شده یافت نشد.");
                return;
            }

            // تبدیل فارسی به انگلیسی
            string percentageText = CommonFunctions.ConvertPersianDigitsToEnglish(txtPercentage.Text.Trim());
            string countText = CommonFunctions.ConvertPersianDigitsToEnglish(txtAVGSectionSell.Text.Trim());

            if (!byte.TryParse(percentageText, out byte percent) || percent > 100)
            {
                MessageBox.Show("درصد وارد شده معتبر نیست (بین 0 تا 100).");
                return;
            }

            if (!short.TryParse(countText, out short count) || count < 0)
            {
                MessageBox.Show("تعداد فروش وارد شده معتبر نیست.");
                return;
            }

            int totalSell = int.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtTotalSellsCount.Text.Trim()), out int tsc) ? tsc : 0;
            int currentSum = sectionList.Where(s => !s.isDeleted && s.SecID != section.SecID).Sum(s => s.CountOfSell) + count;

            if (currentSum > totalSell)
            {
                MessageBox.Show("مجموع فروش سکشن‌ها از کل فروش بیشتر شده است.");
                return;
            }

            // مقداردهی جدید
            section.PerCentage = percent;
            section.CountOfSell = count;

            // محاسبه با سربار ثابت فقط
            section.OverHead = CommonFunctions.CalculateOverHeadPerItem(_currentFixedOverhead, percent, count);
            CommonFunctions.RecalculateOverHeadPerItemForAllSections(sectionList, _currentFixedOverhead);
            DisplaySectionsInListView(sectionList);
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSubmitSectionDraft_Click(object sender, EventArgs e)
        {
            if (sectionList == null || sectionList.Count == 0)
            {
                MessageBox.Show("لیست سکشن‌ها خالی است.");
                return;
            }

            var sectionTable = new DataTable();
            sectionTable.Columns.Add("SecID", typeof(string));
            sectionTable.Columns.Add("SecTitle", typeof(string));
            sectionTable.Columns.Add("OverHead", typeof(decimal));
            sectionTable.Columns.Add("PerCentage", typeof(byte));
            sectionTable.Columns.Add("CountOfSell", typeof(short));

            foreach (var sec in sectionList.Where(s => !s.isDeleted))
            {
                sectionTable.Rows.Add(sec.SecID, sec.SecTitle, sec.OverHead, sec.PerCentage, sec.CountOfSell);
            }

            var manager = new OverHeadManager();
            bool success = manager.SubmitSectionDraft(sectionTable, out string errorMsg);

            if (success)
            {
                MessageBox.Show("پیش‌نویس ورودی سکشن با موفقیت ثبت شد.");
            }
            else
            {
                MessageBox.Show("خطا در ثبت پیش‌نویس:\n" + errorMsg, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmitSubSectionDraft_Click(object sender, EventArgs e)
        {
            if (lstSubSection.Items.Count == 0)
            {
                MessageBox.Show("لیست زیرسکشن‌ها خالی است.");
                return;
            }

            var subSectionTable = new DataTable();
            subSectionTable.Columns.Add("SSID", typeof(string));
            subSectionTable.Columns.Add("SSTitle", typeof(string));
            subSectionTable.Columns.Add("SecID", typeof(string));
            subSectionTable.Columns.Add("OverHead", typeof(decimal));
            subSectionTable.Columns.Add("PerCentage", typeof(byte));
            subSectionTable.Columns.Add("CountOfSell", typeof(short));

            foreach (ListViewItem item in lstSubSection.Items)
            {
                string ssid = item.SubItems[1].Text;
                string sstitle = item.SubItems[2].Text;
                string secid = item.SubItems[3].Text;
                decimal overhead = decimal.TryParse(item.SubItems[4].Text, out var oh) ? oh : 0;
                byte percentage = byte.TryParse(item.SubItems[5].Text, out var pct) ? pct : (byte)0;
                short countOfSell = short.TryParse(item.SubItems[6].Text, out var cos) ? cos : (short)0;

                subSectionTable.Rows.Add(ssid, sstitle, secid, overhead, percentage, countOfSell);
            }

            var manager = new OverHeadManager();
            bool success = manager.SubmitSubSectionDraft(subSectionTable, out string errorMsg);

            if (success)
            {
                MessageBox.Show("پیش‌نویس ورودی زیرسکشن با موفقیت ثبت شد.");
            }
            else
            {
                MessageBox.Show("خطا در ثبت پیش‌نویس:\n" + errorMsg, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalculateAllocation_Click(object sender, EventArgs e)
        {
            var manager = new OverHeadManager();
            var results = manager.CalculateAllocation(out string errorMsg);

            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show("خطا در محاسبه تخصیص سربار:\n" + errorMsg, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (results == null || results.Rows.Count == 0)
            {
                MessageBox.Show("نتیجه‌ای برای نمایش وجود ندارد.");
                return;
            }

            DisplayCalculationResults(results);
            MessageBox.Show("محاسبه تخصیص سربار با موفقیت انجام شد.");
        }

        private void DisplayCalculationResults(DataTable results)
        {
            if (results == null || results.Rows.Count == 0)
                return;

            MessageBox.Show($"نتایج محاسبه:\n{results.Rows.Count} ردیف بازگشت داده شد.\n\nلطفاً نتایج را در گرید یا کنترل مناسب بررسی کنید.", 
                "نتایج محاسبه", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
