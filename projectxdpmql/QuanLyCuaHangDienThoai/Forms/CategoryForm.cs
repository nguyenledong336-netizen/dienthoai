using System;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Services;

namespace QuanLyCuaHangDienThoai.Forms
{
    public partial class CategoryForm : Form
    {
        private readonly CategoryService _catService = new CategoryService();
        private readonly AuthService _authService = AuthService.Instance;
        private int _selectedId = 0;

        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
            SetupDataGridView();
            LoadCategories();
        }

        private void ApplyPermissions()
        {
            bool isAdmin = _authService.IsAdmin();
            btnAdd.Enabled = isAdmin;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            if (!isAdmin)
            {
                grpInput.Enabled = false;
                grpActions.Text = "Thao tác (Chỉ Quản trị viên mới có quyền Thêm/Sửa/Xóa)";
            }
        }

        private void SetupDataGridView()
        {
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.Columns.Clear();

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Mã DM", Width = 80 });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenDanhMuc", HeaderText = "Tên danh mục", Width = 300 });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MoTa", HeaderText = "Mô tả", Width = 500 });
        }

        private void LoadCategories()
        {
            try
            {
                dgvCategories.DataSource = _catService.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!_authService.IsAdmin())
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cat = new Category
            {
                TenDanhMuc = txtName.Text.Trim(),
                MoTa = txtDesc.Text.Trim()
            };

            if (_catService.Add(cat, out string errorMessage))
            {
                MessageBox.Show("Thêm danh mục mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadCategories();
            }
            else
            {
                MessageBox.Show(errorMessage, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!_authService.IsAdmin())
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cat = new Category
            {
                Id = _selectedId,
                TenDanhMuc = txtName.Text.Trim(),
                MoTa = txtDesc.Text.Trim()
            };

            if (_catService.Update(cat, out string errorMessage))
            {
                MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadCategories();
            }
            else
            {
                MessageBox.Show(errorMessage, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_authService.IsAdmin())
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa danh mục '{txtName.Text}' không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_catService.Delete(_selectedId, out string errorMessage))
                {
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    LoadCategories();
                }
                else
                {
                    MessageBox.Show(errorMessage, "Lỗi khi xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            _selectedId = 0;
            txtName.Clear();
            txtDesc.Clear();
            txtSearch.Clear();

            bool isAdmin = _authService.IsAdmin();
            btnAdd.Enabled = isAdmin;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCategories.Rows.Count)
            {
                var row = dgvCategories.Rows[e.RowIndex];
                if (row.DataBoundItem is Category cat)
                {
                    _selectedId = cat.Id;
                    txtName.Text = cat.TenDanhMuc;
                    txtDesc.Text = cat.MoTa;

                    bool isAdmin = _authService.IsAdmin();
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = isAdmin;
                    btnDelete.Enabled = isAdmin;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            dgvCategories.DataSource = _catService.Search(keyword);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadCategories();
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
