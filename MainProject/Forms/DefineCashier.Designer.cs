namespace MainProject.Forms
{
    partial class DefineCashier
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
            this.txtAccouantNumber = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtCashierTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstCashier = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txtAccouantNumber
            // 
            this.txtAccouantNumber.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtAccouantNumber.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAccouantNumber.Location = new System.Drawing.Point(262, 20);
            this.txtAccouantNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAccouantNumber.Name = "txtAccouantNumber";
            this.txtAccouantNumber.Size = new System.Drawing.Size(276, 33);
            this.txtAccouantNumber.TabIndex = 139;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label35.Location = new System.Drawing.Point(542, 24);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(90, 27);
            this.label35.TabIndex = 137;
            this.label35.Text = "شماره حساب";
            // 
            // txtCashierTitle
            // 
            this.txtCashierTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtCashierTitle.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCashierTitle.Location = new System.Drawing.Point(644, 19);
            this.txtCashierTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCashierTitle.Name = "txtCashierTitle";
            this.txtCashierTitle.Size = new System.Drawing.Size(196, 33);
            this.txtCashierTitle.TabIndex = 140;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(848, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 27);
            this.label4.TabIndex = 138;
            this.label4.Text = "عنوان";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(212, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 27);
            this.label1.TabIndex = 138;
            this.label1.Text = "نوع";
            // 
            // cmbType
            // 
            this.cmbType.Font = new System.Drawing.Font("B Nazanin", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(11, 24);
            this.cmbType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(195, 28);
            this.cmbType.TabIndex = 141;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(827, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 27);
            this.label2.TabIndex = 138;
            this.label2.Text = "وضعیت";
            // 
            // cmbState
            // 
            this.cmbState.Font = new System.Drawing.Font("B Nazanin", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(644, 74);
            this.cmbState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(176, 28);
            this.cmbState.TabIndex = 141;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdate.Location = new System.Drawing.Point(99, 74);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 36);
            this.btnUpdate.TabIndex = 148;
            this.btnUpdate.Text = "ویرایش";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAdd.ForeColor = System.Drawing.Color.Green;
            this.btnAdd.Location = new System.Drawing.Point(461, 74);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 36);
            this.btnAdd.TabIndex = 147;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(11, 74);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 36);
            this.btnDelete.TabIndex = 146;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // lstCashier
            // 
            this.lstCashier.BackColor = System.Drawing.SystemColors.Info;
            this.lstCashier.HideSelection = false;
            this.lstCashier.Location = new System.Drawing.Point(13, 129);
            this.lstCashier.Name = "lstCashier";
            this.lstCashier.Size = new System.Drawing.Size(875, 321);
            this.lstCashier.TabIndex = 149;
            this.lstCashier.UseCompatibleStateImageBehavior = false;
            // 
            // DefineCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 462);
            this.Controls.Add(this.lstCashier);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtAccouantNumber);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.txtCashierTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("B Nazanin", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DefineCashier";
            this.Text = "تعریف حساب صندوق";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccouantNumber;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtCashierTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView lstCashier;
    }
}