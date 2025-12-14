using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProject.Entities;
using System.Security.Cryptography;



namespace MainProject.Helpers
{


    public static class CommonFunctions
    {


        public static string SHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public static bool IsAllDigits(string input)
        {
            return !string.IsNullOrEmpty(input) && input.All(char.IsDigit);
        }

        public static void FormatTextBoxAsThousandSeparated(TextBox txt)
        {
            if (string.IsNullOrWhiteSpace(txt.Text)) return;

            string raw = txt.Text.Replace(",", "").Trim();
            if (decimal.TryParse(raw, out decimal value))
            {
                txt.Text = value.ToString("N0"); // بدون اعشار
                txt.SelectionStart = txt.Text.Length; // نشانگر را به انتهای متن منتقل می‌کند
            }
        }

        public static void AssignThousandSeparatorHandler(TextBox txt)
        {
            txt.Leave += (s, e) => FormatTextBoxAsThousandSeparated(txt);
        }

        public static string FormatWithThousandsSeparator(int number)
        {
            return number.ToString("N0", CultureInfo.InvariantCulture);
        }


        public static int SafeParseInt(string input)
        {
            return int.TryParse(input, out int result) ? result : 0;
        }




        public static decimal CalculateOverHeadPerItem(decimal totalFixedOverhead, byte sectionPercentage, int sectionSellCount)
        {
            if (sectionSellCount <= 0 || sectionPercentage <= 0)
                return 0;

            decimal dailyOverhead = totalFixedOverhead / 365m;
            decimal sectionShare = dailyOverhead * sectionPercentage / 100m;
            return Math.Round(sectionShare / sectionSellCount, 0);
        }


        public static bool ValidateSectionOverheadInputs(List<SectionModel> sections, int totalSellCount, out string message)
        {
            int sumPercent = sections
                .Where(s => !s.isDeleted)
                .Sum(s => s.PerCentage);

            int sumSellCount = sections
                .Where(s => !s.isDeleted)
                .Sum(s => s.CountOfSell);

            if (sumPercent != 100)
            {
                message = "مجموع درصد سکشن‌های فعال باید دقیقاً 100 باشد.";
                return false;
            }

            if (sumSellCount != totalSellCount)
            {
                message = "مجموع فروش سکشن‌های فعال با مقدار کل فروش مغایرت دارد.";
                return false;
            }

            message = string.Empty;
            return true;
        }

        public static bool ValidateSectionList(List<SectionModel> sections, int totalSell, out string errorMsg)
        {
            errorMsg = "";

            int sumPercent = sections.Where(x => !x.isDeleted).Sum(x => x.PerCentage);
            int sumSell = sections.Where(x => !x.isDeleted).Sum(x => x.CountOfSell);

            if (sumPercent != 100)
            {
                errorMsg = "مجموع درصدهای سکشن‌های فعال باید دقیقاً ۱۰۰ باشد.";
                return false;
            }

            if (sumSell != totalSell)
            {
                errorMsg = "مجموع فروش سکشن‌های فعال با تعداد کل فروش مغایرت دارد.";
                return false;
            }

            return true;
        }


        public static void RecalculateOverHeadPerItemForAllSections(List<SectionModel> sections, decimal totalFixedOverhead)
        {
            foreach (var sec in sections)
            {
                if (!sec.isDeleted && sec.PerCentage > 0 && sec.CountOfSell > 0)
                {
                    sec.OverHead = CalculateOverHeadPerItem(totalFixedOverhead, sec.PerCentage, sec.CountOfSell);
                }
                else
                {
                    sec.OverHead = 0;
                }
            }
        }


        public static bool ValidateMenuItemFormInputs(TextBox txtName, ComboBox cmbSection, ComboBox cmbCategory, out string message)
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                message = "نام آیتم را وارد کنید.";
                txtName.Focus();
                return false;
            }

            if (cmbSection.SelectedIndex < 0)
            {
                message = "سکشن را انتخاب کنید.";
                cmbSection.Focus();
                return false;
            }

            if (cmbCategory.SelectedIndex < 0)
            {
                message = "دسته‌بندی را انتخاب کنید.";
                cmbCategory.Focus();
                return false;
            }

