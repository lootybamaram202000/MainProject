namespace MainProject.Forms
{
    partial class DefineBasicItemsFRM
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
            this.lstBasicItem = new System.Windows.Forms.ListView();
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SellerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Wastage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUpdateBasicItem = new System.Windows.Forms.Button();
            this.btnSubmitNewSection = new System.Windows.Forms.Button();
            this.btnSubmitNewBasicItem = new System.Windows.Forms.Button();
            this.btnSubmitNewUnit = new System.Windows.Forms.Button();
            this.btnDeletBasicItem = new System.Windows.Forms.Button();
            this.cmbSections = new System.Windows.Forms.ComboBox();
            this.cmbMU = new System.Windows.Forms.ComboBox();
            this.cmbPU = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBasicItemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBasicItemCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBICategories = new System.Windows.Forms.ComboBox();
            this.btnSubmitNewCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBasicItem
            // 
            this.lstBasicItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstBasicItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.lstBasicItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstBasicItem.FullRowSelect = true;
            this.lstBasicItem.GridLines = true;
            this.lstBasicItem.HideSelection = false;
            this.lstBasicItem.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lstBasicItem.Location = new System.Drawing.Point(13, 171);
            this.lstBasicItem.Margin = new System.Windows.Forms.Padding(4);
            this.lstBasicItem.MultiSelect = false;
            this.lstBasicItem.Name = "lstBasicItem";
            this.lstBasicItem.Size = new System.Drawing.Size(1127, 493);
            this.lstBasicItem.TabIndex = 66;
            this.lstBasicItem.UseCompatibleStateImageBehavior = false;
            this.lstBasicItem.SelectedIndexChanged += new System.EventHandler(this.lstBasicItem_SelectedIndexChanged);
            // 
            // Number
            // 
            this.Number.DisplayIndex = 9;
            this.Number.Text = "ردیف";
            // 
            // SCode
            // 
            this.SCode.DisplayIndex = 0;
            this.SCode.Text = "کد کالا";
            // 
            // SName
            // 
            this.SName.DisplayIndex = 1;
            this.SName.Text = "نام کالا";
            this.SName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SPrice
            // 
            this.SPrice.DisplayIndex = 2;
            this.SPrice.Text = "قیمت خرید";
            this.SPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SellerName
            // 
            this.SellerName.DisplayIndex = 3;
            this.SellerName.Text = "فروشنده";
            this.SellerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MUnit
            // 
            this.MUnit.DisplayIndex = 4;
            this.MUnit.Text = "واحد خرید";
            this.MUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PUnit
            // 
            this.PUnit.DisplayIndex = 5;
            this.PUnit.Text = "واحد خرید";
            this.PUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CI
            // 
            this.CI.DisplayIndex = 6;
            this.CI.Text = "مکوجودی بحرانی";
            // 
            // Wastage
            // 
            this.Wastage.DisplayIndex = 7;
            this.Wastage.Text = "دورریز";
            // 
            // isActive
            // 
            this.isActive.DisplayIndex = 8;
            this.isActive.Text = "وضعیت";
            // 
            // btnUpdateBasicItem
            // 
            this.btnUpdateBasicItem.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdateBasicItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdateBasicItem.Location = new System.Drawing.Point(99, 126);
            this.btnUpdateBasicItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateBasicItem.Name = "btnUpdateBasicItem";
            this.btnUpdateBasicItem.Size = new System.Drawing.Size(81, 42);
            this.btnUpdateBasicItem.TabIndex = 65;
            this.btnUpdateBasicItem.Text = "ویرایش";
            this.btnUpdateBasicItem.UseVisualStyleBackColor = true;
            this.btnUpdateBasicItem.Click += new System.EventHandler(this.btnUpdateBasicItem_Click_1);
            // 
            // btnSubmitNewSection
            // 
            this.btnSubmitNewSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSubmitNewSection.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewSection.Location = new System.Drawing.Point(20, 13);
            this.btnSubmitNewSection.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewSection.Name = "btnSubmitNewSection";
            this.btnSubmitNewSection.Size = new System.Drawing.Size(138, 36);
            this.btnSubmitNewSection.TabIndex = 64;
            this.btnSubmitNewSection.Text = "تعریف سکشن جدید";
            this.btnSubmitNewSection.UseVisualStyleBackColor = false;
            this.btnSubmitNewSection.Click += new System.EventHandler(this.btnSubmitNewSection_Click);
            // 
            // btnSubmitNewBasicItem
            // 
            this.btnSubmitNewBasicItem.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewBasicItem.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitNewBasicItem.Location = new System.Drawing.Point(653, 126);
            this.btnSubmitNewBasicItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewBasicItem.Name = "btnSubmitNewBasicItem";
            this.btnSubmitNewBasicItem.Size = new System.Drawing.Size(63, 42);
            this.btnSubmitNewBasicItem.TabIndex = 63;
            this.btnSubmitNewBasicItem.Text = "ثبت";
            this.btnSubmitNewBasicItem.UseVisualStyleBackColor = true;
            this.btnSubmitNewBasicItem.Click += new System.EventHandler(this.btnSubmitNewBasicItem_Click_1);
            // 
            // btnSubmitNewUnit
            // 
            this.btnSubmitNewUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSubmitNewUnit.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewUnit.Location = new System.Drawing.Point(408, 64);
            this.btnSubmitNewUnit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewUnit.Name = "btnSubmitNewUnit";
            this.btnSubmitNewUnit.Size = new System.Drawing.Size(124, 37);
            this.btnSubmitNewUnit.TabIndex = 62;
            this.btnSubmitNewUnit.Text = "تعریف واحد جدید";
            this.btnSubmitNewUnit.UseVisualStyleBackColor = false;
            this.btnSubmitNewUnit.Click += new System.EventHandler(this.btnSubmitNewUnit_Click);
            // 
            // btnDeletBasicItem
            // 
            this.btnDeletBasicItem.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeletBasicItem.ForeColor = System.Drawing.Color.Red;
            this.btnDeletBasicItem.Location = new System.Drawing.Point(29, 126);
            this.btnDeletBasicItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletBasicItem.Name = "btnDeletBasicItem";
            this.btnDeletBasicItem.Size = new System.Drawing.Size(67, 42);
            this.btnDeletBasicItem.TabIndex = 61;
            this.btnDeletBasicItem.Text = "حذف";
            this.btnDeletBasicItem.UseVisualStyleBackColor = true;
            this.btnDeletBasicItem.Click += new System.EventHandler(this.btnDeletBasicItem_Click);
            // 
            // cmbSections
            // 
            this.cmbSections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbSections.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbSections.FormattingEnabled = true;
            this.cmbSections.Location = new System.Drawing.Point(166, 14);
            this.cmbSections.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSections.Name = "cmbSections";
            this.cmbSections.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbSections.Size = new System.Drawing.Size(160, 32);
            this.cmbSections.TabIndex = 60;
            // 
            // cmbMU
            // 
            this.cmbMU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbMU.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbMU.FormattingEnabled = true;
            this.cmbMU.Location = new System.Drawing.Point(821, 67);
            this.cmbMU.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMU.Name = "cmbMU";
            this.cmbMU.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbMU.Size = new System.Drawing.Size(191, 32);
            this.cmbMU.TabIndex = 59;
            this.cmbMU.SelectedIndexChanged += new System.EventHandler(this.cmbMU_SelectedIndexChanged);
            // 
            // cmbPU
            // 
            this.cmbPU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbPU.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbPU.FormattingEnabled = true;
            this.cmbPU.ItemHeight = 24;
            this.cmbPU.Location = new System.Drawing.Point(547, 67);
            this.cmbPU.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPU.Name = "cmbPU";
            this.cmbPU.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPU.Size = new System.Drawing.Size(188, 32);
            this.cmbPU.TabIndex = 58;
            this.cmbPU.SelectedIndexChanged += new System.EventHandler(this.cmbPU_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSearch.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSearch.Location = new System.Drawing.Point(743, 131);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(315, 32);
            this.txtSearch.TabIndex = 57;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(1064, 131);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 30);
            this.label10.TabIndex = 56;
            this.label10.Text = "جستجو";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(325, 14);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 30);
            this.label9.TabIndex = 55;
            this.label9.Text = "سکشن";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(1013, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 30);
            this.label4.TabIndex = 54;
            this.label4.Text = "واحد اندازه‌گیری";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(738, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 30);
            this.label3.TabIndex = 53;
            this.label3.Text = "واحد تولید";
            // 
            // txtBasicItemName
            // 
            this.txtBasicItemName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtBasicItemName.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBasicItemName.Location = new System.Drawing.Point(412, 13);
            this.txtBasicItemName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBasicItemName.Name = "txtBasicItemName";
            this.txtBasicItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBasicItemName.Size = new System.Drawing.Size(429, 32);
            this.txtBasicItemName.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(838, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 30);
            this.label2.TabIndex = 51;
            this.label2.Text = "نام آیتم";
            // 
            // txtBasicItemCode
            // 
            this.txtBasicItemCode.Enabled = false;
            this.txtBasicItemCode.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBasicItemCode.Location = new System.Drawing.Point(905, 17);
            this.txtBasicItemCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtBasicItemCode.Name = "txtBasicItemCode";
            this.txtBasicItemCode.Size = new System.Drawing.Size(120, 28);
            this.txtBasicItemCode.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(1031, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 30);
            this.label1.TabIndex = 49;
            this.label1.Text = "کد آماده‌سازی";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(305, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 30);
            this.label5.TabIndex = 55;
            this.label5.Text = "دسته‌بندی";
            // 
            // cmbBICategories
            // 
            this.cmbBICategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmbBICategories.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbBICategories.FormattingEnabled = true;
            this.cmbBICategories.Location = new System.Drawing.Point(143, 68);
            this.cmbBICategories.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBICategories.Name = "cmbBICategories";
            this.cmbBICategories.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbBICategories.Size = new System.Drawing.Size(160, 32);
            this.cmbBICategories.TabIndex = 60;
            // 
            // btnSubmitNewCategory
            // 
            this.btnSubmitNewCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSubmitNewCategory.Enabled = false;
            this.btnSubmitNewCategory.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewCategory.Location = new System.Drawing.Point(21, 66);
            this.btnSubmitNewCategory.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewCategory.Name = "btnSubmitNewCategory";
            this.btnSubmitNewCategory.Size = new System.Drawing.Size(115, 36);
            this.btnSubmitNewCategory.TabIndex = 64;
            this.btnSubmitNewCategory.Text = "دسته‌بندی جدید";
            this.btnSubmitNewCategory.UseVisualStyleBackColor = false;
            this.btnSubmitNewCategory.Click += new System.EventHandler(this.btnSubmitNewCategory_Click);
            // 
            // DefineBasicItemsFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1153, 677);
            this.Controls.Add(this.lstBasicItem);
            this.Controls.Add(this.btnUpdateBasicItem);
            this.Controls.Add(this.btnSubmitNewCategory);
            this.Controls.Add(this.btnSubmitNewSection);
            this.Controls.Add(this.btnSubmitNewBasicItem);
            this.Controls.Add(this.btnSubmitNewUnit);
            this.Controls.Add(this.cmbBICategories);
            this.Controls.Add(this.btnDeletBasicItem);
            this.Controls.Add(this.cmbSections);
            this.Controls.Add(this.cmbMU);
            this.Controls.Add(this.cmbPU);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBasicItemName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBasicItemCode);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DefineBasicItemsFRM";
            this.Text = "تعریف آیتم های آماده‌سازی";
            this.Load += new System.EventHandler(this.DefineBasicItemsFRM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstBasicItem;
        public System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader SCode;
        private System.Windows.Forms.ColumnHeader SName;
        private System.Windows.Forms.ColumnHeader SPrice;
        private System.Windows.Forms.ColumnHeader SellerName;
        private System.Windows.Forms.ColumnHeader MUnit;
        private System.Windows.Forms.ColumnHeader PUnit;
        private System.Windows.Forms.ColumnHeader CI;
        private System.Windows.Forms.ColumnHeader Wastage;
        private System.Windows.Forms.ColumnHeader isActive;
        private System.Windows.Forms.Button btnUpdateBasicItem;
        private System.Windows.Forms.Button btnSubmitNewSection;
        private System.Windows.Forms.Button btnSubmitNewBasicItem;
        private System.Windows.Forms.Button btnSubmitNewUnit;
        private System.Windows.Forms.Button btnDeletBasicItem;
        private System.Windows.Forms.ComboBox cmbSections;
        private System.Windows.Forms.ComboBox cmbMU;
        private System.Windows.Forms.ComboBox cmbPU;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBasicItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBasicItemCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBICategories;
        private System.Windows.Forms.Button btnSubmitNewCategory;
    }
}