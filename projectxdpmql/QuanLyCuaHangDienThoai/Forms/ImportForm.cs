using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Services;

namespace QuanLyCuaHangDienThoai.Forms
{
    public partial class ImportForm : Form
    {
        private readonly SupplierService _supplierService = new SupplierService();
        private readonly ProductService _productService = new ProductService();
        private readonly InventoryService _inventoryService = new InventoryService();
        private readonly AuthService _authService = AuthService.Instance;

        public ImportForm()
        {
            InitializeComponent();
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
            LoadSuppliers();
            LoadProducts();
            SetupDataGridView();
            LoadImportHistory();
            CalculateTotal();
        }

        private void ApplyPermissions()
        {
            if (!_authService.IsAdmin())
            {
                btnSaveImport.Enabled = false;
                grpImport.Enabled = false;
                grpImport.Text = "Thông tin nhập hàng (Chỉ Quản trị viên mới có quyền Nhập hàng)";
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                var suppliers = _supplierService.GetAll();
                cboSupplier.DataSource = suppliers;
                cboSupplier.DisplayMember = "TenNhaCungCap";
                cboSupplier.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                var products = _productService.GetAll();
                cboProduct.DataSource = products;
                cboProduct.DisplayMember = "TenSanPham";
                cboProduct.ValueMember = "Id";

                if (products.Count > 0)
                {
                    UpdateProductDetails(products[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProductDetails(Product p)
        {
            if (p != null)
            {
                lblStockDisplay.Text = p.SoLuongTon.ToString();
                numImportPrice.Value = p.GiaNhap;
                CalculateTotal();
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedItem is Product p)
            {
                UpdateProductDetails(p);
            }
        }

        private void numPriceOrQty_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = numQuantity.Value * numImportPrice.Value;
            lblTotalAmount.Text = total.ToString("N0") + " VNĐ";
        }

        private void SetupDataGridView()
        {
            dgvImportHistory.AutoGenerateColumns = false;
            dgvImportHistory.Columns.Clear();

            dgvImportHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Mã GD", Width = 70 });
            dgvImportHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaSanPham", HeaderText = "Mã SP", Width = 110 });
            dgvImportHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSanPham", HeaderText = "Tên sản phẩm", Width = 230 });

            var colQty = new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "Số lượng nhập", Width = 110 };
            colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvImportHistory.Columns.Add(colQty);

            var colPrice = new DataGridViewTextBoxColumn { DataPropertyName = "DonGia", HeaderText = "Đơn giá nhập (VNĐ)", Width = 140 };
            colPrice.DefaultCellStyle.Format = "N0";
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvImportHistory.Columns.Add(colPrice);

            var colDate = new DataGridViewTextBoxColumn { DataPropertyName = "NgayGiaoDich", HeaderText = "Ngày nhập", Width = 130 };
            colDate.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvImportHistory.Columns.Add(colDate);

            dgvImportHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Người nhập", Width = 110 });
            dgvImportHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GhiChu", HeaderText = "Ghi chú", Width = 200 });
        }

        private void LoadImportHistory()
        {
            try
            {
                var transactions = _inventoryService.GetAllTransactions()
                    .Where(t => t.LoaiGiaoDich == "NHAP")
                    .ToList();
                dgvImportHistory.DataSource = transactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử nhập hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveImport_Click(object sender, EventArgs e)
        {
            if (!_authService.IsAdmin())
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboSupplier.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboProduct.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = (int)cboProduct.SelectedValue;
            int quantity = (int)numQuantity.Value;
            decimal importPrice = numImportPrice.Value;
            string supplierName = cboSupplier.Text;
            string note = $"Nhập từ NCC {supplierName}. {txtNote.Text.Trim()}".Trim();

            if (quantity <= 0)
            {
                MessageBox.Show("Số lượng nhập phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (importPrice < 0)
            {
                MessageBox.Show("Giá nhập không được âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = _authService.CurrentUser != null ? _authService.CurrentUser.Id : 1;

            if (_inventoryService.ImportProduct(productId, quantity, importPrice, userId, note, out string errorMessage))
            {
                MessageBox.Show($"Nhập hàng thành công!\nSố lượng: +{quantity}\nĐơn giá: {importPrice:N0} VNĐ", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload lại thông tin
                LoadProducts();
                // Chọn lại sản phẩm vừa nhập
                cboProduct.SelectedValue = productId;
                if (cboProduct.SelectedItem is Product currentP)
                {
                    UpdateProductDetails(currentP);
                }

                LoadImportHistory();
                txtNote.Clear();
                numQuantity.Value = 1;
            }
            else
            {
                MessageBox.Show(errorMessage, "Lỗi khi nhập hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            numQuantity.Value = 1;
            txtNote.Clear();
            if (cboProduct.Items.Count > 0)
            {
                cboProduct.SelectedIndex = 0;
            }
            CalculateTotal();
        }
    }
}
