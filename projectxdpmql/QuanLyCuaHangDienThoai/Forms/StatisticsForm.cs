using System;
using System.Data;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.Services;

namespace QuanLyCuaHangDienThoai.Forms
{
    public partial class StatisticsForm : Form
    {
        private readonly StatisticsService _statsService = new StatisticsService();

        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpToDate.Value = DateTime.Today;

            SetupRevenueGrid();
            SetupTopProductsGrid();
            LoadReportData(dtpFromDate.Value, dtpToDate.Value);
        }

        private void SetupRevenueGrid()
        {
            dgvRevenueByDate.AutoGenerateColumns = false;
            dgvRevenueByDate.Columns.Clear();

            dgvRevenueByDate.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ngay", HeaderText = "Ngày", Width = 110 });

            var colCount = new DataGridViewTextBoxColumn { DataPropertyName = "SoHoaDon", HeaderText = "Số HĐ", Width = 90 };
            colCount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRevenueByDate.Columns.Add(colCount);

            var colRev = new DataGridViewTextBoxColumn { DataPropertyName = "DoanhThu", HeaderText = "Doanh thu ngày (VNĐ)", Width = 180 };
            colRev.DefaultCellStyle.Format = "N0";
            colRev.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRevenueByDate.Columns.Add(colRev);
        }

        private void SetupTopProductsGrid()
        {
            dgvTopProducts.AutoGenerateColumns = false;
            dgvTopProducts.Columns.Clear();

            dgvTopProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaSanPham", HeaderText = "Mã SP", Width = 90 });
            dgvTopProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSanPham", HeaderText = "Tên sản phẩm", Width = 180 });

            var colSold = new DataGridViewTextBoxColumn { DataPropertyName = "SoLuongDaBan", HeaderText = "Đã bán", Width = 80 };
            colSold.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTopProducts.Columns.Add(colSold);

            var colAmount = new DataGridViewTextBoxColumn { DataPropertyName = "TongTienBan", HeaderText = "Tổng tiền bán (VNĐ)", Width = 150 };
            colAmount.DefaultCellStyle.Format = "N0";
            colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTopProducts.Columns.Add(colAmount);
        }

        private void LoadReportData(DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                // 1. Thống kê tổng quan
                var overall = _statsService.GetOverallStats(fromDate, toDate);
                lblCardRevenueValue.Text = overall.TotalRevenue.ToString("N0") + " đ";
                lblCardInvoicesValue.Text = overall.TotalInvoices.ToString("N0");
                lblCardProductsValue.Text = overall.TotalProducts.ToString("N0");
                lblCardStockValue.Text = overall.TotalInventoryQuantity.ToString("N0");

                // 2. Doanh thu theo ngày
                DateTime start = fromDate ?? DateTime.Today.AddDays(-30);
                DateTime end = toDate ?? DateTime.Today;
                var dtRevenue = _statsService.GetRevenueByDate(start, end);
                dgvRevenueByDate.DataSource = dtRevenue;

                // 3. Top sản phẩm
                var dtTop = _statsService.GetTopSellingProducts(fromDate, toDate, 5);
                dgvTopProducts.DataSource = dtTop;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadReportData(dtpFromDate.Value, dtpToDate.Value);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpToDate.Value = DateTime.Today;
            LoadReportData(dtpFromDate.Value, dtpToDate.Value);
        }

        private void btnAllTime_Click(object sender, EventArgs e)
        {
            LoadReportData(null, null);
        }
    }
}
