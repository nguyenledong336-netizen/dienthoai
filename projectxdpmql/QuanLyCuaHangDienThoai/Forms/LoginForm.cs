using System;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.Services;

namespace QuanLyCuaHangDienThoai.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService = AuthService.Instance;

        public LoginForm()
        {
            InitializeComponent();
            Utils.UITheme.ApplyButtonStyle(btnLogin, Utils.ButtonStyleType.Primary);
            Utils.UITheme.ApplyButtonStyle(btnExit, Utils.ButtonStyleType.Secondary);
            Utils.UITheme.ApplyTextBoxStyle(txtUsername);
            Utils.UITheme.ApplyTextBoxStyle(txtPassword);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (_authService.Login(username, password, out string errorMessage))
            {
                MessageBox.Show($"Đăng nhập thành công!\nChào mừng {_authService.CurrentUser.Username} ({_authService.CurrentUser.Role})", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                using (var mainForm = new MainForm())
                {
                    mainForm.ShowDialog();
                }

                // Khi MainForm đóng (đăng xuất hoặc đóng form)
                if (_authService.IsLoggedIn())
                {
                    // Nếu vẫn còn đăng nhập mà đóng mainform thì thoát luôn app
                    this.Close();
                }
                else
                {
                    // Đã đăng xuất: xóa ô mật khẩu và hiện lại form login
                    txtPassword.Clear();
                    this.Show();
                    txtUsername.Focus();
                }
            }
            else
            {
                MessageBox.Show(errorMessage, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng không?", 
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }
    }
}
