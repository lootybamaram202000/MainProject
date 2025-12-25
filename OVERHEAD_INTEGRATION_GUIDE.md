# Overhead Allocation Integration Guide

## Overview
This document describes the implementation of the new Overhead Allocation C# integration for the WinForms (.NET Framework 4.7.2) application.

## Changes Made

### 1. Data Access Layer (`MainProject/DataAccess/OverHeadDAL.cs`)

Added four new methods to handle overhead allocation operations:

#### `SubmitOHSectionInputDraft(DataTable sectionInputs, out string errorMessage)`
- **Purpose**: Submits section input drafts to the database
- **Parameters**: 
  - `sectionInputs`: DataTable with columns matching `dbo.OHSectionInputTVP` schema
  - `errorMessage`: Output parameter for error details
- **Returns**: `bool` - true if successful, false otherwise
- **SQL Procedure**: `dbo.sp_SubmitOHSectionInputDraft`
- **TVP Type**: `dbo.OHSectionInputTVP`

#### `SubmitOHSubSectionInputDraft(DataTable subSectionInputs, out string errorMessage)`
- **Purpose**: Submits subsection input drafts to the database
- **Parameters**:
  - `subSectionInputs`: DataTable with columns matching `dbo.OHSubSectionInputTVP` schema
  - `errorMessage`: Output parameter for error details
- **Returns**: `bool` - true if successful, false otherwise
- **SQL Procedure**: `dbo.sp_SubmitOHSubSectionInputDraft`
- **TVP Type**: `dbo.OHSubSectionInputTVP`

#### `CalcOverheadAllocation(out string errorMessage)`
- **Purpose**: Executes overhead allocation calculation
- **Parameters**:
  - `errorMessage`: Output parameter for error details
- **Returns**: `DataTable` with calculation results
- **SQL Procedure**: `dbo.sp_CalcOverheadAllocation`

#### `GetOHPerItemBySSID(string ssid, out string errorMessage)`
- **Purpose**: Retrieves overhead per item by subsection ID (optional helper)
- **Parameters**:
  - `ssid`: Subsection ID
  - `errorMessage`: Output parameter for error details
- **Returns**: `DataTable` with results
- **SQL Procedure**: `dbo.sp_GetOHPerItemBySSID`

### 2. Business Layer (`MainProject/Core/Business/OverHeadManager.cs`)

Added corresponding manager methods that delegate to the DAL:

- `SubmitSectionDraft(DataTable sectionInputs, out string errorMessage)`
- `SubmitSubSectionDraft(DataTable subSectionInputs, out string errorMessage)`
- `CalculateAllocation(out string errorMessage)`
- `GetOHPerItemBySSID(string ssid, out string errorMessage)`

### 3. UI Layer (`MainProject/Forms/OverHeadFRM.cs`)

Added three event handler methods:

#### `btnSubmitSectionDraft_Click(object sender, EventArgs e)`
- Collects section data from `sectionList`
- Builds DataTable with columns: SecID, SecTitle, OverHead, PerCentage, CountOfSell
- Calls `OverHeadManager.SubmitSectionDraft()`
- Displays success/error messages in Persian

#### `btnSubmitSubSectionDraft_Click(object sender, EventArgs e)`
- Collects subsection data from `lstSubSection` ListView
- Builds DataTable with columns: SSID, SSTitle, SecID, OverHead, PerCentage, CountOfSell
- Calls `OverHeadManager.SubmitSubSectionDraft()`
- Displays success/error messages in Persian

#### `btnCalculateAllocation_Click(object sender, EventArgs e)`
- Calls `OverHeadManager.CalculateAllocation()`
- Displays results via `DisplayCalculationResults()` helper
- Shows error messages if calculation fails

#### `DisplayCalculationResults(DataTable results)`
- Helper method to display calculation results
- Currently shows row count in MessageBox
- Can be extended to populate grid controls with detailed results

## UI Integration Instructions

To complete the UI integration, you need to wire up the button click events in the Designer:

### Option 1: Using Visual Studio Designer

