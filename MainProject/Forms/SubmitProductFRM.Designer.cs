using System.Drawing;
using System.Windows.Forms;

namespace MainProject.Forms
{
    partial class SubmitProductFRM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("");
            this.btnSubmitNewType = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.isActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Wastage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SellerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lstProduct = new System.Windows.Forms.ListView();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnNewCategory = new System.Windows.Forms.Button();
            this.btnSubmitNewSection = new System.Windows.Forms.Button();
            this.btnSubmitNewSeller = new System.Windows.Forms.Button();
            this.btnSubmitNewProduct = new System.Windows.Forms.Button();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.btnSubmitNewUnit = new System.Windows.Forms.Button();
            this.cmbSections = new System.Windows.Forms.ComboBox();
            this.btnDeletProduct = new System.Windows.Forms.Button();
            this.cmbSeller = new System.Windows.Forms.ComboBox();
            this.cmbMU = new System.Windows.Forms.ComboBox();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            this.cmbPU = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCriticalInventory = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWastage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chkIsDirectUse = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSubmitNewType
            // 
            this.btnSubmitNewType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSubmitNewType.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewType.Location = new System.Drawing.Point(993, 111);
            this.btnSubmitNewType.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewType.Name = "btnSubmitNewType";
            this.btnSubmitNewType.Size = new System.Drawing.Size(115, 36);
            this.btnSubmitNewType.TabIndex = 60;
            this.btnSubmitNewType.Text = "تعریف نوع جدید";
            this.btnSubmitNewType.UseVisualStyleBackColor = false;
            this.btnSubmitNewType.Click += new System.EventHandler(this.btnSubmitNewType_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.Location = new System.Drawing.Point(1279, 113);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 30);
            this.label13.TabIndex = 58;
            this.label13.Text = "نوع";
            // 
            // isActive
            // 
            this.isActive.DisplayIndex = 8;
            this.isActive.Text = "وضعیت";
            // 
            // Wastage
            // 
            this.Wastage.DisplayIndex = 7;
            this.Wastage.Text = "دورریز";
            // 
            // CI
            // 
            this.CI.DisplayIndex = 6;
            this.CI.Text = "مکوجودی بحرانی";
            // 
            // PUnit
            // 
            this.PUnit.DisplayIndex = 5;
            this.PUnit.Text = "واحد خرید";
            this.PUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MUnit
            // 
            this.MUnit.DisplayIndex = 4;
            this.MUnit.Text = "واحد خرید";
            this.MUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SellerName
            // 
            this.SellerName.DisplayIndex = 3;
            this.SellerName.Text = "فروشنده";
            this.SellerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SPrice
            // 
            this.SPrice.DisplayIndex = 2;
            this.SPrice.Text = "قیمت خرید";
            this.SPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SName
            // 
            this.SName.DisplayIndex = 1;
            this.SName.Text = "نام کالا";
            this.SName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SCode
            // 
            this.SCode.DisplayIndex = 0;
            this.SCode.Text = "کد کالا";
            // 
            // Number
            // 
            this.Number.DisplayIndex = 9;
            this.Number.Text = "ردیف";
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbType.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(1116, 113);
            this.cmbType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbType.Name = "cmbType";
            this.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbType.Size = new System.Drawing.Size(160, 32);
            this.cmbType.TabIndex = 59;
            // 
            // lstProduct
            // 
            this.lstProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.SCode,
            this.SName,
            this.SPrice,
            this.SellerName,
            this.MUnit,
            this.PUnit,
            this.CI,
            this.Wastage,
            this.isActive});
            this.lstProduct.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstProduct.FullRowSelect = true;
            this.lstProduct.GridLines = true;
            this.lstProduct.HideSelection = false;
            this.lstProduct.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lstProduct.Location = new System.Drawing.Point(11, 198);
            this.lstProduct.Margin = new System.Windows.Forms.Padding(4);
            this.lstProduct.MultiSelect = false;
            this.lstProduct.Name = "lstProduct";
            this.lstProduct.Size = new System.Drawing.Size(1314, 473);
            this.lstProduct.TabIndex = 57;
            this.lstProduct.UseCompatibleStateImageBehavior = false;
            this.lstProduct.SelectedIndexChanged += new System.EventHandler(this.lstProduct_SelectedIndexChanged);
            this.lstProduct.Click += new System.EventHandler(this.lstProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdateProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdateProduct.Location = new System.Drawing.Point(811, 155);
            this.btnUpdateProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(83, 35);
            this.btnUpdateProduct.TabIndex = 50;
            this.btnUpdateProduct.Text = "ویرایش";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnNewCategory
            // 
            this.btnNewCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNewCategory.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnNewCategory.Location = new System.Drawing.Point(597, 110);
            this.btnNewCategory.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewCategory.Name = "btnNewCategory";
            this.btnNewCategory.Size = new System.Drawing.Size(151, 36);
            this.btnNewCategory.TabIndex = 51;
            this.btnNewCategory.Text = "تعریف دسته‌بندی جدید";
            this.btnNewCategory.UseVisualStyleBackColor = false;
            this.btnNewCategory.Click += new System.EventHandler(this.btnNewCategory_Click);
            // 
            // btnSubmitNewSection
            // 
            this.btnSubmitNewSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSubmitNewSection.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewSection.Location = new System.Drawing.Point(17, 57);
            this.btnSubmitNewSection.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewSection.Name = "btnSubmitNewSection";
            this.btnSubmitNewSection.Size = new System.Drawing.Size(126, 36);
            this.btnSubmitNewSection.TabIndex = 52;
            this.btnSubmitNewSection.Text = "تعریف سکشن جدید";
            this.btnSubmitNewSection.UseVisualStyleBackColor = false;
            this.btnSubmitNewSection.Click += new System.EventHandler(this.btnSubmitNewSection_Click);
            // 
            // btnSubmitNewSeller
            // 
            this.btnSubmitNewSeller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSubmitNewSeller.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewSeller.Location = new System.Drawing.Point(389, 57);
            this.btnSubmitNewSeller.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewSeller.Name = "btnSubmitNewSeller";
            this.btnSubmitNewSeller.Size = new System.Drawing.Size(146, 36);
            this.btnSubmitNewSeller.TabIndex = 56;
            this.btnSubmitNewSeller.Text = "تعریف فروشنده‌ی جدید";
            this.btnSubmitNewSeller.UseVisualStyleBackColor = false;
            this.btnSubmitNewSeller.Click += new System.EventHandler(this.btnSubmitNewSeller_Click);
            // 
            // btnSubmitNewProduct
            // 
            this.btnSubmitNewProduct.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewProduct.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitNewProduct.Location = new System.Drawing.Point(909, 155);
            this.btnSubmitNewProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewProduct.Name = "btnSubmitNewProduct";
            this.btnSubmitNewProduct.Size = new System.Drawing.Size(83, 35);
            this.btnSubmitNewProduct.TabIndex = 53;
            this.btnSubmitNewProduct.Text = "ثبت";
            this.btnSubmitNewProduct.UseVisualStyleBackColor = true;
            this.btnSubmitNewProduct.Click += new System.EventHandler(this.btnSubmitNewProduct_Click);
            // 
            // cmbCategories
            // 
            this.cmbCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmbCategories.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(756, 112);
            this.cmbCategories.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCategories.Size = new System.Drawing.Size(160, 32);
            this.cmbCategories.TabIndex = 48;
            // 
            // btnSubmitNewUnit
            // 
            this.btnSubmitNewUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSubmitNewUnit.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewUnit.Location = new System.Drawing.Point(19, 10);
            this.btnSubmitNewUnit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewUnit.Name = "btnSubmitNewUnit";
            this.btnSubmitNewUnit.Size = new System.Drawing.Size(126, 37);
            this.btnSubmitNewUnit.TabIndex = 54;
            this.btnSubmitNewUnit.Text = "تعریف واحد جدید";
            this.btnSubmitNewUnit.UseVisualStyleBackColor = false;
            this.btnSubmitNewUnit.Click += new System.EventHandler(this.btnSubmitNewUnit_Click);
            // 
            // cmbSections
            // 
            this.cmbSections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmbSections.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbSections.FormattingEnabled = true;
            this.cmbSections.Location = new System.Drawing.Point(145, 60);
            this.cmbSections.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSections.Name = "cmbSections";
            this.cmbSections.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbSections.Size = new System.Drawing.Size(155, 32);
            this.cmbSections.TabIndex = 47;
            // 
            // btnDeletProduct
            // 
            this.btnDeletProduct.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeletProduct.ForeColor = System.Drawing.Color.Red;
            this.btnDeletProduct.Location = new System.Drawing.Point(720, 155);
            this.btnDeletProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletProduct.Name = "btnDeletProduct";
            this.btnDeletProduct.Size = new System.Drawing.Size(83, 35);
            this.btnDeletProduct.TabIndex = 55;
            this.btnDeletProduct.Text = "حذف";
            this.btnDeletProduct.UseVisualStyleBackColor = true;
            this.btnDeletProduct.Click += new System.EventHandler(this.btnDeletProduct_Click);
            // 
            // cmbSeller
            // 
            this.cmbSeller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbSeller.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbSeller.FormattingEnabled = true;
            this.cmbSeller.Location = new System.Drawing.Point(548, 58);
            this.cmbSeller.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSeller.Name = "cmbSeller";
            this.cmbSeller.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbSeller.Size = new System.Drawing.Size(246, 32);
            this.cmbSeller.TabIndex = 46;
            // 
            // cmbMU
            // 
            this.cmbMU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbMU.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbMU.FormattingEnabled = true;
            this.cmbMU.Location = new System.Drawing.Point(391, 9);
            this.cmbMU.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMU.Name = "cmbMU";
            this.cmbMU.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMU.Size = new System.Drawing.Size(144, 32);
            this.cmbMU.TabIndex = 45;
            this.cmbMU.SelectedIndexChanged += new System.EventHandler(this.cmbMU_SelectedIndexChanged);
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Location = new System.Drawing.Point(391, 111);
            this.cmbIsActive.Margin = new System.Windows.Forms.Padding(4);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(142, 32);
            this.cmbIsActive.TabIndex = 49;
            // 
            // cmbPU
            // 
            this.cmbPU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbPU.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbPU.FormattingEnabled = true;
            this.cmbPU.Location = new System.Drawing.Point(147, 11);
            this.cmbPU.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPU.Name = "cmbPU";
            this.cmbPU.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPU.Size = new System.Drawing.Size(153, 32);
            this.cmbPU.TabIndex = 44;
            this.cmbPU.SelectedIndexChanged += new System.EventHandler(this.cmbPU_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.Location = new System.Drawing.Point(913, 112);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 30);
            this.label12.TabIndex = 41;
            this.label12.Text = "دسته‌بندی";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSearch.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSearch.Location = new System.Drawing.Point(1006, 155);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(264, 32);
            this.txtSearch.TabIndex = 43;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label11.Location = new System.Drawing.Point(308, 60);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 30);
            this.label11.TabIndex = 40;
            this.label11.Text = "سکشن";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(1268, 154);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 30);
            this.label10.TabIndex = 42;
            this.label10.Text = "جستجو";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(792, 59);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 30);
            this.label9.TabIndex = 39;
            this.label9.Text = "فروشنده";
            // 
            // txtCriticalInventory
            // 
            this.txtCriticalInventory.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCriticalInventory.Location = new System.Drawing.Point(865, 58);
            this.txtCriticalInventory.Margin = new System.Windows.Forms.Padding(4);
            this.txtCriticalInventory.Name = "txtCriticalInventory";
            this.txtCriticalInventory.Size = new System.Drawing.Size(67, 32);
            this.txtCriticalInventory.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(933, 59);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 30);
            this.label8.TabIndex = 37;
            this.label8.Text = "موجودی بحرانی";
            // 
            // txtWastage
            // 
            this.txtWastage.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtWastage.Location = new System.Drawing.Point(1063, 58);
            this.txtWastage.Margin = new System.Windows.Forms.Padding(4);
            this.txtWastage.Name = "txtWastage";
            this.txtWastage.Size = new System.Drawing.Size(65, 32);
            this.txtWastage.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(1131, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 30);
            this.label7.TabIndex = 35;
            this.label7.Text = "میزان دورریز در واحد خرید";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(534, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 30);
            this.label6.TabIndex = 34;
            this.label6.Text = "وضعیت";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtPrice.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPrice.Location = new System.Drawing.Point(70, 109);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(230, 39);
            this.txtPrice.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(303, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 30);
            this.label5.TabIndex = 32;
            this.label5.Text = "قیمت خرید";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(543, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 30);
            this.label4.TabIndex = 31;
            this.label4.Text = "واحد اندازه‌گیری";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(308, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 30);
            this.label3.TabIndex = 30;
            this.label3.Text = "واحد خرید";
            // 
            // txtSName
            // 
            this.txtSName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtSName.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSName.Location = new System.Drawing.Point(665, 9);
            this.txtSName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSName.Name = "txtSName";
            this.txtSName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSName.Size = new System.Drawing.Size(409, 32);
            this.txtSName.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(1074, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 30);
            this.label2.TabIndex = 28;
            this.label2.Text = "نام کالا";
            // 
            // txtSCode
            // 
            this.txtSCode.Enabled = false;
            this.txtSCode.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSCode.Location = new System.Drawing.Point(1138, 9);
            this.txtSCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtSCode.Name = "txtSCode";
            this.txtSCode.Size = new System.Drawing.Size(132, 28);
            this.txtSCode.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(1268, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 30);
            this.label1.TabIndex = 26;
            this.label1.Text = "کد کالا";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label14.Location = new System.Drawing.Point(17, 117);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 30);
            this.label14.TabIndex = 61;
            this.label14.Text = "تومان";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // chkIsDirectUse
            // 
            this.chkIsDirectUse.AutoSize = true;
            this.chkIsDirectUse.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkIsDirectUse.ForeColor = System.Drawing.Color.DarkRed;
            this.chkIsDirectUse.Location = new System.Drawing.Point(8, 155);
            this.chkIsDirectUse.Name = "chkIsDirectUse";
            this.chkIsDirectUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsDirectUse.Size = new System.Drawing.Size(556, 36);
            this.chkIsDirectUse.TabIndex = 62;
            this.chkIsDirectUse.Text = "این کالا مستقیما در تهیه آیتم منو استفاده می‌شود و نیاز به آماده‌سازی ندارد";
            this.chkIsDirectUse.UseVisualStyleBackColor = true;
            // 
            // SubmitProductFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1332, 680);
            this.Controls.Add(this.chkIsDirectUse);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnSubmitNewType);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lstProduct);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.btnNewCategory);
            this.Controls.Add(this.btnSubmitNewSection);
            this.Controls.Add(this.btnSubmitNewSeller);
            this.Controls.Add(this.btnSubmitNewProduct);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.btnSubmitNewUnit);
            this.Controls.Add(this.cmbSections);
            this.Controls.Add(this.btnDeletProduct);
            this.Controls.Add(this.cmbSeller);
            this.Controls.Add(this.cmbMU);
            this.Controls.Add(this.cmbIsActive);
            this.Controls.Add(this.cmbPU);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCriticalInventory);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtWastage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSCode);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SubmitProductFRM";
            this.Text = "تعریف و ویرایش کالا";
            this.Load += new System.EventHandler(this.SubmitProductFRM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmitNewType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ColumnHeader isActive;
        private System.Windows.Forms.ColumnHeader Wastage;
        private System.Windows.Forms.ColumnHeader CI;
        private System.Windows.Forms.ColumnHeader PUnit;
        private System.Windows.Forms.ColumnHeader MUnit;
        private System.Windows.Forms.ColumnHeader SellerName;
        private System.Windows.Forms.ColumnHeader SPrice;
        private System.Windows.Forms.ColumnHeader SName;
        private System.Windows.Forms.ColumnHeader SCode;
        public System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ListView lstProduct;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Button btnNewCategory;
        private System.Windows.Forms.Button btnSubmitNewSection;
        private System.Windows.Forms.Button btnSubmitNewSeller;
        private System.Windows.Forms.Button btnSubmitNewProduct;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Button btnSubmitNewUnit;
        private System.Windows.Forms.ComboBox cmbSections;
        private System.Windows.Forms.Button btnDeletProduct;
        private System.Windows.Forms.ComboBox cmbSeller;
        private System.Windows.Forms.ComboBox cmbMU;
        private System.Windows.Forms.ComboBox cmbIsActive;
        private System.Windows.Forms.ComboBox cmbPU;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCriticalInventory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtWastage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSCode;
        private System.Windows.Forms.Label label1;
        private Label label14;
        private CheckBox chkIsDirectUse;
    }
}