using System;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Services;

namespace QuanLyCuaHangDienThoai.Forms
{
    public partial class SupplierForm : Form
    {
        private readonly SupplierService _supplierService = new SupplierService();
        private readonly AuthService _authService = AuthService.Instance;
        private int _selectedId = 0;

        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            pnlTop.Visible = false;
            ApplyPermissions();
            SetupDataGridView();
            LoadSuppliers();
            ResetForm();
            Utils.UITheme.BeautifyForm(this);
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
            Utils.UITheme.ApplyGridStyle(dgvSuppliers);
            dgvSuppliers.AutoGenerateColumns = false;
            dgvSuppliers.Columns.Clear();

            var colId = new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Mã NCC", Width = 90 };
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colId.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSuppliers.Columns.Add(colId);

            var colName = new DataGridViewTextBoxColumn { DataPropertyName = "TenNhaCungCap", HeaderText = "Tên nhà cung cấp", Width = 260 };
            colName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvSuppliers.Columns.Add(colName);

            var colPhone = new DataGridViewTextBoxColumn { DataPropertyName = "SoDienThoai", HeaderText = "Số điện thoại", Width = 140 };
            colPhone.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colPhone.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSuppliers.Columns.Add(colPhone);

            var colAddress = new DataGridViewTextBoxColumn { DataPropertyName = "DiaChi", HeaderText = "Địa chỉ", Width = 280 };
            colAddress.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvSuppliers.Columns.Add(colAddress);

            var colEmail = new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Width = 220 };
            colEmail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvSuppliers.Columns.Add(colEmail);
        }

        private void LoadSuppliers()
        {
            try
            {
                dgvSuppliers.DataSource = _supplierService.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!_authService.IsAdmin())
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var s = new Supplier
            {
                TenNhaCungCap = txtName.Text.Trim(),
                SoDienThoai = txtPhone.Text.Trim(),
                DiaChi = txtAddress.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            if (_supplierService.Add(s, out string errorMessage))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadSuppliers();
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
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var s = new Supplier
            {
                Id = _selectedId,
                TenNhaCungCap = txtName.Text.Trim(),
                SoDienThoai = txtPhone.Text.Trim(),
                DiaChi = txtAddress.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            if (_supplierService.Update(s, out string errorMessage))
            {
                MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadSuppliers();
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
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhà cung cấp '{txtName.Text}' không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_supplierService.Delete(_selectedId, out string errorMessage))
                {
                    MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    LoadSuppliers();
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
            txtPhone.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtSearch.Clear();

            bool isAdmin = _authService.IsAdmin();
            btnAdd.Enabled = isAdmin;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSuppliers.Rows.Count)
            {
                var row = dgvSuppliers.Rows[e.RowIndex];
                if (row.DataBoundItem is Supplier s)
                {
                    _selectedId = s.Id;
                    txtName.Text = s.TenNhaCungCap;
                    txtPhone.Text = s.SoDienThoai;
                    txtAddress.Text = s.DiaChi;
                    txtEmail.Text = s.Email;

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
            dgvSuppliers.DataSource = _supplierService.Search(keyword);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadSuppliers();
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
