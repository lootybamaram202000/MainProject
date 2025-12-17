# فصل 4: جزئیات منطق کسب‌وکار (Business Logic Details)

## 📋 فهرست مطالب
- [معرفی](#معرفی)
- [Manager Classes](#manager-classes)

---

## معرفی

این بخش شامل مستندات کامل تمام کلاس‌های Manager است که منطق کسب‌وکار سیستم را پیاده‌سازی می‌کنند.

---

## Manager Classes

### ItemManager

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/Core/Business/ItemManager.cs`
- **نام فنی**: ItemManager
- **نام فارسی**: مدیر اقلام پایه

#### 🎯 هدف و کاربرد
مدیریت منطق کسب‌وکار مربوط به اقلام پایه (مواد اولیه) شامل اعتبارسنجی، محاسبات و هماهنگی با DAL.

#### 🔗 وابستگیها (Dependencies)
**ورودیها:**
- `ItemDAL`: دسترسی به داده‌های اقلام

**خروجیها:**
- استفاده توسط فرمها: `DefineBasicItemsFRM`, `DefineMenuItemsFRM`

#### ⚙️ متدهای اصلی

##### GetAllItems()
```csharp
public List<ItemModel> GetAllItems()
```
**توضیح**: دریافت لیست تمام اقلام فعال

**خروجی**: لیست ItemModel

**نمونه استفاده**:
```csharp
ItemManager manager = new ItemManager();
var items = manager.GetAllItems();
```

##### AddItem(ItemModel)
```csharp
public bool AddItem(ItemModel item)
```
**توضیح**: افزودن قلم جدید با اعتبارسنجی

**پارامتر**: ItemModel - اطلاعات قلم جدید

**بازگشتی**: true در صورت موفقیت

**نمونه استفاده**:
```csharp
ItemModel newItem = new ItemModel
{
    ItemName = "برنج",
    UnitID = 1,
    UnitPrice = 50000,
    Quantity = 100
};

bool result = manager.AddItem(newItem);
```

##### UpdateInventory(int itemId, int quantity)
```csharp
public bool UpdateInventory(int itemId, int quantity)
```
**توضیح**: به‌روزرسانی موجودی انبار

**پارامترها**:
- itemId: شناسه قلم
- quantity: مقدار تغییر (مثبت برای افزایش، منفی برای کاهش)

#### ⚠️ نکات مهم
- بررسی تکراری نبودن نام قلم
- بررسی موجودی کافی قبل از کسر
- هشدار برای موجودی کمتر از حد مجاز (MinQuantity)

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### ProductManager

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/Core/Business/ProductManager.cs`
- **نام فنی**: ProductManager
- **نام فارسی**: مدیر محصولات

#### 🎯 هدف و کاربرد
مدیریت محصولات نهایی، دستور پخت و محاسبه قیمت تمام شده.

#### 🔗 وابستگیها
**ورودیها:**
- `ProductDAL`: دسترسی به داده‌های محصولات
- `ItemDAL`: برای محاسبه قیمت تمام شده

**خروجیها:**
- استفاده در `DefineMenuItemsFRM`, `CreatSellFactorFRM`

#### ⚙️ متدهای اصلی

##### GetAllProducts()
##### AddProduct(ProductModel, List<RecipeModel>)
##### CalculateProductCost(int productId)
**توضیح**: محاسبه قیمت تمام شده بر اساس دستور پخت

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### FactorManager

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/Core/Business/FactorManager.cs`
- **نام فنی**: FactorManager
- **نام فارسی**: مدیر فاکتورها

#### 🎯 هدف و کاربرد
مدیریت فاکتورهای فروش، محاسبات مالی و به‌روزرسانی موجودی.

#### ⚙️ متدهای اصلی

##### CreateFactor(FactorModel, List<SubFactorModel>)
**توضیح**: ثبت فاکتور جدید همراه با آیتم‌ها

**فرآیند**:
1. ثبت فاکتور اصلی
2. ثبت آیتم‌های فاکتور
3. کسر موجودی مواد اولیه
4. به‌روزرسانی حساب‌ها

##### CalculateTotal(List<SubFactorModel>)
**توضیح**: محاسبه مجموع فاکتور

##### ApplyDiscount(FactorModel)
**توضیح**: اعمال تخفیف بر اساس قوانین کسب‌وکار

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### AccountManager

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/Core/Business/AccountManager.cs`
- **نام فنی**: AccountManager
- **نام فارسی**: مدیر حساب‌های بانکی

#### 🎯 هدف و کاربرد
مدیریت حساب‌های بانکی، موجودی و تراکنش‌ها.

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### OverHeadManager

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/Core/Business/OverHeadManager.cs`
- **نام فنی**: OverHeadManager
- **نام فارسی**: مدیر هزینه‌ها

#### 🎯 هدف و کاربرد
مدیریت هزینه‌های رستوران و ثبت آنها در حساب‌ها.

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### SellerManager

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/Core/Business/SellerManager.cs`
- **نام فنی**: SellerManager
- **نام فارسی**: مدیر فروشندگان

#### 🎯 هدف و کاربرد
مدیریت اطلاعات فروشندگان و تأمین‌کنندگان.

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### UnitManager

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/Core/Business/UnitManager.cs`
- **نام فنی**: UnitManager
- **نام فارسی**: مدیر واحدها

#### 🎯 هدف و کاربرد
مدیریت واحدهای اندازه‌گیری.

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### SectionManager

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/Core/Business/SectionManager.cs`
- **نام فنی**: SectionManager
- **نام فارسی**: مدیر بخش‌ها

#### 🎯 هدف و کاربرد
مدیریت بخش‌های محصولات.

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### LoginManager

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/Core/Business/LoginManager.cs`
- **نام فنی**: LoginManager
- **نام فارسی**: مدیر ورود

#### 🎯 هدف و کاربرد
مدیریت احراز هویت کاربران و بررسی سطح دسترسی.

#### ⚙️ متدهای اصلی

##### Login(string username, string password)
**توضیح**: ورود کاربر به سیستم

**فرآیند**:
1. بررسی نام کاربری و رمز عبور
2. دریافت سطح دسترسی
3. ذخیره در LoginInfo.Instance

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

## یادداشت

**این فایل در حال تکمیل است.** جزئیات کامل‌تر هر Manager Class در نسخه‌های بعدی اضافه خواهد شد.

---

**تاریخ ایجاد**: 2025-12-17  
**آخرین به‌روزرسانی**: 2025-12-17

---

## Metadata (برای AI)

```json
{
  "document_type": "details_documentation",
  "chapter": 4,
  "layer": "business_logic",
  "managers_documented": 12,
  "language": "Persian (Farsi)",
  "last_updated": "2025-12-17",
  "status": "in_progress"
}
```
