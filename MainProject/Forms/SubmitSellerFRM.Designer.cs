namespace MainProject.Forms
{
    partial class SubmitSellerFRM
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
            System.Windows.Forms.ListViewItem listViewItem41 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem42 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem43 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem44 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem45 = new System.Windows.Forms.ListViewItem("");
            this.txtSearchSeller = new System.Windows.Forms.TextBox();
            this.lstSeller = new System.Windows.Forms.ListView();
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
            this.btnUpdateSeller = new System.Windows.Forms.Button();
            this.btnSubmitNewSeller = new System.Windows.Forms.Button();
            this.btnDeletSeller = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtISellerCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSellerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.rdbdebtor = new System.Windows.Forms.RadioButton();
            this.rdbcreditor = new System.Windows.Forms.RadioButton();
            this.btnDefineBankAccouant = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCardNumb = new System.Windows.Forms.TextBox();
            this.txtBank = new System.Windows.Forms.Label();
            this.txtBanks = new System.Windows.Forms.TextBox();
            this.txtShabaNumb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnNewCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearchSeller
            // 
            this.txtSearchSeller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSearchSeller.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSearchSeller.Location = new System.Drawing.Point(543, 250);
            this.txtSearchSeller.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchSeller.Name = "txtSearchSeller";
            this.txtSearchSeller.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearchSeller.Size = new System.Drawing.Size(335, 32);
            this.txtSearchSeller.TabIndex = 69;
            this.txtSearchSeller.TextChanged += new System.EventHandler(this.txtSearchSeller_TextChanged);
            // 
            // lstSeller
            // 
            this.lstSeller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstSeller.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.lstSeller.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstSeller.FullRowSelect = true;
            this.lstSeller.GridLines = true;
            this.lstSeller.HideSelection = false;
            this.lstSeller.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem41,
            listViewItem42,
            listViewItem43,
            listViewItem44,
            listViewItem45});
            this.lstSeller.Location = new System.Drawing.Point(13, 290);
            this.lstSeller.Margin = new System.Windows.Forms.Padding(4);
            this.lstSeller.MultiSelect = false;
            this.lstSeller.Name = "lstSeller";
            this.lstSeller.Size = new System.Drawing.Size(1073, 471);
            this.lstSeller.TabIndex = 64;
            this.lstSeller.UseCompatibleStateImageBehavior = false;
            this.lstSeller.SelectedIndexChanged += new System.EventHandler(this.lstSeller_SelectedIndexChanged);
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
            // btnUpdateSeller
            // 
            this.btnUpdateSeller.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdateSeller.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdateSeller.Location = new System.Drawing.Point(121, 240);
            this.btnUpdateSeller.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateSeller.Name = "btnUpdateSeller";
            this.btnUpdateSeller.Size = new System.Drawing.Size(100, 42);
            this.btnUpdateSeller.TabIndex = 65;
            this.btnUpdateSeller.Text = "ویرایش";
            this.btnUpdateSeller.UseVisualStyleBackColor = true;
            this.btnUpdateSeller.Click += new System.EventHandler(this.btnUpdateSeller_Click);
            // 
            // btnSubmitNewSeller
            // 
            this.btnSubmitNewSeller.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewSeller.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitNewSeller.Location = new System.Drawing.Point(435, 242);
            this.btnSubmitNewSeller.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewSeller.Name = "btnSubmitNewSeller";
            this.btnSubmitNewSeller.Size = new System.Drawing.Size(100, 40);
            this.btnSubmitNewSeller.TabIndex = 66;
            this.btnSubmitNewSeller.Text = "ثبت";
            this.btnSubmitNewSeller.UseVisualStyleBackColor = true;
            this.btnSubmitNewSeller.Click += new System.EventHandler(this.btnSubmitNewSeller_Click);
            // 
            // btnDeletSeller
            // 
            this.btnDeletSeller.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeletSeller.ForeColor = System.Drawing.Color.Red;
            this.btnDeletSeller.Location = new System.Drawing.Point(14, 240);
            this.btnDeletSeller.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletSeller.Name = "btnDeletSeller";
            this.btnDeletSeller.Size = new System.Drawing.Size(100, 42);
            this.btnDeletSeller.TabIndex = 67;
            this.btnDeletSeller.Text = "حذف";
            this.btnDeletSeller.UseVisualStyleBackColor = true;
            this.btnDeletSeller.Click += new System.EventHandler(this.btnDeletSeller_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(881, 249);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 30);
            this.label7.TabIndex = 68;
            this.label7.Text = "جستجو در لیست فروشنده‌ها";
            // 
            // txtISellerCode
            // 
            this.txtISellerCode.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtISellerCode.Enabled = false;
            this.txtISellerCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtISellerCode.Location = new System.Drawing.Point(830, 63);
            this.txtISellerCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtISellerCode.Name = "txtISellerCode";
            this.txtISellerCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtISellerCode.Size = new System.Drawing.Size(165, 32);
            this.txtISellerCode.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(999, 64);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(84, 29);
            this.label6.TabIndex = 47;
            this.label6.Text = "کد فروشنده";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtCompanyName.Font = new System.Drawing.Font("B Nazanin", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtCompanyName.Location = new System.Drawing.Point(14, 62);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCompanyName.Size = new System.Drawing.Size(381, 33);
            this.txtCompanyName.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(395, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(74, 29);
            this.label2.TabIndex = 48;
            this.label2.Text = "نام شرکت";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.Thistle;
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhone.Location = new System.Drawing.Point(14, 107);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPhone.Size = new System.Drawing.Size(245, 32);
            this.txtPhone.TabIndex = 59;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label11.Location = new System.Drawing.Point(259, 109);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(102, 29);
            this.label11.TabIndex = 54;
            this.label11.Text = "شماره‌ی تماس";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.Thistle;
            this.txtAddress.Font = new System.Drawing.Font("B Nazanin", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtAddress.Location = new System.Drawing.Point(369, 107);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.Size = new System.Drawing.Size(656, 33);
            this.txtAddress.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(909, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(173, 38);
            this.label5.TabIndex = 52;
            this.label5.Text = "مشخصات فروشنده";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(1029, 108);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(54, 29);
            this.label10.TabIndex = 50;
            this.label10.Text = "آدرس ";
            // 
            // txtSellerName
            // 
            this.txtSellerName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSellerName.Font = new System.Drawing.Font("B Nazanin", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtSellerName.Location = new System.Drawing.Point(473, 63);
            this.txtSellerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSellerName.Name = "txtSellerName";
            this.txtSellerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSellerName.Size = new System.Drawing.Size(271, 33);
            this.txtSellerName.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(743, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(84, 29);
            this.label1.TabIndex = 46;
            this.label1.Text = "نام فروشنده";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(966, 155);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(117, 29);
            this.label8.TabIndex = 53;
            this.label8.Text = "دسته‌بندی فروش";
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.Lavender;
            this.cmbCategory.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(778, 153);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCategory.Size = new System.Drawing.Size(188, 34);
            this.cmbCategory.TabIndex = 61;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(569, 155);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(88, 29);
            this.label9.TabIndex = 49;
            this.label9.Text = "مانده حساب";
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtBalance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBalance.Location = new System.Drawing.Point(363, 154);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBalance.Size = new System.Drawing.Size(205, 32);
            this.txtBalance.TabIndex = 60;
            this.txtBalance.TextChanged += new System.EventHandler(this.txtBalance_TextChanged);
            this.txtBalance.Leave += new System.EventHandler(this.txtBalance_Leave);
            // 
            // rdbdebtor
            // 
            this.rdbdebtor.AutoSize = true;
            this.rdbdebtor.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rdbdebtor.Location = new System.Drawing.Point(228, 153);
            this.rdbdebtor.Name = "rdbdebtor";
            this.rdbdebtor.Size = new System.Drawing.Size(72, 31);
            this.rdbdebtor.TabIndex = 70;
            this.rdbdebtor.TabStop = true;
            this.rdbdebtor.Text = "بدهکار";
            this.rdbdebtor.UseVisualStyleBackColor = true;
            this.rdbdebtor.CheckedChanged += new System.EventHandler(this.rdbdebtor_CheckedChanged);
            // 
            // rdbcreditor
            // 
            this.rdbcreditor.AutoSize = true;
            this.rdbcreditor.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rdbcreditor.Location = new System.Drawing.Point(139, 153);
            this.rdbcreditor.Name = "rdbcreditor";
            this.rdbcreditor.Size = new System.Drawing.Size(82, 31);
            this.rdbcreditor.TabIndex = 70;
            this.rdbcreditor.TabStop = true;
            this.rdbcreditor.Text = "بستانکار";
            this.rdbcreditor.UseVisualStyleBackColor = true;
            this.rdbcreditor.CheckedChanged += new System.EventHandler(this.rdbcreditor_CheckedChanged);
            // 
            // btnDefineBankAccouant
            // 
            this.btnDefineBankAccouant.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDefineBankAccouant.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnDefineBankAccouant.Location = new System.Drawing.Point(14, 152);
            this.btnDefineBankAccouant.Margin = new System.Windows.Forms.Padding(4);
            this.btnDefineBankAccouant.Name = "btnDefineBankAccouant";
            this.btnDefineBankAccouant.Size = new System.Drawing.Size(125, 35);
            this.btnDefineBankAccouant.TabIndex = 66;
            this.btnDefineBankAccouant.Text = "تعریف حساب بانکی";
            this.btnDefineBankAccouant.UseVisualStyleBackColor = true;
            this.btnDefineBankAccouant.Click += new System.EventHandler(this.btnSubmitNewSeller_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(1005, 202);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(75, 29);
            this.label3.TabIndex = 71;
            this.label3.Text = "شماره شبا";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(738, 204);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(38, 29);
            this.label4.TabIndex = 49;
            this.label4.Text = "IR-";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.Location = new System.Drawing.Point(523, 202);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(86, 29);
            this.label12.TabIndex = 71;
            this.label12.Text = "شماره کارت";
            // 
            // txtCardNumb
            // 
            this.txtCardNumb.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtCardNumb.Enabled = false;
            this.txtCardNumb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCardNumb.Location = new System.Drawing.Point(295, 202);
            this.txtCardNumb.Margin = new System.Windows.Forms.Padding(4);
            this.txtCardNumb.Name = "txtCardNumb";
            this.txtCardNumb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCardNumb.Size = new System.Drawing.Size(226, 32);
            this.txtCardNumb.TabIndex = 72;
            // 
            // txtBank
            // 
            this.txtBank.AutoSize = true;
            this.txtBank.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBank.Location = new System.Drawing.Point(245, 203);
            this.txtBank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtBank.Name = "txtBank";
            this.txtBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBank.Size = new System.Drawing.Size(41, 29);
            this.txtBank.TabIndex = 71;
            this.txtBank.Text = "بانک";
            // 
            // txtBanks
            // 
            this.txtBanks.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtBanks.Enabled = false;
            this.txtBanks.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBanks.Location = new System.Drawing.Point(14, 201);
            this.txtBanks.Margin = new System.Windows.Forms.Padding(4);
            this.txtBanks.Name = "txtBanks";
            this.txtBanks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBanks.Size = new System.Drawing.Size(226, 32);
            this.txtBanks.TabIndex = 72;
            // 
            // txtShabaNumb
            // 
            this.txtShabaNumb.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtShabaNumb.Enabled = false;
            this.txtShabaNumb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtShabaNumb.Location = new System.Drawing.Point(778, 202);
            this.txtShabaNumb.Margin = new System.Windows.Forms.Padding(4);
            this.txtShabaNumb.Name = "txtShabaNumb";
            this.txtShabaNumb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtShabaNumb.Size = new System.Drawing.Size(226, 32);
            this.txtShabaNumb.TabIndex = 72;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label13.Location = new System.Drawing.Point(313, 155);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(47, 29);
            this.label13.TabIndex = 71;
            this.label13.Text = "تومان";
            // 
            // btnNewCategory
            // 
            this.btnNewCategory.BackColor = System.Drawing.Color.Lavender;
            this.btnNewCategory.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnNewCategory.ForeColor = System.Drawing.Color.Black;
            this.btnNewCategory.Location = new System.Drawing.Point(658, 152);
            this.btnNewCategory.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewCategory.Name = "btnNewCategory";
            this.btnNewCategory.Size = new System.Drawing.Size(112, 35);
            this.btnNewCategory.TabIndex = 66;
            this.btnNewCategory.Text = "دسته‌بندی جدید";
            this.btnNewCategory.UseVisualStyleBackColor = false;
            this.btnNewCategory.Click += new System.EventHandler(this.btnNewCategory_Click);
            // 
            // SubmitSellerFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1099, 767);
            this.Controls.Add(this.txtBanks);
            this.Controls.Add(this.txtShabaNumb);
            this.Controls.Add(this.txtCardNumb);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdbcreditor);
            this.Controls.Add(this.rdbdebtor);
            this.Controls.Add(this.txtSearchSeller);
            this.Controls.Add(this.lstSeller);
            this.Controls.Add(this.btnUpdateSeller);
            this.Controls.Add(this.btnNewCategory);
            this.Controls.Add(this.btnDefineBankAccouant);
            this.Controls.Add(this.btnSubmitNewSeller);
            this.Controls.Add(this.btnDeletSeller);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txtISellerCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSellerName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SubmitSellerFRM";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "اطلاعات فروشندگان";
            this.Load += new System.EventHandler(this.SubmitSellerFRM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchSeller;
        private System.Windows.Forms.ListView lstSeller;
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
        private System.Windows.Forms.Button btnUpdateSeller;
        private System.Windows.Forms.Button btnSubmitNewSeller;
        private System.Windows.Forms.Button btnDeletSeller;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtISellerCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSellerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.RadioButton rdbdebtor;
        private System.Windows.Forms.RadioButton rdbcreditor;
        private System.Windows.Forms.Button btnDefineBankAccouant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCardNumb;
        private System.Windows.Forms.Label txtBank;
        private System.Windows.Forms.TextBox txtBanks;
        private System.Windows.Forms.TextBox txtShabaNumb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnNewCategory;
    }
}