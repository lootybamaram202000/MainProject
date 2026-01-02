namespace MainProject.Forms
{
    partial class DefineSectionsFRM
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
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("");
            this.btnUpdateSection = new System.Windows.Forms.Button();
            this.btnSubmitNewSection = new System.Windows.Forms.Button();
            this.btnDeletSection = new System.Windows.Forms.Button();
            this.txtSectionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSectionCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.lstSection = new System.Windows.Forms.ListView();
            this.lstSubSections = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubSection = new System.Windows.Forms.TextBox();
            this.btnDeletSubSection = new System.Windows.Forms.Button();
            this.btnSubmitNewSubSection = new System.Windows.Forms.Button();
            this.btnUpdateSubSection = new System.Windows.Forms.Button();
            this.txtPercentage = new System.Windows.Forms.TextBox();
            this.txtCountOfSell = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpdateSection
            // 
            this.btnUpdateSection.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdateSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdateSection.Location = new System.Drawing.Point(81, 135);
            this.btnUpdateSection.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateSection.Name = "btnUpdateSection";
            this.btnUpdateSection.Size = new System.Drawing.Size(81, 42);
            this.btnUpdateSection.TabIndex = 86;
            this.btnUpdateSection.Text = "ویرایش";
            this.btnUpdateSection.UseVisualStyleBackColor = true;
            this.btnUpdateSection.Click += new System.EventHandler(this.btnUpdateSection_Click);
            // 
            // btnSubmitNewSection
            // 
            this.btnSubmitNewSection.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewSection.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitNewSection.Location = new System.Drawing.Point(438, 135);
            this.btnSubmitNewSection.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewSection.Name = "btnSubmitNewSection";
            this.btnSubmitNewSection.Size = new System.Drawing.Size(63, 42);
            this.btnSubmitNewSection.TabIndex = 85;
            this.btnSubmitNewSection.Text = "ثبت";
            this.btnSubmitNewSection.UseVisualStyleBackColor = true;
            this.btnSubmitNewSection.Click += new System.EventHandler(this.btnSubmitNewSection_Click);
            // 
            // btnDeletSection
            // 
            this.btnDeletSection.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeletSection.ForeColor = System.Drawing.Color.Red;
            this.btnDeletSection.Location = new System.Drawing.Point(11, 135);
            this.btnDeletSection.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletSection.Name = "btnDeletSection";
            this.btnDeletSection.Size = new System.Drawing.Size(67, 42);
            this.btnDeletSection.TabIndex = 84;
            this.btnDeletSection.Text = "حذف";
            this.btnDeletSection.UseVisualStyleBackColor = true;
            this.btnDeletSection.Click += new System.EventHandler(this.btnDeletSection_Click);
            // 
            // txtSectionName
            // 
            this.txtSectionName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtSectionName.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSectionName.Location = new System.Drawing.Point(13, 54);
            this.txtSectionName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSectionName.Name = "txtSectionName";
            this.txtSectionName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSectionName.Size = new System.Drawing.Size(399, 32);
            this.txtSectionName.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(413, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 30);
            this.label2.TabIndex = 82;
            this.label2.Text = "نام سکشن";
            // 
            // txtSectionCode
            // 
            this.txtSectionCode.Enabled = false;
            this.txtSectionCode.Font = new System.Drawing.Font("Square721 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSectionCode.Location = new System.Drawing.Point(256, 14);
            this.txtSectionCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtSectionCode.Name = "txtSectionCode";
            this.txtSectionCode.Size = new System.Drawing.Size(156, 32);
            this.txtSectionCode.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(413, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 30);
            this.label1.TabIndex = 80;
            this.label1.Text = "کد سکشن";
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
            // lstSection
            // 
            this.lstSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstSection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.lstSection.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstSection.FullRowSelect = true;
            this.lstSection.GridLines = true;
            this.lstSection.HideSelection = false;
            this.lstSection.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lstSection.Location = new System.Drawing.Point(10, 185);
            this.lstSection.Margin = new System.Windows.Forms.Padding(4);
            this.lstSection.MultiSelect = false;
            this.lstSection.Name = "lstSection";
            this.lstSection.Size = new System.Drawing.Size(490, 151);
            this.lstSection.TabIndex = 87;
            this.lstSection.UseCompatibleStateImageBehavior = false;
            this.lstSection.SelectedIndexChanged += new System.EventHandler(this.lstSection_SelectedIndexChanged);
            // 
            // lstSubSections
            // 
            this.lstSubSections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lstSubSections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lstSubSections.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstSubSections.FullRowSelect = true;
            this.lstSubSections.GridLines = true;
            this.lstSubSections.HideSelection = false;
            this.lstSubSections.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.lstSubSections.Location = new System.Drawing.Point(11, 438);
            this.lstSubSections.Margin = new System.Windows.Forms.Padding(4);
            this.lstSubSections.MultiSelect = false;
            this.lstSubSections.Name = "lstSubSections";
            this.lstSubSections.Size = new System.Drawing.Size(490, 180);
            this.lstSubSections.TabIndex = 87;
            this.lstSubSections.UseCompatibleStateImageBehavior = false;
            this.lstSubSections.SelectedIndexChanged += new System.EventHandler(this.lstSubSections_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 9;
            this.columnHeader1.Text = "ردیف";
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 0;
            this.columnHeader2.Text = "کد کالا";
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 1;
            this.columnHeader3.Text = "نام کالا";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 2;
            this.columnHeader4.Text = "قیمت خرید";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 3;
            this.columnHeader5.Text = "فروشنده";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 4;
            this.columnHeader6.Text = "واحد خرید";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 5;
            this.columnHeader7.Text = "واحد خرید";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 6;
            this.columnHeader8.Text = "مکوجودی بحرانی";
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 7;
            this.columnHeader9.Text = "دورریز";
            // 
            // columnHeader10
            // 
            this.columnHeader10.DisplayIndex = 8;
            this.columnHeader10.Text = "وضعیت";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(384, 344);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 30);
            this.label3.TabIndex = 82;
            this.label3.Text = "نام زیر سکشن";
            // 
            // txtSubSection
            // 
            this.txtSubSection.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtSubSection.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSubSection.Location = new System.Drawing.Point(14, 344);
            this.txtSubSection.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubSection.Name = "txtSubSection";
            this.txtSubSection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubSection.Size = new System.Drawing.Size(362, 32);
            this.txtSubSection.TabIndex = 83;
            // 
            // btnDeletSubSection
            // 
            this.btnDeletSubSection.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeletSubSection.ForeColor = System.Drawing.Color.Red;
            this.btnDeletSubSection.Location = new System.Drawing.Point(11, 388);
            this.btnDeletSubSection.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletSubSection.Name = "btnDeletSubSection";
            this.btnDeletSubSection.Size = new System.Drawing.Size(67, 42);
            this.btnDeletSubSection.TabIndex = 84;
            this.btnDeletSubSection.Text = "حذف";
            this.btnDeletSubSection.UseVisualStyleBackColor = true;
            this.btnDeletSubSection.Click += new System.EventHandler(this.btnDeletSection_Click);
            // 
            // btnSubmitNewSubSection
            // 
            this.btnSubmitNewSubSection.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewSubSection.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitNewSubSection.Location = new System.Drawing.Point(438, 388);
            this.btnSubmitNewSubSection.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewSubSection.Name = "btnSubmitNewSubSection";
            this.btnSubmitNewSubSection.Size = new System.Drawing.Size(63, 42);
            this.btnSubmitNewSubSection.TabIndex = 85;
            this.btnSubmitNewSubSection.Text = "ثبت";
            this.btnSubmitNewSubSection.UseVisualStyleBackColor = true;
            this.btnSubmitNewSubSection.Click += new System.EventHandler(this.btnSubmitNewSection_Click);
            // 
            // btnUpdateSubSection
            // 
            this.btnUpdateSubSection.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdateSubSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdateSubSection.Location = new System.Drawing.Point(81, 388);
            this.btnUpdateSubSection.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateSubSection.Name = "btnUpdateSubSection";
            this.btnUpdateSubSection.Size = new System.Drawing.Size(81, 42);
            this.btnUpdateSubSection.TabIndex = 86;
            this.btnUpdateSubSection.Text = "ویرایش";
            this.btnUpdateSubSection.UseVisualStyleBackColor = true;
            this.btnUpdateSubSection.Click += new System.EventHandler(this.btnUpdateSection_Click);
            // 
            // txtPercentage
            // 
            this.txtPercentage.Enabled = false;
            this.txtPercentage.Font = new System.Drawing.Font("Square721 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPercentage.Location = new System.Drawing.Point(310, 94);
            this.txtPercentage.Margin = new System.Windows.Forms.Padding(4);
            this.txtPercentage.Name = "txtPercentage";
            this.txtPercentage.Size = new System.Drawing.Size(66, 32);
            this.txtPercentage.TabIndex = 81;
            // 
            // txtCountOfSell
            // 
            this.txtCountOfSell.Enabled = false;
            this.txtCountOfSell.Font = new System.Drawing.Font("Square721 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountOfSell.Location = new System.Drawing.Point(128, 95);
            this.txtCountOfSell.Margin = new System.Windows.Forms.Padding(4);
            this.txtCountOfSell.Name = "txtCountOfSell";
            this.txtCountOfSell.Size = new System.Drawing.Size(66, 32);
            this.txtCountOfSell.TabIndex = 81;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(202, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 30);
            this.label4.TabIndex = 80;
            this.label4.Text = "تعداد فروش";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(384, 97);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 30);
            this.label5.TabIndex = 80;
            this.label5.Text = "درصد فروش";
            // 
            // DefineSectionsFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 625);
            this.Controls.Add(this.btnUpdateSubSection);
            this.Controls.Add(this.btnUpdateSection);
            this.Controls.Add(this.btnSubmitNewSubSection);
            this.Controls.Add(this.btnSubmitNewSection);
            this.Controls.Add(this.btnDeletSubSection);
            this.Controls.Add(this.btnDeletSection);
            this.Controls.Add(this.txtSubSection);
            this.Controls.Add(this.txtSectionName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCountOfSell);
            this.Controls.Add(this.txtPercentage);
            this.Controls.Add(this.txtSectionCode);
            this.Controls.Add(this.lstSubSections);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSection);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DefineSectionsFRM";
            this.Text = "تعریف سکشن‌ها";
            this.Load += new System.EventHandler(this.DefineSectionsFRM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUpdateSection;
        private System.Windows.Forms.Button btnSubmitNewSection;
        private System.Windows.Forms.Button btnDeletSection;
        private System.Windows.Forms.TextBox txtSectionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSectionCode;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.ListView lstSection;
        private System.Windows.Forms.ListView lstSubSections;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubSection;
        private System.Windows.Forms.Button btnDeletSubSection;
        private System.Windows.Forms.Button btnSubmitNewSubSection;
        private System.Windows.Forms.Button btnUpdateSubSection;
        private System.Windows.Forms.TextBox txtPercentage;
        private System.Windows.Forms.TextBox txtCountOfSell;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}