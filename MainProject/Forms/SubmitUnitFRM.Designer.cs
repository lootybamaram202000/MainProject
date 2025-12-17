namespace MainProject.Forms
{
    partial class SubmitUnitFRM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubmitUnitFRM));
            this.rdbProductUnit = new System.Windows.Forms.RadioButton();
            this.rdbPurchaseUnit = new System.Windows.Forms.RadioButton();
            this.btnUpdateUnit = new System.Windows.Forms.Button();
            this.btnSubmitNewUnit = new System.Windows.Forms.Button();
            this.btnDeletUnit = new System.Windows.Forms.Button();
            this.txtMeasurmentUnitTitle = new System.Windows.Forms.TextBox();
            this.txtMeasurmentUnitQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPUnitQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPUnitTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lstUnits = new System.Windows.Forms.ListView();
            this.pictureBoxInfo = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbProductUnit
            // 
            this.rdbProductUnit.AutoSize = true;
            this.rdbProductUnit.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rdbProductUnit.Location = new System.Drawing.Point(468, 7);
            this.rdbProductUnit.Margin = new System.Windows.Forms.Padding(4);
            this.rdbProductUnit.Name = "rdbProductUnit";
            this.rdbProductUnit.Size = new System.Drawing.Size(109, 36);
            this.rdbProductUnit.TabIndex = 49;
            this.rdbProductUnit.TabStop = true;
            this.rdbProductUnit.Text = "واحد تولید";
            this.rdbProductUnit.UseVisualStyleBackColor = true;
            // 
            // rdbPurchaseUnit
            // 
            this.rdbPurchaseUnit.AutoSize = true;
            this.rdbPurchaseUnit.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rdbPurchaseUnit.Location = new System.Drawing.Point(599, 7);
            this.rdbPurchaseUnit.Margin = new System.Windows.Forms.Padding(4);
            this.rdbPurchaseUnit.Name = "rdbPurchaseUnit";
            this.rdbPurchaseUnit.Size = new System.Drawing.Size(109, 36);
            this.rdbPurchaseUnit.TabIndex = 48;
            this.rdbPurchaseUnit.TabStop = true;
            this.rdbPurchaseUnit.Text = "واحد خرید";
            this.rdbPurchaseUnit.UseVisualStyleBackColor = true;
            // 
            // btnUpdateUnit
            // 
            this.btnUpdateUnit.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdateUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdateUnit.Location = new System.Drawing.Point(176, 10);
            this.btnUpdateUnit.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateUnit.Name = "btnUpdateUnit";
            this.btnUpdateUnit.Size = new System.Drawing.Size(85, 42);
            this.btnUpdateUnit.TabIndex = 44;
            this.btnUpdateUnit.Text = "ویرایش";
            this.btnUpdateUnit.UseVisualStyleBackColor = true;
            this.btnUpdateUnit.Click += new System.EventHandler(this.btnUpdateUnit_Click);
            // 
            // btnSubmitNewUnit
            // 
            this.btnSubmitNewUnit.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewUnit.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitNewUnit.Location = new System.Drawing.Point(269, 10);
            this.btnSubmitNewUnit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitNewUnit.Name = "btnSubmitNewUnit";
            this.btnSubmitNewUnit.Size = new System.Drawing.Size(85, 42);
            this.btnSubmitNewUnit.TabIndex = 45;
            this.btnSubmitNewUnit.Text = "ثبت";
            this.btnSubmitNewUnit.UseVisualStyleBackColor = true;
            this.btnSubmitNewUnit.Click += new System.EventHandler(this.btnSubmitNewUnit_Click);
            // 
            // btnDeletUnit
            // 
            this.btnDeletUnit.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeletUnit.ForeColor = System.Drawing.Color.Red;
            this.btnDeletUnit.Location = new System.Drawing.Point(7, 10);
            this.btnDeletUnit.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletUnit.Name = "btnDeletUnit";
            this.btnDeletUnit.Size = new System.Drawing.Size(85, 42);
            this.btnDeletUnit.TabIndex = 47;
            this.btnDeletUnit.Text = "حذف";
            this.btnDeletUnit.UseVisualStyleBackColor = true;
            this.btnDeletUnit.Click += new System.EventHandler(this.btnDeletUnit_Click);
            // 
            // txtMeasurmentUnitTitle
            // 
            this.txtMeasurmentUnitTitle.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeasurmentUnitTitle.Location = new System.Drawing.Point(13, 85);
            this.txtMeasurmentUnitTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtMeasurmentUnitTitle.Name = "txtMeasurmentUnitTitle";
            this.txtMeasurmentUnitTitle.Size = new System.Drawing.Size(282, 29);
            this.txtMeasurmentUnitTitle.TabIndex = 42;
            // 
            // txtMeasurmentUnitQuantity
            // 
            this.txtMeasurmentUnitQuantity.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeasurmentUnitQuantity.Location = new System.Drawing.Point(621, 85);
            this.txtMeasurmentUnitQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtMeasurmentUnitQuantity.Name = "txtMeasurmentUnitQuantity";
            this.txtMeasurmentUnitQuantity.Size = new System.Drawing.Size(82, 28);
            this.txtMeasurmentUnitQuantity.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(299, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 30);
            this.label3.TabIndex = 41;
            this.label3.Text = "عنوان واحد مورد اندازه‌گیری";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(710, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 32);
            this.label4.TabIndex = 40;
            this.label4.Text = "   :نوع واحد کاربردی ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(706, 81);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 30);
            this.label7.TabIndex = 39;
            this.label7.Text = "مقدار واحد اندازه‌گیری";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtPUnitQuantity
            // 
            this.txtPUnitQuantity.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPUnitQuantity.Location = new System.Drawing.Point(621, 47);
            this.txtPUnitQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtPUnitQuantity.Name = "txtPUnitQuantity";
            this.txtPUnitQuantity.Size = new System.Drawing.Size(82, 28);
            this.txtPUnitQuantity.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(726, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 30);
            this.label2.TabIndex = 36;
            this.label2.Text = "مقدار واحد کاربردی";
            // 
            // txtPUnitTitle
            // 
            this.txtPUnitTitle.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPUnitTitle.Location = new System.Drawing.Point(13, 47);
            this.txtPUnitTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtPUnitTitle.Name = "txtPUnitTitle";
            this.txtPUnitTitle.Size = new System.Drawing.Size(282, 29);
            this.txtPUnitTitle.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(349, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 30);
            this.label1.TabIndex = 35;
            this.label1.Text = "عنوان  واحد کاربردی";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSearch.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSearch.Location = new System.Drawing.Point(538, 137);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(262, 32);
            this.txtSearch.TabIndex = 33;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(804, 139);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 30);
            this.label10.TabIndex = 32;
            this.label10.Text = "جستجو";
            // 
            // lstUnits
            // 
            this.lstUnits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstUnits.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstUnits.FullRowSelect = true;
            this.lstUnits.GridLines = true;
            this.lstUnits.HideSelection = false;
            this.lstUnits.Location = new System.Drawing.Point(13, 181);
            this.lstUnits.Margin = new System.Windows.Forms.Padding(4);
            this.lstUnits.MultiSelect = false;
            this.lstUnits.Name = "lstUnits";
            this.lstUnits.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lstUnits.RightToLeftLayout = true;
            this.lstUnits.Size = new System.Drawing.Size(855, 383);
            this.lstUnits.TabIndex = 34;
            this.lstUnits.UseCompatibleStateImageBehavior = false;
            this.lstUnits.View = System.Windows.Forms.View.Details;
            this.lstUnits.SelectedIndexChanged += new System.EventHandler(this.lstUnits_SelectedIndexChanged);
            // 
            // pictureBoxInfo
            // 
            this.pictureBoxInfo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxInfo.ErrorImage")));
            this.pictureBoxInfo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInfo.Image")));
            this.pictureBoxInfo.Location = new System.Drawing.Point(13, 7);
            this.pictureBoxInfo.Name = "pictureBoxInfo";
            this.pictureBoxInfo.Size = new System.Drawing.Size(39, 33);
            this.pictureBoxInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxInfo.TabIndex = 50;
            this.pictureBoxInfo.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSubmitNewUnit);
            this.groupBox1.Controls.Add(this.btnUpdateUnit);
            this.groupBox1.Controls.Add(this.btnDeletUnit);
            this.groupBox1.Location = new System.Drawing.Point(13, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 58);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            // 
            // SubmitUnitFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(881, 569);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBoxInfo);
            this.Controls.Add(this.rdbProductUnit);
            this.Controls.Add(this.rdbPurchaseUnit);
            this.Controls.Add(this.txtMeasurmentUnitTitle);
            this.Controls.Add(this.txtMeasurmentUnitQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPUnitQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPUnitTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstUnits);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label10);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SubmitUnitFRM";
            this.Text = "تعریف و ثبت واحد‌های اندازه‌گیری";
            this.Load += new System.EventHandler(this.SubmitUnitFRM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbProductUnit;
        private System.Windows.Forms.RadioButton rdbPurchaseUnit;
        private System.Windows.Forms.Button btnUpdateUnit;
        private System.Windows.Forms.Button btnSubmitNewUnit;
        private System.Windows.Forms.Button btnDeletUnit;
        private System.Windows.Forms.TextBox txtMeasurmentUnitTitle;
        private System.Windows.Forms.TextBox txtMeasurmentUnitQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPUnitQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPUnitTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView lstUnits;
        private System.Windows.Forms.PictureBox pictureBoxInfo;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}