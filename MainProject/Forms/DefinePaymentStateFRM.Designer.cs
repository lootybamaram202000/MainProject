namespace MainProject.Forms
{
    partial class DefinePaymentStateFRM
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
            this.lstPaymentStates = new System.Windows.Forms.ListView();
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
            this.btnSubmitNewPaymentState = new System.Windows.Forms.Button();
            this.btnDeletPaymentState = new System.Windows.Forms.Button();
            this.txtPaymentStateTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaymentStateCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdatePaymentState = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPaymentStates
            // 
            this.lstPaymentStates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstPaymentStates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.lstPaymentStates.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstPaymentStates.FullRowSelect = true;
            this.lstPaymentStates.GridLines = true;
            this.lstPaymentStates.HideSelection = false;
            this.lstPaymentStates.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.lstPaymentStates.Location = new System.Drawing.Point(12, 98);
            this.lstPaymentStates.MultiSelect = false;
            this.lstPaymentStates.Name = "lstPaymentStates";
            this.lstPaymentStates.Size = new System.Drawing.Size(380, 180);
            this.lstPaymentStates.TabIndex = 95;
            this.lstPaymentStates.UseCompatibleStateImageBehavior = false;
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
            // btnSubmitNewPaymentState
            // 
            this.btnSubmitNewPaymentState.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitNewPaymentState.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitNewPaymentState.Location = new System.Drawing.Point(328, 58);
            this.btnSubmitNewPaymentState.Name = "btnSubmitNewPaymentState";
            this.btnSubmitNewPaymentState.Size = new System.Drawing.Size(47, 34);
            this.btnSubmitNewPaymentState.TabIndex = 93;
            this.btnSubmitNewPaymentState.Text = "ثبت";
            this.btnSubmitNewPaymentState.UseVisualStyleBackColor = true;
            // 
            // btnDeletPaymentState
            // 
            this.btnDeletPaymentState.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeletPaymentState.ForeColor = System.Drawing.Color.Red;
            this.btnDeletPaymentState.Location = new System.Drawing.Point(16, 58);
            this.btnDeletPaymentState.Name = "btnDeletPaymentState";
            this.btnDeletPaymentState.Size = new System.Drawing.Size(50, 34);
            this.btnDeletPaymentState.TabIndex = 92;
            this.btnDeletPaymentState.Text = "حذف";
            this.btnDeletPaymentState.UseVisualStyleBackColor = true;
            // 
            // txtPaymentStateTitle
            // 
            this.txtPaymentStateTitle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtPaymentStateTitle.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPaymentStateTitle.Location = new System.Drawing.Point(12, 12);
            this.txtPaymentStateTitle.Name = "txtPaymentStateTitle";
            this.txtPaymentStateTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPaymentStateTitle.Size = new System.Drawing.Size(195, 27);
            this.txtPaymentStateTitle.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(209, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 24);
            this.label2.TabIndex = 90;
            this.label2.Text = "عنوان";
            // 
            // txtPaymentStateCode
            // 
            this.txtPaymentStateCode.Enabled = false;
            this.txtPaymentStateCode.Font = new System.Drawing.Font("Square721 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentStateCode.Location = new System.Drawing.Point(253, 13);
            this.txtPaymentStateCode.Name = "txtPaymentStateCode";
            this.txtPaymentStateCode.Size = new System.Drawing.Size(70, 27);
            this.txtPaymentStateCode.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(324, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 24);
            this.label1.TabIndex = 88;
            this.label1.Text = "کد پرداخت";
            // 
            // btnUpdatePaymentState
            // 
            this.btnUpdatePaymentState.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdatePaymentState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdatePaymentState.Location = new System.Drawing.Point(68, 58);
            this.btnUpdatePaymentState.Name = "btnUpdatePaymentState";
            this.btnUpdatePaymentState.Size = new System.Drawing.Size(61, 34);
            this.btnUpdatePaymentState.TabIndex = 94;
            this.btnUpdatePaymentState.Text = "ویرایش";
            this.btnUpdatePaymentState.UseVisualStyleBackColor = true;
            // 
            // DefinePaymentStateFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(406, 295);
            this.Controls.Add(this.lstPaymentStates);
            this.Controls.Add(this.btnSubmitNewPaymentState);
            this.Controls.Add(this.btnDeletPaymentState);
            this.Controls.Add(this.txtPaymentStateTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPaymentStateCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdatePaymentState);
            this.Name = "DefinePaymentStateFRM";
            this.Text = "تعریف وضعیت پرداخت";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstPaymentStates;
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
        private System.Windows.Forms.Button btnSubmitNewPaymentState;
        private System.Windows.Forms.Button btnDeletPaymentState;
        private System.Windows.Forms.TextBox txtPaymentStateTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPaymentStateCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdatePaymentState;
    }
}