namespace MainProject.Forms
{
    partial class DefineBankAccountFRM
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
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("");
            this.cmbAccountState = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAccountCard = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstBankAccount = new System.Windows.Forms.ListView();
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
            this.btnUpdateBankAccount = new System.Windows.Forms.Button();
            this.btnSubmitNewBankAccount = new System.Windows.Forms.Button();
            this.btnDeletBankAccount = new System.Windows.Forms.Button();
            this.cmbBankName = new System.Windows.Forms.ComboBox();
            this.cmbAccCategory = new System.Windows.Forms.ComboBox();
            this.cmbAccountType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccountOwner = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBACode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chbPayer = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbAccountState
            // 
            this.cmbAccountState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbAccountState.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbAccountState.FormattingEnabled = true;
            this.cmbAccountState.Location = new System.Drawing.Point(1420, 516);
            this.cmbAccountState.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAccountState.Name = "cmbAccountState";
            this.cmbAccountState.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbAccountState.Size = new System.Drawing.Size(139, 32);
            this.cmbAccountState.TabIndex = 59;
            this.cmbAccountState.SelectedIndexChanged += new System.EventHandler(this.cmbAccountState_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(1564, 518);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 30);
            this.label7.TabIndex = 58;
            this.label7.Text = "وضعیت";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtAccountCard
            // 
            this.txtAccountCard.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtAccountCard.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAccountCard.Location = new System.Drawing.Point(16, 58);
            this.txtAccountCard.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountCard.Name = "txtAccountCard";
            this.txtAccountCard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAccountCard.Size = new System.Drawing.Size(389, 32);
            this.txtAccountCard.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(408, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 30);
            this.label6.TabIndex = 55;
            this.label6.Text = "شماره‌کارت";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtAccountNumber.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAccountNumber.Location = new System.Drawing.Point(500, 57);
            this.txtAccountNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAccountNumber.Size = new System.Drawing.Size(378, 32);
            this.txtAccountNumber.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(880, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 30);
            this.label5.TabIndex = 54;
            this.label5.Text = "شماره‌حساب";
            // 
            // lstBankAccount
            // 
            this.lstBankAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstBankAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.lstBankAccount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstBankAccount.FullRowSelect = true;
            this.lstBankAccount.GridLines = true;
            this.lstBankAccount.HideSelection = false;
            this.lstBankAccount.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.lstBankAccount.Location = new System.Drawing.Point(4, 188);
            this.lstBankAccount.Margin = new System.Windows.Forms.Padding(4);
            this.lstBankAccount.MultiSelect = false;
            this.lstBankAccount.Name = "lstBankAccount";
            this.lstBankAccount.Size = new System.Drawing.Size(970, 376);
            this.lstBankAccount.TabIndex = 53;
            this.lstBankAccount.UseCompatibleStateImageBehavior = false;
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
            // btnUpdateBankAccount
            // 
            this.btnUpdateBankAccount.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdateBankAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdateBankAccount.Location = new System.Drawing.Point(219, 138);
            this.btnUpdateBankAccount.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateBankAccount.Name = "btnUpdateBankAccount";
            this.btnUpdateBankAccount.Size = new System.Drawing.Size(100, 42);
            this.btnUpdateBankAccount.TabIndex = 50;
            this.btnUpdateBankAccount.Text = "ویرایش";
            this.btnUpdateBankAccount.UseVisualStyleBackColor = true;
            // 
            // btnSubmitNewBankAccount
            // 
            this.btnSubmitNewBankAccount.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewBankAccount.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitNewBankAccount.Location = new System.Drawing.Point(485, 138);
            this.btnSubmitNewBankAccount.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewBankAccount.Name = "btnSubmitNewBankAccount";
            this.btnSubmitNewBankAccount.Size = new System.Drawing.Size(100, 42);
            this.btnSubmitNewBankAccount.TabIndex = 51;
            this.btnSubmitNewBankAccount.Text = "ثبت";
            this.btnSubmitNewBankAccount.UseVisualStyleBackColor = true;
            this.btnSubmitNewBankAccount.Click += new System.EventHandler(this.btnSubmitNewBankAccount_Click);
            // 
            // btnDeletBankAccount
            // 
            this.btnDeletBankAccount.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeletBankAccount.ForeColor = System.Drawing.Color.Red;
            this.btnDeletBankAccount.Location = new System.Drawing.Point(16, 138);
            this.btnDeletBankAccount.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletBankAccount.Name = "btnDeletBankAccount";
            this.btnDeletBankAccount.Size = new System.Drawing.Size(195, 42);
            this.btnDeletBankAccount.TabIndex = 52;
            this.btnDeletBankAccount.Text = "حذف و غیرفعال‌سازی";
            this.btnDeletBankAccount.UseVisualStyleBackColor = true;
            // 
            // cmbBankName
            // 
            this.cmbBankName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbBankName.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbBankName.FormattingEnabled = true;
            this.cmbBankName.Location = new System.Drawing.Point(16, 15);
            this.cmbBankName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBankName.Name = "cmbBankName";
            this.cmbBankName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbBankName.Size = new System.Drawing.Size(192, 32);
            this.cmbBankName.TabIndex = 47;
            // 
            // cmbAccCategory
            // 
            this.cmbAccCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbAccCategory.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbAccCategory.FormattingEnabled = true;
            this.cmbAccCategory.Location = new System.Drawing.Point(16, 95);
            this.cmbAccCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAccCategory.Name = "cmbAccCategory";
            this.cmbAccCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbAccCategory.Size = new System.Drawing.Size(142, 32);
            this.cmbAccCategory.TabIndex = 49;
            this.cmbAccCategory.SelectedIndexChanged += new System.EventHandler(this.cmbAccCategory_SelectedIndexChanged);
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbAccountType.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbAccountType.FormattingEnabled = true;
            this.cmbAccountType.Location = new System.Drawing.Point(245, 95);
            this.cmbAccountType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbAccountType.Size = new System.Drawing.Size(160, 32);
            this.cmbAccountType.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(155, 97);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 30);
            this.label8.TabIndex = 45;
            this.label8.Text = "دسته‌بندی";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(211, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 30);
            this.label4.TabIndex = 46;
            this.label4.Text = "بانک";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(408, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 30);
            this.label3.TabIndex = 44;
            this.label3.Text = "نوع حساب";
            // 
            // txtAccountOwner
            // 
            this.txtAccountOwner.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtAccountOwner.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAccountOwner.Location = new System.Drawing.Point(262, 15);
            this.txtAccountOwner.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountOwner.Name = "txtAccountOwner";
            this.txtAccountOwner.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccountOwner.Size = new System.Drawing.Size(397, 32);
            this.txtAccountOwner.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(655, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 30);
            this.label2.TabIndex = 42;
            this.label2.Text = "صاحب حساب";
            // 
            // txtBACode
            // 
            this.txtBACode.Enabled = false;
            this.txtBACode.Font = new System.Drawing.Font("Square721 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBACode.Location = new System.Drawing.Point(766, 17);
            this.txtBACode.Margin = new System.Windows.Forms.Padding(4);
            this.txtBACode.Name = "txtBACode";
            this.txtBACode.Size = new System.Drawing.Size(112, 32);
            this.txtBACode.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(881, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 30);
            this.label1.TabIndex = 40;
            this.label1.Text = "کد حساب";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(881, 97);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 30);
            this.label9.TabIndex = 55;
            this.label9.Text = "شماره ‌شبا";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox1.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox1.Location = new System.Drawing.Point(536, 97);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(342, 32);
            this.textBox1.TabIndex = 57;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(502, 102);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 30);
            this.label10.TabIndex = 55;
            this.label10.Text = "IR";
            // 
            // chbPayer
            // 
            this.chbPayer.AutoSize = true;
            this.chbPayer.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chbPayer.Location = new System.Drawing.Point(618, 145);
            this.chbPayer.Name = "chbPayer";
            this.chbPayer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbPayer.Size = new System.Drawing.Size(349, 31);
            this.chbPayer.TabIndex = 60;
            this.chbPayer.Text = "از این حساب، خریدها و تراکنش‌های مالی انجام می‌شود";
            this.chbPayer.UseVisualStyleBackColor = true;
            // 
            // DefineBankAccountFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(979, 570);
            this.Controls.Add(this.chbPayer);
            this.Controls.Add(this.cmbAccountState);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAccountCard);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstBankAccount);
            this.Controls.Add(this.btnUpdateBankAccount);
            this.Controls.Add(this.btnSubmitNewBankAccount);
            this.Controls.Add(this.btnDeletBankAccount);
            this.Controls.Add(this.cmbBankName);
            this.Controls.Add(this.cmbAccCategory);
            this.Controls.Add(this.cmbAccountType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAccountOwner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBACode);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DefineBankAccountFRM";
            this.Text = "تعریف حساب و پوز بانکی";
            this.Load += new System.EventHandler(this.DefineBankAccountFRM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAccountState;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAccountCard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lstBankAccount;
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
        private System.Windows.Forms.Button btnUpdateBankAccount;
        private System.Windows.Forms.Button btnSubmitNewBankAccount;
        private System.Windows.Forms.Button btnDeletBankAccount;
        private System.Windows.Forms.ComboBox cmbBankName;
        private System.Windows.Forms.ComboBox cmbAccCategory;
        private System.Windows.Forms.ComboBox cmbAccountType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccountOwner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBACode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chbPayer;
    }
}