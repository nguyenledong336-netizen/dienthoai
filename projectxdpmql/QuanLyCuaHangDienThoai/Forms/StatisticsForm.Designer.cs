namespace QuanLyCuaHangDienThoai.Forms
{
    partial class StatisticsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox grpDateFilter;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnThisMonth;
        private System.Windows.Forms.Button btnAllTime;
        private System.Windows.Forms.TableLayoutPanel tblCards;
        private System.Windows.Forms.Panel pnlCardRevenue;
        private System.Windows.Forms.Label lblCardRevenueTitle;
        private System.Windows.Forms.Label lblCardRevenueValue;
        private System.Windows.Forms.Panel pnlCardInvoices;
        private System.Windows.Forms.Label lblCardInvoicesTitle;
        private System.Windows.Forms.Label lblCardInvoicesValue;
        private System.Windows.Forms.Panel pnlCardProducts;
        private System.Windows.Forms.Label lblCardProductsTitle;
        private System.Windows.Forms.Label lblCardProductsValue;
        private System.Windows.Forms.Panel pnlCardStock;
        private System.Windows.Forms.Label lblCardStockTitle;
        private System.Windows.Forms.Label lblCardStockValue;
        private System.Windows.Forms.SplitContainer splitTables;
        private System.Windows.Forms.GroupBox grpRevenueByDate;
        private System.Windows.Forms.DataGridView dgvRevenueByDate;
        private System.Windows.Forms.GroupBox grpTopProducts;
        private System.Windows.Forms.DataGridView dgvTopProducts;

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
            System.Windows.Forms.DataGridViewCellStyle dgvStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.grpDateFilter = new System.Windows.Forms.GroupBox();
            this.btnAllTime = new System.Windows.Forms.Button();
            this.btnThisMonth = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.tblCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardStock = new System.Windows.Forms.Panel();
            this.lblCardStockValue = new System.Windows.Forms.Label();
            this.lblCardStockTitle = new System.Windows.Forms.Label();
            this.pnlCardProducts = new System.Windows.Forms.Panel();
            this.lblCardProductsValue = new System.Windows.Forms.Label();
            this.lblCardProductsTitle = new System.Windows.Forms.Label();
            this.pnlCardInvoices = new System.Windows.Forms.Panel();
            this.lblCardInvoicesValue = new System.Windows.Forms.Label();
            this.lblCardInvoicesTitle = new System.Windows.Forms.Label();
            this.pnlCardRevenue = new System.Windows.Forms.Panel();
            this.lblCardRevenueValue = new System.Windows.Forms.Label();
            this.lblCardRevenueTitle = new System.Windows.Forms.Label();
            this.splitTables = new System.Windows.Forms.SplitContainer();
            this.grpRevenueByDate = new System.Windows.Forms.GroupBox();
            this.dgvRevenueByDate = new System.Windows.Forms.DataGridView();
            this.grpTopProducts = new System.Windows.Forms.GroupBox();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.grpDateFilter.SuspendLayout();
            this.tblCards.SuspendLayout();
            this.pnlCardStock.SuspendLayout();
            this.pnlCardProducts.SuspendLayout();
            this.pnlCardInvoices.SuspendLayout();
            this.pnlCardRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTables)).BeginInit();
            this.splitTables.Panel1.SuspendLayout();
            this.splitTables.Panel2.SuspendLayout();
            this.splitTables.SuspendLayout();
            this.grpRevenueByDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenueByDate)).BeginInit();
            this.grpTopProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.pnlTop.Controls.Add(this.lblHeader);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1040, 0);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.Visible = false;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(15, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(462, 32);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "BÁO CÁO THỐNG KÊ DOANH THU & KHO";
            // 
            // grpDateFilter
            // 
            this.grpDateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDateFilter.Controls.Add(this.btnAllTime);
            this.grpDateFilter.Controls.Add(this.btnThisMonth);
            this.grpDateFilter.Controls.Add(this.btnFilter);
            this.grpDateFilter.Controls.Add(this.dtpToDate);
            this.grpDateFilter.Controls.Add(this.lblToDate);
            this.grpDateFilter.Controls.Add(this.dtpFromDate);
            this.grpDateFilter.Controls.Add(this.lblFromDate);
            this.grpDateFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDateFilter.Location = new System.Drawing.Point(15, 12);
            this.grpDateFilter.Name = "grpDateFilter";
            this.grpDateFilter.Size = new System.Drawing.Size(1010, 72);
            this.grpDateFilter.TabIndex = 1;
            this.grpDateFilter.TabStop = false;
            this.grpDateFilter.Text = "Bộ lọc thời gian thống kê";
            // 
            // btnAllTime
            // 
            this.btnAllTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnAllTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllTime.FlatAppearance.BorderSize = 0;
            this.btnAllTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAllTime.ForeColor = System.Drawing.Color.White;
            this.btnAllTime.Location = new System.Drawing.Point(820, 26);
            this.btnAllTime.Name = "btnAllTime";
            this.btnAllTime.Size = new System.Drawing.Size(110, 34);
            this.btnAllTime.TabIndex = 6;
            this.btnAllTime.Text = "Tất cả";
            this.btnAllTime.UseVisualStyleBackColor = false;
            this.btnAllTime.Click += new System.EventHandler(this.btnAllTime_Click);
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnThisMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThisMonth.FlatAppearance.BorderSize = 0;
            this.btnThisMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisMonth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThisMonth.ForeColor = System.Drawing.Color.White;
            this.btnThisMonth.Location = new System.Drawing.Point(695, 26);
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(110, 34);
            this.btnThisMonth.TabIndex = 5;
            this.btnThisMonth.Text = "Tháng này";
            this.btnThisMonth.UseVisualStyleBackColor = false;
            this.btnThisMonth.Click += new System.EventHandler(this.btnThisMonth_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(550, 26);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(130, 34);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "📊 Xem Báo Cáo";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(365, 29);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(155, 29);
            this.dtpToDate.TabIndex = 3;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblToDate.Location = new System.Drawing.Point(285, 33);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(75, 20);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "Đến ngày:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(95, 29);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(155, 29);
            this.dtpFromDate.TabIndex = 1;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFromDate.Location = new System.Drawing.Point(20, 33);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(65, 20);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "Từ ngày:";
            // 
            // tblCards
            // 
            this.tblCards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblCards.ColumnCount = 4;
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCards.Controls.Add(this.pnlCardStock, 3, 0);
            this.tblCards.Controls.Add(this.pnlCardProducts, 2, 0);
            this.tblCards.Controls.Add(this.pnlCardInvoices, 1, 0);
            this.tblCards.Controls.Add(this.pnlCardRevenue, 0, 0);
            this.tblCards.Location = new System.Drawing.Point(15, 90);
            this.tblCards.Name = "tblCards";
            this.tblCards.RowCount = 1;
            this.tblCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCards.Size = new System.Drawing.Size(1010, 105);
            this.tblCards.TabIndex = 2;
            // 
            // pnlCardStock
            // 
            this.pnlCardStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.pnlCardStock.Controls.Add(this.lblCardStockValue);
            this.pnlCardStock.Controls.Add(this.lblCardStockTitle);
            this.pnlCardStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardStock.Location = new System.Drawing.Point(762, 3);
            this.pnlCardStock.Name = "pnlCardStock";
            this.pnlCardStock.Padding = new System.Windows.Forms.Padding(12);
            this.pnlCardStock.Size = new System.Drawing.Size(245, 99);
            this.pnlCardStock.TabIndex = 3;
            // 
            // lblCardStockValue
            // 
            this.lblCardStockValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCardStockValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCardStockValue.ForeColor = System.Drawing.Color.White;
            this.lblCardStockValue.Location = new System.Drawing.Point(12, 42);
            this.lblCardStockValue.Name = "lblCardStockValue";
            this.lblCardStockValue.Size = new System.Drawing.Size(221, 45);
            this.lblCardStockValue.TabIndex = 1;
            this.lblCardStockValue.Text = "0";
            this.lblCardStockValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardStockTitle
            // 
            this.lblCardStockTitle.AutoSize = true;
            this.lblCardStockTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardStockTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCardStockTitle.ForeColor = System.Drawing.Color.White;
            this.lblCardStockTitle.Location = new System.Drawing.Point(12, 12);
            this.lblCardStockTitle.Name = "lblCardStockTitle";
            this.lblCardStockTitle.Size = new System.Drawing.Size(155, 21);
            this.lblCardStockTitle.TabIndex = 0;
            this.lblCardStockTitle.Text = "📦 TỔNG TỒN KHO";
            // 
            // pnlCardProducts
            // 
            this.pnlCardProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(58)))), ((int)(((byte)(237)))));
            this.pnlCardProducts.Controls.Add(this.lblCardProductsValue);
            this.pnlCardProducts.Controls.Add(this.lblCardProductsTitle);
            this.pnlCardProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardProducts.Location = new System.Drawing.Point(509, 3);
            this.pnlCardProducts.Name = "pnlCardProducts";
            this.pnlCardProducts.Padding = new System.Windows.Forms.Padding(12);
            this.pnlCardProducts.Size = new System.Drawing.Size(247, 99);
            this.pnlCardProducts.TabIndex = 2;
            // 
            // lblCardProductsValue
            // 
            this.lblCardProductsValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCardProductsValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCardProductsValue.ForeColor = System.Drawing.Color.White;
            this.lblCardProductsValue.Location = new System.Drawing.Point(12, 42);
            this.lblCardProductsValue.Name = "lblCardProductsValue";
            this.lblCardProductsValue.Size = new System.Drawing.Size(223, 45);
            this.lblCardProductsValue.TabIndex = 1;
            this.lblCardProductsValue.Text = "0";
            this.lblCardProductsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardProductsTitle
            // 
            this.lblCardProductsTitle.AutoSize = true;
            this.lblCardProductsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardProductsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCardProductsTitle.ForeColor = System.Drawing.Color.White;
            this.lblCardProductsTitle.Location = new System.Drawing.Point(12, 12);
            this.lblCardProductsTitle.Name = "lblCardProductsTitle";
            this.lblCardProductsTitle.Size = new System.Drawing.Size(184, 21);
            this.lblCardProductsTitle.TabIndex = 0;
            this.lblCardProductsTitle.Text = "📱 TỔNG SỐ SẢN PHẨM";
            // 
            // pnlCardInvoices
            // 
            this.pnlCardInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.pnlCardInvoices.Controls.Add(this.lblCardInvoicesValue);
            this.pnlCardInvoices.Controls.Add(this.lblCardInvoicesTitle);
            this.pnlCardInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardInvoices.Location = new System.Drawing.Point(256, 3);
            this.pnlCardInvoices.Name = "pnlCardInvoices";
            this.pnlCardInvoices.Padding = new System.Windows.Forms.Padding(12);
            this.pnlCardInvoices.Size = new System.Drawing.Size(247, 99);
            this.pnlCardInvoices.TabIndex = 1;
            // 
            // lblCardInvoicesValue
            // 
            this.lblCardInvoicesValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCardInvoicesValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCardInvoicesValue.ForeColor = System.Drawing.Color.White;
            this.lblCardInvoicesValue.Location = new System.Drawing.Point(12, 42);
            this.lblCardInvoicesValue.Name = "lblCardInvoicesValue";
            this.lblCardInvoicesValue.Size = new System.Drawing.Size(223, 45);
            this.lblCardInvoicesValue.TabIndex = 1;
            this.lblCardInvoicesValue.Text = "0";
            this.lblCardInvoicesValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardInvoicesTitle
            // 
            this.lblCardInvoicesTitle.AutoSize = true;
            this.lblCardInvoicesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardInvoicesTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCardInvoicesTitle.ForeColor = System.Drawing.Color.White;
            this.lblCardInvoicesTitle.Location = new System.Drawing.Point(12, 12);
            this.lblCardInvoicesTitle.Name = "lblCardInvoicesTitle";
            this.lblCardInvoicesTitle.Size = new System.Drawing.Size(176, 21);
            this.lblCardInvoicesTitle.TabIndex = 0;
            this.lblCardInvoicesTitle.Text = "🧾 TỔNG SỐ HÓA ĐƠN";
            // 
            // pnlCardRevenue
            // 
            this.pnlCardRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(160)))), ((int)(((byte)(107)))));
            this.pnlCardRevenue.Controls.Add(this.lblCardRevenueValue);
            this.pnlCardRevenue.Controls.Add(this.lblCardRevenueTitle);
            this.pnlCardRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardRevenue.Location = new System.Drawing.Point(3, 3);
            this.pnlCardRevenue.Name = "pnlCardRevenue";
            this.pnlCardRevenue.Padding = new System.Windows.Forms.Padding(12);
            this.pnlCardRevenue.Size = new System.Drawing.Size(247, 99);
            this.pnlCardRevenue.TabIndex = 0;
            // 
            // lblCardRevenueValue
            // 
            this.lblCardRevenueValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCardRevenueValue.Font = new System.Drawing.Font("Segoe UI", 16.5F, System.Drawing.FontStyle.Bold);
            this.lblCardRevenueValue.ForeColor = System.Drawing.Color.White;
            this.lblCardRevenueValue.Location = new System.Drawing.Point(12, 42);
            this.lblCardRevenueValue.Name = "lblCardRevenueValue";
            this.lblCardRevenueValue.Size = new System.Drawing.Size(223, 45);
            this.lblCardRevenueValue.TabIndex = 1;
            this.lblCardRevenueValue.Text = "0 VNĐ";
            this.lblCardRevenueValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardRevenueTitle
            // 
            this.lblCardRevenueTitle.AutoSize = true;
            this.lblCardRevenueTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCardRevenueTitle.ForeColor = System.Drawing.Color.White;
            this.lblCardRevenueTitle.Location = new System.Drawing.Point(12, 12);
            this.lblCardRevenueTitle.Name = "lblCardRevenueTitle";
            this.lblCardRevenueTitle.Size = new System.Drawing.Size(175, 21);
            this.lblCardRevenueTitle.TabIndex = 0;
            this.lblCardRevenueTitle.Text = "💰 TỔNG DOANH THU";
            // 
            // splitTables
            // 
            this.splitTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitTables.Location = new System.Drawing.Point(15, 205);
            this.splitTables.Name = "splitTables";
            // 
            // splitTables.Panel1
            // 
            this.splitTables.Panel1.Controls.Add(this.grpRevenueByDate);
            // 
            // splitTables.Panel2
            // 
            this.splitTables.Panel2.Controls.Add(this.grpTopProducts);
            this.splitTables.Size = new System.Drawing.Size(1010, 410);
            this.splitTables.SplitterDistance = 505;
            this.splitTables.TabIndex = 3;
            // 
            // grpRevenueByDate
            // 
            this.grpRevenueByDate.Controls.Add(this.dgvRevenueByDate);
            this.grpRevenueByDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRevenueByDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpRevenueByDate.Location = new System.Drawing.Point(0, 0);
            this.grpRevenueByDate.Name = "grpRevenueByDate";
            this.grpRevenueByDate.Size = new System.Drawing.Size(505, 410);
            this.grpRevenueByDate.TabIndex = 0;
            this.grpRevenueByDate.TabStop = false;
            this.grpRevenueByDate.Text = "Doanh thu theo ngày";
            // 
            // dgvRevenueByDate
            // 
            this.dgvRevenueByDate.AllowUserToAddRows = false;
            this.dgvRevenueByDate.AllowUserToDeleteRows = false;
            this.dgvRevenueByDate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRevenueByDate.BackgroundColor = System.Drawing.Color.White;
            this.dgvRevenueByDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            dgvStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvStyle1.ForeColor = System.Drawing.Color.White;
            dgvStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dgvStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dgvStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRevenueByDate.ColumnHeadersDefaultCellStyle = dgvStyle1;
            this.dgvRevenueByDate.ColumnHeadersHeight = 32;
            dgvStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvRevenueByDate.AlternatingRowsDefaultCellStyle = dgvStyle2;
            this.dgvRevenueByDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRevenueByDate.EnableHeadersVisualStyles = false;
            this.dgvRevenueByDate.Location = new System.Drawing.Point(3, 25);
            this.dgvRevenueByDate.MultiSelect = false;
            this.dgvRevenueByDate.Name = "dgvRevenueByDate";
            this.dgvRevenueByDate.ReadOnly = true;
            this.dgvRevenueByDate.RowHeadersWidth = 30;
            this.dgvRevenueByDate.RowTemplate.Height = 28;
            this.dgvRevenueByDate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRevenueByDate.Size = new System.Drawing.Size(499, 382);
            this.dgvRevenueByDate.TabIndex = 0;
            // 
            // grpTopProducts
            // 
            this.grpTopProducts.Controls.Add(this.dgvTopProducts);
            this.grpTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTopProducts.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpTopProducts.Location = new System.Drawing.Point(0, 0);
            this.grpTopProducts.Name = "grpTopProducts";
            this.grpTopProducts.Size = new System.Drawing.Size(501, 410);
            this.grpTopProducts.TabIndex = 0;
            this.grpTopProducts.TabStop = false;
            this.grpTopProducts.Text = "Top 5 sản phẩm bán chạy nhất";
            // 
            // dgvTopProducts
            // 
            this.dgvTopProducts.AllowUserToAddRows = false;
            this.dgvTopProducts.AllowUserToDeleteRows = false;
            this.dgvTopProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            dgvStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvStyle3.ForeColor = System.Drawing.Color.White;
            dgvStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dgvStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dgvStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopProducts.ColumnHeadersDefaultCellStyle = dgvStyle3;
            this.dgvTopProducts.ColumnHeadersHeight = 32;
            dgvStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvTopProducts.AlternatingRowsDefaultCellStyle = dgvStyle4;
            this.dgvTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopProducts.EnableHeadersVisualStyles = false;
            this.dgvTopProducts.Location = new System.Drawing.Point(3, 25);
            this.dgvTopProducts.MultiSelect = false;
            this.dgvTopProducts.Name = "dgvTopProducts";
            this.dgvTopProducts.ReadOnly = true;
            this.dgvTopProducts.RowHeadersWidth = 30;
            this.dgvTopProducts.RowTemplate.Height = 28;
            this.dgvTopProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopProducts.Size = new System.Drawing.Size(495, 382);
            this.dgvTopProducts.TabIndex = 0;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1040, 670);
            this.Controls.Add(this.splitTables);
            this.Controls.Add(this.tblCards);
            this.Controls.Add(this.grpDateFilter);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo Cáo Thống Kê";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpDateFilter.ResumeLayout(false);
            this.grpDateFilter.PerformLayout();
            this.tblCards.ResumeLayout(false);
            this.pnlCardStock.ResumeLayout(false);
            this.pnlCardStock.PerformLayout();
            this.pnlCardProducts.ResumeLayout(false);
            this.pnlCardProducts.PerformLayout();
            this.pnlCardInvoices.ResumeLayout(false);
            this.pnlCardInvoices.PerformLayout();
            this.pnlCardRevenue.ResumeLayout(false);
            this.pnlCardRevenue.PerformLayout();
            this.splitTables.Panel1.ResumeLayout(false);
            this.splitTables.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitTables)).EndInit();
            this.splitTables.ResumeLayout(false);
            this.grpRevenueByDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenueByDate)).EndInit();
            this.grpTopProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
