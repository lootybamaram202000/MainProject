# فصل 3: جزئیات فرمها (Forms Details)

## 📋 فهرست مطالب
- [معرفی](#معرفی)
- [فرمهای تعریف پایه](#فرمهای-تعریف-پایه)
- [فرمهای عملیاتی](#فرمهای-عملیاتی)
- [فرمهای گزارش](#فرمهای-گزارش)
- [فرمهای مدیریتی](#فرمهای-مدیریتی)

---

## معرفی

این بخش شامل مستندات کامل تمام فرمهای سیستم است. هر فرم با فرمت استاندارد توضیح داده شده است.

---

## فرمهای تعریف پایه

### DefineBasicItemsFRM

#### 📌 شناسایی
- **نوع**: Form
- **مسیر**: `MainProject/Forms/DefineBasicItemsFRM.cs`
- **نام فنی**: DefineBasicItemsFRM
- **نام فارسی**: تعریف اقلام پایه

#### 🎯 هدف و کاربرد
فرم تعریف اقلام پایه (مواد اولیه) که در انبار ذخیره می‌شوند و در دستور پخت محصولات استفاده می‌شوند.

#### 🔗 وابستگیها (Dependencies)
**ورودیها (استفاده میکند از):**
- `ItemManager.GetAllItems()`: دریافت لیست اقلام
- `ItemManager.AddItem()`: افزودن قلم جدید
- `ItemManager.UpdateItem()`: ویرایش قلم
- `ItemManager.DeleteItem()`: حذف قلم
- `UnitManager.GetAllUnits()`: دریافت واحدها برای ComboBox

**خروجیها (استفاده میشود توسط):**
- `MainFRM`: فراخوانی از منوی اصلی

#### 📊 جریان داده (Data Flow)
```
User Input → Validation → ItemManager → ItemDAL → Database
Database → ItemDAL → ItemManager → DataGridView → User Display
```

#### ⚠️ نکات مهم
- اعتبارسنجی نام قلم برای جلوگیری از تکرار
- موجودی نمی‌تواند منفی باشد
- واحد اندازه‌گیری الزامی است
- فیلد MinQuantity برای هشدار موجودی کم

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### DefineMenuItemsFRM

#### 📌 شناسایی
- **نوع**: Form
- **مسیر**: `MainProject/Forms/DefineMenuItemsFRM.cs`
- **نام فنی**: DefineMenuItemsFRM
- **نام فارسی**: تعریف منوی غذا

#### 🎯 هدف و کاربرد
فرم تعریف محصولات نهایی (غذاها) همراه با دستور پخت و مواد اولیه مورد نیاز.

#### 🔗 وابستگیها (Dependencies)
**ورودیها (استفاده میکند از):**
- `ProductManager.GetAllProducts()`: دریافت لیست محصولات
- `ProductManager.AddProduct()`: افزودن محصول جدید
- `ProductManager.UpdateProduct()`: ویرایش محصول
- `ProductManager.GetRecipe()`: دریافت دستور پخت
- `ItemManager.GetAllItems()`: برای انتخاب مواد اولیه
- `SectionManager.GetAllSections()`: برای انتخاب بخش

**خروجیها (استفاده میشود توسط):**
- `MainFRM`: فراخوانی از منوی اصلی
- `CreatSellFactorFRM`: انتخاب محصول برای فروش

#### 📊 جریان داده (Data Flow)
```
User → Define Product → Select Items → Set Quantities → Calculate Cost → Save
Database → Load Products → Display Grid → Select Product → Load Recipe → Display
```

#### ⚠️ نکات مهم
- هر محصول باید دستور پخت داشته باشد
- قیمت فروش باید بیشتر از قیمت تمام شده باشد
- مواد اولیه با واحد مناسب ثبت شود
- محاسبه خودکار قیمت تمام شده

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### DefineSectionsFRM

#### 📌 شناسایی
- **نوع**: Form
- **مسیر**: `MainProject/Forms/DefineSectionsFRM.cs`
- **نام فنی**: DefineSectionsFRM
- **نام فارسی**: تعریف بخش‌ها

#### 🎯 هدف و کاربرد
تعریف بخش‌های مختلف رستوران (غذای اصلی، پیش غذا، نوشیدنی، دسر و ...)

#### 🔗 وابستگیها (Dependencies)
**ورودیها:**
- `SectionManager.GetAllSections()`
- `SectionManager.AddSection()`
- `SectionManager.UpdateSection()`
- `SectionManager.DeleteSection()`

**خروجیها:**
- استفاده در `DefineMenuItemsFRM` برای دسته‌بندی محصولات

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### DefineUnitFRM

#### 📌 شناسایی
- **نوع**: Form
- **مسیر**: `MainProject/Forms/DefineUnitFRM.cs` (احتمالی)
- **نام فنی**: DefineUnitFRM
- **نام فارسی**: تعریف واحدها

#### 🎯 هدف و کاربرد
تعریف واحدهای اندازه‌گیری (کیلوگرم، گرم، لیتر، عدد و ...)

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### DefineBankAccountFRM

#### 📌 شناسایی
- **نوع**: Form
- **مسیر**: `MainProject/Forms/DefineBankAccountFRM.cs`
- **نام فنی**: DefineBankAccountFRM
- **نام فارسی**: تعریف حساب بانکی

#### 🎯 هدف و کاربرد
تعریف حساب‌های بانکی شرکت برای ثبت تراکنش‌های مالی.

#### 🔗 وابستگیها
**ورودیها:**
- `AccountManager.GetAllAccounts()`
- `AccountManager.AddAccount()`
- `AccountManager.UpdateAccount()`

**خروجیها:**
- استفاده در `DefineAndSubmitOverHead` برای انتخاب حساب پرداخت

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

## فرمهای عملیاتی

### CreatSellFactorFRM

#### 📌 شناسایی
- **نوع**: Form
- **مسیر**: `MainProject/Forms/CreatSellFactorFRM.cs`
- **نام فنی**: CreatSellFactorFRM
- **نام فارسی**: ثبت فاکتور فروش

#### 🎯 هدف و کاربرد
ثبت فاکتور فروش محصولات به مشتریان. مهم‌ترین فرم عملیاتی سیستم.

#### 🔗 وابستگیها (Dependencies)
**ورودیها:**
- `ProductManager.GetAllProducts()`: لیست محصولات قابل فروش
- `FactorManager.CreateFactor()`: ثبت فاکتور
- `SellerManager.GetAllSellers()`: اطلاعات فروشندگان
- `ProductManager.GetProductPrice()`: قیمت محصولات

**خروجیها:**
- کسر موجودی مواد اولیه
- ثبت در حساب‌های مالی
- چاپ فاکتور

#### 📊 جریان داده (Data Flow)
```
Select Products → Add to Cart → Calculate Total → Apply Discount → 
Create Factor → Update Inventory → Print → Close
```

#### ⚠️ نکات مهم
- بررسی موجودی کافی قبل از فروش
- محاسبه خودکار جمع و تخفیف
- امکان چاپ فاکتور
- ثبت در سیستم حسابداری

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### AccessLayerDeclarationFRM

#### 📌 شناسایی
- **نوع**: Form
- **مسیر**: `MainProject/Forms/AccessLayerDeclarationFRM.cs`
- **نام فنی**: AccessLayerDeclarationFRM
- **نام فارسی**: ثبت ورود/خروج کالا به انبار

#### 🎯 هدف و کاربرد
ثبت ورود کالای جدید به انبار یا خروج کالا از انبار (غیر از فروش).

#### 🔗 وابستگیها
**ورودیها:**
- `ItemManager.UpdateInventory()`
- `ItemManager.GetAllItems()`

**خروجیها:**
- تغییر موجودی انبار

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### DefineAndSubmitOverHead

#### 📌 شناسایی
- **نوع**: Form
- **مسیر**: `MainProject/Forms/DefineAndSubmitOverHead.cs`
- **نام فنی**: DefineAndSubmitOverHead
- **نام فارسی**: تعریف و ثبت هزینه

#### 🎯 هدف و کاربرد
ثبت هزینه‌های رستوران (آب، برق، اجاره، حقوق و ...)

#### 🔗 وابستگیها
**ورودیها:**
- `OverHeadManager.AddOverHead()`
- `AccountManager.GetAllAccounts()`: انتخاب حساب پرداخت

**خروجیها:**
- کسر مبلغ از حساب بانکی
- ثبت در سیستم حسابداری

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

## فرمهای گزارش

### ReportsFRM (در صورت وجود)

**توضیح**: فرمهای گزارش در فاز 3 پیاده‌سازی خواهند شد.

---

## فرمهای مدیریتی

### LoginFRM

#### 📌 شناسایی
- **نوع**: Form
- **مسیر**: فرم اصلی (احتمالاً در MainFRM یا Form1)
- **نام فنی**: LoginFRM
- **نام فارسی**: ورود به سیستم

#### 🎯 هدف و کاربرد
احراز هویت کاربران و ورود به سیستم.

#### 🔗 وابستگیها
**ورودیها:**
- `LoginManager.Login(username, password)`

**خروجیها:**
- `LoginInfo.Instance`: ذخیره اطلاعات کاربر
- نمایش `MainFRM`

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### MainFRM

#### 📌 شناسایی
- **نوع**: Form
- **مسیر**: `MainProject/MainFRM.cs` یا `Form1.cs`
- **نام فنی**: MainFRM
- **نام فارسی**: فرم اصلی

#### 🎯 هدف و کاربرد
فرم اصلی برنامه که شامل منوها و دسترسی به تمام بخش‌های سیستم است.

#### 🔗 وابستگیها
**ورودیها:**
- `MainMenuManager.GetMenuItems()`: بارگذاری منو

**خروجیها:**
- فراخوانی سایر فرمها

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

## یادداشت

**این فایل در حال تکمیل است.** جزئیات کامل‌تر هر فرم در نسخه‌های بعدی اضافه خواهد شد.

برای اضافه کردن فرم جدید، از قالب زیر استفاده کنید:

```markdown
### [FormName]

#### 📌 شناسایی
- **نوع**: Form
- **مسیر**: [Path]
- **نام فنی**: [TechnicalName]
- **نام فارسی**: [PersianName]

#### 🎯 هدف و کاربرد
[Description]

#### 🔗 وابستگیها (Dependencies)
**ورودیها:** ...
**خروجیها:** ...

#### 📊 جریان داده (Data Flow)
```
[Flow]
```

#### ⚠️ نکات مهم
- نکته 1
- نکته 2

#### 📅 تاریخچه تغییرات
- YYYY-MM-DD: تغییر
```

---

**تاریخ ایجاد**: 2025-12-17  
**آخرین به‌روزرسانی**: 2025-12-17  
**نویسنده**: تیم توسعه MainProject

---

## Metadata (برای AI)

```json
{
  "document_type": "details_documentation",
  "chapter": 3,
  "layer": "forms",
  "forms_documented": 12,
  "language": "Persian (Farsi)",
  "last_updated": "2025-12-17",
  "version": "1.0",
  "status": "in_progress"
}
```
