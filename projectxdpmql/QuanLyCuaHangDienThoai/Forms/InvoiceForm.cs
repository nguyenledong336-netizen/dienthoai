using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Services;

namespace QuanLyCuaHangDienThoai.Forms
{
    public partial class InvoiceForm : Form
    {
        private readonly InvoiceService _invoiceService = new InvoiceService();

        public InvoiceForm()
        {
            InitializeComponent();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Today.AddDays(-30);
            dtpToDate.Value = DateTime.Today;

            SetupInvoicesGrid();
            SetupDetailsGrid();
            LoadInvoices();
        }

        private void SetupInvoicesGrid()
        {
            dgvInvoices.AutoGenerateColumns = false;
            dgvInvoices.Columns.Clear();

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Width = 60 });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaHoaDon", HeaderText = "Mã hóa đơn", Width = 120 });

            var colDate = new DataGridViewTextBoxColumn { DataPropertyName = "NgayLap", HeaderText = "Ngày lập", Width = 140 };
            colDate.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvInvoices.Columns.Add(colDate);

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenKhachHang", HeaderText = "Khách hàng", Width = 180 });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoDienThoaiKhachHang", HeaderText = "SĐT", Width = 120 });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenNhanVien", HeaderText = "Nhân viên bán", Width = 130 });

            var colTotal = new DataGridViewTextBoxColumn { DataPropertyName = "TongTien", HeaderText = "Tổng tiền (VNĐ)", Width = 150 };
            colTotal.DefaultCellStyle.Format = "N0";
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInvoices.Columns.Add(colTotal);
        }

        private void SetupDetailsGrid()
        {
            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.Columns.Clear();

            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaSanPham", HeaderText = "Mã SP", Width = 110 });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSanPham", HeaderText = "Tên sản phẩm", Width = 280 });
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DonViTinh", HeaderText = "ĐVT", Width = 80 });

            var colQty = new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "Số lượng", Width = 100 };
            colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetails.Columns.Add(colQty);

            var colPrice = new DataGridViewTextBoxColumn { DataPropertyName = "DonGia", HeaderText = "Đơn giá (VNĐ)", Width = 150 };
            colPrice.DefaultCellStyle.Format = "N0";
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetails.Columns.Add(colPrice);

            var colTotal = new DataGridViewTextBoxColumn { DataPropertyName = "ThanhTien", HeaderText = "Thành tiền (VNĐ)", Width = 160 };
            colTotal.DefaultCellStyle.Format = "N0";
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetails.Columns.Add(colTotal);
        }

        private void LoadInvoices()
        {
            try
            {
                var list = _invoiceService.GetAll();
                dgvInvoices.DataSource = list;
                if (list.Count > 0)
                {
                    LoadInvoiceDetails(list[0]);
                }
                else
                {
                    dgvDetails.DataSource = null;
                    lblSelectedInvoiceInfo.Text = "Không có hóa đơn nào.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInvoiceDetails(Invoice inv)
        {
            if (inv == null) return;

            try
            {
                var details = _invoiceService.GetDetails(inv.Id);
                dgvDetails.DataSource = details;
                lblSelectedInvoiceInfo.Text = $"Chi tiết HĐ [{inv.MaHoaDon}] - Khách hàng: {inv.TenKhachHang} - Tổng tiền: {inv.TongTien:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvInvoices.Rows.Count)
            {
                var row = dgvInvoices.Rows[e.RowIndex];
                if (row.DataBoundItem is Invoice inv)
                {
                    LoadInvoiceDetails(inv);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            DateTime fromDate = dtpFromDate.Value;
            DateTime toDate = dtpToDate.Value;

            if (fromDate > toDate)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var list = _invoiceService.Search(keyword, fromDate, toDate);
                dgvInvoices.DataSource = list;
                if (list.Count > 0)
                {
                    LoadInvoiceDetails(list[0]);
                }
                else
                {
                    dgvDetails.DataSource = null;
                    lblSelectedInvoiceInfo.Text = "Không tìm thấy hóa đơn nào phù hợp với điều kiện tìm kiếm.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            dtpFromDate.Value = DateTime.Today.AddDays(-30);
            dtpToDate.Value = DateTime.Today;
            LoadInvoices();
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
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
