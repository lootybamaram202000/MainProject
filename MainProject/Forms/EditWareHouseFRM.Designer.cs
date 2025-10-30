namespace MainProject.Forms
{
    partial class EditWareHouseFRM
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("");
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lstWareHouse = new System.Windows.Forms.ListView();
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.cmbWareHouseSelection = new System.Windows.Forms.ComboBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtCriticalInventory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEntity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUnit1 = new System.Windows.Forms.Label();
            this.lblUnit2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtNewEntity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescribtion = new System.Windows.Forms.TextBox();
            this.btnSubmitEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Info;
            this.txtSearch.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSearch.Location = new System.Drawing.Point(336, 355);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(235, 37);
            this.txtSearch.TabIndex = 210;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(569, 359);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(103, 29);
            this.label22.TabIndex = 209;
            this.label22.Text = "جستجوی آیتم";
            // 
            // lstWareHouse
            // 
            this.lstWareHouse.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lstWareHouse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader31,
            this.columnHeader32,
            this.columnHeader33,
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40});
            this.lstWareHouse.Enabled = false;
            this.lstWareHouse.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lstWareHouse.FullRowSelect = true;
            this.lstWareHouse.GridLines = true;
            this.lstWareHouse.HideSelection = false;
            this.lstWareHouse.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lstWareHouse.Location = new System.Drawing.Point(13, 400);
            this.lstWareHouse.Margin = new System.Windows.Forms.Padding(4);
            this.lstWareHouse.MultiSelect = false;
            this.lstWareHouse.Name = "lstWareHouse";
            this.lstWareHouse.Size = new System.Drawing.Size(660, 367);
            this.lstWareHouse.TabIndex = 208;
            this.lstWareHouse.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader31
            // 
            this.columnHeader31.DisplayIndex = 9;
            this.columnHeader31.Text = "ردیف";
            // 
            // columnHeader32
            // 
            this.columnHeader32.DisplayIndex = 0;
            this.columnHeader32.Text = "کد کالا";
            // 
            // columnHeader33
            // 
            this.columnHeader33.DisplayIndex = 1;
            this.columnHeader33.Text = "نام کالا";
            this.columnHeader33.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader34
            // 
            this.columnHeader34.DisplayIndex = 2;
            this.columnHeader34.Text = "قیمت خرید";
            this.columnHeader34.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader35
            // 
            this.columnHeader35.DisplayIndex = 3;
            this.columnHeader35.Text = "فروشنده";
            this.columnHeader35.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader36
            // 
            this.columnHeader36.DisplayIndex = 4;
            this.columnHeader36.Text = "واحد خرید";
            this.columnHeader36.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader37
            // 
            this.columnHeader37.DisplayIndex = 5;
            this.columnHeader37.Text = "واحد خرید";
            this.columnHeader37.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader38
            // 
            this.columnHeader38.DisplayIndex = 6;
            this.columnHeader38.Text = "مکوجودی بحرانی";
            // 
            // columnHeader39
            // 
            this.columnHeader39.DisplayIndex = 7;
            this.columnHeader39.Text = "دورریز";
            // 
            // columnHeader40
            // 
            this.columnHeader40.DisplayIndex = 8;
            this.columnHeader40.Text = "وضعیت";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(245, 359);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(83, 29);
            this.label5.TabIndex = 207;
            this.label5.Text = "انتخاب انبار";
            // 
            // cmbWareHouseSelection
            // 
            this.cmbWareHouseSelection.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmbWareHouseSelection.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbWareHouseSelection.FormattingEnabled = true;
            this.cmbWareHouseSelection.Location = new System.Drawing.Point(13, 356);
            this.cmbWareHouseSelection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbWareHouseSelection.Name = "cmbWareHouseSelection";
            this.cmbWareHouseSelection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbWareHouseSelection.Size = new System.Drawing.Size(224, 32);
            this.cmbWareHouseSelection.TabIndex = 206;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtItemName.Enabled = false;
            this.txtItemName.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtItemName.Location = new System.Drawing.Point(13, 11);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtItemName.Size = new System.Drawing.Size(292, 37);
            this.txtItemName.TabIndex = 220;
            // 
            // txtCriticalInventory
            // 
            this.txtCriticalInventory.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCriticalInventory.Enabled = false;
            this.txtCriticalInventory.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCriticalInventory.Location = new System.Drawing.Point(230, 60);
            this.txtCriticalInventory.Margin = new System.Windows.Forms.Padding(4);
            this.txtCriticalInventory.Name = "txtCriticalInventory";
            this.txtCriticalInventory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCriticalInventory.Size = new System.Drawing.Size(75, 37);
            this.txtCriticalInventory.TabIndex = 225;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(313, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(59, 29);
            this.label2.TabIndex = 219;
            this.label2.Text = "نام آیتم";
            // 
            // txtEntity
            // 
            this.txtEntity.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtEntity.Enabled = false;
            this.txtEntity.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtEntity.Location = new System.Drawing.Point(524, 60);
            this.txtEntity.Margin = new System.Windows.Forms.Padding(4);
            this.txtEntity.Name = "txtEntity";
            this.txtEntity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEntity.Size = new System.Drawing.Size(77, 37);
            this.txtEntity.TabIndex = 226;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(603, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(66, 29);
            this.label3.TabIndex = 221;
            this.label3.Text = "موجودی";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(307, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(111, 29);
            this.label4.TabIndex = 222;
            this.label4.Text = "موجودی بحرانی";
            // 
            // lblUnit1
            // 
            this.lblUnit1.AutoSize = true;
            this.lblUnit1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUnit1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblUnit1.Location = new System.Drawing.Point(450, 68);
            this.lblUnit1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnit1.Name = "lblUnit1";
            this.lblUnit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUnit1.Size = new System.Drawing.Size(41, 29);
            this.lblUnit1.TabIndex = 223;
            this.lblUnit1.Text = "واحد";
            // 
            // lblUnit2
            // 
            this.lblUnit2.AutoSize = true;
            this.lblUnit2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUnit2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblUnit2.Location = new System.Drawing.Point(181, 68);
            this.lblUnit2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnit2.Name = "lblUnit2";
            this.lblUnit2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUnit2.Size = new System.Drawing.Size(41, 29);
            this.lblUnit2.TabIndex = 224;
            this.lblUnit2.Text = "واحد";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(613, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(59, 29);
            this.label1.TabIndex = 219;
            this.label1.Text = "کد آیتم";
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtItemCode.Enabled = false;
            this.txtItemCode.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtItemCode.Location = new System.Drawing.Point(402, 14);
            this.txtItemCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtItemCode.Size = new System.Drawing.Size(203, 37);
            this.txtItemCode.TabIndex = 220;
            // 
            // txtNewEntity
            // 
            this.txtNewEntity.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNewEntity.Enabled = false;
            this.txtNewEntity.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNewEntity.Location = new System.Drawing.Point(454, 131);
            this.txtNewEntity.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewEntity.Name = "txtNewEntity";
            this.txtNewEntity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNewEntity.Size = new System.Drawing.Size(77, 37);
            this.txtNewEntity.TabIndex = 229;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(538, 139);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(136, 29);
            this.label6.TabIndex = 227;
            this.label6.Text = "موجودی اصلاح شده";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(380, 139);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(41, 29);
            this.label7.TabIndex = 228;
            this.label7.Text = "واحد";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(548, 184);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(124, 29);
            this.label8.TabIndex = 227;
            this.label8.Text = "توضیحات (الزامی)";
            // 
            // txtDescribtion
            // 
            this.txtDescribtion.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDescribtion.Enabled = false;
            this.txtDescribtion.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDescribtion.Location = new System.Drawing.Point(13, 216);
            this.txtDescribtion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescribtion.Multiline = true;
            this.txtDescribtion.Name = "txtDescribtion";
            this.txtDescribtion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescribtion.Size = new System.Drawing.Size(660, 87);
            this.txtDescribtion.TabIndex = 229;
            // 
            // btnSubmitEdit
            // 
            this.btnSubmitEdit.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitEdit.ForeColor = System.Drawing.Color.Green;
            this.btnSubmitEdit.Location = new System.Drawing.Point(13, 313);
            this.btnSubmitEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitEdit.Name = "btnSubmitEdit";
            this.btnSubmitEdit.Size = new System.Drawing.Size(83, 35);
            this.btnSubmitEdit.TabIndex = 230;
            this.btnSubmitEdit.Text = "ثبت";
            this.btnSubmitEdit.UseVisualStyleBackColor = true;
            // 
            // EditWareHouseFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(687, 781);
            this.Controls.Add(this.btnSubmitEdit);
            this.Controls.Add(this.txtDescribtion);
            this.Controls.Add(this.txtNewEntity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCriticalInventory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEntity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblUnit1);
            this.Controls.Add(this.lblUnit2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lstWareHouse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbWareHouseSelection);
            this.Name = "EditWareHouseFRM";
            this.Text = "اصلاح انبار";
            this.Load += new System.EventHandler(this.EditWareHouseFRM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ListView lstWareHouse;
        public System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        private System.Windows.Forms.ColumnHeader columnHeader36;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.ColumnHeader columnHeader39;
        private System.Windows.Forms.ColumnHeader columnHeader40;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbWareHouseSelection;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtCriticalInventory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEntity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUnit1;
        private System.Windows.Forms.Label lblUnit2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.TextBox txtNewEntity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescribtion;
        private System.Windows.Forms.Button btnSubmitEdit;
    }
}