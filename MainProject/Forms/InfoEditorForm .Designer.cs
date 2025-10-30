namespace MainProject.Forms
{
    partial class InfoEditorForm
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
            this.btnUpdateInfo = new System.Windows.Forms.Button();
            this.btnSubmitNewInfo = new System.Windows.Forms.Button();
            this.btnDeleteInfo = new System.Windows.Forms.Button();
            this.txtDigitalValue = new System.Windows.Forms.TextBox();
            this.txtStringValuePer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStringValueEng = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPersianTitle = new System.Windows.Forms.TextBox();
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
            this.lstInfo = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPersianContext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpdateInfo
            // 
            this.btnUpdateInfo.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdateInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdateInfo.Location = new System.Drawing.Point(84, 46);
            this.btnUpdateInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateInfo.Name = "btnUpdateInfo";
            this.btnUpdateInfo.Size = new System.Drawing.Size(76, 41);
            this.btnUpdateInfo.TabIndex = 87;
            this.btnUpdateInfo.Text = "ویرایش";
            this.btnUpdateInfo.UseVisualStyleBackColor = true;
            this.btnUpdateInfo.Click += new System.EventHandler(this.btnUpdateInfo_Click);
            // 
            // btnSubmitNewInfo
            // 
            this.btnSubmitNewInfo.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewInfo.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitNewInfo.Location = new System.Drawing.Point(196, 49);
            this.btnSubmitNewInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewInfo.Name = "btnSubmitNewInfo";
            this.btnSubmitNewInfo.Size = new System.Drawing.Size(63, 40);
            this.btnSubmitNewInfo.TabIndex = 86;
            this.btnSubmitNewInfo.Text = "ثبت";
            this.btnSubmitNewInfo.UseVisualStyleBackColor = true;
            this.btnSubmitNewInfo.Click += new System.EventHandler(this.btnSubmitNewInfo_Click);
            // 
            // btnDeleteInfo
            // 
            this.btnDeleteInfo.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeleteInfo.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteInfo.Location = new System.Drawing.Point(13, 47);
            this.btnDeleteInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteInfo.Name = "btnDeleteInfo";
            this.btnDeleteInfo.Size = new System.Drawing.Size(63, 40);
            this.btnDeleteInfo.TabIndex = 85;
            this.btnDeleteInfo.Text = "حذف";
            this.btnDeleteInfo.UseVisualStyleBackColor = true;
            this.btnDeleteInfo.Click += new System.EventHandler(this.btnDeleteInfo_Click);
            // 
            // txtDigitalValue
            // 
            this.txtDigitalValue.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtDigitalValue.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDigitalValue.Location = new System.Drawing.Point(279, 53);
            this.txtDigitalValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtDigitalValue.Name = "txtDigitalValue";
            this.txtDigitalValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDigitalValue.Size = new System.Drawing.Size(75, 32);
            this.txtDigitalValue.TabIndex = 81;
            // 
            // txtStringValuePer
            // 
            this.txtStringValuePer.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtStringValuePer.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtStringValuePer.Location = new System.Drawing.Point(794, 53);
            this.txtStringValuePer.Margin = new System.Windows.Forms.Padding(4);
            this.txtStringValuePer.Name = "txtStringValuePer";
            this.txtStringValuePer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtStringValuePer.Size = new System.Drawing.Size(222, 32);
            this.txtStringValuePer.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(679, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(114, 30);
            this.label4.TabIndex = 77;
            this.label4.Text = "عنوان انگلیسی";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtStringValueEng
            // 
            this.txtStringValueEng.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtStringValueEng.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtStringValueEng.Location = new System.Drawing.Point(449, 53);
            this.txtStringValueEng.Margin = new System.Windows.Forms.Padding(4);
            this.txtStringValueEng.Name = "txtStringValueEng";
            this.txtStringValueEng.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtStringValueEng.Size = new System.Drawing.Size(229, 32);
            this.txtStringValueEng.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(1017, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(99, 30);
            this.label3.TabIndex = 78;
            this.label3.Text = "عنوان فارسی";
            // 
            // txtPersianTitle
            // 
            this.txtPersianTitle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPersianTitle.Enabled = false;
            this.txtPersianTitle.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPersianTitle.Location = new System.Drawing.Point(449, 9);
            this.txtPersianTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersianTitle.Name = "txtPersianTitle";
            this.txtPersianTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPersianTitle.Size = new System.Drawing.Size(229, 32);
            this.txtPersianTitle.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(1051, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(65, 30);
            this.label1.TabIndex = 79;
            this.label1.Text = "موضوع:";
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
            // lstInfo
            // 
            this.lstInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.lstInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstInfo.FullRowSelect = true;
            this.lstInfo.GridLines = true;
            this.lstInfo.HideSelection = false;
            this.lstInfo.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lstInfo.Location = new System.Drawing.Point(13, 93);
            this.lstInfo.Margin = new System.Windows.Forms.Padding(4);
            this.lstInfo.MultiSelect = false;
            this.lstInfo.Name = "lstInfo";
            this.lstInfo.Size = new System.Drawing.Size(1103, 245);
            this.lstInfo.TabIndex = 88;
            this.lstInfo.UseCompatibleStateImageBehavior = false;
            this.lstInfo.SelectedIndexChanged += new System.EventHandler(this.lstInfo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(353, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(95, 30);
            this.label5.TabIndex = 80;
            this.label5.Text = "معادل عددی";
            // 
            // txtPersianContext
            // 
            this.txtPersianContext.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPersianContext.Enabled = false;
            this.txtPersianContext.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPersianContext.Location = new System.Drawing.Point(794, 9);
            this.txtPersianContext.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersianContext.Name = "txtPersianContext";
            this.txtPersianContext.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPersianContext.Size = new System.Drawing.Size(249, 32);
            this.txtPersianContext.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(679, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(112, 30);
            this.label2.TabIndex = 77;
            this.label2.Text = "معادل انگلیسی";
            this.label2.Click += new System.EventHandler(this.label4_Click);
            // 
            // InfoEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 351);
            this.Controls.Add(this.btnUpdateInfo);
            this.Controls.Add(this.btnSubmitNewInfo);
            this.Controls.Add(this.btnDeleteInfo);
            this.Controls.Add(this.txtDigitalValue);
            this.Controls.Add(this.txtStringValuePer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStringValueEng);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPersianContext);
            this.Controls.Add(this.txtPersianTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstInfo);
            this.Controls.Add(this.label5);
            this.Name = "InfoEditorForm";
            this.Text = "تعریف دسته‌بندی‌ها";
            this.Load += new System.EventHandler(this.InfoEditorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateInfo;
        private System.Windows.Forms.Button btnSubmitNewInfo;
        private System.Windows.Forms.Button btnDeleteInfo;
        private System.Windows.Forms.TextBox txtDigitalValue;
        private System.Windows.Forms.TextBox txtStringValuePer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStringValueEng;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPersianTitle;
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
        private System.Windows.Forms.ListView lstInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPersianContext;
        private System.Windows.Forms.Label label2;
    }
}