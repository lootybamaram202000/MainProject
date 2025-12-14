namespace MainProject.Forms
{
    partial class DefineNewPersonalFRM
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
            this.label14 = new System.Windows.Forms.Label();
            this.txtPerssonalCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstPersonals = new System.Windows.Forms.ListView();
            this.cmbJobs = new System.Windows.Forms.ComboBox();
            this.cmbGrd = new System.Windows.Forms.ComboBox();
            this.btnSelectDate = new System.Windows.Forms.Button();
            this.btnFormPatch = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnIDCardNumPatch = new System.Windows.Forms.Button();
            this.btnCertificateNumPatch = new System.Windows.Forms.Button();
            this.btnPImagePatch = new System.Windows.Forms.Button();
            this.txtIDCardNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCertificateNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtETitle = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEPhone = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBDDate = new System.Windows.Forms.Label();
            this.txtSearchPersonal = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSubmitPersonal = new System.Windows.Forms.Button();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label14.Location = new System.Drawing.Point(894, 423);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(118, 27);
            this.label14.TabIndex = 61;
            this.label14.Text = "وضعیت استخدامی";
            // 
            // txtPerssonalCode
            // 
            this.txtPerssonalCode.BackColor = System.Drawing.Color.PowderBlue;
            this.txtPerssonalCode.Enabled = false;
            this.txtPerssonalCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPerssonalCode.Location = new System.Drawing.Point(701, 6);
            this.txtPerssonalCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtPerssonalCode.Name = "txtPerssonalCode";
            this.txtPerssonalCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPerssonalCode.Size = new System.Drawing.Size(227, 32);
            this.txtPerssonalCode.TabIndex = 60;
            this.txtPerssonalCode.TextChanged += new System.EventHandler(this.txtPerssonalCode_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(939, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(76, 27);
            this.label4.TabIndex = 59;
            this.label4.Text = "کد پرسنلی";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lstPersonals
            // 
            this.lstPersonals.BackColor = System.Drawing.SystemColors.Info;
            this.lstPersonals.HideSelection = false;
            this.lstPersonals.Location = new System.Drawing.Point(13, 56);
            this.lstPersonals.Margin = new System.Windows.Forms.Padding(4);
            this.lstPersonals.Name = "lstPersonals";
            this.lstPersonals.Size = new System.Drawing.Size(528, 401);
            this.lstPersonals.TabIndex = 44;
            this.lstPersonals.UseCompatibleStateImageBehavior = false;
            // 
            // cmbJobs
            // 
            this.cmbJobs.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cmbJobs.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbJobs.FormattingEnabled = true;
            this.cmbJobs.Location = new System.Drawing.Point(702, 47);
            this.cmbJobs.Margin = new System.Windows.Forms.Padding(4);
            this.cmbJobs.Name = "cmbJobs";
            this.cmbJobs.Size = new System.Drawing.Size(226, 34);
            this.cmbJobs.TabIndex = 56;
            // 
            // cmbGrd
            // 
            this.cmbGrd.BackColor = System.Drawing.Color.Thistle;
            this.cmbGrd.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbGrd.FormattingEnabled = true;
            this.cmbGrd.Location = new System.Drawing.Point(701, 377);
            this.cmbGrd.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGrd.Name = "cmbGrd";
            this.cmbGrd.Size = new System.Drawing.Size(199, 34);
            this.cmbGrd.TabIndex = 55;
            // 
            // btnSelectDate
            // 
            this.btnSelectDate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSelectDate.Font = new System.Drawing.Font("B Nazanin", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnSelectDate.Location = new System.Drawing.Point(701, 253);
            this.btnSelectDate.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectDate.Name = "btnSelectDate";
            this.btnSelectDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSelectDate.Size = new System.Drawing.Size(117, 34);
            this.btnSelectDate.TabIndex = 46;
            this.btnSelectDate.Text = "انتخاب تاریخ تولد";
            this.btnSelectDate.UseVisualStyleBackColor = false;
            // 
            // btnFormPatch
            // 
            this.btnFormPatch.BackColor = System.Drawing.SystemColors.Control;
            this.btnFormPatch.Font = new System.Drawing.Font("B Nazanin", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnFormPatch.Location = new System.Drawing.Point(550, 378);
            this.btnFormPatch.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormPatch.Name = "btnFormPatch";
            this.btnFormPatch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnFormPatch.Size = new System.Drawing.Size(143, 79);
            this.btnFormPatch.TabIndex = 57;
            this.btnFormPatch.Text = "انتخاب\r\n عکس فرم استخدام";
            this.btnFormPatch.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSubmit.Font = new System.Drawing.Font("B Nazanin", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnSubmit.Location = new System.Drawing.Point(-370, 349);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSubmit.Size = new System.Drawing.Size(176, 58);
            this.btnSubmit.TabIndex = 58;
            this.btnSubmit.Text = "ثبت اطلاعات";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // btnIDCardNumPatch
            // 
            this.btnIDCardNumPatch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIDCardNumPatch.Font = new System.Drawing.Font("B Nazanin", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnIDCardNumPatch.Location = new System.Drawing.Point(550, 212);
            this.btnIDCardNumPatch.Margin = new System.Windows.Forms.Padding(4);
            this.btnIDCardNumPatch.Name = "btnIDCardNumPatch";
            this.btnIDCardNumPatch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnIDCardNumPatch.Size = new System.Drawing.Size(145, 75);
            this.btnIDCardNumPatch.TabIndex = 50;
            this.btnIDCardNumPatch.Text = "عکس کارت ملی";
            this.btnIDCardNumPatch.UseVisualStyleBackColor = false;
            // 
            // btnCertificateNumPatch
            // 
            this.btnCertificateNumPatch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCertificateNumPatch.Font = new System.Drawing.Font("B Nazanin", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnCertificateNumPatch.Location = new System.Drawing.Point(549, 295);
            this.btnCertificateNumPatch.Margin = new System.Windows.Forms.Padding(4);
            this.btnCertificateNumPatch.Name = "btnCertificateNumPatch";
            this.btnCertificateNumPatch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCertificateNumPatch.Size = new System.Drawing.Size(145, 76);
            this.btnCertificateNumPatch.TabIndex = 48;
            this.btnCertificateNumPatch.Text = " عکس شناسنامه";
            this.btnCertificateNumPatch.UseVisualStyleBackColor = false;
            // 
            // btnPImagePatch
            // 
            this.btnPImagePatch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPImagePatch.Font = new System.Drawing.Font("B Nazanin", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnPImagePatch.Location = new System.Drawing.Point(549, 7);
            this.btnPImagePatch.Margin = new System.Windows.Forms.Padding(4);
            this.btnPImagePatch.Name = "btnPImagePatch";
            this.btnPImagePatch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPImagePatch.Size = new System.Drawing.Size(145, 193);
            this.btnPImagePatch.TabIndex = 42;
            this.btnPImagePatch.Text = "انتخاب عکس پرسنلی";
            this.btnPImagePatch.UseVisualStyleBackColor = false;
            this.btnPImagePatch.Click += new System.EventHandler(this.btnPImagePatch_Click);
            // 
            // txtIDCardNum
            // 
            this.txtIDCardNum.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtIDCardNum.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtIDCardNum.Location = new System.Drawing.Point(702, 295);
            this.txtIDCardNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDCardNum.Name = "txtIDCardNum";
            this.txtIDCardNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIDCardNum.Size = new System.Drawing.Size(242, 32);
            this.txtIDCardNum.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(958, 300);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(54, 27);
            this.label6.TabIndex = 33;
            this.label6.Text = "کد ملی";
            // 
            // txtCertificateNum
            // 
            this.txtCertificateNum.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCertificateNum.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCertificateNum.Location = new System.Drawing.Point(701, 336);
            this.txtCertificateNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtCertificateNum.Name = "txtCertificateNum";
            this.txtCertificateNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCertificateNum.Size = new System.Drawing.Size(199, 32);
            this.txtCertificateNum.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(905, 338);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(107, 27);
            this.label5.TabIndex = 32;
            this.label5.Text = "شماره شناسنامه";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCity.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCity.Location = new System.Drawing.Point(701, 212);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCity.Name = "txtCity";
            this.txtCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCity.Size = new System.Drawing.Size(243, 33);
            this.txtCity.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(947, 216);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(67, 27);
            this.label3.TabIndex = 23;
            this.label3.Text = "محل تولد";
            // 
            // txtLName
            // 
            this.txtLName.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtLName.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtLName.Location = new System.Drawing.Point(701, 130);
            this.txtLName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLName.Name = "txtLName";
            this.txtLName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLName.Size = new System.Drawing.Size(227, 33);
            this.txtLName.TabIndex = 41;
            this.txtLName.TextChanged += new System.EventHandler(this.txtLName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(931, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(85, 27);
            this.label2.TabIndex = 31;
            this.label2.Text = "نام خانوادگی";
            // 
            // txtETitle
            // 
            this.txtETitle.BackColor = System.Drawing.Color.Thistle;
            this.txtETitle.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtETitle.Location = new System.Drawing.Point(393, 465);
            this.txtETitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtETitle.Name = "txtETitle";
            this.txtETitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtETitle.Size = new System.Drawing.Size(148, 33);
            this.txtETitle.TabIndex = 54;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.Location = new System.Drawing.Point(555, 467);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(139, 27);
            this.label13.TabIndex = 30;
            this.label13.Text = "عنوان تماس اضطراری";
            // 
            // txtEPhone
            // 
            this.txtEPhone.BackColor = System.Drawing.Color.Thistle;
            this.txtEPhone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtEPhone.Location = new System.Drawing.Point(13, 465);
            this.txtEPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtEPhone.Name = "txtEPhone";
            this.txtEPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEPhone.Size = new System.Drawing.Size(214, 32);
            this.txtEPhone.TabIndex = 53;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.Location = new System.Drawing.Point(235, 467);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(150, 27);
            this.label12.TabIndex = 29;
            this.label12.Text = "شماره‌ی تماس اضطراری";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.Thistle;
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhone.Location = new System.Drawing.Point(702, 463);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPhone.Size = new System.Drawing.Size(209, 32);
            this.txtPhone.TabIndex = 52;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label11.Location = new System.Drawing.Point(917, 467);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(95, 27);
            this.label11.TabIndex = 28;
            this.label11.Text = "شماره‌ی تماس";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.Thistle;
            this.txtAddress.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAddress.Location = new System.Drawing.Point(13, 504);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.Size = new System.Drawing.Size(865, 33);
            this.txtAddress.TabIndex = 51;
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(886, 505);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(126, 27);
            this.label10.TabIndex = 27;
            this.label10.Text = "آدرس محل سکونت";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(931, 49);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(84, 27);
            this.label9.TabIndex = 26;
            this.label9.Text = "عنوان شغلی";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(908, 378);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(104, 27);
            this.label8.TabIndex = 25;
            this.label8.Text = "میزان تحصیلات";
            // 
            // txtFatherName
            // 
            this.txtFatherName.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFatherName.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFatherName.Location = new System.Drawing.Point(701, 171);
            this.txtFatherName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFatherName.Size = new System.Drawing.Size(258, 33);
            this.txtFatherName.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(963, 175);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(51, 27);
            this.label7.TabIndex = 24;
            this.label7.Text = "نام پدر";
            // 
            // txtFName
            // 
            this.txtFName.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFName.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFName.Location = new System.Drawing.Point(701, 89);
            this.txtFName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFName.Name = "txtFName";
            this.txtFName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFName.Size = new System.Drawing.Size(258, 33);
            this.txtFName.TabIndex = 40;
            this.txtFName.TextChanged += new System.EventHandler(this.txtFName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(984, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(28, 27);
            this.label1.TabIndex = 34;
            this.label1.Text = "نام";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblBDDate
            // 
            this.lblBDDate.AutoSize = true;
            this.lblBDDate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBDDate.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBDDate.Location = new System.Drawing.Point(823, 260);
            this.lblBDDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBDDate.Name = "lblBDDate";
            this.lblBDDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBDDate.Size = new System.Drawing.Size(118, 21);
            this.lblBDDate.TabIndex = 23;
            this.lblBDDate.Text = "____/__/__";
            // 
            // txtSearchPersonal
            // 
            this.txtSearchPersonal.BackColor = System.Drawing.SystemColors.Info;
            this.txtSearchPersonal.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSearchPersonal.Location = new System.Drawing.Point(13, 16);
            this.txtSearchPersonal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchPersonal.Name = "txtSearchPersonal";
            this.txtSearchPersonal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearchPersonal.Size = new System.Drawing.Size(456, 33);
            this.txtSearchPersonal.TabIndex = 71;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label16.Location = new System.Drawing.Point(484, 18);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 27);
            this.label16.TabIndex = 70;
            this.label16.Text = "جستجو";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label17.Location = new System.Drawing.Point(944, 257);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(70, 27);
            this.label17.TabIndex = 23;
            this.label17.Text = "تاریخ تولد";
            // 
            // btnSubmitPersonal
            // 
            this.btnSubmitPersonal.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitPersonal.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitPersonal.Location = new System.Drawing.Point(13, 545);
            this.btnSubmitPersonal.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitPersonal.Name = "btnSubmitPersonal";
            this.btnSubmitPersonal.Size = new System.Drawing.Size(214, 43);
            this.btnSubmitPersonal.TabIndex = 145;
            this.btnSubmitPersonal.Text = "ثبت و به‌روزرسانی اطلاعات";
            this.btnSubmitPersonal.UseVisualStyleBackColor = true;
            this.btnSubmitPersonal.Click += new System.EventHandler(this.btnSubmitPersonal_Click);
            // 
            // cmbState
            // 
            this.cmbState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbState.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(702, 421);
            this.cmbState.Margin = new System.Windows.Forms.Padding(4);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(176, 34);
            this.cmbState.TabIndex = 62;
            // 
            // DefineNewPersonalFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1018, 591);
            this.Controls.Add(this.btnSubmitPersonal);
            this.Controls.Add(this.txtSearchPersonal);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPerssonalCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstPersonals);
            this.Controls.Add(this.cmbJobs);
            this.Controls.Add(this.cmbGrd);
            this.Controls.Add(this.btnSelectDate);
            this.Controls.Add(this.btnFormPatch);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnIDCardNumPatch);
            this.Controls.Add(this.btnCertificateNumPatch);
            this.Controls.Add(this.btnPImagePatch);
            this.Controls.Add(this.txtIDCardNum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCertificateNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblBDDate);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtETitle);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtEPhone);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFatherName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DefineNewPersonalFRM";
            this.Text = "تعریف مشخصات پرسنل";
            this.Load += new System.EventHandler(this.DefineNewPersonalFRM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPerssonalCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstPersonals;
        private System.Windows.Forms.ComboBox cmbJobs;
        private System.Windows.Forms.ComboBox cmbGrd;
        private System.Windows.Forms.Button btnSelectDate;
        private System.Windows.Forms.Button btnFormPatch;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnIDCardNumPatch;
        private System.Windows.Forms.Button btnCertificateNumPatch;
        private System.Windows.Forms.Button btnPImagePatch;
        private System.Windows.Forms.TextBox txtIDCardNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCertificateNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtETitle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEPhone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBDDate;
        private System.Windows.Forms.TextBox txtSearchPersonal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSubmitPersonal;
        private System.Windows.Forms.ComboBox cmbState;
    }
}