using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProject.Core.Business;
using MainProject.Entities;
using MainProject.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MainProject.Forms
{
    public partial class LogInFRM : Form
    {
        public LogInFRM()
        {
            CommonFunctions.ScaleForm(this);
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassWord.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("لطفاً نام کاربری و رمز عبور را وارد کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var login = new LoginModel { Username = username, Password = password };
            var manager = new LoginManager();

            try
            {
                if (manager.Authenticate(login, out DataTable messages, out DataTable notifs, out DataTable pending))
                {
                    MessageBox.Show($"ورود موفقیت‌آمیز، خوش آمدید {LoginInfo.Instance.FullName}", "ورود", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    MainMenuFRM menu = new MainMenuFRM(username, messages, notifs, pending);
                    menu.Show();

                    // ❌ دیگه نباید Close بشه چون بعداً نیاز داریم دوباره Show کنیم.
                }
                else
                {
                    MessageBox.Show("نام کاربری یا رمز عبور نادرست است یا دسترسی ندارید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در ورود: " + ex.Message, "اشکال داخلی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LogInFRM_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LogInFRM_FormClosing(object sender, FormClosingEventArgs e)
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

        private void LogInFRM_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "SystemAdmin";
            txtPassWord.Text = "111111";
            txtPassWord.PasswordChar = '●'; // نمایش به صورت نقطه
        }
    }
}
