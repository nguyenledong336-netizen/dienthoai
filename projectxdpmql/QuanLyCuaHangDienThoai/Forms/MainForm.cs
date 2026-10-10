using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.Services;

namespace QuanLyCuaHangDienThoai.Forms
{
    public partial class MainForm : Form
    {
        private readonly AuthService _authService = AuthService.Instance;
        private Form _activeChildForm = null;
        private Button _activeNavButton = null;

        public MainForm()
        {
            InitializeComponent();
            SetupNavigationHover();
            pnlTopBar.Paint += PnlTopBar_Paint;
        }

        private void PnlTopBar_Paint(object sender, PaintEventArgs e)
        {
            // Vẽ đường kẻ viền mảnh bên dưới TopBar
            using (var pen = new Pen(Color.FromArgb(229, 231, 235), 1f))
            {
                e.Graphics.DrawLine(pen, 0, pnlTopBar.Height - 1, pnlTopBar.Width, pnlTopBar.Height - 1);
            }
        }

        private void SetupNavigationHover()
        {
            Button[] navButtons = new Button[]
            {
                btnNavDashboard, btnNavUsers, btnNavProducts, btnNavCategories,
                btnNavCustomers, btnNavSuppliers, btnNavSale, btnNavImport,
                btnNavInvoices, btnNavInventory, btnNavStatistics
            };

            foreach (var btn in navButtons)
            {
                btn.MouseEnter += (s, e) =>
                {
                    if (btn != _activeNavButton)
                    {
                        btn.BackColor = Color.FromArgb(30, 41, 59); // #1E293B
                        btn.ForeColor = Color.White;
                    }
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn != _activeNavButton)
                    {
                        btn.BackColor = Color.Transparent;
                        btn.ForeColor = Color.FromArgb(203, 213, 225); // #CBD5E1
                    }
                };
            }

            btnNavLogout.MouseEnter += (s, e) => { btnNavLogout.BackColor = Color.FromArgb(40, 25, 35); };
            btnNavLogout.MouseLeave += (s, e) => { btnNavLogout.BackColor = Color.Transparent; };

            btnNavExit.MouseEnter += (s, e) => { btnNavExit.BackColor = Color.FromArgb(50, 20, 25); };
            btnNavExit.MouseLeave += (s, e) => { btnNavExit.BackColor = Color.Transparent; };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateUserInfo();
            UpdateClock();
            // Mở trang Thống kê làm Dashboard ban đầu rất đẹp và trực quan
            btnNavDashboard_Click(btnNavDashboard, EventArgs.Empty);
        }

        private void UpdateUserInfo()
        {
            if (_authService.CurrentUser != null)
            {
                lblUsername.Text = _authService.CurrentUser.Username;
                lblUserRole.Text = _authService.IsAdmin() ? "QUẢN TRỊ VIÊN" : "NHÂN VIÊN";

                if (_authService.IsAdmin())
                {
                    lblUserRole.ForeColor = Color.FromArgb(245, 158, 11); // Vàng hổ phách cho Admin (#F59E0B)
                }
                else
                {
                    lblUserRole.ForeColor = Color.FromArgb(34, 197, 94); // Xanh lá ngọc (#22C55E)
                }
            }
        }

        private void UpdateClock()
        {
            lblClock.Text = $"📅 {DateTime.Now:dd/MM/yyyy}   ⏰ {DateTime.Now:HH:mm:ss}";
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        /// <summary>
        /// Nhúng Form con vào pnlContent mà không làm vỡ giao diện
        /// </summary>
        public void ShowChildForm(Form childForm, string title, Button activeBtn)
        {
            if (_activeChildForm != null)
            {
                _activeChildForm.Close();
                _activeChildForm.Dispose();
            }

            // Đổi màu nút active trên sidebar
            HighlightNavButton(activeBtn);

            _activeChildForm = childForm;
            lblCurrentPageTitle.Text = title.ToUpper();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void HighlightNavButton(Button btn)
        {
            if (_activeNavButton != null)
            {
                _activeNavButton.BackColor = Color.Transparent;
                _activeNavButton.ForeColor = Color.FromArgb(203, 213, 225);
                _activeNavButton.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            }

            _activeNavButton = btn;
            if (_activeNavButton != null)
            {
                _activeNavButton.BackColor = Color.FromArgb(25, 118, 210); // #1976D2
                _activeNavButton.ForeColor = Color.White;
                _activeNavButton.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            }
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            // Trang Thống kê với các thẻ KPI doanh thu & kho làm Dashboard
            ShowChildForm(new StatisticsForm(), "Dashboard Tổng Quan", btnNavDashboard);
        }

        private void btnNavUsers_Click(object sender, EventArgs e)
        {
            // Kiểm tra phân quyền trực tiếp bằng code
            if (!_authService.IsAdmin())
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!\nChỉ Quản trị viên (Admin) mới có quyền quản lý người dùng hệ thống.",
                    "Từ chối quyền truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShowChildForm(new UserForm(), "Quản Lý Người Dùng Hệ Thống", btnNavUsers);
        }

        private void btnNavProducts_Click(object sender, EventArgs e)
        {
            ShowChildForm(new ProductForm(), "Quản Lý Sản Phẩm & Điện Thoại", btnNavProducts);
        }

        private void btnNavCategories_Click(object sender, EventArgs e)
        {
            ShowChildForm(new CategoryForm(), "Quản Lý Danh Mục Sản Phẩm", btnNavCategories);
        }

        private void btnNavCustomers_Click(object sender, EventArgs e)
        {
            ShowChildForm(new CustomerForm(), "Quản Lý Khách Hàng", btnNavCustomers);
        }

        private void btnNavSuppliers_Click(object sender, EventArgs e)
        {
            ShowChildForm(new SupplierForm(), "Quản Lý Nhà Cung Cấp", btnNavSuppliers);
        }

        private void btnNavSale_Click(object sender, EventArgs e)
        {
            ShowChildForm(new SaleForm(), "Bán Hàng & Xuất Hóa Đơn", btnNavSale);
        }

        private void btnNavImport_Click(object sender, EventArgs e)
        {
            if (!_authService.IsAdmin())
            {
                MessageBox.Show("Chỉ Quản trị viên (Admin) mới có quyền nhập hàng vào kho!",
                    "Từ chối quyền truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShowChildForm(new ImportForm(), "Quản Lý Nhập Hàng Vào Kho", btnNavImport);
        }

        private void btnNavInvoices_Click(object sender, EventArgs e)
        {
            ShowChildForm(new InvoiceForm(), "Tra Cứu & Quản Lý Hóa Đơn Bán", btnNavInvoices);
        }

        private void btnNavInventory_Click(object sender, EventArgs e)
        {
            ShowChildForm(new InventoryForm(), "Theo Dõi & Kiểm Soát Tồn Kho", btnNavInventory);
        }

        private void btnNavStatistics_Click(object sender, EventArgs e)
        {
            ShowChildForm(new StatisticsForm(), "Báo Cáo Doanh Thu & Thống Kê", btnNavStatistics);
        }

        private void btnNavLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất tài khoản không?",
                "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _authService.Logout();
                this.Close(); // Đóng MainForm, LoginForm sẽ hiện lại
            }
        }

        private void btnNavExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_activeChildForm != null)
            {
                _activeChildForm.Close();
                _activeChildForm.Dispose();
                _activeChildForm = null;
            }
        }
    }
}
