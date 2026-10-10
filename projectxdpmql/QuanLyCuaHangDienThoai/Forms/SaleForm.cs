using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Services;

namespace QuanLyCuaHangDienThoai.Forms
{
    public partial class SaleForm : Form
    {
        private readonly ProductService _productService = new ProductService();
        private readonly CustomerService _customerService = new CustomerService();
        private readonly InvoiceService _invoiceService = new InvoiceService();
        private readonly AuthService _authService = AuthService.Instance;

        private List<Product> _allActiveProducts = new List<Product>();
        private BindingList<InvoiceDetail> _cartItems = new BindingList<InvoiceDetail>();

        public SaleForm()
        {
            InitializeComponent();
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            SetupCartDataGridView();
            LoadCustomers();
            LoadProducts();
            InitNewInvoice();
        }

        private void SetupCartDataGridView()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();
            dgvCart.DataSource = _cartItems;

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaSanPham", HeaderText = "Mã SP", Width = 110 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSanPham", HeaderText = "Tên sản phẩm", Width = 300 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DonViTinh", HeaderText = "ĐVT", Width = 80 });

            var colQty = new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "Số lượng", Width = 100 };
            colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCart.Columns.Add(colQty);

            var colPrice = new DataGridViewTextBoxColumn { DataPropertyName = "DonGia", HeaderText = "Đơn giá (VNĐ)", Width = 140 };
            colPrice.DefaultCellStyle.Format = "N0";
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCart.Columns.Add(colPrice);

            var colTotal = new DataGridViewTextBoxColumn { DataPropertyName = "ThanhTien", HeaderText = "Thành tiền (VNĐ)", Width = 160 };
            colTotal.DefaultCellStyle.Format = "N0";
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCart.Columns.Add(colTotal);
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = _customerService.GetAll();
                cboCustomer.DataSource = customers;
                cboCustomer.DisplayMember = "HoTen";
                cboCustomer.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                // Chỉ lấy các sản phẩm đang kinh doanh
                _allActiveProducts = _productService.GetAll().Where(p => p.TrangThai).ToList();
                FilterProductCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterProductCombo(string keyword = "")
        {
            var filtered = string.IsNullOrWhiteSpace(keyword)
                ? _allActiveProducts
                : _allActiveProducts.Where(p => 
                    p.MaSanPham.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    p.TenSanPham.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            cboProduct.DataSource = filtered;
            cboProduct.DisplayMember = "TenSanPham";
            cboProduct.ValueMember = "Id";

            if (filtered.Count > 0)
            {
                UpdateSelectedProductDetails(filtered[0]);
            }
            else
            {
                lblStockDisplay.Text = "0";
                lblPriceDisplay.Text = "0 VNĐ";
            }
        }

        private void UpdateSelectedProductDetails(Product p)
        {
            if (p != null)
            {
                lblStockDisplay.Text = p.SoLuongTon.ToString();
                lblPriceDisplay.Text = p.GiaBan.ToString("N0") + " VNĐ";
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedItem is Product p)
            {
                UpdateSelectedProductDetails(p);
            }
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            FilterProductCombo(txtSearchProduct.Text.Trim());
        }

        private void InitNewInvoice()
        {
            txtInvoiceCode.Text = _invoiceService.GenerateNewCode();
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            txtUser.Text = _authService.CurrentUser != null ? _authService.CurrentUser.Username : "Admin";

            _cartItems.Clear();
            UpdateTotalAmount();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (cboProduct.SelectedItem is not Product p)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)numQuantity.Value;
            if (quantity <= 0)
            {
                MessageBox.Show("Số lượng mua phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số lượng đã có trong giỏ hàng
            var existingItem = _cartItems.FirstOrDefault(i => i.ProductId == p.Id);
            int currentCartQty = existingItem != null ? existingItem.SoLuong : 0;
            int totalRequestedQty = currentCartQty + quantity;

            // Kiểm tra với tồn kho thực tế
            if (totalRequestedQty > p.SoLuongTon)
            {
                MessageBox.Show($"Sản phẩm '{p.TenSanPham}' chỉ còn {p.SoLuongTon} trong kho.\n" +
                                $"Giỏ hàng đã có {currentCartQty}, không thể thêm tiếp {quantity}!",
                                "Cảnh báo tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existingItem != null)
            {
                existingItem.SoLuong += quantity;
                existingItem.ThanhTien = existingItem.SoLuong * existingItem.DonGia;
                dgvCart.Refresh();
            }
            else
            {
                _cartItems.Add(new InvoiceDetail
                {
                    ProductId = p.Id,
                    MaSanPham = p.MaSanPham,
                    TenSanPham = p.TenSanPham,
                    DonViTinh = p.DonViTinh,
                    SoLuong = quantity,
                    DonGia = p.GiaBan,
                    ThanhTien = quantity * p.GiaBan
                });
            }

            numQuantity.Value = 1;
            UpdateTotalAmount();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null && dgvCart.CurrentRow.DataBoundItem is InvoiceDetail detail)
            {
                _cartItems.Remove(detail);
                UpdateTotalAmount();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mặt hàng trong giỏ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    _cartItems.Clear();
                    UpdateTotalAmount();
                }
            }
        }

        private void UpdateTotalAmount()
        {
            decimal total = _cartItems.Sum(i => i.ThanhTien);
            lblTotalAmount.Text = total.ToString("N0") + " VNĐ";
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng mua!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng chọn ít nhất 1 sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalAmount = _cartItems.Sum(i => i.ThanhTien);
            string customerName = cboCustomer.Text;

            DialogResult confirm = MessageBox.Show(
                $"Xác nhận thanh toán hóa đơn:\n" +
                $"- Khách hàng: {customerName}\n" +
                $"- Số lượng sản phẩm: {_cartItems.Count}\n" +
                $"- Tổng tiền: {totalAmount:N0} VNĐ\n\n" +
                $"Hệ thống sẽ tự động trừ tồn kho và tạo hóa đơn bán hàng.",
                "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            var invoice = new Invoice
            {
                MaHoaDon = txtInvoiceCode.Text.Trim(),
                CustomerId = (int)cboCustomer.SelectedValue,
                UserId = _authService.CurrentUser != null ? _authService.CurrentUser.Id : 1,
                NgayLap = DateTime.Now,
                TongTien = totalAmount
            };

            var detailsList = _cartItems.ToList();

            if (_invoiceService.CreateSale(invoice, detailsList, out string errorMessage))
            {
                MessageBox.Show($"Thanh toán thành công hóa đơn [{invoice.MaHoaDon}]!\nTổng tiền: {totalAmount:N0} VNĐ\nTồn kho sản phẩm đã được tự động cập nhật.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới dữ liệu
                LoadProducts();
                InitNewInvoice();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại:\n" + errorMessage, "Lỗi thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            InitNewInvoice();
        }
    }
}
