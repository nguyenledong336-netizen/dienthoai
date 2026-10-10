using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Services;

namespace QuanLyCuaHangDienThoai.Forms
{
    public partial class ProductForm : Form
    {
        private readonly ProductService _productService = new ProductService();
        private readonly CategoryService _catService = new CategoryService();
        private readonly AuthService _authService = AuthService.Instance;
        private int _selectedId = 0;

        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
            LoadCategories();
            SetupDataGridView();
            LoadProducts();
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

        private void LoadCategories()
        {
            try
            {
                var categories = _catService.GetAll();
                cboCategory.DataSource = categories;
                cboCategory.DisplayMember = "TenDanhMuc";
                cboCategory.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Width = 50 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaSanPham", HeaderText = "Mã SP", Width = 110 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSanPham", HeaderText = "Tên sản phẩm", Width = 230 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenDanhMuc", HeaderText = "Danh mục", Width = 140 });

            var colImport = new DataGridViewTextBoxColumn { DataPropertyName = "GiaNhap", HeaderText = "Giá nhập (VNĐ)", Width = 115 };
            colImport.DefaultCellStyle.Format = "N0";
            colImport.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns.Add(colImport);

            var colPrice = new DataGridViewTextBoxColumn { DataPropertyName = "GiaBan", HeaderText = "Giá bán (VNĐ)", Width = 115 };
            colPrice.DefaultCellStyle.Format = "N0";
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns.Add(colPrice);

            var colStock = new DataGridViewTextBoxColumn { DataPropertyName = "SoLuongTon", HeaderText = "Tồn kho", Width = 80 };
            colStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducts.Columns.Add(colStock);

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DonViTinh", HeaderText = "ĐVT", Width = 70 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThaiHienThi", HeaderText = "Trạng thái", Width = 120 });
        }

        private void LoadProducts()
        {
            try
            {
                dgvProducts.DataSource = _productService.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!_authService.IsAdmin())
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục cho sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var p = new Product
            {
                MaSanPham = txtCode.Text.Trim().ToUpper(),
                TenSanPham = txtName.Text.Trim(),
                CategoryId = (int)cboCategory.SelectedValue,
                GiaNhap = numImportPrice.Value,
                GiaBan = numPrice.Value,
                SoLuongTon = (int)numStock.Value,
                DonViTinh = string.IsNullOrWhiteSpace(txtUnit.Text) ? "Chiếc" : txtUnit.Text.Trim(),
                TrangThai = chkStatus.Checked
            };

            if (_productService.Add(p, out string errorMessage))
            {
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadProducts();
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
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục cho sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var p = new Product
            {
                Id = _selectedId,
                MaSanPham = txtCode.Text.Trim().ToUpper(),
                TenSanPham = txtName.Text.Trim(),
                CategoryId = (int)cboCategory.SelectedValue,
                GiaNhap = numImportPrice.Value,
                GiaBan = numPrice.Value,
                DonViTinh = string.IsNullOrWhiteSpace(txtUnit.Text) ? "Chiếc" : txtUnit.Text.Trim(),
                TrangThai = chkStatus.Checked
            };

            if (_productService.Update(p, out string errorMessage))
            {
                MessageBox.Show("Cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadProducts();
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
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm [{txtCode.Text}] '{txtName.Text}' không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_productService.Delete(_selectedId, out string errorMessage))
                {
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    LoadProducts();
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
            txtCode.Clear();
            txtCode.Enabled = true;
            txtName.Clear();
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            numImportPrice.Value = 0;
            numPrice.Value = 0;
            numStock.Value = 0;
            numStock.Enabled = true;
            txtUnit.Text = "Chiếc";
            chkStatus.Checked = true;
            txtSearch.Clear();

            bool isAdmin = _authService.IsAdmin();
            btnAdd.Enabled = isAdmin;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvProducts.Rows.Count)
            {
                var row = dgvProducts.Rows[e.RowIndex];
                if (row.DataBoundItem is Product p)
                {
                    _selectedId = p.Id;
                    txtCode.Text = p.MaSanPham;
                    txtName.Text = p.TenSanPham;
                    cboCategory.SelectedValue = p.CategoryId;
                    numImportPrice.Value = p.GiaNhap;
                    numPrice.Value = p.GiaBan;
                    numStock.Value = p.SoLuongTon;
                    numStock.Enabled = false; // Tồn kho chỉ thay đổi qua Nhập hàng hoặc Bán hàng!
                    txtUnit.Text = p.DonViTinh;
                    chkStatus.Checked = p.TrangThai;

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
            dgvProducts.DataSource = _productService.Search(keyword);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadProducts();
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
