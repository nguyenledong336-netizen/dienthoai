using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Services;

namespace QuanLyCuaHangDienThoai.Forms
{
    public partial class InventoryForm : Form
    {
        private readonly ProductService _productService = new ProductService();

        public InventoryForm()
        {
            InitializeComponent();
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadInventoryData();
        }

        private void SetupDataGridView()
        {
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.Columns.Clear();

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaSanPham", HeaderText = "Mã SP", Width = 110 });
            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSanPham", HeaderText = "Tên sản phẩm", Width = 260 });
            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenDanhMuc", HeaderText = "Danh mục", Width = 150 });
            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DonViTinh", HeaderText = "ĐVT", Width = 80 });

            var colStock = new DataGridViewTextBoxColumn { DataPropertyName = "SoLuongTon", HeaderText = "Số lượng tồn", Width = 120 };
            colStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStock.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvInventory.Columns.Add(colStock);

            var colImport = new DataGridViewTextBoxColumn { DataPropertyName = "GiaNhap", HeaderText = "Giá vốn (VNĐ)", Width = 130 };
            colImport.DefaultCellStyle.Format = "N0";
            colImport.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInventory.Columns.Add(colImport);

            var colPrice = new DataGridViewTextBoxColumn { DataPropertyName = "GiaBan", HeaderText = "Giá niêm yết (VNĐ)", Width = 140 };
            colPrice.DefaultCellStyle.Format = "N0";
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInventory.Columns.Add(colPrice);

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThaiHienThi", HeaderText = "Trạng thái", Width = 130 });
        }

        private string GetSelectedFilterType()
        {
            if (radOutOfStock.Checked) return "OUT_OF_STOCK";
            if (radLowStock.Checked) return "LOW_STOCK";
            if (radInStock.Checked) return "IN_STOCK";
            return "ALL";
        }

        private void LoadInventoryData()
        {
            try
            {
                string filterType = GetSelectedFilterType();
                string keyword = txtSearch.Text.Trim();

                var list = _productService.FilterStock(filterType, keyword);
                dgvInventory.DataSource = list;

                // Thống kê nhanh
                int totalProducts = list.Count;
                int totalQty = list.Sum(p => p.SoLuongTon);
                decimal totalCapital = list.Sum(p => p.SoLuongTon * p.GiaNhap);

                lblTotalProducts.Text = $"Tổng số mặt hàng: {totalProducts}";
                lblTotalStockQty.Text = $"Tổng số lượng tồn: {totalQty:N0}";
                lblTotalStockValue.Text = $"Tổng giá trị vốn: {totalCapital:N0} đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu tồn kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rad && rad.Checked)
            {
                LoadInventoryData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadInventoryData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            radAll.Checked = true;
            LoadInventoryData();
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

        private void dgvInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvInventory.Rows.Count)
            {
                var row = dgvInventory.Rows[e.RowIndex];
                if (row.DataBoundItem is Product p)
                {
                    if (p.SoLuongTon == 0)
                    {
                        // Hết hàng: Tô nền hồng nhạt, chữ đỏ
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);
                    }
                    else if (p.SoLuongTon <= 5)
                    {
                        // Sắp hết hàng: Tô nền vàng nhạt, chữ cam đậm
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 230);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(211, 84, 0);
                    }
                }
            }
        }
    }
}
