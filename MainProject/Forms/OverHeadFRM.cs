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
        private sealed class SubSectionRef
        {
            public string SSID { get; set; }
            public string SecID { get; set; }
            public string SSTitle { get; set; }

            public override string ToString() => SSTitle;
        }

        // Keep the existing constants but remap to the new visible column positions
        // Columns: Row, Title, OverHead, Percentage, CountOfSell
        private const int SUBSECTION_COL_ROW = 0;
        private const int SUBSECTION_COL_SSTITLE = 1;
        private const int SUBSECTION_COL_OVERHEAD = 2;
        private const int SUBSECTION_COL_PERCENTAGE = 3;
        private const int SUBSECTION_COL_COUNTOFSELL = 4;

        private readonly SubSectionDAL _subSectionDal = new SubSectionDAL();

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
            // keep existing validation behavior
            int totalSell;
            if (!int.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(txtAVGTotalSell.Text ?? "").Trim(), out totalSell))
                totalSell = 0;

            if (!CommonFunctions.ValidateSectionList(sectionList ?? new List<SectionModel>(), totalSell, out var errorMsg))
            {
                MessageBox.Show(errorMsg);
                return;
            }

            // Step 1: Submit Section Draft
            if (!SubmitSectionDraftInternal(out var msg1))
            {
                MessageBox.Show(string.IsNullOrWhiteSpace(msg1) ? "خطا در ثبت پیش‌نویس سکشن." : msg1);
                return;
            }

            // Step 2: Submit SubSection Draft
            if (!SubmitSubSectionDraftInternal(out var msg2))
            {
                MessageBox.Show(string.IsNullOrWhiteSpace(msg2) ? "خطا در ثبت پیش‌نویس زیرسکشن." : msg2);
                return;
            }

            // Step 3: Calculate Allocation
            var results = _manager.CalculateAllocation(out var msg3);
            if (!string.IsNullOrWhiteSpace(msg3))
            {
                MessageBox.Show(msg3);
                return;
            }

            DisplayCalculationResults(results);
        }

        private void btnSubmitSectionDraft_Click(object sender, EventArgs e)
        {
            if (!SubmitSectionDraftInternal(out var msg))
            {
                MessageBox.Show(string.IsNullOrWhiteSpace(msg) ? "خطا در ثبت پیش‌نویس سکشن." : msg);
                return;
            }

            MessageBox.Show("پیش‌نویس سکشن با موفقیت ثبت شد.");
        }

        private void btnSubmitSubSectionDraft_Click(object sender, EventArgs e)
        {
            if (!SubmitSubSectionDraftInternal(out var msg))
            {
                MessageBox.Show(string.IsNullOrWhiteSpace(msg) ? "خطا در ثبت پیش‌نویس زیرسکشن." : msg);
                return;
            }

            MessageBox.Show("پیش‌نویس زیرسکشن با موفقیت ثبت شد.");
        }

        private void tpgSubmitOH_Click_Duplicate1(object sender, EventArgs e)
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

        private void LoadSubSectionsForSelectedSection(string secId)
        {
            cmbSubSection.DataSource = null;
            cmbSubSection.Items.Clear();

            if (string.IsNullOrWhiteSpace(secId))
            {
                cmbSubSection.SelectedIndex = -1;
                return;
            }

            var dt = _subSectionDal.GetSubSectionsBySectionId(secId);
            var list = new List<SubSectionRef>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SubSectionRef
                {
                    SSID = row["SSID"]?.ToString(),
                    SecID = row["SecID"]?.ToString(),
                    SSTitle = row["SSTitle"]?.ToString()
                });
            }

            cmbSubSection.DisplayMember = nameof(SubSectionRef.SSTitle);
            cmbSubSection.ValueMember = nameof(SubSectionRef.SSID);
            cmbSubSection.DataSource = list;
            cmbSubSection.SelectedIndex = -1;
        }

        private void lstSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSection.SelectedItems.Count == 0)
            {
                LoadSubSectionsForSelectedSection(null);
                return;
            }

            var selected = lstSection.SelectedItems[0].Tag as SectionModel;
            LoadSubSectionsForSelectedSection(selected?.SecID);
        }

        private void btnAddToSSList_Click(object sender, EventArgs e)
        {
            if (cmbSubSection.SelectedItem == null)
            {
                MessageBox.Show("ابتدا یک زیرسکشن را انتخاب کنید.");
                return;
            }

            var selectedSubSectionRef = cmbSubSection.SelectedItem as SubSectionRef;
            if (selectedSubSectionRef == null || string.IsNullOrWhiteSpace(selectedSubSectionRef.SSID) || string.IsNullOrWhiteSpace(selectedSubSectionRef.SecID))
            {
                MessageBox.Show("زیرسکشن انتخاب‌شده معتبر نیست.");
                return;
            }

            // Parse numeric inputs
            string overheadText = CommonFunctions.ConvertPersianDigitsToEnglish(txtOHPerSubSectionItems.Text ?? "").Replace(",", "").Trim();
            string percentText = CommonFunctions.ConvertPersianDigitsToEnglish(txtPartOfOH.Text ?? "").Trim();
            string countText = CommonFunctions.ConvertPersianDigitsToEnglish(txtDailtySells.Text ?? "").Trim();

            if (!decimal.TryParse(overheadText, out var overhead)) overhead = 0m;
            if (!byte.TryParse(percentText, out var percentage)) percentage = 0;
            if (!short.TryParse(countText, out var countOfSell)) countOfSell = 0;

            int row = lstSubSection.Items.Count + 1;

            // Visible columns only: Row, Title, OverHead, Percentage, CountOfSell
            var item = new ListViewItem(row.ToString());
            item.SubItems.Add(selectedSubSectionRef.SSTitle ?? "-");
            item.SubItems.Add(overhead.ToString("0"));
            item.SubItems.Add(percentage.ToString());
            item.SubItems.Add(countOfSell.ToString());

            // Store IDs in Tag (not in columns)
            item.Tag = selectedSubSectionRef;

            lstSubSection.Items.Add(item);
        }

        private bool SubmitSectionDraftInternal(out string errorMessage)
        {
            errorMessage = null;

            if (sectionList == null || sectionList.Count == 0)
            {
                errorMessage = "لیست سکشن‌ها خالی است.";
                return false;
            }

            var sectionTable = new DataTable();
            sectionTable.Columns.Add("SecID", typeof(string));
            sectionTable.Columns.Add("SecTitle", typeof(string));
            sectionTable.Columns.Add("OverHead", typeof(decimal));
            sectionTable.Columns.Add("PerCentage", typeof(byte));
            sectionTable.Columns.Add("CountOfSell", typeof(short));

            foreach (var sec in sectionList.Where(s => s != null && !s.isDeleted))
            {
                sectionTable.Rows.Add(sec.SecID, sec.SecTitle, sec.OverHead, sec.PerCentage, sec.CountOfSell);
            }

            return _manager.SubmitSectionDraft(sectionTable, out errorMessage);
        }

        private bool SubmitSubSectionDraftInternal(out string errorMessage)
        {
            errorMessage = null;

            if (lstSubSection == null || lstSubSection.Items.Count == 0)
            {
                errorMessage = "لیست زیرسکشن‌ها خالی است.";
                return false;
            }

            var dt = new DataTable();
            dt.Columns.Add("SSID", typeof(string));
            dt.Columns.Add("SSTitle", typeof(string));
            dt.Columns.Add("SecID", typeof(string));
            dt.Columns.Add("OverHead", typeof(decimal));
            dt.Columns.Add("PerCentage", typeof(byte));
            dt.Columns.Add("CountOfSell", typeof(short));

            foreach (ListViewItem item in lstSubSection.Items)
            {
                if (!(item.Tag is SubSectionRef tag) || string.IsNullOrWhiteSpace(tag.SSID) || string.IsNullOrWhiteSpace(tag.SecID))
                {
                    errorMessage = "زیرسکشن‌های لیست، شناسه معتبر ندارند. لطفاً لیست را از ابتدا بسازید.";
                    return false;
                }

                // Numeric values only are read from SubItems
                string overheadText = CommonFunctions.ConvertPersianDigitsToEnglish(item.SubItems[SUBSECTION_COL_OVERHEAD].Text ?? "").Replace(",", "").Trim();
                string percentText = CommonFunctions.ConvertPersianDigitsToEnglish(item.SubItems[SUBSECTION_COL_PERCENTAGE].Text ?? "").Trim();
                string countText = CommonFunctions.ConvertPersianDigitsToEnglish(item.SubItems[SUBSECTION_COL_COUNTOFSELL].Text ?? "").Trim();

                if (!decimal.TryParse(overheadText, out var overhead)) overhead = 0m;
                if (!byte.TryParse(percentText, out var perc)) perc = 0;
                if (!short.TryParse(countText, out var count)) count = 0;

                dt.Rows.Add(tag.SSID, tag.SSTitle, tag.SecID, overhead, perc, count);
            }

            return _manager.SubmitSubSectionDraft(dt, out errorMessage);
        }

        private void tpgSubmitOH_Click_Duplicate2(object sender, EventArgs e)
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

        private void btnUpdateSOH_Click_Duplicate(object sender, EventArgs e)
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

        private void btnRefreshForm_Click_Duplicate(object sender, EventArgs e)
        {
            ReloadOverHeadFormData();
        }

        private void tpgDefineCalculation_Click_Duplicate(object sender, EventArgs e)
        {

        }

        private void DisplayCalculationResults(DataTable results)
        {
            if (results == null || results.Rows.Count == 0)
                return;

            // TODO (ISSUE-001): Future Enhancement - Replace MessageBox with DataGridView
            // Implementation Plan:
            // 1. Add a DataGridView control to the form (e.g., dgvCalculationResults)
            // 2. Replace this method content with: dgvCalculationResults.DataSource = results;
            // 3. Add column formatting for better readability
            // 4. Optionally: Create a modal results dialog with export functionality
            // Estimated Effort: 2-4 hours
            string message = $"محاسبه تخصیص سربار با موفقیت انجام شد.\n\n" +
                           $"تعداد ردیف‌های نتیجه: {results.Rows.Count}\n\n" +
                           $"نتایج آماده نمایش در گرید می‌باشند.";
            
            MessageBox.Show(message, "نتایج محاسبه", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Missing event handlers - added to fix designer/code-behind mismatches
        
        private void btnAddNewOHCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOHCategory.Text))
            {
                MessageBox.Show("لطفاً عنوان دسته‌بندی را وارد کنید.");
                return;
            }

            try
            {
                var infoDAL = new InformationDAL();
                var newInfo = new InformationDto
                {
                    Context = "OHCategories",
                    PersianTitle = txtOHCategory.Text.Trim(),
                    StringValuePer = txtOHCategory.Text.Trim(),
                    StringValueEng = "",
                    DigitalValue = 0
                };
                infoDAL.InsertInformation(newInfo);

                MessageBox.Show("دسته‌بندی جدید با موفقیت ثبت شد.");
                txtOHCategory.Text = "";
                LoadOHCategories();
                LoadOHCategoriesToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در ثبت دسته‌بندی: {ex.Message}");
            }
        }

        private void btnAddNewYear_Click(object sender, EventArgs e)
        {
            string yearText = CommonFunctions.ConvertPersianDigitsToEnglish(txtNewYear.Text?.Trim() ?? "");
            if (string.IsNullOrWhiteSpace(yearText) || !int.TryParse(yearText, out int year))
            {
                MessageBox.Show("لطفاً سال مالی معتبر وارد کنید.");
                return;
            }

            try
            {
                var infoDAL = new InformationDAL();
                var existingYears = infoDAL.GetInformationByContext("FinancialYears");
                if (existingYears.Any(y => y.DigitalValue == year))
                {
                    MessageBox.Show("این سال مالی قبلاً ثبت شده است.");
                    return;
                }

                var newInfo = new InformationDto
                {
                    Context = "FinancialYears",
                    PersianTitle = yearText,
                    StringValuePer = yearText,
                    StringValueEng = yearText,
                    DigitalValue = year
                };
                infoDAL.InsertInformation(newInfo);

                MessageBox.Show("سال مالی جدید با موفقیت ثبت شد.");
                txtNewYear.Text = "";
                LoadFinancialYears();
                LoadCurrentYearSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در ثبت سال مالی: {ex.Message}");
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            // This button is for sections - not used in current implementation
            // The actual section list is populated from database
            MessageBox.Show("لیست سکشن‌ها از دیتابیس لود می‌شود.");
        }

        private void btnCalculateAllocation_Click(object sender, EventArgs e)
        {
            // Delegate to the main submission handler
            // This button provides an alternative way to trigger the same operation
            btnSubmitSectionOVERHEAD_Click(sender, e);
        }

        private void btnSetFinancialYear_Click(object sender, EventArgs e)
        {
            if (cmbCurrentYearSource.SelectedItem == null)
            {
                MessageBox.Show("لطفاً سال مالی را انتخاب کنید.");
                return;
            }

            try
            {
                string selectedYear = cmbCurrentYearSource.SelectedItem.ToString();
                var infoDAL = new InformationDAL();
                
                // Get existing CurentYear entry
                var currentYearInfoList = infoDAL.GetInformationByContext("CurentYear");
                
                if (currentYearInfoList.Any())
                {
                    // Update existing entry
                    var currentYearInfo = currentYearInfoList.First();
                    currentYearInfo.StringValuePer = selectedYear;
                    currentYearInfo.StringValueEng = selectedYear;
                    currentYearInfo.DigitalValue = int.Parse(selectedYear);
                    infoDAL.UpdateInformation(currentYearInfo);
                }
                else
                {
                    // Insert new entry
                    var newInfo = new InformationDto
                    {
                        Context = "CurentYear",
                        PersianTitle = "سال مالی جاری",
                        StringValuePer = selectedYear,
                        StringValueEng = selectedYear,
                        DigitalValue = int.Parse(selectedYear)
                    };
                    infoDAL.InsertInformation(newInfo);
                }

                MessageBox.Show($"سال مالی جاری به {selectedYear} تنظیم شد.");
                ReloadOverHeadFormData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در تنظیم سال مالی جاری: {ex.Message}");
            }
        }

        private void btnSubmitNewSection_Click(object sender, EventArgs e)
        {
            // Opens the DefineSectionsFRM form
            var defineSectionsFrm = new DefineSectionsFRM();
            defineSectionsFrm.ShowDialog();
            LoadSectionsToCombo();
            LoadSectionsToList();
        }

        private void btnSubmitTAX_Click(object sender, EventArgs e)
        {
            string taxText = CommonFunctions.ConvertPersianDigitsToEnglish(txtTax.Text?.Trim() ?? "");
            if (!decimal.TryParse(taxText, out decimal taxValue))
            {
                MessageBox.Show("لطفاً مقدار معتبر برای مالیات وارد کنید.");
                return;
            }

            try
            {
                var infoDAL = new InformationDAL();
                var taxInfoList = infoDAL.GetInformationByContext("Tax");

                if (taxInfoList.Any())
                {
                    var taxInfo = taxInfoList.First();
                    taxInfo.DigitalValue = taxValue;
                    infoDAL.UpdateInformation(taxInfo);
                }
                else
                {
                    var newInfo = new InformationDto
                    {
                        Context = "Tax",
                        PersianTitle = "مالیات بر درآمد",
                        StringValuePer = taxValue.ToString(),
                        StringValueEng = taxValue.ToString(),
                        DigitalValue = taxValue
                    };
                    infoDAL.InsertInformation(newInfo);
                }

                MessageBox.Show("مالیات با موفقیت بروزرسانی شد.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بروزرسانی مالیات: {ex.Message}");
            }
        }

        private void btnSubmitTotalSellsCount_Click(object sender, EventArgs e)
        {
            string countText = CommonFunctions.ConvertPersianDigitsToEnglish(txtTotalSellsCount.Text?.Trim() ?? "");
            if (!int.TryParse(countText, out int count))
            {
                MessageBox.Show("لطفاً تعداد معتبر وارد کنید.");
                return;
            }

            try
            {
                var infoDAL = new InformationDAL();
                var sellCountInfoList = infoDAL.GetInformationByContext("TotalCountOfSellOfItems");

                if (sellCountInfoList.Any())
                {
                    var sellCountInfo = sellCountInfoList.First();
                    sellCountInfo.DigitalValue = count;
                    infoDAL.UpdateInformation(sellCountInfo);
                }
                else
                {
                    var newInfo = new InformationDto
                    {
                        Context = "TotalCountOfSellOfItems",
                        PersianTitle = "متوسط تعداد فروش آیتم در روز",
                        StringValuePer = count.ToString(),
                        StringValueEng = count.ToString(),
                        DigitalValue = count
                    };
                    infoDAL.InsertInformation(newInfo);
                }

                MessageBox.Show("متوسط فروش آیتم در روز با موفقیت بروزرسانی شد.");
                txtAVGTotalSell.Text = count.ToString();
                LoadSectionsToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بروزرسانی: {ex.Message}");
            }
        }

        private void btnSubmitVAT_Click(object sender, EventArgs e)
        {
            string vatText = CommonFunctions.ConvertPersianDigitsToEnglish(txtVAT.Text?.Trim() ?? "");
            if (!decimal.TryParse(vatText, out decimal vatValue))
            {
                MessageBox.Show("لطفاً مقدار معتبر برای مالیات بر ارزش افزوده وارد کنید.");
                return;
            }

            try
            {
                var infoDAL = new InformationDAL();
                var vatInfoList = infoDAL.GetInformationByContext("VAT");

                if (vatInfoList.Any())
                {
                    var vatInfo = vatInfoList.First();
                    vatInfo.DigitalValue = vatValue;
                    infoDAL.UpdateInformation(vatInfo);
                }
                else
                {
                    var newInfo = new InformationDto
                    {
                        Context = "VAT",
                        PersianTitle = "مالیات بر ارزش افزوده",
                        StringValuePer = vatValue.ToString(),
                        StringValueEng = vatValue.ToString(),
                        DigitalValue = vatValue
                    };
                    infoDAL.InsertInformation(newInfo);
                }

                MessageBox.Show("مالیات بر ارزش افزوده با موفقیت بروزرسانی شد.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بروزرسانی مالیات بر ارزش افزوده: {ex.Message}");
            }
        }

        // Label click handlers - minimal implementation
        // NOTE: These handlers exist because the WinForms designer has wired these events.
        // They can be removed from the designer if not needed, but are harmless empty handlers.
        private void label16_Click(object sender, EventArgs e)
        {
            // Empty handler - designer generated, can be removed from designer if not needed
        }

        private void label17_Click(object sender, EventArgs e)
        {
            // Empty handler - designer generated, can be removed from designer if not needed
        }

        private void label49_Click(object sender, EventArgs e)
        {
            // Empty handler - designer generated, can be removed from designer if not needed
        }

        private void label50_Click(object sender, EventArgs e)
        {
            // Empty handler - designer generated, can be removed from designer if not needed
        }

        private void label9_Click(object sender, EventArgs e)
        {
            // Empty handler - designer generated, can be removed from designer if not needed
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            // Empty handler - designer generated, can be removed from designer if not needed
        }

        private void txtAVGSectionSell_TextChanged(object sender, EventArgs e)
        {
            // Empty handler - designer generated, can be removed from designer if not needed
        }

        private void lstSubSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Placeholder handler - can be enhanced if subsection selection needs special handling
        }
    }
}
