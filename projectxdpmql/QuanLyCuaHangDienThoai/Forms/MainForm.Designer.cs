namespace QuanLyCuaHangDienThoai.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblAppSub;
        private System.Windows.Forms.Panel pnlUserInfo;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Label lblCat1;
        private System.Windows.Forms.Button btnNavUsers;
        private System.Windows.Forms.Button btnNavProducts;
        private System.Windows.Forms.Button btnNavCategories;
        private System.Windows.Forms.Button btnNavCustomers;
        private System.Windows.Forms.Button btnNavSuppliers;
        private System.Windows.Forms.Label lblCat2;
        private System.Windows.Forms.Button btnNavSale;
        private System.Windows.Forms.Button btnNavImport;
        private System.Windows.Forms.Button btnNavInvoices;
        private System.Windows.Forms.Label lblCat3;
        private System.Windows.Forms.Button btnNavInventory;
        private System.Windows.Forms.Button btnNavStatistics;
        private System.Windows.Forms.Label lblCat4;
        private System.Windows.Forms.Button btnNavLogout;
        private System.Windows.Forms.Button btnNavExit;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblCurrentPageTitle;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Timer timerClock;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnNavExit = new System.Windows.Forms.Button();
            this.btnNavLogout = new System.Windows.Forms.Button();
            this.lblCat4 = new System.Windows.Forms.Label();
            this.btnNavStatistics = new System.Windows.Forms.Button();
            this.btnNavInventory = new System.Windows.Forms.Button();
            this.lblCat3 = new System.Windows.Forms.Label();
            this.btnNavInvoices = new System.Windows.Forms.Button();
            this.btnNavImport = new System.Windows.Forms.Button();
            this.btnNavSale = new System.Windows.Forms.Button();
            this.lblCat2 = new System.Windows.Forms.Label();
            this.btnNavSuppliers = new System.Windows.Forms.Button();
            this.btnNavCustomers = new System.Windows.Forms.Button();
            this.btnNavCategories = new System.Windows.Forms.Button();
            this.btnNavProducts = new System.Windows.Forms.Button();
            this.btnNavUsers = new System.Windows.Forms.Button();
            this.lblCat1 = new System.Windows.Forms.Label();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.pnlUserInfo = new System.Windows.Forms.Panel();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblAppSub = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblCurrentPageTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlUserInfo.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.pnlSidebar.Controls.Add(this.pnlNav);
            this.pnlSidebar.Controls.Add(this.pnlUserInfo);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 780);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlNav
            // 
            this.pnlNav.AutoScroll = true;
            this.pnlNav.Controls.Add(this.btnNavExit);
            this.pnlNav.Controls.Add(this.btnNavLogout);
            this.pnlNav.Controls.Add(this.lblCat4);
            this.pnlNav.Controls.Add(this.btnNavStatistics);
            this.pnlNav.Controls.Add(this.btnNavInventory);
            this.pnlNav.Controls.Add(this.lblCat3);
            this.pnlNav.Controls.Add(this.btnNavInvoices);
            this.pnlNav.Controls.Add(this.btnNavImport);
            this.pnlNav.Controls.Add(this.btnNavSale);
            this.pnlNav.Controls.Add(this.lblCat2);
            this.pnlNav.Controls.Add(this.btnNavSuppliers);
            this.pnlNav.Controls.Add(this.btnNavCustomers);
            this.pnlNav.Controls.Add(this.btnNavCategories);
            this.pnlNav.Controls.Add(this.btnNavProducts);
            this.pnlNav.Controls.Add(this.btnNavUsers);
            this.pnlNav.Controls.Add(this.lblCat1);
            this.pnlNav.Controls.Add(this.btnNavDashboard);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNav.Location = new System.Drawing.Point(0, 150);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(250, 630);
            this.pnlNav.TabIndex = 2;
            // 
            // btnNavExit
            // 
            this.btnNavExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavExit.FlatAppearance.BorderSize = 0;
            this.btnNavExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavExit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnNavExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavExit.Location = new System.Drawing.Point(0, 560);
            this.btnNavExit.Name = "btnNavExit";
            this.btnNavExit.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavExit.Size = new System.Drawing.Size(240, 40);
            this.btnNavExit.TabIndex = 16;
            this.btnNavExit.Text = "✕  Thoát";
            this.btnNavExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavExit.UseVisualStyleBackColor = true;
            this.btnNavExit.Click += new System.EventHandler(this.btnNavExit_Click);
            // 
            // btnNavLogout
            // 
            this.btnNavLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavLogout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavLogout.FlatAppearance.BorderSize = 0;
            this.btnNavLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavLogout.Location = new System.Drawing.Point(0, 520);
            this.btnNavLogout.Name = "btnNavLogout";
            this.btnNavLogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavLogout.Size = new System.Drawing.Size(240, 40);
            this.btnNavLogout.TabIndex = 15;
            this.btnNavLogout.Text = "🚪  Đăng xuất";
            this.btnNavLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavLogout.UseVisualStyleBackColor = true;
            this.btnNavLogout.Click += new System.EventHandler(this.btnNavLogout_Click);
            // 
            // lblCat4
            // 
            this.lblCat4.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCat4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCat4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblCat4.Location = new System.Drawing.Point(0, 492);
            this.lblCat4.Name = "lblCat4";
            this.lblCat4.Padding = new System.Windows.Forms.Padding(18, 10, 0, 0);
            this.lblCat4.Size = new System.Drawing.Size(240, 28);
            this.lblCat4.TabIndex = 14;
            this.lblCat4.Text = "HỆ THỐNG";
            // 
            // btnNavStatistics
            // 
            this.btnNavStatistics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavStatistics.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavStatistics.FlatAppearance.BorderSize = 0;
            this.btnNavStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavStatistics.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavStatistics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavStatistics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavStatistics.Location = new System.Drawing.Point(0, 452);
            this.btnNavStatistics.Name = "btnNavStatistics";
            this.btnNavStatistics.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavStatistics.Size = new System.Drawing.Size(240, 40);
            this.btnNavStatistics.TabIndex = 13;
            this.btnNavStatistics.Text = "📈  Báo cáo";
            this.btnNavStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavStatistics.UseVisualStyleBackColor = true;
            this.btnNavStatistics.Click += new System.EventHandler(this.btnNavStatistics_Click);
            // 
            // btnNavInventory
            // 
            this.btnNavInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavInventory.FlatAppearance.BorderSize = 0;
            this.btnNavInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavInventory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavInventory.Location = new System.Drawing.Point(0, 412);
            this.btnNavInventory.Name = "btnNavInventory";
            this.btnNavInventory.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavInventory.Size = new System.Drawing.Size(240, 40);
            this.btnNavInventory.TabIndex = 12;
            this.btnNavInventory.Text = "📊  Tồn kho";
            this.btnNavInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavInventory.UseVisualStyleBackColor = true;
            this.btnNavInventory.Click += new System.EventHandler(this.btnNavInventory_Click);
            // 
            // lblCat3
            // 
            this.lblCat3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCat3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCat3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblCat3.Location = new System.Drawing.Point(0, 384);
            this.lblCat3.Name = "lblCat3";
            this.lblCat3.Padding = new System.Windows.Forms.Padding(18, 10, 0, 0);
            this.lblCat3.Size = new System.Drawing.Size(240, 28);
            this.lblCat3.TabIndex = 11;
            this.lblCat3.Text = "KHO & THỐNG KÊ";
            // 
            // btnNavInvoices
            // 
            this.btnNavInvoices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavInvoices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavInvoices.FlatAppearance.BorderSize = 0;
            this.btnNavInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavInvoices.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavInvoices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavInvoices.Location = new System.Drawing.Point(0, 344);
            this.btnNavInvoices.Name = "btnNavInvoices";
            this.btnNavInvoices.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavInvoices.Size = new System.Drawing.Size(240, 40);
            this.btnNavInvoices.TabIndex = 10;
            this.btnNavInvoices.Text = "🧾  Hóa đơn";
            this.btnNavInvoices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavInvoices.UseVisualStyleBackColor = true;
            this.btnNavInvoices.Click += new System.EventHandler(this.btnNavInvoices_Click);
            // 
            // btnNavImport
            // 
            this.btnNavImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavImport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavImport.FlatAppearance.BorderSize = 0;
            this.btnNavImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavImport.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavImport.Location = new System.Drawing.Point(0, 304);
            this.btnNavImport.Name = "btnNavImport";
            this.btnNavImport.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavImport.Size = new System.Drawing.Size(240, 40);
            this.btnNavImport.TabIndex = 9;
            this.btnNavImport.Text = "📦  Nhập hàng";
            this.btnNavImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavImport.UseVisualStyleBackColor = true;
            this.btnNavImport.Click += new System.EventHandler(this.btnNavImport_Click);
            // 
            // btnNavSale
            // 
            this.btnNavSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavSale.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavSale.FlatAppearance.BorderSize = 0;
            this.btnNavSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSale.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSale.Location = new System.Drawing.Point(0, 264);
            this.btnNavSale.Name = "btnNavSale";
            this.btnNavSale.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavSale.Size = new System.Drawing.Size(240, 40);
            this.btnNavSale.TabIndex = 8;
            this.btnNavSale.Text = "🛒  Bán hàng";
            this.btnNavSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSale.UseVisualStyleBackColor = true;
            this.btnNavSale.Click += new System.EventHandler(this.btnNavSale_Click);
            // 
            // lblCat2
            // 
            this.lblCat2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCat2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCat2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblCat2.Location = new System.Drawing.Point(0, 236);
            this.lblCat2.Name = "lblCat2";
            this.lblCat2.Padding = new System.Windows.Forms.Padding(18, 10, 0, 0);
            this.lblCat2.Size = new System.Drawing.Size(240, 28);
            this.lblCat2.TabIndex = 7;
            this.lblCat2.Text = "NGHIỆP VỤ";
            // 
            // btnNavSuppliers
            // 
            this.btnNavSuppliers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavSuppliers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavSuppliers.FlatAppearance.BorderSize = 0;
            this.btnNavSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSuppliers.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavSuppliers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSuppliers.Location = new System.Drawing.Point(0, 196);
            this.btnNavSuppliers.Name = "btnNavSuppliers";
            this.btnNavSuppliers.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavSuppliers.Size = new System.Drawing.Size(240, 40);
            this.btnNavSuppliers.TabIndex = 6;
            this.btnNavSuppliers.Text = "🏢  Nhà cung cấp";
            this.btnNavSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSuppliers.UseVisualStyleBackColor = true;
            this.btnNavSuppliers.Click += new System.EventHandler(this.btnNavSuppliers_Click);
            // 
            // btnNavCustomers
            // 
            this.btnNavCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavCustomers.FlatAppearance.BorderSize = 0;
            this.btnNavCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCustomers.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCustomers.Location = new System.Drawing.Point(0, 156);
            this.btnNavCustomers.Name = "btnNavCustomers";
            this.btnNavCustomers.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavCustomers.Size = new System.Drawing.Size(240, 40);
            this.btnNavCustomers.TabIndex = 5;
            this.btnNavCustomers.Text = "👥  Khách hàng";
            this.btnNavCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCustomers.UseVisualStyleBackColor = true;
            this.btnNavCustomers.Click += new System.EventHandler(this.btnNavCustomers_Click);
            // 
            // btnNavCategories
            // 
            this.btnNavCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavCategories.FlatAppearance.BorderSize = 0;
            this.btnNavCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCategories.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavCategories.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCategories.Location = new System.Drawing.Point(0, 116);
            this.btnNavCategories.Name = "btnNavCategories";
            this.btnNavCategories.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavCategories.Size = new System.Drawing.Size(240, 40);
            this.btnNavCategories.TabIndex = 4;
            this.btnNavCategories.Text = "📂  Danh mục";
            this.btnNavCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCategories.UseVisualStyleBackColor = true;
            this.btnNavCategories.Click += new System.EventHandler(this.btnNavCategories_Click);
            // 
            // btnNavProducts
            // 
            this.btnNavProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavProducts.FlatAppearance.BorderSize = 0;
            this.btnNavProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavProducts.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavProducts.Location = new System.Drawing.Point(0, 76);
            this.btnNavProducts.Name = "btnNavProducts";
            this.btnNavProducts.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavProducts.Size = new System.Drawing.Size(240, 40);
            this.btnNavProducts.TabIndex = 3;
            this.btnNavProducts.Text = "📱  Sản phẩm";
            this.btnNavProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavProducts.UseVisualStyleBackColor = true;
            this.btnNavProducts.Click += new System.EventHandler(this.btnNavProducts_Click);
            // 
            // btnNavUsers
            // 
            this.btnNavUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavUsers.FlatAppearance.BorderSize = 0;
            this.btnNavUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavUsers.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavUsers.Location = new System.Drawing.Point(0, 36);
            this.btnNavUsers.Name = "btnNavUsers";
            this.btnNavUsers.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavUsers.Size = new System.Drawing.Size(240, 40);
            this.btnNavUsers.TabIndex = 2;
            this.btnNavUsers.Text = "👤  Người dùng";
            this.btnNavUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavUsers.UseVisualStyleBackColor = true;
            this.btnNavUsers.Click += new System.EventHandler(this.btnNavUsers_Click);
            // 
            // lblCat1
            // 
            this.lblCat1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCat1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCat1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblCat1.Location = new System.Drawing.Point(0, 8);
            this.lblCat1.Name = "lblCat1";
            this.lblCat1.Padding = new System.Windows.Forms.Padding(18, 10, 0, 0);
            this.lblCat1.Size = new System.Drawing.Size(240, 28);
            this.lblCat1.TabIndex = 1;
            this.lblCat1.Text = "QUẢN LÝ";
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnNavDashboard.Size = new System.Drawing.Size(240, 48);
            this.btnNavDashboard.TabIndex = 0;
            this.btnNavDashboard.Text = "🏠  Dashboard";
            this.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDashboard.UseVisualStyleBackColor = false;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            // 
            // pnlUserInfo
            // 
            this.pnlUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(71)))));
            this.pnlUserInfo.Controls.Add(this.lblUserRole);
            this.pnlUserInfo.Controls.Add(this.lblUsername);
            this.pnlUserInfo.Controls.Add(this.lblAvatar);
            this.pnlUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserInfo.Location = new System.Drawing.Point(0, 75);
            this.pnlUserInfo.Name = "pnlUserInfo";
            this.pnlUserInfo.Size = new System.Drawing.Size(240, 75);
            this.pnlUserInfo.TabIndex = 1;
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblUserRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblUserRole.Location = new System.Drawing.Point(70, 42);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(43, 20);
            this.lblUserRole.TabIndex = 2;
            this.lblUserRole.Text = "Role";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(70, 16);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(89, 23);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // lblAvatar
            // 
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.lblAvatar.ForeColor = System.Drawing.Color.White;
            this.lblAvatar.Location = new System.Drawing.Point(12, 10);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(52, 52);
            this.lblAvatar.TabIndex = 0;
            this.lblAvatar.Text = "👤";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(32)))));
            this.pnlLogo.Controls.Add(this.lblAppSub);
            this.pnlLogo.Controls.Add(this.lblLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(240, 75);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblAppSub
            // 
            this.lblAppSub.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblAppSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblAppSub.Location = new System.Drawing.Point(10, 42);
            this.lblAppSub.Name = "lblAppSub";
            this.lblAppSub.Size = new System.Drawing.Size(220, 20);
            this.lblAppSub.TabIndex = 1;
            this.lblAppSub.Text = "HỆ THỐNG QUẢN LÝ";
            this.lblAppSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(10, 12);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(220, 28);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "📱 SMARTPHONE";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.lblClock);
            this.pnlTopBar.Controls.Add(this.lblCurrentPageTitle);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(240, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1080, 64);
            this.pnlTopBar.TabIndex = 1;
            // 
            // lblClock
            // 
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblClock.Location = new System.Drawing.Point(740, 20);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(320, 26);
            this.lblClock.TabIndex = 1;
            this.lblClock.Text = "24/09/2026 12:00:00";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentPageTitle
            // 
            this.lblCurrentPageTitle.AutoSize = true;
            this.lblCurrentPageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblCurrentPageTitle.Location = new System.Drawing.Point(24, 16);
            this.lblCurrentPageTitle.Name = "lblCurrentPageTitle";
            this.lblCurrentPageTitle.Size = new System.Drawing.Size(271, 32);
            this.lblCurrentPageTitle.TabIndex = 0;
            this.lblCurrentPageTitle.Text = "DASHBOARD TỔNG QUAN";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(240, 64);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1080, 716);
            this.pnlContent.TabIndex = 2;
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 780);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần Mềm Quản Lý Cửa Hàng Điện Thoại";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlUserInfo.ResumeLayout(false);
            this.pnlUserInfo.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