1. Open `MainProject/Forms/OverHeadFRM.cs` in Visual Studio
2. Switch to Designer view (F7 or View > Designer)
3. Locate the following buttons (or create them if they don't exist):
   - Button for Section Draft: Name it `btnSubmitSectionDraft`
   - Button for SubSection Draft: Name it `btnSubmitSubSectionDraft`
   - Button for Calculate: Name it `btnCalculateAllocation`
4. Double-click each button to create/assign the click event handler
5. Verify the handler names match the methods added in OverHeadFRM.cs

### Option 2: Manual Designer.cs Editing

If you prefer to manually edit the designer file, add the following lines:

In `OverHeadFRM.Designer.cs`, within the `InitializeComponent()` method:

```csharp
// For Section Draft button (if it doesn't exist, create it)
this.btnSubmitSectionDraft.Click += new System.EventHandler(this.btnSubmitSectionDraft_Click);

// For SubSection Draft button (if it doesn't exist, create it)
this.btnSubmitSubSectionDraft.Click += new System.EventHandler(this.btnSubmitSubSectionDraft_Click);

// For Calculate button (if it doesn't exist, create it)
this.btnCalculateAllocation.Click += new System.EventHandler(this.btnCalculateAllocation_Click);
```

And declare the buttons in the private fields section:

```csharp
private System.Windows.Forms.Button btnSubmitSectionDraft;
private System.Windows.Forms.Button btnSubmitSubSectionDraft;
private System.Windows.Forms.Button btnCalculateAllocation;
```

## TVP Schema Requirements

The stored procedures expect Table-Valued Parameters with the following schemas:

### `dbo.OHSectionInputTVP`
Expected columns:
- `SecID` (string/nvarchar)
- `SecTitle` (string/nvarchar)
- `OverHead` (decimal)
- `PerCentage` (byte/tinyint)
- `CountOfSell` (short/smallint)

### `dbo.OHSubSectionInputTVP`
Expected columns:
- `SSID` (string/nvarchar)
- `SSTitle` (string/nvarchar)
- `SecID` (string/nvarchar)
- `OverHead` (decimal)
- `PerCentage` (byte/tinyint)
- `CountOfSell` (short/smallint)

## Error Handling

All methods follow the repository's error handling pattern:

1. **SQL Exceptions**: Caught in DAL layer and returned via `out string errorMessage`
2. **UI Display**: Error messages shown in MessageBox with Persian text
3. **User-Friendly Messages**: SQL RAISERROR messages are displayed directly to users
4. **No Crashes**: Application doesn't crash on SQL validation errors

## Testing Checklist

Before marking this feature complete, test the following:

- [ ] Build solution successfully in Visual Studio (Windows required)
- [ ] Section draft submission works and displays success message
- [ ] Section draft submission with invalid data shows SQL error message
- [ ] SubSection draft submission works and displays success message
- [ ] SubSection draft submission with invalid data shows SQL error message
- [ ] Calculate allocation runs and returns results
- [ ] Calculate allocation with missing/invalid drafts shows SQL error message
- [ ] All error messages are displayed in Persian
- [ ] No crashes occur when SQL validation fails
- [ ] Existing overhead features still work correctly

## Code Style Compliance

The implementation follows these repository patterns:

✓ Uses `SqlConnection`/`SqlCommand` with stored procedure calls  
✓ Uses `DataTable` + `SqlDbType.Structured` for TVPs  
✓ Similar error handling as `SectionDAL`, `ItemDAL`, `SellerDAL`  
✓ Uses `LoginInfo.Instance` for user/date context (when needed)  
✓ Consistent naming conventions  
✓ Proper resource disposal with `using` statements  

## Additional Notes

- The `LoginInfo.Instance` context (UserID, PersianDate, DateValue, DateDig) is available but not currently used in the new methods since the stored procedures may not require it. If needed, they can be added as parameters.
- The `DisplayCalculationResults()` method is a placeholder and can be enhanced to populate a DataGridView or other controls with the detailed calculation results.
- The subsection functionality assumes the `lstSubSection` ListView is already populated with subsection data in the format: Row, SSID, SSTitle, SecID, OverHead, PerCentage, CountOfSell.

## Support

For questions or issues with this integration:
1. Check that all stored procedures exist in the database
2. Verify TVP types are defined correctly
3. Ensure the connection string in `Config.cs` is correct
4. Review SQL Server logs for detailed error messages

---

**Implementation Date**: 2025-12-25  
**Author**: GitHub Copilot Integration  
**Version**: 1.0
