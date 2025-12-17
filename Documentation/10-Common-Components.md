# فصل 10: اجزای عمومی و مشترک (Common Components)

## 📋 فهرست مطالب
- [معرفی](#معرفی)
- [الگوهای مشترک](#الگوهای-مشترک)
- [کلاس‌های پایه](#کلاسهای-پایه)
- [Interface های مشترک](#interface-های-مشترک)
- [Constants و Enums](#constants-و-enums)
- [توابع کمکی عمومی](#توابع-کمکی-عمومی)

---

## معرفی

این بخش شامل تمام اجزای عمومی و مشترکی است که در سراسر سیستم استفاده می‌شوند.

---

## الگوهای مشترک

### الگوی CRUD استاندارد

تمام Manager Classes از این الگو پیروی می‌کنند:

```csharp
public class BaseManager<T> where T : class
{
    // الگوی استاندارد برای تمام Managers
    public virtual List<T> GetAll() { }
    public virtual T GetById(int id) { }
    public virtual bool Add(T entity) { }
    public virtual bool Update(T entity) { }
    public virtual bool Delete(int id) { }
}
```

**استفاده در:**
- ItemManager
- ProductManager
- SectionManager
- UnitManager
- AccountManager
- و سایر Manager Classes

---

### الگوی Repository

تمام DAL Classes از این الگو استفاده می‌کنند:

```csharp
public interface IRepository<T> where T : class
{
    List<T> SelectAll();
    T SelectByID(int id);
    bool Insert(T entity);
    bool Update(T entity);
    bool Delete(int id);
}
```

**استفاده در:**
- ItemDAL
- ProductDAL
- FactorDAL
- و سایر DAL Classes

---

### الگوی Singleton

برای کلاس‌هایی که باید یک نمونه در کل برنامه داشته باشند:

```csharp
public class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();
    
    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }
    
    private Singleton() { }
}
```

**استفاده در:**
- LoginInfo
- ConfigManager (در صورت وجود)
- ApplicationState (در صورت وجود)

---

## کلاس‌های پایه

### BaseForm (در صورت وجود)

کلاس پایه برای تمام فرمها:

```csharp
public class BaseForm : Form
{
    protected virtual void InitializeForm()
    {
        // تنظیمات مشترک فرمها
        this.RightToLeft = RightToLeft.Yes;
        this.RightToLeftLayout = true;
        this.Font = new Font("Tahoma", 9F);
        this.StartPosition = FormStartPosition.CenterScreen;
    }
    
    protected virtual void ShowSuccess(string message)
    {
        CommonFunctions.ShowSuccess(message);
    }
    
    protected virtual void ShowError(string message)
    {
        CommonFunctions.ShowError(message);
    }
    
    protected virtual bool ShowConfirm(string message)
    {
        return CommonFunctions.ShowConfirm(message);
    }
}
```

---

### BaseManager (در صورت وجود)

کلاس پایه برای Manager Classes:

```csharp
public abstract class BaseManager
{
    protected void LogError(Exception ex)
    {
        // Log error
    }
    
    protected void ValidateNotNull(object obj, string paramName)
    {
        if (obj == null)
            throw new ArgumentNullException(paramName);
    }
    
    protected void ValidateNotEmpty(string str, string paramName)
    {
        if (string.IsNullOrWhiteSpace(str))
            throw new ArgumentException($"{paramName} cannot be empty");
    }
}
```

---

## Interface های مشترک

### IValidator

برای کلاس‌های اعتبارسنجی:

```csharp
public interface IValidator<T>
{
    bool Validate(T entity);
    List<string> GetErrors();
}
```

**استفاده:**
```csharp
public class ItemValidator : IValidator<ItemModel>
{
    private List<string> _errors = new List<string>();
    
    public bool Validate(ItemModel item)
    {
        _errors.Clear();
        
        if (string.IsNullOrWhiteSpace(item.ItemName))
            _errors.Add("نام قلم الزامی است");
        
        if (item.UnitPrice < 0)
            _errors.Add("قیمت نمی‌تواند منفی باشد");
        
        return _errors.Count == 0;
    }
    
    public List<string> GetErrors()
    {
        return _errors;
    }
}
```

---

### IRepository

برای DAL Classes:

```csharp
public interface IRepository<T> where T : class
{
    List<T> SelectAll();
    T SelectByID(int id);
    bool Insert(T entity);
    bool Update(T entity);
    bool Delete(int id);
}
```

---

## Constants و Enums

### AppConstants

مقادیر ثابت برنامه:

```csharp
public static class AppConstants
{
    // پیام‌ها
    public const string MSG_SUCCESS_SAVE = "ذخیره با موفقیت انجام شد";
    public const string MSG_SUCCESS_DELETE = "حذف با موفقیت انجام شد";
    public const string MSG_SUCCESS_UPDATE = "ویرایش با موفقیت انجام شد";
    public const string MSG_ERROR_SAVE = "خطا در ذخیره اطلاعات";
    public const string MSG_CONFIRM_DELETE = "آیا از حذف این رکورد اطمینان دارید؟";
    
    // فرمت‌ها
    public const string DATE_FORMAT = "yyyy/MM/dd";
    public const string DATETIME_FORMAT = "yyyy/MM/dd HH:mm:ss";
    public const string CURRENCY_FORMAT = "N0";
    
    // مقادیر پیش‌فرض
    public const int DEFAULT_PAGE_SIZE = 50;
    public const decimal MAX_DISCOUNT_PERCENT = 0.5m; // 50%
    public const int MIN_INVENTORY_WARNING = 10;
    
    // سطوح دسترسی
    public const int ROLE_ADMIN = 1;
    public const int ROLE_MANAGER = 2;
    public const int ROLE_USER = 3;
    public const int ROLE_CASHIER = 4;
    public const int ROLE_WAREHOUSE = 5;
}
```

---

### UserRole Enum

```csharp
public enum UserRole
{
    Admin = 1,
    Manager = 2,
    User = 3,
    Cashier = 4,
    Warehouse = 5
}
```

---

### FactorStatus Enum

```csharp
public enum FactorStatus
{
    Draft = 0,      // پیش‌نویس
    Pending = 1,    // در انتظار
    Completed = 2,  // تکمیل شده
    Paid = 3,       // پرداخت شده
    Cancelled = 4   // لغو شده
}
```

---

### PaymentStatus Enum

```csharp
public enum PaymentStatus
{
    Unpaid = 0,     // پرداخت نشده
    PartiallyPaid = 1, // پرداخت جزئی
    Paid = 2,       // پرداخت شده
    Overdue = 3     // معوق
}
```

---

## توابع کمکی عمومی

### متدهای مشترک در CommonFunctions

#### 1. اعتبارسنجی

```csharp
public static class ValidationHelpers
{
    public static bool IsValidNationalCode(string nationalCode)
    {
        // اعتبارسنجی کد ملی
        if (string.IsNullOrWhiteSpace(nationalCode) || nationalCode.Length != 10)
            return false;
            
        if (!long.TryParse(nationalCode, out long _))
            return false;
            
        // الگوریتم اعتبارسنجی کد ملی
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += int.Parse(nationalCode[i].ToString()) * (10 - i);
        }
        
        int remainder = sum % 11;
        int checkDigit = remainder < 2 ? remainder : 11 - remainder;
        
        return checkDigit == int.Parse(nationalCode[9].ToString());
    }
    
    public static bool IsValidMobileNumber(string mobile)
    {
        // اعتبارسنجی شماره موبایل
        if (string.IsNullOrWhiteSpace(mobile))
            return false;
            
        string cleaned = new string(mobile.Where(char.IsDigit).ToArray());
        
        if (cleaned.Length != 11)
            return false;
            
        return cleaned.StartsWith("09");
    }
}
```

---

#### 2. تبدیل و فرمت

```csharp
public static class ConversionHelpers
{
    public static string NumberToWords(long number)
    {
        // تبدیل عدد به حروف فارسی
        // پیاده‌سازی کامل...
        return "مبلغ به حروف";
    }
    
    public static DateTime? ParsePersianDate(string persianDate)
    {
        // تبدیل تاریخ شمسی به میلادی
        try
        {
            var parts = persianDate.Split('/');
            if (parts.Length != 3)
                return null;
                
            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);
            
            var pc = new System.Globalization.PersianCalendar();
            return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }
        catch
        {
            return null;
        }
    }
}
```

---

#### 3. DataGridView Helpers

```csharp
public static class DataGridViewHelpers
{
    public static void ApplyStandardStyle(DataGridView dgv)
    {
        dgv.AutoGenerateColumns = true;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.RowHeadersVisible = false;
        dgv.BackgroundColor = Color.White;
        dgv.BorderStyle = BorderStyle.Fixed3D;
        dgv.Font = new Font("Tahoma", 9F);
        dgv.RightToLeft = RightToLeft.Yes;
        
        // Alternating Row Color
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
    }
    
    public static void SetColumnHeaders(DataGridView dgv, Dictionary<string, string> headers)
    {
        foreach (var kvp in headers)
        {
            if (dgv.Columns.Contains(kvp.Key))
            {
                dgv.Columns[kvp.Key].HeaderText = kvp.Value;
            }
        }
    }
    
    public static void HideColumns(DataGridView dgv, params string[] columnNames)
    {
        foreach (var columnName in columnNames)
        {
            if (dgv.Columns.Contains(columnName))
            {
                dgv.Columns[columnName].Visible = false;
            }
        }
    }
}
```

**استفاده:**
```csharp
// در فرمها
DataGridViewHelpers.ApplyStandardStyle(dgvItems);

var headers = new Dictionary<string, string>
{
    { "ItemID", "کد" },
    { "ItemName", "نام قلم" },
    { "UnitPrice", "قیمت" },
    { "Quantity", "موجودی" }
};
DataGridViewHelpers.SetColumnHeaders(dgvItems, headers);

DataGridViewHelpers.HideColumns(dgvItems, "CreatedBy", "ModifiedBy");
```

---

## Exception Classes مشترک

### BusinessException

```csharp
public class BusinessException : Exception
{
    public BusinessException(string message) : base(message) { }
    
    public BusinessException(string message, Exception innerException) 
        : base(message, innerException) { }
}
```

### ValidationException

```csharp
public class ValidationException : Exception
{
    public List<string> Errors { get; set; }
    
    public ValidationException(string message) : base(message)
    {
        Errors = new List<string> { message };
    }
    
    public ValidationException(List<string> errors) 
        : base(string.Join(", ", errors))
    {
        Errors = errors;
    }
}
```

### DatabaseException

```csharp
public class DatabaseException : Exception
{
    public DatabaseException(string message) : base(message) { }
    
    public DatabaseException(string message, Exception innerException) 
        : base(message, innerException) { }
}
```

---

## Extension Methods مشترک

### String Extensions

```csharp
public static class StringExtensions
{
    public static bool IsEmpty(this string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }
    
    public static string ToPersianNumbers(this string str)
    {
        return CommonFunctions.ToPersianNumbers(str);
    }
    
    public static string ToEnglishNumbers(this string str)
    {
        return CommonFunctions.ToEnglishNumbers(str);
    }
    
    public static string Truncate(this string str, int maxLength)
    {
        if (str.IsEmpty() || str.Length <= maxLength)
            return str;
        
        return str.Substring(0, maxLength) + "...";
    }
}
```

### DateTime Extensions

```csharp
public static class DateTimeExtensions
{
    public static string ToPersianDate(this DateTime date)
    {
        return CommonFunctions.FormatDate(date);
    }
    
    public static string ToPersianDateTime(this DateTime dateTime)
    {
        return CommonFunctions.FormatDateTime(dateTime);
    }
    
    public static bool IsToday(this DateTime date)
    {
        return date.Date == DateTime.Now.Date;
    }
}
```

### Decimal Extensions

```csharp
public static class DecimalExtensions
{
    public static string ToCurrency(this decimal amount)
    {
        return CommonFunctions.FormatCurrency(amount);
    }
    
    public static string ToWords(this decimal amount)
    {
        return ConversionHelpers.NumberToWords((long)amount);
    }
}
```

---

## نکات استفاده

### ✅ استفاده صحیح از اجزای مشترک

```csharp
// 1. استفاده از Constants
string message = AppConstants.MSG_SUCCESS_SAVE;

// 2. استفاده از Extension Methods
string persianDate = DateTime.Now.ToPersianDate();
string formatted = price.ToCurrency();

// 3. استفاده از Helper Methods
bool isValid = ValidationHelpers.IsValidNationalCode(nationalCode);

// 4. استفاده از Enums
if (LoginInfo.Instance.RoleID == (int)UserRole.Admin)
{
    // Admin logic
}
```

---

## 📅 تاریخچه تغییرات

### 2025-12-17
- ایجاد اولیه مستند اجزای مشترک
- الگوهای استاندارد
- توابع کمکی عمومی

---

**تاریخ ایجاد**: 2025-12-17  
**آخرین به‌روزرسانی**: 2025-12-17

---

## Metadata (برای AI)

```json
{
  "document_type": "common_components",
  "chapter": 10,
  "patterns_count": 3,
  "helpers_count": 10,
  "language": "Persian (Farsi)",
  "last_updated": "2025-12-17",
  "version": "1.0"
}
```
