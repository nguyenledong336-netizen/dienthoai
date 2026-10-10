-- ============================================================
-- SCRIPT TẠO DATABASE QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI
-- ============================================================

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyCuaHangDienThoai')
BEGIN
    CREATE DATABASE QuanLyCuaHangDienThoai;
END
GO

USE QuanLyCuaHangDienThoai;
GO

-- XÓA BẢNG NẾU ĐÃ TỒN TẠI ĐỂ TẠO MỚI (THEO THỨ TỰ PHỤ THUỘC)
IF OBJECT_ID('dbo.InventoryTransactions', 'U') IS NOT NULL DROP TABLE dbo.InventoryTransactions;
IF OBJECT_ID('dbo.InvoiceDetails', 'U') IS NOT NULL DROP TABLE dbo.InvoiceDetails;
IF OBJECT_ID('dbo.Invoices', 'U') IS NOT NULL DROP TABLE dbo.Invoices;
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL DROP TABLE dbo.Products;
IF OBJECT_ID('dbo.Categories', 'U') IS NOT NULL DROP TABLE dbo.Categories;
IF OBJECT_ID('dbo.Suppliers', 'U') IS NOT NULL DROP TABLE dbo.Suppliers;
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL DROP TABLE dbo.Customers;
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL DROP TABLE dbo.Users;
GO

-- 1. BẢNG USERS (Người dùng hệ thống)
CREATE TABLE dbo.Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(256) NOT NULL,
    Role NVARCHAR(50) NOT NULL, -- 'Admin', 'NhanVien'
    TrangThai BIT NOT NULL DEFAULT 1 -- 1: Đang hoạt động, 0: Đã khóa
);
GO

-- 2. BẢNG CATEGORIES (Danh mục sản phẩm)
CREATE TABLE dbo.Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255) NULL
);
GO

-- 3. BẢNG PRODUCTS (Sản phẩm)
CREATE TABLE dbo.Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MaSanPham NVARCHAR(50) NOT NULL UNIQUE,
    TenSanPham NVARCHAR(200) NOT NULL,
    CategoryId INT NOT NULL,
    GiaNhap DECIMAL(18,2) NOT NULL DEFAULT 0,
    GiaBan DECIMAL(18,2) NOT NULL DEFAULT 0,
    SoLuongTon INT NOT NULL DEFAULT 0,
    DonViTinh NVARCHAR(50) NOT NULL DEFAULT N'Chiếc',
    TrangThai BIT NOT NULL DEFAULT 1, -- 1: Đang kinh doanh, 0: Ngừng kinh doanh
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES dbo.Categories(Id),
    CONSTRAINT CK_Products_GiaNhap CHECK (GiaNhap >= 0),
    CONSTRAINT CK_Products_GiaBan CHECK (GiaBan >= 0),
    CONSTRAINT CK_Products_SoLuongTon CHECK (SoLuongTon >= 0)
);
GO

-- 4. BẢNG CUSTOMERS (Khách hàng)
CREATE TABLE dbo.Customers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai NVARCHAR(20) NULL,
    DiaChi NVARCHAR(255) NULL,
    Email NVARCHAR(100) NULL
);
GO

-- 5. BẢNG SUPPLIERS (Nhà cung cấp)
CREATE TABLE dbo.Suppliers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TenNhaCungCap NVARCHAR(150) NOT NULL,
    SoDienThoai NVARCHAR(20) NULL,
    DiaChi NVARCHAR(255) NULL,
    Email NVARCHAR(100) NULL
);
GO

-- 6. BẢNG INVOICES (Hóa đơn bán hàng)
CREATE TABLE dbo.Invoices (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MaHoaDon NVARCHAR(50) NOT NULL UNIQUE,
    CustomerId INT NOT NULL,
    UserId INT NOT NULL,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_Invoices_Customers FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(Id),
    CONSTRAINT FK_Invoices_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(Id)
);
GO

-- 7. BẢNG INVOICEDETAILS (Chi tiết hóa đơn)
CREATE TABLE dbo.InvoiceDetails (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceId INT NOT NULL,
    ProductId INT NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    ThanhTien DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_InvoiceDetails_Invoices FOREIGN KEY (InvoiceId) REFERENCES dbo.Invoices(Id) ON DELETE CASCADE,
    CONSTRAINT FK_InvoiceDetails_Products FOREIGN KEY (ProductId) REFERENCES dbo.Products(Id),
    CONSTRAINT CK_InvoiceDetails_SoLuong CHECK (SoLuong > 0),
    CONSTRAINT CK_InvoiceDetails_DonGia CHECK (DonGia >= 0),
    CONSTRAINT CK_InvoiceDetails_ThanhTien CHECK (ThanhTien >= 0)
);
GO

