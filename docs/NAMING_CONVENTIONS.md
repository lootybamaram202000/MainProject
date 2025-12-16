# استاندارد نام‌گذاری در پروژه MainProject

این سند قواعد نام‌گذاری کنترل‌ها، متدها و فایل‌ها را مشخص می‌کند. هدف، یکدست‌سازی و خوانایی بیشتر کد است. متن‌های نمایشی UI فارسی می‌مانند؛ فقط شناسه‌ها انگلیسی هستند.

## هدف و دامنه
- اعمال این استاندارد در تمام فرم‌ها به‌ویژه فرم منوی اصلی (MainMenuFRM).
- تمرکز بر نام‌گذاری شناسه‌ها؛ نه تغییر متن‌های نمایشی فارسی.

## اصول کلی
- نام‌ها به‌صورت PascalCase باشند.
- برای کنترل‌های WinForms از پیشوندهای کوتاه و یکدست استفاده شود.
- برای هندلر رویدادها از الگوی زیر استفاده شود:

`ControlName_EventName`

- از نام‌های پیش‌فرض (label1, panel1, ...) پرهیز شود؛ نام معنادار انتخاب گردد.
- تا اطلاع ثانوی، متن‌های نمایشی فارسی (Text) دست‌نخورده باقی بمانند.

## پیشوندهای توصیه‌شده برای کنترل‌ها
- ToolStripMenuItem: `tsm`
- Label: `lbl`
- LinkLabel: `lnk`
- DataGridView: `dgv`
- Panel: `pnl`
- MenuStrip: `ms`
- TabControl: `tbc`
- TabPage: `tbp`
- Button: `btn`
- TextBox: `txt`
- ComboBox: `cmb`

نمونه‌ها:
- `tsmDefineUnit` ، `tsmProducts` ، `tsmRecordDamages`
- `lblCurrentDate` ، `lblUserCaption`
- `lnkNotifications` ، `lnkPending`
- `dgvNotifications` ، `dgvMessages` ، `dgvPending`
- `pnlRightInfo`
- `msMain`
- `tbcNotification` ، `tbpNotifications` ، `tbpMessages`

## نام‌گذاری رویدادها
الگو:

`ControlName_EventName`

نمونه‌ها:
- `tsmDefineUnit_Click`
- `tsmRecordSellFactor_Click`
- `dgvNotifications_CellContentClick`
- `MainMenuFRM_Load`
- `MainMenuFRM_FormClosing`

نکته: اگر نام هندلرهای فعلی فارسی هستند، به‌صورت مرحله‌ای با Rename (Refactor) به نام‌های انگلیسی تبدیل شوند تا سیم‌کشی رویدادها سالم بماند.

## نام‌گذاری فرم‌ها و فایل‌ها
- نام کلاس فرم و فایل `.cs` هم‌نام و PascalCase باشد.
- مثال: `MainMenuFRM.cs` ، `MainMenuFRM.Designer.cs`

## متن‌های نمایشی (UI Text)
- همهٔ `Text` ها فارسی بمانند مگر مستند خلاف آن اقتضا کند.
- تغییر نام شناسه‌ها (Identifiers) به انگلیسی تأثیری بر زبان UI ندارد.

## روند امن بازنام‌گذاری
1) بازنام‌گذاری شناسهٔ کنترل در ویرایشگر کد با ابزار Refactor (نه ویرایش دستی متن Designer).
2) سپس بازنام‌گذاری متد رویداد متناظر با همان ابزار.
3) بیلد پس از هر چند تغییر (کنترل خطا).
4) جست‌وجوی Regex برای یافتن شناسه‌های فارسی باقی‌مانده (فقط روی `.cs` ، نه `.resx`):

`[\u0600-\u06FF]+`

## نمونهٔ کاربرد برای MainMenuFRM
- آیتم‌های منو (نمونه الگوهای پذیرفته‌شده در پروژه):
  - `tsmRecordDamages` ، `tsmSystemManagement` ، `tsmUsersManagement`
  - `tsmSectionManagement` ، `tsmProductManagement` ، `tsmWareHousing`
  - `tsmReports` ، `tsmItems` ، `tsmSellers` ، `tsmAccounting`

- گریدها:
  - `dgvNotifications` ، `dgvMessages` ، `dgvPending`

- تب‌ها:
  - `tbcNotification` ، `tbpNotifications` ، `tbpMessages` ، `tbpPendingList`

- برچسب‌ها و لینک‌ها:
  - `lblCurrentDate` ، `lblSystemDate` ، `lblUserCaption`
  - `lnkNotifications` ، `lnkPending`

- هندلر رویدادها (الگو؛ نام‌های فعلی اگر فارسی‌اند، در فاز بعدی با Rename استاندارد شوند):
  - `tsmDefineUnit_Click` ، `tsmRecordSellFactor_Click` ، `tsmRecordBuyFactors_Click`
  - `tsmBankAccounts_Click` ، `tsmOverheadCalculations_Click`
  - `dgvNotifications_CellContentClick` ، `dgvMessages_CellContentClick` ، `dgvPending_CellContentClick`

---
این سند ممکن است با پیشروی پروژه به‌روزرسانی شود. نسخهٔ نخست برای هم‌ترازی اولیه تدوین شده است.