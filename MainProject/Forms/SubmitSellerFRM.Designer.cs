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

            this.txtSearchSeller = new System.Windows.Forms.TextBox();
            this.lstSeller = new System.Windows.Forms.ListView();
            this.colSellerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSellerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompanyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBalance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUpdateSeller = new System.Windows.Forms.Button();
            this.btnSubmitNewSeller = new System.Windows.Forms.Button();
            this.btnDeletSeller = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtISellerCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSellerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCategory1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.rdbdebtor = new System.Windows.Forms.RadioButton();
            this.rdbcreditor = new System.Windows.Forms.RadioButton();
            this.btnDefineBankAccouant = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone3 = new System.Windows.Forms.TextBox();
            this.cmbCategory2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbSellerType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbCategory3 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.gbxSellerCategories = new System.Windows.Forms.GroupBox();
            this.gbxSellerCategories.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearchSeller
            // 
            this.txtSearchSeller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSearchSeller.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSearchSeller.Location = new System.Drawing.Point(546, 426);
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
            this.colSellerID,
            this.colSellerName,
            this.colCompanyName,
            this.colPhone,
            this.colCategory,
            this.colBalance});
            this.lstSeller.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstSeller.FullRowSelect = true;
            this.lstSeller.GridLines = true;
            this.lstSeller.HideSelection = false;

            this.lstSeller.Location = new System.Drawing.Point(13, 467);
            this.lstSeller.Margin = new System.Windows.Forms.Padding(4);
            this.lstSeller.MultiSelect = false;
            this.lstSeller.Name = "lstSeller";
            this.lstSeller.Size = new System.Drawing.Size(1073, 471);
            this.lstSeller.TabIndex = 64;
            this.lstSeller.UseCompatibleStateImageBehavior = false;
            this.lstSeller.SelectedIndexChanged += new System.EventHandler(this.lstSeller_SelectedIndexChanged);
            // 
            // colSellerID
            // 
            this.colSellerID.Text = "کد فروشنده";
            this.colSellerID.Width = 110;
            // 
            // colSellerName
            // 
            this.colSellerName.Text = "نام فروشنده";
            this.colSellerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSellerName.Width = 160;
            // 
            // colCompanyName
            // 
            this.colCompanyName.Text = "نام شرکت";
            this.colCompanyName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCompanyName.Width = 160;
            // 
            // colPhone
            // 
            this.colPhone.Text = "شماره تماس";
            this.colPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colPhone.Width = 120;
            // 
            // colCategory
            // 
            this.colCategory.Text = "دسته‌بندی";
            this.colCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCategory.Width = 120;
            // 
            // colBalance
            // 
            this.colBalance.Text = "مانده";
            this.colBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colBalance.Width = 110;
            // 
            // btnUpdateSeller
            // 
            this.btnUpdateSeller.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdateSeller.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdateSeller.Location = new System.Drawing.Point(124, 416);
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
            this.btnSubmitNewSeller.Location = new System.Drawing.Point(438, 418);
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
            this.btnDeletSeller.Location = new System.Drawing.Point(17, 416);
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
            this.label7.Location = new System.Drawing.Point(884, 425);
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
            // txtPhone1
            // 
            this.txtPhone1.BackColor = System.Drawing.Color.Thistle;
            this.txtPhone1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhone1.Location = new System.Drawing.Point(749, 151);
            this.txtPhone1.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPhone1.Size = new System.Drawing.Size(224, 32);
            this.txtPhone1.TabIndex = 59;
            this.txtPhone1.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label11.Location = new System.Drawing.Point(975, 153);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(116, 29);
            this.label11.TabIndex = 54;
            this.label11.Text = "شماره‌ی تماس ۱";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.Thistle;
            this.txtAddress.Font = new System.Drawing.Font("B Nazanin", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtAddress.Location = new System.Drawing.Point(14, 107);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.Size = new System.Drawing.Size(981, 33);
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
            // cmbCategory1
            // 
            this.cmbCategory1.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbCategory1.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbCategory1.FormattingEnabled = true;
            this.cmbCategory1.Location = new System.Drawing.Point(607, 48);
            this.cmbCategory1.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory1.Name = "cmbCategory1";
            this.cmbCategory1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCategory1.Size = new System.Drawing.Size(188, 34);
            this.cmbCategory1.TabIndex = 61;
            this.cmbCategory1.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(576, 354);
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
            this.txtBalance.Location = new System.Drawing.Point(370, 353);
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
            this.rdbdebtor.Location = new System.Drawing.Point(235, 352);
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
            this.rdbcreditor.Location = new System.Drawing.Point(146, 352);
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
            this.btnDefineBankAccouant.Location = new System.Drawing.Point(21, 351);
            this.btnDefineBankAccouant.Margin = new System.Windows.Forms.Padding(4);
            this.btnDefineBankAccouant.Name = "btnDefineBankAccouant";
            this.btnDefineBankAccouant.Size = new System.Drawing.Size(125, 35);
            this.btnDefineBankAccouant.TabIndex = 66;
            this.btnDefineBankAccouant.Text = "تعریف حساب بانکی";
            this.btnDefineBankAccouant.UseVisualStyleBackColor = true;
            this.btnDefineBankAccouant.Click += new System.EventHandler(this.btnDefineBankAccouant_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label13.Location = new System.Drawing.Point(320, 354);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(47, 29);
            this.label13.TabIndex = 71;
            this.label13.Text = "تومان";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(607, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(116, 29);
            this.label3.TabIndex = 54;
            this.label3.Text = "شماره‌ی تماس ۲";
            // 
            // txtPhone2
            // 
            this.txtPhone2.BackColor = System.Drawing.Color.Thistle;
            this.txtPhone2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhone2.Location = new System.Drawing.Point(381, 151);
            this.txtPhone2.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPhone2.Size = new System.Drawing.Size(224, 32);
            this.txtPhone2.TabIndex = 59;
            this.txtPhone2.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(240, 151);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(116, 29);
            this.label4.TabIndex = 54;
            this.label4.Text = "شماره‌ی تماس ۳";
            // 
            // txtPhone3
            // 
            this.txtPhone3.BackColor = System.Drawing.Color.Thistle;
            this.txtPhone3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhone3.Location = new System.Drawing.Point(14, 149);
            this.txtPhone3.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone3.Name = "txtPhone3";
            this.txtPhone3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPhone3.Size = new System.Drawing.Size(224, 32);
            this.txtPhone3.TabIndex = 59;
            this.txtPhone3.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // cmbCategory2
            // 
            this.cmbCategory2.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbCategory2.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbCategory2.FormattingEnabled = true;
            this.cmbCategory2.Location = new System.Drawing.Point(317, 48);
            this.cmbCategory2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory2.Name = "cmbCategory2";
            this.cmbCategory2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCategory2.Size = new System.Drawing.Size(188, 34);
            this.cmbCategory2.TabIndex = 61;
            this.cmbCategory2.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(28, 90);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 66;
            this.button1.Text = "دسته‌بندی جدید";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnNewCategory_Click);
            // 
            // cmbSellerType
            // 
            this.cmbSellerType.BackColor = System.Drawing.Color.Lavender;
            this.cmbSellerType.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbSellerType.FormattingEnabled = true;
            this.cmbSellerType.Location = new System.Drawing.Point(815, 349);
            this.cmbSellerType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSellerType.Name = "cmbSellerType";
            this.cmbSellerType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbSellerType.Size = new System.Drawing.Size(188, 34);
            this.cmbSellerType.TabIndex = 73;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label14.Location = new System.Drawing.Point(1003, 351);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(88, 29);
            this.label14.TabIndex = 72;
            this.label14.Text = "نوع فروشنده";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.Location = new System.Drawing.Point(798, 51);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(90, 29);
            this.label15.TabIndex = 53;
            this.label15.Text = "دسته‌بندی ۱";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.Location = new System.Drawing.Point(508, 50);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(90, 29);
            this.label12.TabIndex = 74;
            this.label12.Text = "دسته‌بندی ۲";
            // 
            // cmbCategory3
            // 
            this.cmbCategory3.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbCategory3.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbCategory3.FormattingEnabled = true;
            this.cmbCategory3.Location = new System.Drawing.Point(28, 48);
            this.cmbCategory3.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory3.Name = "cmbCategory3";
            this.cmbCategory3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCategory3.Size = new System.Drawing.Size(188, 34);
            this.cmbCategory3.TabIndex = 61;
            this.cmbCategory3.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label16.Location = new System.Drawing.Point(219, 50);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(90, 29);
            this.label16.TabIndex = 74;
            this.label16.Text = "دسته‌بندی ۳";
            // 
            // gbxSellerCategories
            // 
            this.gbxSellerCategories.BackColor = System.Drawing.Color.Lavender;
            this.gbxSellerCategories.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gbxSellerCategories.Controls.Add(this.label16);
            this.gbxSellerCategories.Controls.Add(this.label12);
            this.gbxSellerCategories.Controls.Add(this.button1);
            this.gbxSellerCategories.Controls.Add(this.cmbCategory3);
            this.gbxSellerCategories.Controls.Add(this.cmbCategory2);
            this.gbxSellerCategories.Controls.Add(this.cmbCategory1);
            this.gbxSellerCategories.Controls.Add(this.label15);
            this.gbxSellerCategories.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gbxSellerCategories.Location = new System.Drawing.Point(12, 201);
            this.gbxSellerCategories.Name = "gbxSellerCategories";
            this.gbxSellerCategories.Size = new System.Drawing.Size(1079, 138);
            this.gbxSellerCategories.TabIndex = 75;
            this.gbxSellerCategories.TabStop = false;
            this.gbxSellerCategories.Text = "دسته‌بندی های فروش";
            // 
            // SubmitSellerFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1099, 953);
            this.Controls.Add(this.cmbSellerType);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rdbcreditor);
            this.Controls.Add(this.rdbdebtor);
            this.Controls.Add(this.txtSearchSeller);
            this.Controls.Add(this.lstSeller);
            this.Controls.Add(this.btnUpdateSeller);
            this.Controls.Add(this.btnDefineBankAccouant);
            this.Controls.Add(this.btnSubmitNewSeller);
            this.Controls.Add(this.btnDeletSeller);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtISellerCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPhone3);
            this.Controls.Add(this.txtPhone2);
            this.Controls.Add(this.txtPhone1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSellerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbxSellerCategories);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SubmitSellerFRM";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "اطلاعات فروشندگان";
            this.Load += new System.EventHandler(this.SubmitSellerFRM_Load);
            this.gbxSellerCategories.ResumeLayout(false);
            this.gbxSellerCategories.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchSeller;
        private System.Windows.Forms.ListView lstSeller;
        private System.Windows.Forms.ColumnHeader colSellerID;
        private System.Windows.Forms.ColumnHeader colSellerName;
        private System.Windows.Forms.ColumnHeader colCompanyName;
        private System.Windows.Forms.ColumnHeader colPhone;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colBalance;
        private System.Windows.Forms.Button btnUpdateSeller;
        private System.Windows.Forms.Button btnSubmitNewSeller;
        private System.Windows.Forms.Button btnDeletSeller;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtISellerCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSellerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCategory1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.RadioButton rdbdebtor;
        private System.Windows.Forms.RadioButton rdbcreditor;
        private System.Windows.Forms.Button btnDefineBankAccouant;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone3;
        private System.Windows.Forms.ComboBox cmbCategory2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbSellerType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbCategory3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox gbxSellerCategories;
    }
}