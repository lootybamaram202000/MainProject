# UI Button Implementation Guide

## Required Buttons for Overhead Allocation

The following buttons need to be added to the `OverHeadFRM` form to complete the overhead allocation integration:

### 1. Section Draft Submit Button

**Button Name**: `btnSubmitSectionDraft`  
**Location**: Near the Section ListView (`lstSection`)  
**Text (Persian)**: "ثبت پیش‌نویس سکشن" or "Submit Section Draft"  
**Event Handler**: `btnSubmitSectionDraft_Click` (already implemented in OverHeadFRM.cs)

**Designer Code to Add**:
```csharp
// In InitializeComponent() method
this.btnSubmitSectionDraft = new System.Windows.Forms.Button();

// Button configuration
this.btnSubmitSectionDraft.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
this.btnSubmitSectionDraft.ForeColor = System.Drawing.Color.Green;
this.btnSubmitSectionDraft.Location = new System.Drawing.Point(20, 300); // Adjust as needed
this.btnSubmitSectionDraft.Name = "btnSubmitSectionDraft";
this.btnSubmitSectionDraft.Size = new System.Drawing.Size(180, 45);
this.btnSubmitSectionDraft.TabIndex = 200; // Adjust as needed
this.btnSubmitSectionDraft.Text = "ثبت پیش‌نویس سکشن";
this.btnSubmitSectionDraft.UseVisualStyleBackColor = true;
this.btnSubmitSectionDraft.Click += new System.EventHandler(this.btnSubmitSectionDraft_Click);

// Add to appropriate panel (likely near lstSection)
this.panel[X].Controls.Add(this.btnSubmitSectionDraft);

// Field declaration
private System.Windows.Forms.Button btnSubmitSectionDraft;
```

### 2. SubSection Draft Submit Button

**Button Name**: `btnSubmitSubSectionDraft`  
**Location**: Near the SubSection ListView (`lstSubSection`) in panel10  
**Text (Persian)**: "ثبت پیش‌نویس زیرسکشن" or "Submit SubSection Draft"  
**Event Handler**: `btnSubmitSubSectionDraft_Click` (already implemented in OverHeadFRM.cs)

**Designer Code to Add**:
```csharp
// In InitializeComponent() method
this.btnSubmitSubSectionDraft = new System.Windows.Forms.Button();

// Button configuration
this.btnSubmitSubSectionDraft.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
this.btnSubmitSubSectionDraft.ForeColor = System.Drawing.Color.Green;
this.btnSubmitSubSectionDraft.Location = new System.Drawing.Point(20, 290); // Below lstSubSection
this.btnSubmitSubSectionDraft.Name = "btnSubmitSubSectionDraft";
this.btnSubmitSubSectionDraft.Size = new System.Drawing.Size(180, 45);
this.btnSubmitSubSectionDraft.TabIndex = 201;
this.btnSubmitSubSectionDraft.Text = "ثبت پیش‌نویس زیرسکشن";
this.btnSubmitSubSectionDraft.UseVisualStyleBackColor = true;
this.btnSubmitSubSectionDraft.Click += new System.EventHandler(this.btnSubmitSubSectionDraft_Click);

// Add to panel10
this.panel10.Controls.Add(this.btnSubmitSubSectionDraft);

// Field declaration
private System.Windows.Forms.Button btnSubmitSubSectionDraft;
```

### 3. Calculate Allocation Button

**Button Name**: `btnCalculateAllocation`  
**Location**: Prominent location, possibly near both section and subsection areas  
**Text (Persian)**: "محاسبه تخصیص سربار" or "Calculate Allocation"  
**Event Handler**: `btnCalculateAllocation_Click` (already implemented in OverHeadFRM.cs)