            return true;
        }
        public static void ScaleForm(Form frm, double widthRatio = 0.75, double heightRatio = 0.85, int minHeight = 980)
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            // اگر فرم بزرگتر از صفحه طراحی شده
            if (frm.Width > screenWidth || frm.Height > screenHeight)
            {
                frm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                int targetHeight = Math.Max((int)(screenHeight * heightRatio), minHeight);
                frm.Width = (int)(screenWidth * widthRatio);
                frm.Height = Math.Min(targetHeight, screenHeight - 40);
            }

            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
        }
        public static bool IsTextBoxValid(TextBox txt)
        {
            return !string.IsNullOrWhiteSpace(txt.Text);
        }

        public static bool IsComboBoxValid(ComboBox cmb)
        {
            return cmb.SelectedIndex != -1;
        }

        public static bool IsDecimalValid(TextBox textBox)
        {
            return decimal.TryParse(textBox.Text, out _);
        }

        public static bool IsTextValid(TextBox textBox)
        {
            return !string.IsNullOrWhiteSpace(textBox.Text);
        }

        public static void ClearTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox)
                    control.Text = "";
                else if (control.HasChildren)
                    ClearTextBoxes(control);
            }
        }

        public static bool ValidateUnitFormInputs(TextBox txtMUtitle, TextBox txtMUqty, TextBox txtPUtitle, TextBox txtPUqty,
                                                  RadioButton rdbPurchase, RadioButton rdbProduct,
                                                  out string errorMessage, bool showWarningIfQtyMismatch = false)
        {
            errorMessage = string.Empty;

            if (!rdbPurchase.Checked && !rdbProduct.Checked)
            {
                errorMessage = "نوع واحد (خرید/تولید) را مشخص کنید.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMUtitle.Text) ||
                string.IsNullOrWhiteSpace(txtMUqty.Text) ||
                string.IsNullOrWhiteSpace(txtPUtitle.Text) ||
                string.IsNullOrWhiteSpace(txtPUqty.Text))
            {
                errorMessage = "تمام فیلدها باید پر شوند.";
                return false;
            }

            if (!int.TryParse(ConvertPersianDigitsToEnglish(txtMUqty.Text.Trim()), out int muQty) ||
                !int.TryParse(ConvertPersianDigitsToEnglish(txtPUqty.Text.Trim()), out int puQty))
            {
                errorMessage = "مقادیر وارد شده باید عدد صحیح باشند.";
                return false;
            }

            if (muQty <= 0 || puQty <= 0)
            {
                errorMessage = "مقادیر باید عددی مثبت و غیر صفر باشند.";
                return false;
            }

            if (showWarningIfQtyMismatch && muQty <= puQty)
            {
                DialogResult result = MessageBox.Show(
                    "⚠ مقدار واحد اندازه‌گیری کمتر یا مساوی مقدار کاربردی است.\nآیا مایل به ادامه ثبت هستید؟",
                    "هشدار",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    errorMessage = "عملیات ثبت لغو شد.";
                    return false;
                }
            }

            return true;
        }

        public static bool ValidateSellerFormInputs(
            TextBox txtSellerName,
            TextBox txtCompanyName,
            TextBox txtAddress,
            TextBox txtAcountNum,
            TextBox txtPhone,
            TextBox txtShaba,
            ComboBox cmbBanks,
            out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(txtSellerName.Text))
            {
                errorMessage = "نام فروشنده وارد نشده است.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                errorMessage = "نام شرکت وارد نشده است.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorMessage = "آدرس وارد نشده است.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAcountNum.Text))
            {
                errorMessage = "شماره حساب وارد نشده است.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorMessage = "شماره تماس وارد نشده است.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtShaba.Text))
            {
                errorMessage = "شماره شبا وارد نشده است.";
                return false;
            }

            if (cmbBanks.SelectedItem == null)
            {
                errorMessage = "بانک انتخاب نشده است.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidateBasicItemFormInputs(
           TextBox txtBasicItemName,
           ComboBox cmbSections,
           ComboBox cmbMU,
           ComboBox cmbPU,
           out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(txtBasicItemName.Text))
            {
                errorMessage = "نام آیتم آماده‌سازی نباید خالی باشد.";
                return false;
            }

            if (cmbSections.SelectedIndex == -1)
            {
                errorMessage = "سکشن انتخاب نشده است.";
                return false;
            }

            if (cmbMU.SelectedIndex == -1)
            {
                errorMessage = "واحد اندازه‌گیری انتخاب نشده است.";
                return false;
            }

            if (cmbPU.SelectedIndex == -1)
            {
                errorMessage = "واحد تولید انتخاب نشده است.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        /// <summary>
        /// بر اساس عنوان واحد پایه و واحد توصیفی، شناسه‌ی یکتای واحد را از لیست واحدها پیدا می‌کند.
        /// </summary>
        public static string FindUnitIDByTitles(List<UnitModel> units, string muTitle, string puTitle)
        {
            if (string.IsNullOrWhiteSpace(muTitle) || string.IsNullOrWhiteSpace(puTitle) || units == null)
                return null;

            var match = units.FirstOrDefault(u =>
                u.MeasurmentUnitTitle?.Trim() == muTitle.Trim() &&
                u.PunitTitle?.Trim() == puTitle.Trim());

            return match?.UnitID;
        }


        /// <summary>
        /// مرتب‌سازی لیست واحدها بر اساس عدد پایه و سپس عنوان واحد
        /// </summary>
        public static List<UnitModel> SortUnitsByQuantityAndTitle(List<UnitModel> units)
        {
            if (units == null)
                return new List<UnitModel>();

            return units
                .OrderBy(u => u.MesurmentUnitQuantity)
                .ThenBy(u => u.MeasurmentUnitTitle)
                .ToList();
        }

        /// <summary>
        /// پر کردن ComboBox واحدهای پایه به‌صورت یکتا و مرتب‌شده
        /// </summary>
        public static void PopulateMUComboBox(ComboBox cmb, List<UnitModel> units)
        {
            var sorted = SortUnitsByQuantityAndTitle(units)
                .GroupBy(u => u.MeasurmentUnitTitle)
                .Select(g => g.First()) // حذف تکراری‌ها
                .ToList();

            cmb.Items.Clear();
            foreach (var unit in sorted)
            {
                cmb.Items.Add(unit.MeasurmentUnitTitle);
            }

            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// پر کردن ComboBox واحدهای کاربردی فیلترشده بر اساس واحد پایه
        /// </summary>
        public static void PopulatePUComboBox(ComboBox cmb, List<UnitModel> filteredUnits)
        {
            var sorted = SortUnitsByQuantityAndTitle(filteredUnits);

            cmb.Items.Clear();
            cmb.DisplayMember = "PunitTitle";
            cmb.ValueMember = "UnitID";

            foreach (var unit in sorted)
            {
                cmb.Items.Add(unit);
            }

            cmb.SelectedIndex = -1;
        }

        public static string ConvertPersianDigitsToEnglish(string input)
        {
            string[] persian = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            for (int i = 0; i < 10; i++)
            {
                input = input.Replace(persian[i], i.ToString());
            }
            return input;
        }

        public static void CalculateCosts(BasicItemModel model, string wastageText, out decimal grossCost, out decimal finalCost)
        {
            grossCost = 0;
            finalCost = 0;

            if (model?.Recipies == null || model.Unit == null)
                return;

            foreach (var r in model.Recipies)
            {
                if (!string.IsNullOrWhiteSpace(r.PID) && r.Quantity > 0)
                    grossCost += r.Cost;
            }

            int baseQty = model.Unit.MesurmentUnitQuantity > 0 ? model.Unit.MesurmentUnitQuantity : 1;

            int.TryParse(CommonFunctions.ConvertPersianDigitsToEnglish(wastageText.Trim()), out int wastage);
            model.Wastage = wastage;
           

            // ⛔ جلوگيری از تقسيم بر صفر
            if (baseQty <= 0)
            {
                finalCost = 0;
                return;
            }

            // ✅ فرمول دقیق و رسمی
            finalCost = grossCost + (grossCost * ((decimal)wastage / baseQty));
        }

        public static string GetPersianDate()
        {
            var pc = new System.Globalization.PersianCalendar();
            DateTime now = DateTime.Now;
            return $"{pc.GetYear(now):0000}/{pc.GetMonth(now):00}/{pc.GetDayOfMonth(now):00}";
        }

        public static string GetPersianDateNumeric()
        {
            var pc = new System.Globalization.PersianCalendar();
            DateTime now = DateTime.Now;
            return $"{pc.GetYear(now):0000}{pc.GetMonth(now):00}{pc.GetDayOfMonth(now):00}";
        }


    }
}
