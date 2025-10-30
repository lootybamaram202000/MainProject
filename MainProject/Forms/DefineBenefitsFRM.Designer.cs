namespace MainProject.Forms
{
    partial class DefineBenefitsFRM
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
            this.lstBenefits = new System.Windows.Forms.ListView();
            this.cmbFY = new System.Windows.Forms.ComboBox();
            this.btnDeletBenefits = new System.Windows.Forms.Button();
            this.btnSubmitBenefits = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtJBCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSeverancePay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmployeeAllowance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHousingAllowance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFamilyAllowance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChildAllowance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInsurance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstBenefits
            // 
            this.lstBenefits.BackColor = System.Drawing.SystemColors.Info;
            this.lstBenefits.HideSelection = false;
            this.lstBenefits.Location = new System.Drawing.Point(12, 141);
            this.lstBenefits.Name = "lstBenefits";
            this.lstBenefits.Size = new System.Drawing.Size(851, 97);
            this.lstBenefits.TabIndex = 78;
            this.lstBenefits.UseCompatibleStateImageBehavior = false;
            // 
            // cmbFY
            // 
            this.cmbFY.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbFY.FormattingEnabled = true;
            this.cmbFY.Location = new System.Drawing.Point(457, 23);
            this.cmbFY.Name = "cmbFY";
            this.cmbFY.Size = new System.Drawing.Size(141, 32);
            this.cmbFY.TabIndex = 77;
            // 
            // btnDeletBenefits
            // 
            this.btnDeletBenefits.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnDeletBenefits.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeletBenefits.ForeColor = System.Drawing.Color.Crimson;
            this.btnDeletBenefits.Location = new System.Drawing.Point(12, 97);
            this.btnDeletBenefits.Name = "btnDeletBenefits";
            this.btnDeletBenefits.Size = new System.Drawing.Size(100, 38);
            this.btnDeletBenefits.TabIndex = 76;
            this.btnDeletBenefits.Text = "حذف";
            this.btnDeletBenefits.UseVisualStyleBackColor = false;
            // 
            // btnSubmitBenefits
            // 
            this.btnSubmitBenefits.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnSubmitBenefits.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitBenefits.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitBenefits.Location = new System.Drawing.Point(763, 99);
            this.btnSubmitBenefits.Name = "btnSubmitBenefits";
            this.btnSubmitBenefits.Size = new System.Drawing.Size(100, 38);
            this.btnSubmitBenefits.TabIndex = 75;
            this.btnSubmitBenefits.Text = "ثبت";
            this.btnSubmitBenefits.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(604, 30);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(57, 24);
            this.label8.TabIndex = 71;
            this.label8.Text = "سال مالی";
            // 
            // txtJBCode
            // 
            this.txtJBCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtJBCode.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtJBCode.Location = new System.Drawing.Point(663, 25);
            this.txtJBCode.Name = "txtJBCode";
            this.txtJBCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtJBCode.Size = new System.Drawing.Size(162, 31);
            this.txtJBCode.TabIndex = 74;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(825, 30);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(42, 24);
            this.label7.TabIndex = 70;
            this.label7.Text = "شناسه";
            // 
            // txtSeverancePay
            // 
            this.txtSeverancePay.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSeverancePay.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSeverancePay.Location = new System.Drawing.Point(663, 62);
            this.txtSeverancePay.Name = "txtSeverancePay";
            this.txtSeverancePay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSeverancePay.Size = new System.Drawing.Size(162, 31);
            this.txtSeverancePay.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(825, 67);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(42, 24);
            this.label3.TabIndex = 72;
            this.label3.Text = "سنوات";
            // 
            // txtEmployeeAllowance
            // 
            this.txtEmployeeAllowance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtEmployeeAllowance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtEmployeeAllowance.Location = new System.Drawing.Point(12, 23);
            this.txtEmployeeAllowance.Name = "txtEmployeeAllowance";
            this.txtEmployeeAllowance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmployeeAllowance.Size = new System.Drawing.Size(149, 31);
            this.txtEmployeeAllowance.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(162, 26);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 68;
            this.label1.Text = "بن‌کارمندی";
            // 
            // txtHousingAllowance
            // 
            this.txtHousingAllowance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtHousingAllowance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtHousingAllowance.Location = new System.Drawing.Point(12, 60);
            this.txtHousingAllowance.Name = "txtHousingAllowance";
            this.txtHousingAllowance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtHousingAllowance.Size = new System.Drawing.Size(149, 31);
            this.txtHousingAllowance.TabIndex = 66;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(157, 65);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(59, 24);
            this.label6.TabIndex = 63;
            this.label6.Text = "حق‌مسکن";
            // 
            // txtFamilyAllowance
            // 
            this.txtFamilyAllowance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtFamilyAllowance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFamilyAllowance.Location = new System.Drawing.Point(215, 62);
            this.txtFamilyAllowance.Name = "txtFamilyAllowance";
            this.txtFamilyAllowance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFamilyAllowance.Size = new System.Drawing.Size(162, 31);
            this.txtFamilyAllowance.TabIndex = 65;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(377, 67);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(80, 24);
            this.label5.TabIndex = 62;
            this.label5.Text = "حق‌عائله‌مندی";
            // 
            // txtChildAllowance
            // 
            this.txtChildAllowance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtChildAllowance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtChildAllowance.Location = new System.Drawing.Point(457, 62);
            this.txtChildAllowance.Name = "txtChildAllowance";
            this.txtChildAllowance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtChildAllowance.Size = new System.Drawing.Size(162, 31);
            this.txtChildAllowance.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(621, 67);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(49, 24);
            this.label4.TabIndex = 61;
            this.label4.Text = "حق‌اولاد";
            // 
            // txtInsurance
            // 
            this.txtInsurance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtInsurance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtInsurance.Location = new System.Drawing.Point(234, 25);
            this.txtInsurance.Name = "txtInsurance";
            this.txtInsurance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInsurance.Size = new System.Drawing.Size(143, 31);
            this.txtInsurance.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(383, 28);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(32, 24);
            this.label2.TabIndex = 60;
            this.label2.Text = "بیمه";
            // 
            // DefineBenefitsFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(871, 247);
            this.Controls.Add(this.lstBenefits);
            this.Controls.Add(this.cmbFY);
            this.Controls.Add(this.btnDeletBenefits);
            this.Controls.Add(this.btnSubmitBenefits);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtJBCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSeverancePay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmployeeAllowance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHousingAllowance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFamilyAllowance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtChildAllowance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInsurance);
            this.Controls.Add(this.label2);
            this.Name = "DefineBenefitsFRM";
            this.Text = "تعریف مزایای شغلی";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstBenefits;
        private System.Windows.Forms.ComboBox cmbFY;
        private System.Windows.Forms.Button btnDeletBenefits;
        private System.Windows.Forms.Button btnSubmitBenefits;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtJBCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSeverancePay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmployeeAllowance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHousingAllowance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFamilyAllowance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChildAllowance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInsurance;
        private System.Windows.Forms.Label label2;
    }
}