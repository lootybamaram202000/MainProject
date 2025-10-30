namespace MainProject.Forms
{
    partial class SubmitDailySellsByImportFileFRM
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
            this.lstDailySells = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalDeficit = new System.Windows.Forms.TextBox();
            this.txtTotalDiscount = new System.Windows.Forms.TextBox();
            this.txtTotalSold = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtFilePatch = new System.Windows.Forms.TextBox();
            this.btnSubmitFile = new System.Windows.Forms.Button();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDailySells
            // 
            this.lstDailySells.BackColor = System.Drawing.SystemColors.Info;
            this.lstDailySells.HideSelection = false;
            this.lstDailySells.Location = new System.Drawing.Point(5, 122);
            this.lstDailySells.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstDailySells.Name = "lstDailySells";
            this.lstDailySells.Size = new System.Drawing.Size(1208, 441);
            this.lstDailySells.TabIndex = 18;
            this.lstDailySells.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(171, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(86, 26);
            this.label4.TabIndex = 13;
            this.label4.Text = "جمع کسری‌ها";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(430, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(88, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "جمع تخفیفات";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(681, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(72, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "جمع فروش";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(1168, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(50, 26);
            this.label5.TabIndex = 16;
            this.label5.Text = "از تاریخ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(953, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(51, 26);
            this.label1.TabIndex = 17;
            this.label1.Text = "تا تاریخ";
            // 
            // txtTotalDeficit
            // 
            this.txtTotalDeficit.BackColor = System.Drawing.Color.Pink;
            this.txtTotalDeficit.Location = new System.Drawing.Point(11, 84);
            this.txtTotalDeficit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalDeficit.Name = "txtTotalDeficit";
            this.txtTotalDeficit.Size = new System.Drawing.Size(151, 22);
            this.txtTotalDeficit.TabIndex = 7;
            // 
            // txtTotalDiscount
            // 
            this.txtTotalDiscount.BackColor = System.Drawing.Color.Wheat;
            this.txtTotalDiscount.Location = new System.Drawing.Point(270, 84);
            this.txtTotalDiscount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalDiscount.Name = "txtTotalDiscount";
            this.txtTotalDiscount.Size = new System.Drawing.Size(151, 22);
            this.txtTotalDiscount.TabIndex = 8;
            // 
            // txtTotalSold
            // 
            this.txtTotalSold.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtTotalSold.Location = new System.Drawing.Point(521, 84);
            this.txtTotalSold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalSold.Name = "txtTotalSold";
            this.txtTotalSold.Size = new System.Drawing.Size(151, 22);
            this.txtTotalSold.TabIndex = 9;
            // 
            // txtStartDate
            // 
            this.txtStartDate.BackColor = System.Drawing.Color.BurlyWood;
            this.txtStartDate.Location = new System.Drawing.Point(1008, 78);
            this.txtStartDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(151, 22);
            this.txtStartDate.TabIndex = 10;
            // 
            // txtEndDate
            // 
            this.txtEndDate.BackColor = System.Drawing.Color.BurlyWood;
            this.txtEndDate.Location = new System.Drawing.Point(793, 78);
            this.txtEndDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(151, 22);
            this.txtEndDate.TabIndex = 11;
            // 
            // txtFilePatch
            // 
            this.txtFilePatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFilePatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePatch.Location = new System.Drawing.Point(681, 15);
            this.txtFilePatch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilePatch.Name = "txtFilePatch";
            this.txtFilePatch.Size = new System.Drawing.Size(376, 30);
            this.txtFilePatch.TabIndex = 12;
            // 
            // btnSubmitFile
            // 
            this.btnSubmitFile.BackColor = System.Drawing.Color.LightGreen;
            this.btnSubmitFile.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitFile.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnSubmitFile.Location = new System.Drawing.Point(5, 571);
            this.btnSubmitFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubmitFile.Name = "btnSubmitFile";
            this.btnSubmitFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSubmitFile.Size = new System.Drawing.Size(207, 55);
            this.btnSubmitFile.TabIndex = 4;
            this.btnSubmitFile.Text = "تایید و ثبت";
            this.btnSubmitFile.UseVisualStyleBackColor = false;
            // 
            // btnReadFile
            // 
            this.btnReadFile.BackColor = System.Drawing.Color.Yellow;
            this.btnReadFile.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReadFile.Location = new System.Drawing.Point(16, 15);
            this.btnReadFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnReadFile.Size = new System.Drawing.Size(207, 55);
            this.btnReadFile.TabIndex = 5;
            this.btnReadFile.Text = "خواندن فایل";
            this.btnReadFile.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.Location = new System.Drawing.Point(1065, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(137, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "انتخاب فایل اکسل";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // SubmitDailySellsByImportFileFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 642);
            this.Controls.Add(this.lstDailySells);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalDeficit);
            this.Controls.Add(this.txtTotalDiscount);
            this.Controls.Add(this.txtTotalSold);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtFilePatch);
            this.Controls.Add(this.btnSubmitFile);
            this.Controls.Add(this.btnReadFile);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SubmitDailySellsByImportFileFRM";
            this.Text = "ورود فایل اکسل";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstDailySells;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalDeficit;
        private System.Windows.Forms.TextBox txtTotalDiscount;
        private System.Windows.Forms.TextBox txtTotalSold;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.TextBox txtFilePatch;
        private System.Windows.Forms.Button btnSubmitFile;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.Button button1;
    }
}