**Designer Code to Add**:
```csharp
// In InitializeComponent() method
this.btnCalculateAllocation = new System.Windows.Forms.Button();

// Button configuration
this.btnCalculateAllocation.Font = new System.Drawing.Font("B Nazanin", 14F, System.Drawing.FontStyle.Bold);
this.btnCalculateAllocation.ForeColor = System.Drawing.Color.DarkBlue;
this.btnCalculateAllocation.BackColor = System.Drawing.Color.LightGreen;
this.btnCalculateAllocation.Location = new System.Drawing.Point(400, 350); // Prominent location
this.btnCalculateAllocation.Name = "btnCalculateAllocation";
this.btnCalculateAllocation.Size = new System.Drawing.Size(220, 55);
this.btnCalculateAllocation.TabIndex = 202;
this.btnCalculateAllocation.Text = "محاسبه تخصیص سربار";
this.btnCalculateAllocation.UseVisualStyleBackColor = false;
this.btnCalculateAllocation.Click += new System.EventHandler(this.btnCalculateAllocation_Click);

// Add to appropriate panel
this.panel[Y].Controls.Add(this.btnCalculateAllocation);

// Field declaration
private System.Windows.Forms.Button btnCalculateAllocation;
```

## Alternative: Using Existing Buttons

If you prefer to reuse existing buttons instead of creating new ones, you can:

### Option A: Repurpose `btnSubmitSectionOVERHEAD`

This button already exists and is used for submitting section overheads. You could extend its functionality:

```csharp
private void btnSubmitSectionOVERHEAD_Click(object sender, EventArgs e)
{
    // Existing code...
    
    // Add the new draft submission call
    var sectionTable = new DataTable();
    sectionTable.Columns.Add("SecID", typeof(string));
    sectionTable.Columns.Add("SecTitle", typeof(string));
    sectionTable.Columns.Add("OverHead", typeof(decimal));
    sectionTable.Columns.Add("PerCentage", typeof(byte));
    sectionTable.Columns.Add("CountOfSell", typeof(short));

    foreach (var sec in sectionList.Where(s => !s.isDeleted))
    {
        sectionTable.Rows.Add(sec.SecID, sec.SecTitle, sec.OverHead, sec.PerCentage, sec.CountOfSell);
    }

    var draftResult = _manager.SubmitSectionDraft(sectionTable, out string draftError);
    if (!draftResult && !string.IsNullOrEmpty(draftError))
    {
        MessageBox.Show("خطا در ثبت پیش‌نویس: " + draftError);
    }
}
```

### Option B: Add Menu Items

Instead of buttons, you could add menu items to a menu strip:

```csharp
// Add to existing menu
this.toolStripMenuItemSectionDraft.Click += new System.EventHandler(this.btnSubmitSectionDraft_Click);
this.toolStripMenuItemSubSectionDraft.Click += new System.EventHandler(this.btnSubmitSubSectionDraft_Click);
this.toolStripMenuItemCalculate.Click += new System.EventHandler(this.btnCalculateAllocation_Click);
```

## Workflow Recommendation

The recommended user workflow is:

1. **Prepare Section Data**: User enters/modifies section overhead data in the Section ListView
2. **Submit Section Draft**: Click `btnSubmitSectionDraft` to save section drafts to database
3. **Prepare SubSection Data**: User enters/modifies subsection data in the SubSection ListView
4. **Submit SubSection Draft**: Click `btnSubmitSubSectionDraft` to save subsection drafts
5. **Calculate**: Click `btnCalculateAllocation` to run the overhead allocation calculation
6. **View Results**: Results are displayed in a MessageBox (can be enhanced to show in grid)

## Visual Studio Designer Steps

To add these buttons using Visual Studio Designer:

1. Open `OverHeadFRM.cs` in Visual Studio
2. Press `F7` or right-click and select "View Designer"
3. From the Toolbox, drag a `Button` control to the appropriate panel
4. In Properties window:
   - Set the `(Name)` property to the button name (e.g., `btnSubmitSectionDraft`)
   - Set `Text` to the Persian text
   - Set `Font` to "B Nazanin, 12pt, Bold"
   - Set `ForeColor` as needed
   - Adjust `Location` and `Size`
5. Double-click the button to create the click event handler
6. If the handler is already implemented (as in this case), just ensure the names match

## Testing Buttons

After adding the buttons, test each one:

1. **Section Draft Button**: Should collect section data and call the stored procedure
2. **SubSection Draft Button**: Should collect subsection data and call the stored procedure
3. **Calculate Button**: Should trigger calculation and display results

Check for:
- Proper error handling
- Persian error messages
- No application crashes on SQL errors
- Success messages display correctly

---

**Note**: The exact panel names and positions will depend on your form layout. Adjust the `Location`, `Size`, and parent panel as needed to fit your UI design.