-- 8. BẢNG INVENTORYTRANSACTIONS (Lịch sử giao dịch kho: NHAP / BAN)
CREATE TABLE dbo.InventoryTransactions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    LoaiGiaoDich NVARCHAR(20) NOT NULL, -- 'NHAP', 'BAN'
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    NgayGiaoDich DATETIME NOT NULL DEFAULT GETDATE(),
    UserId INT NOT NULL,
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT FK_InventoryTransactions_Products FOREIGN KEY (ProductId) REFERENCES dbo.Products(Id),
    CONSTRAINT FK_InventoryTransactions_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(Id),
    CONSTRAINT CK_InventoryTransactions_Loai CHECK (LoaiGiaoDich IN (N'NHAP', N'BAN'))
);
GO

-- ============================================================
-- DỮ LIỆU MẪU (SEED DATA)
-- ============================================================

-- Mật khẩu đã băm SHA256:
-- admin / admin123  -> 240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9
-- nhanvien / 123456 -> 8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92
INSERT INTO dbo.Users (Username, Password, Role, TrangThai) VALUES
(N'admin', N'240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', N'Admin', 1),
(N'nhanvien', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'NhanVien', 1);
GO

-- Danh mục
INSERT INTO dbo.Categories (TenDanhMuc, MoTa) VALUES
(N'iPhone - Apple', N'Các dòng điện thoại Apple chính hãng VN/A'),
(N'Samsung Galaxy', N'Điện thoại thông minh Samsung phân khúc cao cấp và tầm trung'),
(N'Xiaomi', N'Điện thoại Xiaomi hiệu năng cao giá tốt'),
(N'Phụ kiện & Củ cáp sạc', N'Bộ sạc nhanh, cáp lightning, type-C chính hãng'),
(N'Tai nghe không dây', N'Tai nghe bluetooth, true wireless cao cấp');
GO

-- Nhà cung cấp
INSERT INTO dbo.Suppliers (TenNhaCungCap, SoDienThoai, DiaChi, Email) VALUES
(N'Công ty Cổ phần Synnex FPT', N'02473006666', N'Tòa nhà FPT Cầu Giấy, Hà Nội', N'contact@synnexfpt.com.vn'),
(N'Công ty Digiworld (DGW)', N'02839290059', N'195 Cô Bắc, Quận 1, TP.HCM', N'info@digiworld.com.vn'),
(N'Công ty Phân Phối Viễn Sơn', N'02838326085', N'162 Bùi Thị Xuân, Quận 1, TP.HCM', N'sales@microstar.vn');
GO

-- Khách hàng
INSERT INTO dbo.Customers (HoTen, SoDienThoai, DiaChi, Email) VALUES
(N'Nguyễn Văn An', N'0912345678', N'123 Cầu Giấy, Hà Nội', N'an.nguyen@gmail.com'),
(N'Trần Thị Mai', N'0987654321', N'45 Hai Bà Trưng, Hà Nội', N'mai.tran@yahoo.com'),
(N'Lê Hoàng Long', N'0905123456', N'78 Nguyễn Huệ, Quận 1, TP.HCM', N'long.le@gmail.com'),
(N'Phạm Thu Trang', N'0933998877', N'12 Đống Đa, Đà Nẵng', N'trang.pham@gmail.com');
GO

-- Sản phẩm
INSERT INTO dbo.Products (MaSanPham, TenSanPham, CategoryId, GiaNhap, GiaBan, SoLuongTon, DonViTinh, TrangThai) VALUES
(N'IP15PM-256', N'iPhone 15 Pro Max 256GB Titan Tự Nhiên', 1, 26500000, 29990000, 15, N'Chiếc', 1),
(N'IP15-128', N'iPhone 15 128GB Đen', 1, 17500000, 19990000, 20, N'Chiếc', 1),
(N'SS-S24U-256', N'Samsung Galaxy S24 Ultra 5G 256GB Xám', 2, 24000000, 27490000, 12, N'Chiếc', 1),
(N'SS-A55-128', N'Samsung Galaxy A55 5G 128GB Xanh', 2, 8000000, 9690000, 25, N'Chiếc', 1),
(N'MI-14-256', N'Xiaomi 14 256GB Trắng', 3, 16000000, 18990000, 10, N'Chiếc', 1),
(N'MI-NOTE13', N'Xiaomi Redmi Note 13 128GB Đen', 3, 3800000, 4490000, 30, N'Chiếc', 1),
(N'ANKER-65W', N'Củ sạc Anker GaNPrime 65W 3 Cổng', 4, 750000, 1050000, 50, N'Củ', 1),
(N'CABLE-C2L', N'Cáp sạc Type-C sang Lightning 1m', 4, 180000, 320000, 60, N'Sợi', 1),
(N'AIRPODS-P2', N'Tai nghe Apple AirPods Pro 2 Type-C', 5, 4800000, 5690000, 18, N'Bộ', 1),
(N'BUDS-2PRO', N'Tai nghe Samsung Galaxy Buds 2 Pro', 5, 2300000, 2990000, 15, N'Bộ', 1);
GO

