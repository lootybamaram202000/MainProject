namespace MainProject.Forms
{
    partial class SelectDateFRM
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
            this.dtpSystemDate = new System.Windows.Forms.DateTimePicker();
            this.btnSubmitSystemDate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpSystemDate
            // 
            this.dtpSystemDate.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dtpSystemDate.Location = new System.Drawing.Point(13, 63);
            this.dtpSystemDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpSystemDate.Name = "dtpSystemDate";
            this.dtpSystemDate.Size = new System.Drawing.Size(390, 37);
            this.dtpSystemDate.TabIndex = 29;
            // 
            // btnSubmitSystemDate
            // 
            this.btnSubmitSystemDate.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitSystemDate.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitSystemDate.Location = new System.Drawing.Point(13, 13);
            this.btnSubmitSystemDate.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitSystemDate.Name = "btnSubmitSystemDate";
            this.btnSubmitSystemDate.Size = new System.Drawing.Size(100, 42);
            this.btnSubmitSystemDate.TabIndex = 28;
            this.btnSubmitSystemDate.Text = "ثبت";
            this.btnSubmitSystemDate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(290, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 30);
            this.label1.TabIndex = 27;
            this.label1.Text = "انتخاب از تقویم";
            // 
            // SelectDateFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(416, 133);
            this.Controls.Add(this.dtpSystemDate);
            this.Controls.Add(this.btnSubmitSystemDate);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectDateFRM";
            this.Text = "انتخاب تاریخ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpSystemDate;
        private System.Windows.Forms.Button btnSubmitSystemDate;
        private System.Windows.Forms.Label label1;
    }
}