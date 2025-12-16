using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProject.Core.Business;
using MainProject.Entities;
using MainProject.Forms;
using MainProject.Helpers;



namespace MainProject
{


    public partial class MainMenuFRM : Form
    {
        private readonly MainMenuManager _menuManager = new MainMenuManager();
        private MainMenuInfo _menuInfo;

        public MainMenuFRM(string username)
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            _menuInfo = _menuManager.LoadInfo();
            _menuInfo.CurrentUser = username;
        }


        public MainMenuFRM(string username, DataTable messages, DataTable notifs, DataTable pending)
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            _menuInfo = _menuManager.LoadInfo();
            _menuInfo.CurrentUser = username;

            SetupMessageGrid();
            SetupNotificationGrid();
            SetupPendingGrid();

            dgvMessages.DataSource = messages;
            dgvNotifications.DataSource = notifs;
            dgvPending.DataSource = pending;

        }


        private void MainMenuFRM_Load(object sender, EventArgs e)
        {
            lblCurentUser.Text = _menuInfo.CurrentUser;
            lblCurentDate.Text = _menuInfo.CurrentDate;
            lblSystemDate.Text = _menuInfo.SystemDate;

            LoadDashboardData();
            UpdateTabTitles();
        }

        private void LoadDashboardData()
        {
            SetupMessageGrid();
            SetupNotificationGrid();
            SetupPendingGrid();

            LoadMessages();
            LoadNotifications();
            LoadPendingItems();
        }

        private void ApplyGridStyle(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        private void SetupMessageGrid()
        {
            dgvMessages.CellContentClick -= dgvMessages_CellContentClick;
            dgvMessages.DataBindingComplete -= dgvMessages_DataBindingComplete;

            dgvMessages.Columns.Clear();
            dgvMessages.AutoGenerateColumns = false;
            dgvMessages.AllowUserToAddRows = false;
            dgvMessages.ReadOnly = true;
            dgvMessages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvMessages.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "ID", Name = "ID", Visible = false });
            dgvMessages.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ردیف", Name = "RowIndex", Width = 50 });
            dgvMessages.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "عنوان پیام", DataPropertyName = "Title", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvMessages.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "فرستنده", DataPropertyName = "SenderName", Width = 120 });
            dgvMessages.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "تاریخ", DataPropertyName = "Date", Width = 100 });
            dgvMessages.Columns.Add(new DataGridViewButtonColumn { HeaderText = "حذف", Text = "🗑 حذف", UseColumnTextForButtonValue = true, Width = 70 });

            dgvMessages.CellContentClick += dgvMessages_CellContentClick;
            dgvMessages.DataBindingComplete += dgvMessages_DataBindingComplete;
            ApplyGridStyle(dgvMessages);
        }

        private void SetupNotificationGrid()
        {
            dgvNotifications.CellContentClick -= dgvNotifications_CellContentClick;
            dgvNotifications.DataBindingComplete -= dgvNotifications_DataBindingComplete;

            dgvNotifications.Columns.Clear();
            dgvNotifications.AutoGenerateColumns = false;
            dgvNotifications.AllowUserToAddRows = false;
            dgvNotifications.ReadOnly = true;
            dgvNotifications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "ID", Name = "ID", Visible = false });
            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ردیف", Name = "RowIndex", Width = 50 });
            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "عنوان", DataPropertyName = "Title", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "تاریخ", DataPropertyName = "Date", Width = 100 });
            dgvNotifications.Columns.Add(new DataGridViewButtonColumn { HeaderText = "حذف", Text = "🗑 حذف", UseColumnTextForButtonValue = true, Width = 70 });

            dgvNotifications.CellContentClick += dgvNotifications_CellContentClick;
            dgvNotifications.DataBindingComplete += dgvNotifications_DataBindingComplete;
            ApplyGridStyle(dgvNotifications);
        }

        private void SetupPendingGrid()
        {
            dgvPending.CellContentClick -= dgvPending_CellContentClick;
            dgvPending.DataBindingComplete -= dgvPending_DataBindingComplete;

            dgvPending.Columns.Clear();
            dgvPending.AutoGenerateColumns = false;
            dgvPending.AllowUserToAddRows = false;
            dgvPending.ReadOnly = true;
            dgvPending.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvPending.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "ID", Name = "ID", Visible = false });
            dgvPending.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ردیف", Name = "RowIndex", Width = 50 });
            dgvPending.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "نام آیتم", DataPropertyName = "Title", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPending.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "پیام", DataPropertyName = "Message", Width = 200 });
            dgvPending.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "تاریخ", DataPropertyName = "Date", Width = 100 });
            dgvPending.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "EntityCode", DataPropertyName = "RelatedEntity", Name = "EntityCode", Visible = false });
            dgvPending.Columns.Add(new DataGridViewButtonColumn { HeaderText = "رسیدگی", Text = "✅ رسیدگی", UseColumnTextForButtonValue = true, Width = 80 });

            dgvPending.CellContentClick += dgvPending_CellContentClick;
            dgvPending.DataBindingComplete += dgvPending_DataBindingComplete;
            ApplyGridStyle(dgvPending);
        }

        private void dgvMessages_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvMessages.Rows.Count; i++)
                dgvMessages.Rows[i].Cells["RowIndex"].Value = (i + 1).ToString();
        }

        private void dgvNotifications_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvNotifications.Rows.Count; i++)
                dgvNotifications.Rows[i].Cells["RowIndex"].Value = (i + 1).ToString();
        }

        private void dgvPending_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvPending.Rows.Count; i++)
                dgvPending.Rows[i].Cells["RowIndex"].Value = (i + 1).ToString();
        }

        private void LoadMessages()
        {
            var manager = new UserPanelManager();
            DataTable dt = manager.GetMessages(LoginInfo.Instance.UserID);
            dgvMessages.DataSource = dt;
            for (int i = 0; i < dgvMessages.Rows.Count; i++)
                dgvMessages.Rows[i].Cells["RowIndex"].Value = (i + 1).ToString();
            UpdateTabTitles();

        }

        private void LoadNotifications()
        {
            var manager = new UserPanelManager();
            DataTable dt = manager.GetNotifications(LoginInfo.Instance.UserID);
            dgvNotifications.DataSource = dt;
            for (int i = 0; i < dgvNotifications.Rows.Count; i++)
                dgvNotifications.Rows[i].Cells["RowIndex"].Value = (i + 1).ToString();
            UpdateTabTitles();

        }

        private void LoadPendingItems()
        {
            var manager = new UserPanelManager();
            DataTable dt = manager.GetPendingItems(LoginInfo.Instance.UserID);
            dgvPending.DataSource = dt;
            for (int i = 0; i < dgvPending.Rows.Count; i++)
                dgvPending.Rows[i].Cells["RowIndex"].Value = (i + 1).ToString();
            UpdateTabTitles();

        }

        private void UpdateTabTitles()
        {
            tbpNotifications.Text = $"اعلان‌ها ({dgvNotifications.RowCount})";
            tbpMeesages.Text = $"پیام‌ها ({dgvMessages.RowCount})";
            tbpPendingList.Text = $"در انتظار ({dgvPending.RowCount})";
        }



        private void dgvNotifications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !(dgvNotifications.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;

            if (!dgvNotifications.Columns.Contains("ID")) return;
            if (e.RowIndex >= dgvNotifications.Rows.Count) return;

            var cell = dgvNotifications.Rows[e.RowIndex].Cells["ID"];
            if (cell == null || cell.Value == null) return;

            string id = cell.Value.ToString();
            DialogResult confirm = MessageBox.Show("آیا اعلان حذف شود؟", "تأیید حذف اعلان", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                var manager = new UserPanelManager();
                if (manager.DeleteNotification(id))
                    LoadNotifications();
                else
                    MessageBox.Show("خطا در حذف اعلان.");
            }
        }

        private void dgvMessages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // بررسی اینکه روی دکمه کلیک شده و ردیف معتبر است
            if (e.RowIndex < 0 || !(dgvMessages.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;

            // بررسی اینکه ستون "ID" وجود دارد
            if (!dgvMessages.Columns.Contains("ID")) return;

            // بررسی اینکه ردیف در محدوده است
            if (e.RowIndex >= dgvMessages.Rows.Count) return;

            // دریافت مقدار سلول "ID" و بررسی آن
            var cell = dgvMessages.Rows[e.RowIndex].Cells["ID"];
            if (cell == null || cell.Value == null) return;

            string id = cell.Value.ToString();
            var confirm = MessageBox.Show("آیا پیام حذف شود؟", "تأیید حذف پیام", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                var manager = new UserPanelManager();
                if (manager.DeleteMessage(id))
                    LoadMessages();
                else
                    MessageBox.Show("خطا در حذف پیام.");
            }
        }

        private void dgvPending_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !(dgvPending.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;

            var cell = dgvPending.Rows[e.RowIndex].Cells["EntityCode"];
            if (cell.Value == null) return;

            string id = cell.Value.ToString();
            MessageBox.Show($"Handling item {id} - Coming Soon", "In Progress");
        }

        private void MainMenuFRM_FormClosed(object sender, FormClosedEventArgs e)
        {
            // پاک‌سازی اطلاعات لاگین
            LoginInfo.Instance.Clear();

            // نمایش مجدد فرم لاگین
            LogInFRM loginForm = Application.OpenForms["LogInFRM"] as LogInFRM;
            if (loginForm != null)
            {
                loginForm.Show();
            }
        }

        private void MainMenuFRM_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "آیا مطمئن هستید که می‌خواهید از برنامه خارج شوید؟",
                "خروج از برنامه",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
               );

            if (result == DialogResult.No)
            {
                e.Cancel = true; // جلوگیری از بستن فرم
            }
        }

        private void DefineUnitOfMeasureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubmitUnitFRM unitFRM = new SubmitUnitFRM();
            unitFRM.ShowDialog();
        }

        private void DefineSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineSectionsFRM sectionsFRM = new DefineSectionsFRM();
            sectionsFRM.ShowDialog();
        }

        private void DefineProductToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SubmitProductFRM productFRM = new SubmitProductFRM();
            productFRM.ShowDialog();
        }

        private void DefineCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SubmitSellerFRM sellerFRM = new SubmitSellerFRM();
            sellerFRM.ShowDialog();
        }

        private void DefinePreparationItemsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DefineBasicItemsFRM defineBasic = new DefineBasicItemsFRM();
            defineBasic.ShowDialog();

        }

        private void SubmitAndEditRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubmitBasicRecipieFRM submitBasicRecipieFRM = new SubmitBasicRecipieFRM();
            submitBasicRecipieFRM.ShowDialog();
        }

        private void DefineSalesItemsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DefineMenuItemsFRM defineMenuItemsFRM = new DefineMenuItemsFRM();
            defineMenuItemsFRM.ShowDialog();
        }

        private void SubmitAndEditRecipeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SubmitMenuRecipieFRM submitMenuRecipieFRM = new SubmitMenuRecipieFRM();
            submitMenuRecipieFRM.ShowDialog();
        }

        private void RegisterPurchaseInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubmitFactorFRM submitFactorFRM = new SubmitFactorFRM();
            submitFactorFRM.ShowDialog();
        }

        private void lblSystemDate_Click(object sender, EventArgs e)
        {

        }

        private void lblCurentUser_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void DefinePersonnelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineNewPersonalFRM newPersonalFRM = new DefineNewPersonalFRM();
            newPersonalFRM.ShowDialog();
        }

        private void SalarySlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubmitSalarySlipFRM salarySlipFRM = new SubmitSalarySlipFRM();
            salarySlipFRM.ShowDialog();
        }

        private void AccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineBankAccountFRM bankAccountFRM = new DefineBankAccountFRM();
            bankAccountFRM.ShowDialog();
        }

        private void IssueSalesInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubmitDailySellsFRM dailySellsFRM = new SubmitDailySellsFRM();
            dailySellsFRM.ShowDialog();
        }

        private void CategoriesAndGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoEditorForm infoEditorForm = new InfoEditorForm();
            infoEditorForm.ShowDialog();
        }

        private void OverheadCalculationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OverHeadFRM overHeadFRM = new OverHeadFRM();
            overHeadFRM.ShowDialog();
        }

        private void CentralWarehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WareHouseManagementFRM wareHouse = new WareHouseManagementFRM();
            wareHouse.ShowDialog();
        }

        private void دستوردهیهاوگروه‌بندیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // عملکرد موردنظر بعداً نوشته می‌شود
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }

}

