# فصل 9: نقشه ارتباطات (Cross-References Map)

## 📋 فهرست مطالب
- [معرفی](#معرفی)
- [نمودار کلی ارتباطات](#نمودار-کلی-ارتباطات)
- [ارتباطات Forms به Business](#ارتباطات-forms-به-business)
- [ارتباطات Business به DAL](#ارتباطات-business-به-dal)
- [ارتباطات DAL به Database](#ارتباطات-dal-به-database)
- [جریان داده End-to-End](#جریان-داده-end-to-end)

---

## معرفی

این بخش نقشه کامل ارتباطات و وابستگی‌های بین اجزای مختلف سیستم را نمایش می‌دهد.

---

## نمودار کلی ارتباطات

### معماری کلی سیستم

```mermaid
graph TB
    subgraph "Presentation Layer"
        F1[DefineBasicItemsFRM]
        F2[DefineMenuItemsFRM]
        F3[CreatSellFactorFRM]
        F4[DefineBankAccountFRM]
        F5[DefineAndSubmitOverHead]
    end
    
    subgraph "Business Logic Layer"
        M1[ItemManager]
        M2[ProductManager]
        M3[FactorManager]
        M4[AccountManager]
        M5[OverHeadManager]
        M6[SellerManager]
        M7[UnitManager]
        M8[SectionManager]
        M9[LoginManager]
    end
    
    subgraph "Data Access Layer"
        D1[ItemDAL]
        D2[ProductDAL]
        D3[FactorDAL]
        D4[AccountDAL]
        D5[OverHeadDAL]
        D6[SellerDAL]
        D7[UnitDAL]
        D8[SectionDAL]
        D9[LoginDAL]
    end
    
    subgraph "Database Layer"
        DB[(SQL Server)]
    end
    
    subgraph "Cross-Cutting"
        E[Entity Models]
        H[Helper Functions]
    end
    
    F1 --> M1
    F2 --> M2
    F2 --> M1
    F3 --> M3
    F3 --> M2
    F4 --> M4
    F5 --> M5
    
    M1 --> D1
    M2 --> D2
    M3 --> D3
    M4 --> D4
    M5 --> D5
    M6 --> D6
    M7 --> D7
    M8 --> D8
    M9 --> D9
    
    D1 --> DB
    D2 --> DB
    D3 --> DB
    D4 --> DB
    D5 --> DB
    D6 --> DB
    D7 --> DB
    D8 --> DB
    D9 --> DB
    
    F1 -.-> E
    F2 -.-> E
    F3 -.-> E
    M1 -.-> E
    M2 -.-> E
    M3 -.-> E
    D1 -.-> E
    D2 -.-> E
    D3 -.-> E
    
    F1 -.-> H
    F2 -.-> H
    M1 -.-> H
    M2 -.-> H
```

---

## ارتباطات Forms به Business

### نمودار ارتباطات فرمها

```mermaid
graph LR
    subgraph "Forms"
        F1[DefineBasicItemsFRM]
        F2[DefineMenuItemsFRM]
        F3[CreatSellFactorFRM]
        F4[DefineSectionsFRM]
        F5[DefineUnitFRM]
        F6[DefineBankAccountFRM]
        F7[DefineAndSubmitOverHead]
    end
    
    subgraph "Managers"
        M1[ItemManager]
        M2[ProductManager]
        M3[FactorManager]
        M4[SectionManager]
        M5[UnitManager]
        M6[AccountManager]
        M7[OverHeadManager]
    end
    
    F1 -->|GetAllItems<br/>AddItem<br/>UpdateItem<br/>DeleteItem| M1
    F1 -->|GetAllUnits| M5
    
    F2 -->|GetAllProducts<br/>AddProduct<br/>UpdateProduct| M2
    F2 -->|GetAllItems| M1
    F2 -->|GetAllSections| M4
    
    F3 -->|GetAllProducts| M2
    F3 -->|CreateFactor| M3
    
    F4 -->|GetAllSections<br/>AddSection| M4
    
    F5 -->|GetAllUnits<br/>AddUnit| M5
    
    F6 -->|GetAllAccounts<br/>AddAccount| M6
    
    F7 -->|AddOverHead| M7
    F7 -->|GetAllAccounts| M6
```

---

## ارتباطات Business به DAL

### جدول وابستگی‌ها

| Manager Class | استفاده از DAL | متدهای استفاده شده |
|---------------|----------------|-------------------|
| ItemManager | ItemDAL | SelectAll, SelectByID, Insert, Update, Delete |
| ItemManager | UnitDAL | SelectAll (برای اعتبارسنجی) |
| ProductManager | ProductDAL | SelectAll, SelectByID, Insert, Update |
| ProductManager | ItemDAL | SelectAll (برای دستور پخت) |
| ProductManager | BasicRecipeDAL | Insert, Update, Delete |
| FactorManager | FactorDAL | Insert, SelectAll |
| FactorManager | SubFactorDAL | Insert |
| FactorManager | ItemDAL | UpdateInventory |
| AccountManager | AccountDAL | SelectAll, Insert, Update |
| OverHeadManager | OverHeadDAL | Insert, SelectAll |
| OverHeadManager | AccountDAL | UpdateBalance |

---

## ارتباطات DAL به Database

### نمودار Stored Procedures

```mermaid
graph LR
    subgraph "DAL Classes"
        D1[ItemDAL]
        D2[ProductDAL]
        D3[FactorDAL]
        D4[AccountDAL]
    end
    
    subgraph "Stored Procedures"
        SP1[SP_Items_SelectAll]
        SP2[SP_Items_Insert]
        SP3[SP_Items_Update]
        SP4[SP_Items_Delete]
        
        SP5[SP_Products_SelectAll]
        SP6[SP_Products_Insert]
        
        SP7[SP_Factor_Insert]
        SP8[SP_SubFactor_Insert]
        
        SP9[SP_Account_SelectAll]
        SP10[SP_Account_UpdateBalance]
    end
    
    D1 --> SP1
    D1 --> SP2
    D1 --> SP3
    D1 --> SP4
    
    D2 --> SP5
    D2 --> SP6
    
    D3 --> SP7
    D3 --> SP8
    
    D4 --> SP9
    D4 --> SP10
```

### جدول کامل SP ها

| DAL Class | Stored Procedure | عملیات |
|-----------|------------------|--------|
| ItemDAL | SP_Items_SelectAll | دریافت لیست |
| ItemDAL | SP_Items_SelectByID | دریافت یک رکورد |
| ItemDAL | SP_Items_Insert | افزودن |
| ItemDAL | SP_Items_Update | ویرایش |
| ItemDAL | SP_Items_Delete | حذف |
| ItemDAL | SP_Items_UpdateInventory | به‌روزرسانی موجودی |
| ProductDAL | SP_Products_SelectAll | دریافت لیست |
| ProductDAL | SP_Products_Insert | افزودن |
| ProductDAL | SP_Products_Update | ویرایش |
| ProductDAL | SP_BasicRecipe_Insert | افزودن دستور پخت |
| FactorDAL | SP_Factor_Insert | ثبت فاکتور |
| FactorDAL | SP_Factor_SelectAll | دریافت فاکتورها |
| FactorDAL | SP_SubFactor_Insert | ثبت آیتم فاکتور |

---

## جریان داده End-to-End

### سناریو 1: تعریف قلم جدید

```mermaid
sequenceDiagram
    participant User
    participant DefineBasicItemsFRM
    participant ItemManager
    participant ItemDAL
    participant Database
    
    User->>DefineBasicItemsFRM: ورود اطلاعات + کلیک ذخیره
    DefineBasicItemsFRM->>DefineBasicItemsFRM: اعتبارسنجی ورودی
    DefineBasicItemsFRM->>ItemManager: AddItem(itemModel)
    ItemManager->>ItemManager: اعتبارسنجی Business Rules
    ItemManager->>ItemManager: بررسی تکراری نبودن نام
    ItemManager->>ItemDAL: Insert(itemModel)
    ItemDAL->>Database: EXEC SP_Items_Insert
    Database-->>ItemDAL: Success/NewID
    ItemDAL-->>ItemManager: Success
    ItemManager-->>DefineBasicItemsFRM: Success
    DefineBasicItemsFRM-->>User: پیغام موفقیت
    DefineBasicItemsFRM->>ItemManager: GetAllItems()
    ItemManager->>ItemDAL: SelectAll()
    ItemDAL->>Database: EXEC SP_Items_SelectAll
    Database-->>ItemDAL: ResultSet
    ItemDAL-->>ItemManager: List<ItemModel>
    ItemManager-->>DefineBasicItemsFRM: List<ItemModel>
    DefineBasicItemsFRM->>DefineBasicItemsFRM: نمایش در DataGridView
```

---

### سناریو 2: ثبت فاکتور فروش

```mermaid
sequenceDiagram
    participant User
    participant CreatSellFactorFRM
    participant ProductManager
    participant FactorManager
    participant FactorDAL
    participant SubFactorDAL
    participant ItemDAL
    participant Database
    
    User->>CreatSellFactorFRM: انتخاب محصولات
    CreatSellFactorFRM->>ProductManager: GetAllProducts()
    ProductManager-->>CreatSellFactorFRM: لیست محصولات
    
    User->>CreatSellFactorFRM: تکمیل و ذخیره فاکتور
    CreatSellFactorFRM->>FactorManager: CreateFactor(factor, items)
    
    FactorManager->>FactorManager: محاسبه مجموع و تخفیف
    FactorManager->>FactorManager: اعتبارسنجی
    
    Note over FactorManager,Database: شروع Transaction
    
    FactorManager->>FactorDAL: Insert(factorModel)
    FactorDAL->>Database: EXEC SP_Factor_Insert
    Database-->>FactorDAL: NewFactorID
    
    loop برای هر آیتم
        FactorManager->>SubFactorDAL: Insert(subFactor)
        SubFactorDAL->>Database: EXEC SP_SubFactor_Insert
        
        FactorManager->>ItemDAL: UpdateInventory(itemId, -quantity)
        ItemDAL->>Database: EXEC SP_Items_UpdateInventory
    end
    
    Note over FactorManager,Database: Commit Transaction
    
    FactorDAL-->>FactorManager: Success
    FactorManager-->>CreatSellFactorFRM: FactorID
    CreatSellFactorFRM-->>User: پیغام موفقیت + چاپ فاکتور
```

---

### سناریو 3: تعریف محصول با دستور پخت

```mermaid
sequenceDiagram
    participant User
    participant DefineMenuItemsFRM
    participant ProductManager
    participant ProductDAL
    participant BasicRecipeDAL
    participant ItemManager
    participant Database
    
    User->>DefineMenuItemsFRM: ورود اطلاعات محصول
    DefineMenuItemsFRM->>ItemManager: GetAllItems()
    ItemManager-->>DefineMenuItemsFRM: لیست مواد اولیه
    
    User->>DefineMenuItemsFRM: انتخاب مواد و مقادیر
    User->>DefineMenuItemsFRM: ذخیره
    
    DefineMenuItemsFRM->>ProductManager: AddProduct(product, recipe)
    
    Note over ProductManager,Database: شروع Transaction
    
    ProductManager->>ProductDAL: Insert(productModel)
    ProductDAL->>Database: EXEC SP_Products_Insert
    Database-->>ProductDAL: NewProductID
    
    loop برای هر ماده اولیه
        ProductManager->>BasicRecipeDAL: Insert(recipeItem)
        BasicRecipeDAL->>Database: EXEC SP_BasicRecipe_Insert
    end
    
    ProductManager->>ProductManager: محاسبه قیمت تمام شده
    ProductManager->>ProductDAL: UpdateCostPrice(productId, cost)
    ProductDAL->>Database: EXEC SP_Products_UpdateCost
    
    Note over ProductManager,Database: Commit Transaction
    
    ProductManager-->>DefineMenuItemsFRM: Success
    DefineMenuItemsFRM-->>User: پیغام موفقیت
```

---

## ماتریس وابستگی کامل

### Forms → Managers

| Form | Managers استفاده شده |
|------|---------------------|
| DefineBasicItemsFRM | ItemManager, UnitManager |
| DefineMenuItemsFRM | ProductManager, ItemManager, SectionManager |
| CreatSellFactorFRM | FactorManager, ProductManager, SellerManager |
| DefineSectionsFRM | SectionManager |
| DefineUnitFRM | UnitManager |
| DefineBankAccountFRM | AccountManager |
| DefineAndSubmitOverHead | OverHeadManager, AccountManager |
| LoginFRM | LoginManager |

### Managers → DAL Classes

| Manager | DAL Classes استفاده شده |
|---------|----------------------|
| ItemManager | ItemDAL, UnitDAL |
| ProductManager | ProductDAL, BasicRecipeDAL, ItemDAL |
| FactorManager | FactorDAL, SubFactorDAL, ItemDAL |
| AccountManager | AccountDAL |
| OverHeadManager | OverHeadDAL, AccountDAL |
| SellerManager | SellerDAL |
| UnitManager | UnitDAL |
| SectionManager | SectionDAL |
| LoginManager | LoginDAL |

---

## نکات مهم

### قواعد وابستگی

1. **Forms** فقط به **Managers** وابسته است (نه DAL)
2. **Managers** فقط به **DAL** وابسته است (نه Database)
3. **DAL** فقط به **Database** وابسته است (نه Business Logic)
4. **Entity Models** به هیچ لایه‌ای وابسته نیست (POCO)
5. **Helpers** به هیچ لایه‌ای وابسته نیست (Utility)

### الگوی ارتباط

```
Form → Manager → DAL → Database
```

این الگو در تمام عملیات رعایت می‌شود.

---

## 📅 تاریخچه تغییرات

### 2025-12-17
- ایجاد اولیه نقشه ارتباطات
- نمودارهای Mermaid
- سناریوهای End-to-End

---

**تاریخ ایجاد**: 2025-12-17  
**آخرین به‌روزرسانی**: 2025-12-17

---

## Metadata (برای AI)

```json
{
  "document_type": "cross_references",
  "chapter": 9,
  "diagrams_count": 6,
  "scenarios_count": 3,
  "language": "Persian (Farsi)",
  "last_updated": "2025-12-17",
  "version": "1.0"
}
```
