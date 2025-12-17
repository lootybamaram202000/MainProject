# فصل 6: جزئیات موجودیت‌ها (Entity Details)

## 📋 فهرست مطالب
- [معرفی](#معرفی)
- [Model Classes](#model-classes)

---

## معرفی

این بخش شامل مستندات کامل تمام کلاس‌های Model (Entity) است.

---

## Model Classes

### ItemModel

#### 📌 شناسایی
- **نوع**: Class (POCO)
- **مسیر**: `MainProject/Entities/ItemModel.cs`
- **نام فنی**: ItemModel
- **نام فارسی**: مدل قلم انبار

#### 🎯 هدف و کاربرد
نمایش اطلاعات اقلام پایه (مواد اولیه) برای انتقال بین لایه‌ها.

#### ⚙️ خصوصیات (Properties)

| Property | Type | توضیحات |
|----------|------|---------|
| ItemID | int | شناسه یکتا |
| ItemName | string | نام قلم |
| UnitID | int | شناسه واحد |
| UnitPrice | decimal | قیمت واحد |
| Quantity | int | موجودی |
| MinQuantity | int | حداقل موجودی |
| IsActive | bool | وضعیت فعال |
| CreatedDate | DateTime | تاریخ ایجاد |

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### ProductModel

#### 📌 شناسایی
- **نوع**: Class (POCO)
- **مسیر**: `MainProject/Entities/ProductModel.cs`
- **نام فنی**: ProductModel
- **نام فارسی**: مدل محصول

#### 🎯 هدف و کاربرد
نمایش اطلاعات محصولات نهایی.

#### ⚙️ خصوصیات

| Property | Type | توضیحات |
|----------|------|---------|
| ProductID | int | شناسه یکتا |
| ProductName | string | نام محصول |
| SectionID | int | شناسه بخش |
| SalePrice | decimal | قیمت فروش |
| CostPrice | decimal | قیمت تمام شده |
| Description | string | توضیحات |
| IsAvailable | bool | موجود بودن |

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### FactorModel

#### 📌 شناسایی
- **نوع**: Class (POCO)
- **مسیر**: `MainProject/Entities/FactorModel.cs`
- **نام فنی**: FactorModel
- **نام فارسی**: مدل فاکتور

#### 🎯 هدف و کاربرد
نمایش اطلاعات فاکتور فروش.

#### ⚙️ خصوصیات

| Property | Type | توضیحات |
|----------|------|---------|
| FactorID | int | شناسه یکتا |
| FactorNumber | string | شماره فاکتور |
| FactorDate | DateTime | تاریخ فاکتور |
| CustomerID | int | شناسه مشتری |
| TotalAmount | decimal | مجموع |
| Discount | decimal | تخفیف |
| FinalAmount | decimal | مبلغ نهایی |
| IsPaid | bool | پرداخت شده |

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### SubFactorModel

#### 📌 شناسایی
- **نوع**: Class (POCO)
- **مسیر**: `MainProject/Entities/SubFactorModel.cs`
- **نام فنی**: SubFactorModel
- **نام فارسی**: مدل آیتم فاکتور

#### 🎯 هدف و کاربرد
نمایش آیتم‌های یک فاکتور (محصولات فروخته شده).

#### ⚙️ خصوصیات

| Property | Type | توضیحات |
|----------|------|---------|
| SubFactorID | int | شناسه یکتا |
| FactorID | int | شناسه فاکتور |
| ProductID | int | شناسه محصول |
| Quantity | int | تعداد |
| UnitPrice | decimal | قیمت واحد |
| TotalPrice | decimal | جمع |
| Discount | decimal | تخفیف |

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### AccountModel

#### 📌 شناسایی
- **نوع**: Class (POCO)
- **مسیر**: `MainProject/Entities/AccountModel.cs`
- **نام فنی**: AccountModel
- **نام فارسی**: مدل حساب بانکی

#### 🎯 هدف و کاربرد
نمایش اطلاعات حساب‌های بانکی.

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### OverHeadModel

#### 📌 شناسایی
- **نوع**: Class (POCO)
- **مسیر**: `MainProject/Entities/OverHeadModel.cs`
- **نام فنی**: OverHeadModel
- **نام فارسی**: مدل هزینه

#### 🎯 هدف و کاربرد
نمایش اطلاعات هزینه‌ها.

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

## یادداشت

**این فایل در حال تکمیل است.** تمام Model Classes با جزئیات کامل در نسخه‌های بعدی اضافه خواهند شد.

---

**تاریخ ایجاد**: 2025-12-17  
**آخرین به‌روزرسانی**: 2025-12-17

---

## Metadata (برای AI)

```json
{
  "document_type": "details_documentation",
  "chapter": 6,
  "layer": "entity",
  "models_documented": 16,
  "language": "Persian (Farsi)",
  "last_updated": "2025-12-17",
  "status": "in_progress"
}
```
