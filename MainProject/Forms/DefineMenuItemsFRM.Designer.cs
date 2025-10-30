namespace MainProject.Forms
{
    partial class DefineMenuItemsFRM
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
            this.lstMenuItem = new System.Windows.Forms.ListView();
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
            this.btnUpdateMenuItem = new System.Windows.Forms.Button();
            this.btnDefineNewCategory = new System.Windows.Forms.Button();
            this.cmbItemCategory = new System.Windows.Forms.ComboBox();
            this.btnSubmitNewSection = new System.Windows.Forms.Button();
            this.btnSubmitNewMenuItem = new System.Windows.Forms.Button();
            this.btnDeletMenuItem = new System.Windows.Forms.Button();
            this.cmbSections = new System.Windows.Forms.ComboBox();
            this.txtSearchMenuItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMenuItemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMenuItemCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstMenuItem
            // 
            this.lstMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstMenuItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.lstMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstMenuItem.FullRowSelect = true;
            this.lstMenuItem.GridLines = true;
            this.lstMenuItem.HideSelection = false;
            this.lstMenuItem.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lstMenuItem.Location = new System.Drawing.Point(13, 158);
            this.lstMenuItem.Margin = new System.Windows.Forms.Padding(4);
            this.lstMenuItem.MultiSelect = false;
            this.lstMenuItem.Name = "lstMenuItem";
            this.lstMenuItem.Size = new System.Drawing.Size(1124, 517);
            this.lstMenuItem.TabIndex = 82;
            this.lstMenuItem.UseCompatibleStateImageBehavior = false;
            this.lstMenuItem.SelectedIndexChanged += new System.EventHandler(this.lstMenuItem_SelectedIndexChanged);
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
            // btnUpdateMenuItem
            // 
            this.btnUpdateMenuItem.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdateMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdateMenuItem.Location = new System.Drawing.Point(106, 108);
            this.btnUpdateMenuItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateMenuItem.Name = "btnUpdateMenuItem";
            this.btnUpdateMenuItem.Size = new System.Drawing.Size(81, 42);
            this.btnUpdateMenuItem.TabIndex = 81;
            this.btnUpdateMenuItem.Text = "ویرایش";
            this.btnUpdateMenuItem.UseVisualStyleBackColor = true;
            this.btnUpdateMenuItem.Click += new System.EventHandler(this.btnUpdateMenuItem_Click);
            // 
            // btnDefineNewCategory
            // 
            this.btnDefineNewCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDefineNewCategory.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDefineNewCategory.Location = new System.Drawing.Point(528, 56);
            this.btnDefineNewCategory.Margin = new System.Windows.Forms.Padding(4);
            this.btnDefineNewCategory.Name = "btnDefineNewCategory";
            this.btnDefineNewCategory.Size = new System.Drawing.Size(151, 36);
            this.btnDefineNewCategory.TabIndex = 79;
            this.btnDefineNewCategory.Text = "تعریف دسته‌بندی جدید";
            this.btnDefineNewCategory.UseVisualStyleBackColor = false;
            this.btnDefineNewCategory.Click += new System.EventHandler(this.btnDefineNewCategory_Click);
            // 
            // cmbItemCategory
            // 
            this.cmbItemCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbItemCategory.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbItemCategory.FormattingEnabled = true;
            this.cmbItemCategory.Location = new System.Drawing.Point(687, 59);
            this.cmbItemCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbItemCategory.Name = "cmbItemCategory";
            this.cmbItemCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbItemCategory.Size = new System.Drawing.Size(311, 32);
            this.cmbItemCategory.TabIndex = 75;
            // 
            // btnSubmitNewSection
            // 
            this.btnSubmitNewSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSubmitNewSection.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewSection.Location = new System.Drawing.Point(36, 8);
            this.btnSubmitNewSection.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewSection.Name = "btnSubmitNewSection";
            this.btnSubmitNewSection.Size = new System.Drawing.Size(151, 36);
            this.btnSubmitNewSection.TabIndex = 80;
            this.btnSubmitNewSection.Text = "تعریف سکشن جدید";
            this.btnSubmitNewSection.UseVisualStyleBackColor = false;
            this.btnSubmitNewSection.Click += new System.EventHandler(this.btnSubmitNewSection_Click);
            // 
            // btnSubmitNewMenuItem
            // 
            this.btnSubmitNewMenuItem.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewMenuItem.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitNewMenuItem.Location = new System.Drawing.Point(685, 105);
            this.btnSubmitNewMenuItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewMenuItem.Name = "btnSubmitNewMenuItem";
            this.btnSubmitNewMenuItem.Size = new System.Drawing.Size(63, 42);
            this.btnSubmitNewMenuItem.TabIndex = 78;
            this.btnSubmitNewMenuItem.Text = "ثبت";
            this.btnSubmitNewMenuItem.UseVisualStyleBackColor = true;
            this.btnSubmitNewMenuItem.Click += new System.EventHandler(this.btnSubmitNewMenuItem_Click);
            // 
            // btnDeletMenuItem
            // 
            this.btnDeletMenuItem.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeletMenuItem.ForeColor = System.Drawing.Color.Red;
            this.btnDeletMenuItem.Location = new System.Drawing.Point(36, 108);
            this.btnDeletMenuItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletMenuItem.Name = "btnDeletMenuItem";
            this.btnDeletMenuItem.Size = new System.Drawing.Size(67, 42);
            this.btnDeletMenuItem.TabIndex = 77;
            this.btnDeletMenuItem.Text = "حذف";
            this.btnDeletMenuItem.UseVisualStyleBackColor = true;
            this.btnDeletMenuItem.Click += new System.EventHandler(this.btnDeletMenuItem_Click);
            // 
            // cmbSections
            // 
            this.cmbSections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbSections.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbSections.FormattingEnabled = true;
            this.cmbSections.Location = new System.Drawing.Point(193, 10);
            this.cmbSections.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSections.Name = "cmbSections";
            this.cmbSections.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbSections.Size = new System.Drawing.Size(187, 32);
            this.cmbSections.TabIndex = 76;
            // 
            // txtSearchMenuItem
            // 
            this.txtSearchMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSearchMenuItem.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSearchMenuItem.Location = new System.Drawing.Point(765, 111);
            this.txtSearchMenuItem.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchMenuItem.Name = "txtSearchMenuItem";
            this.txtSearchMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearchMenuItem.Size = new System.Drawing.Size(295, 32);
            this.txtSearchMenuItem.TabIndex = 74;
            this.txtSearchMenuItem.TextChanged += new System.EventHandler(this.txtSearchMenuItem_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(1001, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 30);
            this.label3.TabIndex = 71;
            this.label3.Text = "دسته‌بندی فروش";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(1063, 114);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 30);
            this.label10.TabIndex = 73;
            this.label10.Text = "جستجو";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(379, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 30);
            this.label9.TabIndex = 72;
            this.label9.Text = "سکشن";
            // 
            // txtMenuItemName
            // 
            this.txtMenuItemName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtMenuItemName.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtMenuItemName.Location = new System.Drawing.Point(444, 11);
            this.txtMenuItemName.Margin = new System.Windows.Forms.Padding(4);
            this.txtMenuItemName.Name = "txtMenuItemName";
            this.txtMenuItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMenuItemName.Size = new System.Drawing.Size(401, 32);
            this.txtMenuItemName.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(849, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 30);
            this.label2.TabIndex = 69;
            this.label2.Text = "نام آیتم";
            // 
            // txtMenuItemCode
            // 
            this.txtMenuItemCode.Enabled = false;
            this.txtMenuItemCode.Font = new System.Drawing.Font("Square721 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMenuItemCode.Location = new System.Drawing.Point(923, 13);
            this.txtMenuItemCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtMenuItemCode.Name = "txtMenuItemCode";
            this.txtMenuItemCode.Size = new System.Drawing.Size(144, 32);
            this.txtMenuItemCode.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(1068, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 30);
            this.label1.TabIndex = 67;
            this.label1.Text = "کد آیتم";
            // 
            // DefineMenuItemsFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1150, 688);
            this.Controls.Add(this.lstMenuItem);
            this.Controls.Add(this.btnUpdateMenuItem);
            this.Controls.Add(this.btnDefineNewCategory);
            this.Controls.Add(this.cmbItemCategory);
            this.Controls.Add(this.btnSubmitNewSection);
            this.Controls.Add(this.btnSubmitNewMenuItem);
            this.Controls.Add(this.btnDeletMenuItem);
            this.Controls.Add(this.cmbSections);
            this.Controls.Add(this.txtSearchMenuItem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMenuItemName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMenuItemCode);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DefineMenuItemsFRM";
            this.Text = "تعریف آیتم های منو";
            this.Load += new System.EventHandler(this.DefineMenuItemsFRM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstMenuItem;
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
        private System.Windows.Forms.Button btnUpdateMenuItem;
        private System.Windows.Forms.Button btnDefineNewCategory;
        private System.Windows.Forms.ComboBox cmbItemCategory;
        private System.Windows.Forms.Button btnSubmitNewSection;
        private System.Windows.Forms.Button btnSubmitNewMenuItem;
        private System.Windows.Forms.Button btnDeletMenuItem;
        private System.Windows.Forms.ComboBox cmbSections;
        private System.Windows.Forms.TextBox txtSearchMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMenuItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMenuItemCode;
        private System.Windows.Forms.Label label1;
    }
}