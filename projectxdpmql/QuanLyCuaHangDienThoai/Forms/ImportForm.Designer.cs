namespace QuanLyCuaHangDienThoai.Forms
{
    partial class ImportForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox grpImport;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label lblCurrentStock;
        private System.Windows.Forms.Label lblStockDisplay;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblImportPrice;
        private System.Windows.Forms.NumericUpDown numImportPrice;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnSaveImport;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpHistory;
        private System.Windows.Forms.DataGridView dgvImportHistory;

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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.grpImport = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSaveImport = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.numImportPrice = new System.Windows.Forms.NumericUpDown();
            this.lblImportPrice = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblStockDisplay = new System.Windows.Forms.Label();
            this.lblCurrentStock = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.grpHistory = new System.Windows.Forms.GroupBox();
            this.dgvImportHistory = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.grpImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImportPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.pnlTop.Controls.Add(this.lblHeader);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1020, 50);
            this.pnlTop.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(15, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(431, 32);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "QUẢN LÝ NHẬP HÀNG VÀO KHO";
            // 
            // grpImport
            // 
            this.grpImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImport.Controls.Add(this.btnReset);
            this.grpImport.Controls.Add(this.btnSaveImport);
            this.grpImport.Controls.Add(this.txtNote);
            this.grpImport.Controls.Add(this.lblNote);
            this.grpImport.Controls.Add(this.lblTotalAmount);
            this.grpImport.Controls.Add(this.lblTotal);
            this.grpImport.Controls.Add(this.numImportPrice);
            this.grpImport.Controls.Add(this.lblImportPrice);
            this.grpImport.Controls.Add(this.numQuantity);
            this.grpImport.Controls.Add(this.lblQuantity);
            this.grpImport.Controls.Add(this.lblStockDisplay);
            this.grpImport.Controls.Add(this.lblCurrentStock);
            this.grpImport.Controls.Add(this.cboProduct);
            this.grpImport.Controls.Add(this.lblProduct);
            this.grpImport.Controls.Add(this.cboSupplier);
            this.grpImport.Controls.Add(this.lblSupplier);
            this.grpImport.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpImport.Location = new System.Drawing.Point(15, 60);
            this.grpImport.Name = "grpImport";
            this.grpImport.Size = new System.Drawing.Size(990, 205);
            this.grpImport.TabIndex = 1;
            this.grpImport.TabStop = false;
            this.grpImport.Text = "Thông tin phiếu nhập hàng";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(825, 148);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(145, 40);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "↺ Làm mới";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSaveImport
            // 
            this.btnSaveImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnSaveImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveImport.FlatAppearance.BorderSize = 0;
            this.btnSaveImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveImport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveImport.ForeColor = System.Drawing.Color.White;
            this.btnSaveImport.Location = new System.Drawing.Point(620, 148);
            this.btnSaveImport.Name = "btnSaveImport";
            this.btnSaveImport.Size = new System.Drawing.Size(190, 40);
            this.btnSaveImport.TabIndex = 14;
            this.btnSaveImport.Text = "💾 Lưu Phiếu Nhập";
            this.btnSaveImport.UseVisualStyleBackColor = false;
            this.btnSaveImport.Click += new System.EventHandler(this.btnSaveImport_Click);
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNote.Location = new System.Drawing.Point(125, 155);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(465, 29);
            this.txtNote.TabIndex = 13;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNote.Location = new System.Drawing.Point(20, 158);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(61, 20);
            this.lblNote.TabIndex = 12;
            this.lblNote.Text = "Ghi chú:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(695, 96);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(275, 28);
            this.lblTotalAmount.TabIndex = 11;
            this.lblTotalAmount.Text = "0 VNĐ";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTotal.Location = new System.Drawing.Point(600, 100);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(97, 21);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Thành tiền:";
            // 
            // numImportPrice
            // 
            this.numImportPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numImportPrice.Increment = new decimal(new int[] { 50000, 0, 0, 0 });
            this.numImportPrice.Location = new System.Drawing.Point(395, 97);
            this.numImportPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numImportPrice.Name = "numImportPrice";
            this.numImportPrice.Size = new System.Drawing.Size(180, 29);
            this.numImportPrice.TabIndex = 9;
            this.numImportPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numImportPrice.ThousandsSeparator = true;
            this.numImportPrice.ValueChanged += new System.EventHandler(this.numPriceOrQty_ValueChanged);
            // 
            // lblImportPrice
            // 
            this.lblImportPrice.AutoSize = true;
            this.lblImportPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblImportPrice.Location = new System.Drawing.Point(300, 100);
            this.lblImportPrice.Name = "lblImportPrice";
            this.lblImportPrice.Size = new System.Drawing.Size(71, 20);
            this.lblImportPrice.TabIndex = 8;
            this.lblImportPrice.Text = "Giá nhập:";
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numQuantity.Location = new System.Drawing.Point(125, 97);
            this.numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 29);
            this.numQuantity.TabIndex = 7;
            this.numQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.ValueChanged += new System.EventHandler(this.numPriceOrQty_ValueChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuantity.Location = new System.Drawing.Point(20, 100);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(109, 20);
            this.lblQuantity.TabIndex = 6;
            this.lblQuantity.Text = "Số lượng nhập:";
            // 
            // lblStockDisplay
            // 
            this.lblStockDisplay.AutoSize = true;
            this.lblStockDisplay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStockDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblStockDisplay.Location = new System.Drawing.Point(885, 41);
            this.lblStockDisplay.Name = "lblStockDisplay";
            this.lblStockDisplay.Size = new System.Drawing.Size(19, 21);
            this.lblStockDisplay.TabIndex = 5;
            this.lblStockDisplay.Text = "0";
            // 
            // lblCurrentStock
            // 
            this.lblCurrentStock.AutoSize = true;
            this.lblCurrentStock.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentStock.Location = new System.Drawing.Point(800, 41);
            this.lblCurrentStock.Name = "lblCurrentStock";
            this.lblCurrentStock.Size = new System.Drawing.Size(89, 20);
            this.lblCurrentStock.TabIndex = 4;
            this.lblCurrentStock.Text = "Tồn hiện tại:";
            // 
            // cboProduct
            // 
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(475, 38);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(310, 29);
            this.cboProduct.TabIndex = 3;
            this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProduct.Location = new System.Drawing.Point(395, 41);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(78, 20);
            this.lblProduct.TabIndex = 2;
            this.lblProduct.Text = "Sản phẩm:";
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(125, 38);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(250, 29);
            this.cboSupplier.TabIndex = 1;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSupplier.Location = new System.Drawing.Point(20, 41);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(103, 20);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Nhà cung cấp:";
            // 
            // grpHistory
            // 
            this.grpHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHistory.Controls.Add(this.dgvImportHistory);
            this.grpHistory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpHistory.Location = new System.Drawing.Point(15, 275);
            this.grpHistory.Name = "grpHistory";
            this.grpHistory.Size = new System.Drawing.Size(990, 380);
            this.grpHistory.TabIndex = 2;
            this.grpHistory.TabStop = false;
            this.grpHistory.Text = "Lịch sử các lần nhập hàng";
            // 
            // dgvImportHistory
            // 
            this.dgvImportHistory.AllowUserToAddRows = false;
            this.dgvImportHistory.AllowUserToDeleteRows = false;
            this.dgvImportHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvImportHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvImportHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvImportHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            dgvStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvStyle1.ForeColor = System.Drawing.Color.White;
            dgvStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dgvStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dgvStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImportHistory.ColumnHeadersDefaultCellStyle = dgvStyle1;
            this.dgvImportHistory.ColumnHeadersHeight = 35;
            dgvStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvImportHistory.AlternatingRowsDefaultCellStyle = dgvStyle2;
            this.dgvImportHistory.EnableHeadersVisualStyles = false;
            this.dgvImportHistory.Location = new System.Drawing.Point(15, 28);
            this.dgvImportHistory.MultiSelect = false;
            this.dgvImportHistory.Name = "dgvImportHistory";
            this.dgvImportHistory.ReadOnly = true;
            this.dgvImportHistory.RowHeadersWidth = 30;
            this.dgvImportHistory.RowTemplate.Height = 30;
            this.dgvImportHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImportHistory.Size = new System.Drawing.Size(960, 335);
            this.dgvImportHistory.TabIndex = 0;
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1020, 670);
            this.Controls.Add(this.grpHistory);
            this.Controls.Add(this.grpImport);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập Hàng Vào Kho";
            this.Load += new System.EventHandler(this.ImportForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpImport.ResumeLayout(false);
            this.grpImport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImportPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportHistory)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
