using System;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Repositories;
using QuanLyCuaHangDienThoai.Services;
using QuanLyCuaHangDienThoai.Utils;

namespace QuanLyCuaHangDienThoai.Forms
{
    public partial class UserForm : Form
    {
        private readonly UserRepository _userRepo = new UserRepository();
        private readonly AuthService _authService = AuthService.Instance;
        private int _selectedUserId = 0;

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            // Kiểm tra phân quyền: Chỉ Admin mới được quản lý người dùng
            if (!_authService.IsAdmin())
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng Quản lý người dùng!\nChỉ Quản trị viên (Admin) mới có quyền này.",
                    "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            cboRole.SelectedIndex = 1; // Mặc định NhanVien
            SetupDataGridView();
            LoadUsers();
        }

        private void SetupDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Width = 60 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Tên đăng nhập", Width = 220 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Role", HeaderText = "Quyền (Role)", Width = 150 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThaiHienThi", HeaderText = "Trạng thái", Width = 150 });
        }

        private void LoadUsers()
        {
            try
            {
                var list = _userRepo.GetAll();
                dgvUsers.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cboRole.SelectedItem?.ToString();
            bool status = chkTrangThai.Checked;

            if (ValidationHelper.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cho tài khoản mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng chọn phân quyền cho tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_userRepo.IsUsernameExists(username))
            {
                MessageBox.Show($"Tên đăng nhập '{username}' đã tồn tại! Vui lòng chọn tên khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            var newUser = new User
            {
                Username = username,
                Password = PasswordHelper.HashPassword(password),
                Role = role,
                TrangThai = status
            };

            if (_userRepo.Add(newUser))
            {
                MessageBox.Show("Thêm người dùng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Thêm người dùng thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng từ danh sách bên dưới để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = cboRole.SelectedItem?.ToString();
            bool status = chkTrangThai.Checked;
            string newPassword = txtPassword.Text;

            // Kiểm tra nếu tự đổi quyền hoặc khóa chính mình
            if (_selectedUserId == _authService.CurrentUser.Id)
            {
                if (!status)
                {
                    MessageBox.Show("Bạn không thể tự khóa tài khoản đang đăng nhập của chính mình!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (role != "Admin")
                {
                    MessageBox.Show("Bạn không thể tự hạ quyền Admin của tài khoản đang đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var user = new User
            {
                Id = _selectedUserId,
                Username = txtUsername.Text.Trim(),
                Role = role,
                TrangThai = status
            };

            bool success = _userRepo.Update(user);

            // Nếu có nhập mật khẩu mới thì cập nhật luôn mật khẩu
            if (!string.IsNullOrEmpty(newPassword))
            {
                _userRepo.UpdatePassword(_selectedUserId, PasswordHelper.HashPassword(newPassword));
            }

            if (success)
            {
                MessageBox.Show("Cập nhật thông tin người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng để thay đổi trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedUserId == _authService.CurrentUser.Id)
            {
                MessageBox.Show("Bạn không thể tự khóa tài khoản đang đăng nhập của chính mình!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _userRepo.GetById(_selectedUserId);
            if (user != null)
            {
                bool newStatus = !user.TrangThai;
                string actionName = newStatus ? "mở khóa" : "khóa";
                DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn {actionName} tài khoản '{user.Username}' không?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    if (_userRepo.ToggleStatus(_selectedUserId, newStatus))
                    {
                        MessageBox.Show($"Đã {actionName} tài khoản '{user.Username}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                        LoadUsers();
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            _selectedUserId = 0;
            txtUsername.Clear();
            txtUsername.Enabled = true;
            txtPassword.Clear();
            cboRole.SelectedIndex = 1;
            chkTrangThai.Checked = true;
            txtSearch.Clear();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnToggleStatus.Enabled = false;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvUsers.Rows.Count)
            {
                var row = dgvUsers.Rows[e.RowIndex];
                if (row.DataBoundItem is User user)
                {
                    _selectedUserId = user.Id;
                    txtUsername.Text = user.Username;
                    txtUsername.Enabled = false; // Không cho sửa username
                    txtPassword.Clear(); // Để trống, nếu muốn đổi pass thì nhập pass mới
                    cboRole.SelectedItem = user.Role;
                    chkTrangThai.Checked = user.TrangThai;

                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnToggleStatus.Enabled = true;
                    btnToggleStatus.Text = user.TrangThai ? "🔒 Khóa TK" : "🔓 Mở khóa TK";
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadUsers();
                return;
            }
            dgvUsers.DataSource = _userRepo.Search(keyword);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadUsers();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
