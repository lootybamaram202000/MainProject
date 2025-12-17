# فصل 8: جزئیات توابع کمکی (Helper Functions Details)

## 📋 فهرست مطالب
- [معرفی](#معرفی)
- [Helper Classes](#helper-classes)

---

## معرفی

این بخش شامل مستندات کامل تمام توابع و کلاس‌های کمکی است.

---

## Helper Classes

### CommonFunctions

#### 📌 شناسایی
- **نوع**: Static Class
- **مسیر**: `MainProject/Helpers/CommonFunctions.cs`
- **نام فنی**: CommonFunctions
- **نام فارسی**: توابع عمومی

#### 🎯 هدف و کاربرد
مجموعه توابع عمومی و پرکاربرد برای استفاده در سراسر برنامه.

---

#### متد: FormatCurrency

##### 📌 شناسایی
- **نام متد**: `FormatCurrency`
- **نوع بازگشتی**: `string`

##### 🎯 هدف و کاربرد
فرمت کردن مبالغ به صورت ریالی با جداکننده هزارگان.

##### ⚙️ پارامترها

| Parameter | Type | Description |
|-----------|------|-------------|
| amount | decimal | مبلغ برای فرمت |

##### 🧪 نمونه استفاده
```csharp
decimal price = 1500000;
string formatted = CommonFunctions.FormatCurrency(price);
// خروجی: "1,500,000 ریال"
```

##### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

#### متد: FormatDate

##### 📌 شناسایی
- **نام متد**: `FormatDate`
- **نوع بازگشتی**: `string`

##### 🎯 هدف و کاربرد
تبدیل تاریخ میلادی به تاریخ شمسی با فرمت استاندارد.

##### ⚙️ پارامترها

| Parameter | Type | Description |
|-----------|------|-------------|
| date | DateTime | تاریخ میلادی |

##### 🧪 نمونه استفاده
```csharp
DateTime now = DateTime.Now;
string persianDate = CommonFunctions.FormatDate(now);
// خروجی: "1404/09/27"
```

##### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

#### متد: IsValidEmail

##### 📌 شناسایی
- **نام متد**: `IsValidEmail`
- **نوع بازگشتی**: `bool`

##### 🎯 هدف و کاربرد
اعتبارسنجی ایمیل.

##### ⚙️ پارامترها

| Parameter | Type | Description |
|-----------|------|-------------|
| email | string | آدرس ایمیل |

##### 🧪 نمونه استفاده
```csharp
bool isValid = CommonFunctions.IsValidEmail("test@example.com");
// خروجی: true
```

##### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

#### متد: ToPersianNumbers

##### 📌 شناسایی
- **نام متد**: `ToPersianNumbers`
- **نوع بازگشتی**: `string`

##### 🎯 هدف و کاربرد
تبدیل اعداد انگلیسی به فارسی.

##### ⚙️ پارامترها

| Parameter | Type | Description |
|-----------|------|-------------|
| input | string | رشته ورودی |

##### 🧪 نمونه استفاده
```csharp
string persian = CommonFunctions.ToPersianNumbers("123");
// خروجی: "۱۲۳"
```

##### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

#### متد: ShowSuccess

##### 📌 شناسایی
- **نام متد**: `ShowSuccess`
- **نوع بازگشتی**: `void`

##### 🎯 هدف و کاربرد
نمایش پیغام موفقیت به کاربر.

##### ⚙️ پارامترها

| Parameter | Type | Description |
|-----------|------|-------------|
| message | string | متن پیغام |

##### 🧪 نمونه استفاده
```csharp
CommonFunctions.ShowSuccess("ذخیره با موفقیت انجام شد");
```

##### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### LoginInfo

#### 📌 شناسایی
- **نوع**: Singleton Class
- **مسیر**: `MainProject/Helpers/LoginInfo.cs`
- **نام فنی**: LoginInfo
- **نام فارسی**: اطلاعات ورود

#### 🎯 هدف و کاربرد
نگهداری اطلاعات کاربر جاری در سراسر برنامه (Singleton Pattern).

---

#### Property: Instance

##### 📌 شناسایی
- **نام**: `Instance`
- **نوع**: `LoginInfo`
- **دسترسی**: `public static`

##### 🎯 هدف و کاربرد
دسترسی به نمونه یکتای کلاس.

##### 🧪 نمونه استفاده
```csharp
LoginInfo current = LoginInfo.Instance;
```

---

#### Property: UserID

##### 📌 شناسایی
- **نام**: `UserID`
- **نوع**: `int`

##### 🎯 هدف و کاربرد
شناسه کاربر جاری.

---

#### Property: IsLoggedIn

##### 📌 شناسایی
- **نام**: `IsLoggedIn`
- **نوع**: `bool`

##### 🎯 هدف و کاربرد
وضعیت ورود کاربر.

##### 🧪 نمونه استفاده
```csharp
if (LoginInfo.Instance.IsLoggedIn)
{
    // کاربر وارد شده است
}
```

---

#### متد: Login

##### 📌 شناسایی
- **نام متد**: `Login`
- **نوع بازگشتی**: `void`

##### 🎯 هدف و کاربرد
ثبت ورود کاربر و ذخیره اطلاعات.

##### ⚙️ پارامترها

| Parameter | Type | Description |
|-----------|------|-------------|
| userId | int | شناسه کاربر |
| username | string | نام کاربری |
| fullName | string | نام کامل |
| roleId | int | شناسه نقش |

##### 🧪 نمونه استفاده
```csharp
LoginInfo.Instance.Login(1, "admin", "مدیر سیستم", 1);
```

##### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

#### متد: Logout

##### 📌 شناسایی
- **نام متد**: `Logout`
- **نوع بازگشتی**: `void`

##### 🎯 هدف و کاربرد
خروج کاربر و پاکسازی اطلاعات.

##### 🧪 نمونه استفاده
```csharp
LoginInfo.Instance.Logout();
```

##### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

### Config

#### 📌 شناسایی
- **نوع**: Static Class
- **مسیر**: `MainProject/Config.cs`
- **نام فنی**: Config
- **نام فارسی**: تنظیمات

#### 🎯 هدف و کاربرد
مدیریت تنظیمات و پیکربندی برنامه.

---

#### Property: ConnectionString

##### 📌 شناسایی
- **نام**: `ConnectionString`
- **نوع**: `string`
- **دسترسی**: `public static`

##### 🎯 هدف و کاربرد
دریافت رشته اتصال به پایگاه داده.

##### 🧪 نمونه استفاده
```csharp
string connStr = Config.ConnectionString;
```

##### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

#### متد: GetSetting

##### 📌 شناسایی
- **نام متد**: `GetSetting`
- **نوع بازگشتی**: `string`

##### 🎯 هدف و کاربرد
دریافت مقدار یک تنظیم از App.config.

##### ⚙️ پارامترها

| Parameter | Type | Description |
|-----------|------|-------------|
| key | string | کلید تنظیم |

##### 🧪 نمونه استفاده
```csharp
string companyName = Config.GetSetting("CompanyName");
```

##### 📅 تاریخچه تغییرات
- 2025-12-17: ایجاد مستند اولیه

---

## یادداشت

**این فایل در حال تکمیل است.** تمام توابع کمکی با جزئیات کامل در نسخه‌های بعدی اضافه خواهند شد.

---

**تاریخ ایجاد**: 2025-12-17  
**آخرین به‌روزرسانی**: 2025-12-17

---

## Metadata (برای AI)

```json
{
  "document_type": "details_documentation",
  "chapter": 8,
  "layer": "helper",
  "classes_documented": 3,
  "language": "Persian (Farsi)",
  "last_updated": "2025-12-17",
  "status": "in_progress"
}
```