-- Giao dịch kho mẫu (Giao dịch nhập ban đầu)
INSERT INTO dbo.InventoryTransactions (ProductId, LoaiGiaoDich, SoLuong, DonGia, NgayGiaoDich, UserId, GhiChu) VALUES
(1, N'NHAP', 15, 26500000, DATEADD(DAY, -5, GETDATE()), 1, N'Nhập kho ban đầu'),
(2, N'NHAP', 20, 17500000, DATEADD(DAY, -5, GETDATE()), 1, N'Nhập kho ban đầu'),
(3, N'NHAP', 12, 24000000, DATEADD(DAY, -5, GETDATE()), 1, N'Nhập kho ban đầu'),
(4, N'NHAP', 25, 8000000, DATEADD(DAY, -5, GETDATE()), 1, N'Nhập kho ban đầu'),
(5, N'NHAP', 10, 16000000, DATEADD(DAY, -5, GETDATE()), 1, N'Nhập kho ban đầu'),
(6, N'NHAP', 30, 3800000, DATEADD(DAY, -5, GETDATE()), 1, N'Nhập kho ban đầu'),
(7, N'NHAP', 50, 750000, DATEADD(DAY, -5, GETDATE()), 1, N'Nhập kho ban đầu'),
(8, N'NHAP', 60, 180000, DATEADD(DAY, -5, GETDATE()), 1, N'Nhập kho ban đầu'),
(9, N'NHAP', 18, 4800000, DATEADD(DAY, -5, GETDATE()), 1, N'Nhập kho ban đầu'),
(10, N'NHAP', 15, 2300000, DATEADD(DAY, -5, GETDATE()), 1, N'Nhập kho ban đầu');
GO

-- Hóa đơn mẫu 1
INSERT INTO dbo.Invoices (MaHoaDon, CustomerId, UserId, NgayLap, TongTien) VALUES
(N'HD000001', 1, 1, DATEADD(DAY, -2, GETDATE()), 31040000);
GO

INSERT INTO dbo.InvoiceDetails (InvoiceId, ProductId, SoLuong, DonGia, ThanhTien) VALUES
(1, 1, 1, 29990000, 29990000),
(1, 7, 1, 1050000, 1050000);
GO

-- Giao dịch kho bán hàng cho HD000001
INSERT INTO dbo.InventoryTransactions (ProductId, LoaiGiaoDich, SoLuong, DonGia, NgayGiaoDich, UserId, GhiChu) VALUES
(1, N'BAN', 1, 29990000, DATEADD(DAY, -2, GETDATE()), 1, N'Xuất bán theo hóa đơn HD000001'),
(7, N'BAN', 1, 1050000, DATEADD(DAY, -2, GETDATE()), 1, N'Xuất bán theo hóa đơn HD000001');
GO

-- Hóa đơn mẫu 2
INSERT INTO dbo.Invoices (MaHoaDon, CustomerId, UserId, NgayLap, TongTien) VALUES
(N'HD000002', 2, 2, DATEADD(DAY, -1, GETDATE()), 5690000);
GO

INSERT INTO dbo.InvoiceDetails (InvoiceId, ProductId, SoLuong, DonGia, ThanhTien) VALUES
(2, 9, 1, 5690000, 5690000);
GO

-- Giao dịch kho bán hàng cho HD000002
INSERT INTO dbo.InventoryTransactions (ProductId, LoaiGiaoDich, SoLuong, DonGia, NgayGiaoDich, UserId, GhiChu) VALUES
(9, N'BAN', 1, 5690000, DATEADD(DAY, -1, GETDATE()), 2, N'Xuất bán theo hóa đơn HD000002');
GO

PRINT N'CƠ SỞ DỮ LIỆU ĐÃ ĐƯỢC TẠO VÀ CHÈN DỮ LIỆU MẪU THÀNH CÔNG!';
