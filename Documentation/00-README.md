# 📚 مستندات سیستم حسابداری رستوران

## 🎯 درباره این مستندات

این مجموعه مستندات، راهنمای جامع و کاملی از سیستم حسابداری رستوران است که به صورت لایه‌ای (Layered Architecture) طراحی و پیاده‌سازی شده است.

## 📖 فهرست مطالب

### فصل 1: معرفی
- [01-Introduction.md](01-Introduction.md) - معرفی برنامه، اهداف و دامنه کاری

### فصل 2: معماری
- [02-Architecture-Overview.md](02-Architecture-Overview.md) - نمای کلی معماری سیستم
  - [2.1-Forms-Layer.md](02-Architecture-Overview/2.1-Forms-Layer.md) - لایه رابط کاربری (Presentation)
  - [2.2-Business-Layer.md](02-Architecture-Overview/2.2-Business-Layer.md) - لایه منطق کسب‌وکار
  - [2.3-DataAccess-Layer.md](02-Architecture-Overview/2.3-DataAccess-Layer.md) - لایه دسترسی به داده
  - [2.4-Entity-Layer.md](02-Architecture-Overview/2.4-Entity-Layer.md) - لایه موجودیت‌ها
  - [2.5-Database-Layer.md](02-Architecture-Overview/2.5-Database-Layer.md) - لایه پایگاه داده
  - [2.6-Helper-Layer.md](02-Architecture-Overview/2.6-Helper-Layer.md) - لایه توابع کمکی

### فصل 3-8: جزئیات لایه‌ها
- [03-Forms-Details.md](03-Forms-Details.md) - جزئیات کامل فرمها و رابط کاربری
- [04-Business-Details.md](04-Business-Details.md) - جزئیات کامل کلاس‌های Business Manager
- [05-DataAccess-Details.md](05-DataAccess-Details.md) - جزئیات کامل کلاس‌های DAL
- [06-Entity-Details.md](06-Entity-Details.md) - جزئیات کامل Model Classes
- [07-Database-Details.md](07-Database-Details.md) - جزئیات کامل پایگاه داده
- [08-Helper-Details.md](08-Helper-Details.md) - جزئیات کامل توابع کمکی

### فصل 9-10: ارتباطات و اجزای مشترک
- [09-Cross-References.md](09-Cross-References.md) - نقشه ارتباطات و وابستگی‌های سیستم
- [10-Common-Components.md](10-Common-Components.md) - اجزای عمومی و مشترک

## 🗺️ راهنمای استفاده

### برای توسعه‌دهندگان جدید
1. ابتدا [01-Introduction.md](01-Introduction.md) را مطالعه کنید
2. سپس [02-Architecture-Overview.md](02-Architecture-Overview.md) را بخوانید
3. برای شروع کار با هر لایه، به فصل مربوطه (3-8) مراجعه کنید
4. برای درک روابط، [09-Cross-References.md](09-Cross-References.md) را بررسی کنید

### برای توسعه‌دهندگان فعلی
- برای اضافه کردن ویژگی جدید: ابتدا معماری را در فصل 2 بررسی کنید
- برای رفع باگ: از Cross-References برای یافتن وابستگی‌ها استفاده کنید
- برای رفکتورینگ: Common-Components را بررسی کنید

### برای مدیران پروژه
- نمای کلی: فصل 1 و 2
- وضعیت پیشرفت: بخش "تاریخچه تغییرات" در هر فصل
- وابستگی‌ها: فصل 9

## 📋 فازهای پروژه

### ✅ فاز 1: مدیریت انبار و فروش (تقریباً کامل)
- مدیریت کالا و محصولات
- مدیریت فروش و فاکتور
- مدیریت موجودی انبار
- تعریف واحدها و بخش‌ها

### 🚧 فاز 2: حسابداری (در حال توسعه)
- مدیریت حساب‌های بانکی
- مدیریت هزینه‌ها
- گزارش‌های مالی
- تسویه حساب

### 📅 فاز 3: تحلیل و گزارشگیری (برنامه‌ریزی شده)
- داشبورد مدیریتی
- گزارش‌های تحلیلی
- پیش‌بینی و تحلیل روند
- گزارش‌های قابل تنظیم

## 🔄 نحوه به‌روزرسانی مستندات

هنگام ایجاد یا تغییر هر قسمت از کد:

1. **فایل مربوطه را پیدا کنید**: مثلاً برای تغییر در یک Manager Class، فایل `04-Business-Details.md`
2. **بخش مربوط به کلاس را به‌روز کنید**: از قالب استاندارد استفاده کنید
3. **وابستگی‌ها را بررسی کنید**: اگر رابطه جدیدی ایجاد شد، `09-Cross-References.md` را به‌روز کنید
4. **تاریخچه را ثبت کنید**: تاریخ و توضیح تغییر را اضافه کنید

## 📝 قالب استاندارد مستندسازی

برای جزئیات کامل قالب‌ها و دستورالعمل‌های مستندسازی، به فایل `.github/copilot/documentation-agent.md` مراجعه کنید.

## 🛠️ ابزارهای مورد استفاده

- **زبان**: C# (.NET Framework)
- **رابط کاربری**: Windows Forms
- **پایگاه داده**: SQL Server
- **الگوی معماری**: Layered Architecture
- **مستندسازی**: Markdown با پشتیبانی Mermaid

## 📞 ارتباط با تیم

برای سوالات یا پیشنهادات درباره مستندات:
- Issue جدید در GitHub ایجاد کنید
- از تگ `documentation` استفاده کنید
- پیشنهادات بهبود را با Pull Request ارسال کنید

---

**آخرین به‌روزرسانی**: 2025-12-17  
**نسخه مستندات**: 1.0  
**وضعیت**: در حال توسعه
