# فصل 5: جزئیات دسترسی به داده (Data Access Details)

## 📋 فهرست مطالب
- [معرفی](#معرفی)
- [DAL Classes](#dal-classes)

---

## معرفی

این بخش شامل مستندات کامل تمام کلاس‌های DAL است که مسئول دسترسی به پایگاه داده هستند.

---

## DAL Classes

### ItemDAL

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/DataAccess/ItemDAL.cs`
- **نام فنی**: ItemDAL
- **نام فارسی**: لایه دسترسی اقلام

#### 🎯 هدف و کاربرد
دسترسی به داده‌های جدول Tbl_Items و اجرای عملیات CRUD.

#### 🔗 وابستگیها
**ورودیها:**
- Stored Procedures: `SP_Items_*`

**خروجیها:**
- استفاده توسط `ItemManager`

#### ⚙️ متدهای اصلی

##### SelectAll()
```csharp
public List<ItemModel> SelectAll()
```
**SP**: `SP_Items_SelectAll`

##### SelectByID(int id)
```csharp
public ItemModel SelectByID(int id)
```
**SP**: `SP_Items_SelectByID`

##### Insert(ItemModel model)
```csharp
public bool Insert(ItemModel model)
```
**SP**: `SP_Items_Insert`

##### Update(ItemModel model)
```csharp
public bool Update(ItemModel model)
```
**SP**: `SP_Items_Update`

##### Delete(int id)
```csharp
public bool Delete(int id)
```
**SP**: `SP_Items_Delete`

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### ProductDAL

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/DataAccess/ProductDAL.cs`
- **نام فنی**: ProductDAL
- **نام فارسی**: لایه دسترسی محصولات

#### 🎯 هدف و کاربرد
دسترسی به داده‌های محصولات و دستور پخت.

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### FactorDAL

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/DataAccess/FactorDAL.cs`
- **نام فنی**: FactorDAL
- **نام فارسی**: لایه دسترسی فاکتور

#### 🎯 هدف و کاربرد
دسترسی به داده‌های فاکتورها و آیتم‌های فاکتور.

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### AccountDAL

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/DataAccess/AccountDAL.cs`
- **نام فنی**: AccountDAL
- **نام فارسی**: لایه دسترسی حساب‌ها

#### 🎯 هدف و کاربرد
دسترسی به داده‌های حساب‌های بانکی.

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### OverHeadDAL

#### 📌 شناسایی
- **نوع**: Class
- **مسیر**: `MainProject/DataAccess/OverHeadDAL.cs`
- **نام فنی**: OverHeadDAL
- **نام فارسی**: لایه دسترسی هزینه‌ها

#### 🎯 هدف و کاربرد
دسترسی به داده‌های هزینه‌ها.

#### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

## یادداشت

**این فایل در حال تکمیل است.** جزئیات کامل‌تر هر DAL Class و Stored Procedures مرتبط در نسخه‌های بعدی اضافه خواهد شد.

---

**تاریخ ایجاد**: 2025-12-17  
**آخرین به‌روزرسانی**: 2025-12-17

---

## Metadata (برای AI)

```json
{
  "document_type": "details_documentation",
  "chapter": 5,
  "layer": "data_access",
  "dal_documented": 12,
  "language": "Persian (Farsi)",
  "last_updated": "2025-12-17",
  "status": "in_progress"
}
```
