# فصل 7: جزئیات پایگاه داده (Database Details)

## 📋 فهرست مطالب
- [معرفی](#معرفی)
- [جداول](#جداول)
- [Stored Procedures](#stored-procedures)
- [Views](#views)
- [Functions](#functions)

---

## معرفی

این بخش شامل مستندات کامل پایگاه داده SQL Server است.

---

## جداول

### Tbl_Items

#### 📌 شناسایی
- **نوع**: Table
- **نام فنی**: Tbl_Items
- **نام فارسی**: جدول اقلام پایه

#### 🎯 هدف و کاربرد
ذخیره اطلاعات اقلام پایه (مواد اولیه) انبار.

#### 📊 ساختار

| Column | Type | Null | Default | Description |
|--------|------|------|---------|-------------|
| ItemID | INT | NO | IDENTITY | شناسه یکتا (PK) |
| ItemName | NVARCHAR(100) | NO | - | نام قلم |
| UnitID | INT | YES | - | شناسه واحد (FK) |
| UnitPrice | DECIMAL(18,2) | YES | 0 | قیمت واحد |
| Quantity | INT | YES | 0 | موجودی |
| MinQuantity | INT | YES | 0 | حداقل موجودی |
| IsActive | BIT | YES | 1 | فعال/غیرفعال |
| CreatedDate | DATETIME | YES | GETDATE() | تاریخ ایجاد |
| CreatedBy | INT | YES | - | ایجادکننده |

#### 🔗 روابط
- FK: UnitID → Tbl_Units(UnitID)

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### Tbl_Products

#### 📌 شناسایی
- **نوع**: Table
- **نام فنی**: Tbl_Products
- **نام فارسی**: جدول محصولات

#### 🎯 هدف و کاربرد
ذخیره اطلاعات محصولات نهایی (غذاها).

#### 📊 ساختار

| Column | Type | Null | Description |
|--------|------|------|-------------|
| ProductID | INT | NO | شناسه (PK) |
| ProductName | NVARCHAR(100) | NO | نام محصول |
| SectionID | INT | YES | شناسه بخش (FK) |
| SalePrice | DECIMAL(18,2) | NO | قیمت فروش |
| CostPrice | DECIMAL(18,2) | YES | قیمت تمام شده |
| Description | NVARCHAR(500) | YES | توضیحات |
| IsAvailable | BIT | YES | موجود |
| CreatedDate | DATETIME | YES | تاریخ |

#### 🔗 روابط
- FK: SectionID → Tbl_Sections(SectionID)

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### Tbl_Factors

#### 📌 شناسایی
- **نوع**: Table
- **نام فنی**: Tbl_Factors
- **نام فارسی**: جدول فاکتورها

#### 🎯 هدف و کاربرد
ذخیره اطلاعات اصلی فاکتورهای فروش.

#### 📊 ساختار

| Column | Type | Null | Description |
|--------|------|------|-------------|
| FactorID | INT | NO | شناسه (PK) |
| FactorNumber | NVARCHAR(20) | NO | شماره فاکتور (Unique) |
| FactorDate | DATETIME | YES | تاریخ |
| CustomerID | INT | YES | شناسه مشتری |
| TotalAmount | DECIMAL(18,2) | YES | مجموع |
| Discount | DECIMAL(18,2) | YES | تخفیف |
| FinalAmount | DECIMAL(18,2) | YES | مبلغ نهایی |
| IsPaid | BIT | YES | پرداخت شده |

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### Tbl_SubFactors

#### 📌 شناسایی
- **نوع**: Table
- **نام فنی**: Tbl_SubFactors
- **نام فارسی**: جدول آیتم‌های فاکتور

#### 🎯 هدف و کاربرد
ذخیره آیتم‌های (محصولات) هر فاکتور.

#### 🔗 روابط
- FK: FactorID → Tbl_Factors(FactorID)
- FK: ProductID → Tbl_Products(ProductID)

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

## Stored Procedures

### SP_Items_SelectAll

#### 📌 شناسایی
- **نوع**: Stored Procedure
- **نام فنی**: SP_Items_SelectAll
- **نام فارسی**: دریافت لیست اقلام

#### 🎯 هدف و کاربرد
دریافت لیست تمام اقلام فعال.

#### ⚙️ پارامترها
بدون پارامتر

#### 🧪 نمونه استفاده
```sql
EXEC SP_Items_SelectAll
```

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### SP_Items_Insert

#### 📌 شناسایی
- **نوع**: Stored Procedure
- **نام فنی**: SP_Items_Insert
- **نام فارسی**: افزودن قلم جدید

#### 🎯 هدف و کاربرد
افزودن قلم جدید به انبار.

#### ⚙️ پارامترها

| Parameter | Type | Direction | Description |
|-----------|------|-----------|-------------|
| @ItemName | NVARCHAR(100) | IN | نام قلم |
| @UnitID | INT | IN | شناسه واحد |
| @UnitPrice | DECIMAL(18,2) | IN | قیمت |
| @Quantity | INT | IN | موجودی |
| @MinQuantity | INT | IN | حداقل موجودی |
| @CreatedBy | INT | IN | کاربر ایجادکننده |

#### 🧪 نمونه استفاده
```sql
EXEC SP_Items_Insert 
    @ItemName = N'برنج', 
    @UnitID = 1, 
    @UnitPrice = 50000, 
    @Quantity = 100,
    @MinQuantity = 20,
    @CreatedBy = 1
```

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

## Views

### VW_ProductsWithCost

#### 📌 شناسایی
- **نوع**: View
- **نام فنی**: VW_ProductsWithCost
- **نام فارسی**: نمای محصولات با قیمت تمام شده

#### 🎯 هدف و کاربرد
نمایش محصولات همراه با قیمت تمام شده محاسبه شده از دستور پخت.

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

## Functions

### FN_CalculateProductCost

#### 📌 شناسایی
- **نوع**: Scalar Function
- **نام فنی**: FN_CalculateProductCost
- **نام فارسی**: محاسبه قیمت تمام شده محصول

#### 🎯 هدف و کاربرد
محاسبه قیمت تمام شده یک محصول بر اساس دستور پخت.

#### ⚙️ پارامترها

| Parameter | Type | Description |
|-----------|------|-------------|
| @ProductID | INT | شناسه محصول |

**بازگشتی**: DECIMAL(18,2) - قیمت تمام شده

#### 🧪 نمونه استفاده
```sql
SELECT dbo.FN_CalculateProductCost(1) AS CostPrice
```

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

## یادداشت

**این فایل در حال تکمیل است.** تمام جداول، Stored Procedures، Views و Functions با جزئیات کامل در نسخه‌های بعدی اضافه خواهند شد.

---

**تاریخ ایجاد**: 2025-12-17  
**آخرین به‌روزرسانی**: 2025-12-17

---

## Metadata (برای AI)

```json
{
  "document_type": "details_documentation",
  "chapter": 7,
  "layer": "database",
  "tables_documented": 5,
  "procedures_documented": 2,
  "language": "Persian (Farsi)",
  "last_updated": "2025-12-17",
  "status": "in_progress"
}
```
