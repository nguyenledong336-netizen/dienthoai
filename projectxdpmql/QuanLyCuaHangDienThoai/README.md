# PHẦN MỀM QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI

> **Đề tài Đồ án Sinh viên**: Xây dựng phần mềm quản lý cửa hàng điện thoại  
> **Nền tảng**: Windows Desktop  
> **Công nghệ**: C# (.NET 8 LTS) | Windows Forms | Microsoft SQL Server | ADO.NET  
> **IDE khuyến nghị**: Microsoft Visual Studio 2022 / 2026 hoặc mới hơn  

---

## 1. GIỚI THIỆU HỆ THỐNG

Phần mềm Quản lý Cửa hàng Điện thoại được xây dựng hoàn chỉnh với mục tiêu đáp ứng đầy đủ nghiệp vụ quản lý bán lẻ, nhập xuất kho, kiểm soát doanh thu và phân quyền người dùng thực tế.  
Toàn bộ dữ liệu được lưu trữ và truy vấn thực tế trên **Microsoft SQL Server** thông qua công nghệ **ADO.NET** (sử dụng Parameterized Query chống SQL Injection, Transaction đảm bảo tính toàn vẹn dữ liệu khi bán hàng và nhập hàng).

---

## 2. YÊU CẦU MÔI TRƯỜNG

- **Hệ điều hành**: Windows 10 / Windows 11 (64-bit)
- **.NET SDK / Runtime**: .NET 8.0 Desktop Runtime trở lên
- **Hệ quản trị CSDL**: Microsoft SQL Server (2016, 2017, 2019, 2022 hoặc bản Express / Developer)
- **Công cụ quản lý CSDL (tùy chọn)**: SQL Server Management Studio (SSMS)
- **Công cụ lập trình (IDE)**: Microsoft Visual Studio (có cài đặt workload *.NET Desktop Development*)

---

## 3. CẤU TRÚC THƯ MỤC PROJECT

```text
QuanLyCuaHangDienThoai/
│
├── Data/
│   └── DatabaseConnection.cs       # Quản lý tập trung chuỗi kết nối SQL Server
│
├── Models/
│   ├── User.cs                     # Model Người dùng hệ thống
│   ├── Category.cs                 # Model Danh mục sản phẩm
│   ├── Product.cs                  # Model Sản phẩm điện thoại / phụ kiện
│   ├── Customer.cs                 # Model Khách hàng
│   ├── Supplier.cs                 # Model Nhà cung cấp
│   ├── Invoice.cs                  # Model Hóa đơn bán hàng
│   ├── InvoiceDetail.cs            # Model Chi tiết hóa đơn
│   └── InventoryTransaction.cs     # Model Biến động lịch sử kho
│
├── Repositories/
│   ├── UserRepository.cs           # Thao tác CSDL bảng Users
│   ├── CategoryRepository.cs       # Thao tác CSDL bảng Categories
│   ├── ProductRepository.cs        # Thao tác CSDL bảng Products
│   ├── CustomerRepository.cs       # Thao tác CSDL bảng Customers
│   ├── SupplierRepository.cs       # Thao tác CSDL bảng Suppliers
│   ├── InvoiceRepository.cs        # Nghiệp vụ Hóa đơn + SqlTransaction Bán hàng
│   └── InventoryRepository.cs      # Nghiệp vụ Kho + SqlTransaction Nhập hàng
│
├── Services/
│   ├── AuthService.cs              # Quản lý đăng nhập, phiên làm việc & phân quyền
│   ├── CategoryService.cs          # Nghiệp vụ danh mục sản phẩm
│   ├── ProductService.cs           # Nghiệp vụ sản phẩm
│   ├── CustomerService.cs          # Nghiệp vụ khách hàng
│   ├── SupplierService.cs          # Nghiệp vụ nhà cung cấp
│   ├── InvoiceService.cs           # Nghiệp vụ bán hàng và tra cứu hóa đơn
│   ├── InventoryService.cs         # Nghiệp vụ nhập hàng và lịch sử kho
│   └── StatisticsService.cs        # Thống kê doanh thu, KPI và báo cáo từ CSDL
│
├── Forms/
│   ├── LoginForm.cs                # Màn hình đăng nhập hệ thống
│   ├── MainForm.cs                 # Màn hình chính (Sidebar Navigation & Content)
│   ├── UserForm.cs                 # Quản lý người dùng hệ thống (chỉ Admin)
│   ├── CategoryForm.cs             # Quản lý danh mục sản phẩm
│   ├── ProductForm.cs              # Quản lý sản phẩm và điện thoại
│   ├── CustomerForm.cs             # Quản lý thông tin khách hàng
│   ├── SupplierForm.cs             # Quản lý thông tin nhà cung cấp
│   ├── ImportForm.cs               # Nghiệp vụ nhập hàng vào kho (tăng tồn kho)
│   ├── SaleForm.cs                 # Nghiệp vụ bán hàng & xuất HĐ (giảm tồn kho)
│   ├── InvoiceForm.cs              # Tra cứu danh sách và chi tiết hóa đơn
│   ├── InventoryForm.cs            # Theo dõi tồn kho (Lọc hết hàng, sắp hết, còn hàng)
│   └── StatisticsForm.cs           # Báo cáo doanh thu theo ngày, top sản phẩm
│
├── Utils/
│   ├── PasswordHelper.cs           # Băm và kiểm tra mật khẩu bằng SHA-256 an toàn
│   └── ValidationHelper.cs         # Kiểm tra hợp lệ dữ liệu (rỗng, SĐT, Email, số dương)
│
├── Database.sql                    # Script tạo Database, bảng, quan hệ và dữ liệu mẫu
├── Program.cs                      # Điểm vào chính của ứng dụng
└── QuanLyCuaHangDienThoai.csproj   # File cấu hình Project C#
```

---

## 4. HƯỚNG DẪN CÀI ĐẶT CƠ SỞ DỮ LIỆU

### Cách 1: Sử dụng SQL Server Management Studio (SSMS)
1. Mở SSMS và kết nối vào SQL Server trên máy tính của bạn.
2. Chọn menu **File -> Open -> File...** (hoặc nhấn `Ctrl + O`).
3. Trỏ đến file `Database.sql` trong thư mục dự án (`d:\projectxdpmql\Database.sql`).
4. Nhấn nút **Execute** (hoặc phím `F5`) để chạy toàn bộ script.
5. Kiểm tra thấy Database `QuanLyCuaHangDienThoai` đã được tạo cùng 8 bảng và dữ liệu mẫu.

### Cách 2: Chạy trực tiếp qua PowerShell
Mở PowerShell tại thư mục dự án và chạy lệnh:
```powershell
$sql = Get-Content -Raw "Database.sql"
$batches = $sql -split "(?m)^\s*GO\s*$"
$conn = New-Object System.Data.SqlClient.SqlConnection("Server=localhost;Integrated Security=True;TrustServerCertificate=True;")
$conn.Open()
foreach ($b in $batches) {
    if ($b.Trim().Length -gt 0) {
        $cmd = $conn.CreateCommand()
        $cmd.CommandText = $b.Trim()
        $cmd.ExecuteNonQuery() | Out-Null
    }
}
$conn.Close()
Write-Host "Tạo CSDL thành công!"
```

---

## 5. CẤU HÌNH KẾT NỐI DATABASE

Chuỗi kết nối SQL Server được quản lý tập trung tại file:  
`QuanLyCuaHangDienThoai/Data/DatabaseConnection.cs`

Mặc định chuỗi kết nối sử dụng Windows Authentication trên Default Instance:
```csharp
public static string ConnectionString { get; set; } = 
    @"Server=localhost;Database=QuanLyCuaHangDienThoai;Integrated Security=True;TrustServerCertificate=True;";
```

- Nếu máy của bạn dùng SQL Server Express, bạn chỉ cần sửa:
```csharp
@"Server=.\SQLEXPRESS;Database=QuanLyCuaHangDienThoai;Integrated Security=True;TrustServerCertificate=True;";
```
- Nếu dùng tài khoản sa:
```csharp
@"Server=localhost;Database=QuanLyCuaHangDienThoai;User Id=sa;Password=your_password;TrustServerCertificate=True;";
```

---

## 6. HƯỚNG DẪN MỞ, BUILD VÀ CHẠY PROJECT

### Cách 1: Sử dụng Microsoft Visual Studio
1. Mở Visual Studio.
2. Chọn **Open a project or solution**.
3. Chọn file `QuanLyCuaHangDienThoai.sln` tại thư mục `d:\projectxdpmql`.
4. Nhấn phím `F6` hoặc `Ctrl + Shift + B` để Build Solution.
5. Nhấn phím `F5` hoặc nút **Start** màu xanh để chạy chương trình.

### Cách 2: Sử dụng dòng lệnh (.NET CLI)
Mở Command Prompt hoặc PowerShell tại thư mục dự án:
```powershell
# Di chuyển vào thư mục project
cd d:\projectxdpmql\QuanLyCuaHangDienThoai

# Build dự án
dotnet build

# Chạy ứng dụng
dotnet run
```

---

## 7. TÀI KHOẢN ĐĂNG NHẬP MẪU

Hệ thống đã được nạp sẵn 2 tài khoản mẫu (mật khẩu đã được mã hóa an toàn bằng SHA-256 trong CSDL):

| Vai trò (Role) | Tên đăng nhập | Mật khẩu | Quyền hạn |
| :--- | :--- | :--- | :--- |
| **Quản trị viên (Admin)** | `admin` | `admin123` | Toàn quyền: Quản lý người dùng, sản phẩm, danh mục, khách hàng, nhà cung cấp, nhập hàng, bán hàng, hóa đơn, tồn kho, thống kê |
| **Nhân viên (NhanVien)** | `nhanvien` | `123456` | Xem sản phẩm, xem tồn kho, quản lý khách hàng, bán hàng và xuất hóa đơn, tra cứu hóa đơn, tìm kiếm |

---

## 8. DANH SÁCH CHỨC NĂNG CHI TIẾT

1. **Đăng nhập & Phân quyền**:
   - Xác thực tài khoản với mật khẩu băm SHA-256.
   - Kiểm tra trạng thái hoạt động (tài khoản bị khóa không được đăng nhập).
   - Phân quyền chặt chẽ bằng code (chỉ Admin mới được quản lý người dùng và nhập hàng).
   - Đăng xuất an toàn và chuyển về màn hình đăng nhập.

2. **Quản lý Người dùng (Chỉ Admin)**:
   - Thêm tài khoản mới (kiểm tra không trùng tên đăng nhập).
   - Cập nhật quyền (Admin / NhanVien).
   - Đặt lại mật khẩu mới.
   - Khóa / Mở khóa tài khoản (ngăn chặn tự khóa chính mình).

3. **Quản lý Sản phẩm**:
   - Hiển thị danh sách sản phẩm với DataGridView định dạng tiền tệ VNĐ rõ ràng.
   - Thêm, sửa, xóa sản phẩm (kiểm tra không trùng mã, giá và tồn kho không âm).
   - Danh mục nạp động từ CSDL SQL Server.
   - Tìm kiếm nhanh theo mã, tên hoặc danh mục.

4. **Quản lý Danh mục**:
   - Quản lý các nhóm hàng (Apple, Samsung, Xiaomi, Phụ kiện, Tai nghe...).
   - Kiểm tra ràng buộc khóa ngoại trước khi xóa (báo lỗi nếu đang có sản phẩm thuộc danh mục).

5. **Quản lý Khách hàng & Nhà cung cấp**:
   - Đầy đủ thông tin: Họ tên/Tên công ty, SĐT, Địa chỉ, Email.
   - Kiểm tra hợp lệ định dạng số điện thoại Việt Nam (10-11 số) và định dạng Email.

6. **Nghiệp vụ Nhập hàng (Import)**:
   - Chọn nhà cung cấp và sản phẩm.
   - Tự động gợi ý giá nhập và hiển thị tồn kho hiện tại.
   - Khi lưu phiếu: Tự động tăng tồn kho `SoLuongTon = SoLuongTon + SoLuongNhap` và ghi nhật ký giao dịch vào bảng `InventoryTransactions` với `LoaiGiaoDich = 'NHAP'` trong 1 Transaction an toàn.

7. **Nghiệp vụ Bán hàng (Sale)**:
   - Tự động sinh mã hóa đơn `HD00000x`.
   - Chọn khách hàng, chọn sản phẩm, nhập số lượng mua.
   - **Kiểm soát tồn kho nghiêm ngặt**: Không cho phép bán vượt số lượng tồn thực tế.
   - Thêm/Xóa sản phẩm khỏi giỏ hàng, tính tổng tiền tự động.
   - **Thanh toán bằng SqlTransaction**: Tạo hóa đơn, tạo chi tiết hóa đơn, trừ tồn kho `SoLuongTon = SoLuongTon - SoLuongBan`, ghi lịch sử `LoaiGiaoDich = 'BAN'`. Nếu bất kỳ bước nào thất bại, hệ thống tự động Rollback đảm bảo không bao giờ sai lệch dữ liệu!

8. **Tra cứu Hóa đơn (Invoices)**:
   - Hiển thị danh sách hóa đơn bán hàng.
   - Click chọn hóa đơn để xem chi tiết từng mặt hàng đã bán, đơn giá, thành tiền.
   - Tìm kiếm theo mã hóa đơn, tên khách hàng, số điện thoại, khoảng ngày (Từ ngày -> Đến ngày).

9. **Theo dõi Tồn kho (Inventory)**:
   - Hiển thị danh sách tồn kho thực tế từ bảng `Products`.
   - Lọc nhanh: Tất cả, Hết hàng (`SoLuongTon = 0`), Sắp hết hàng (`0 < SoLuongTon <= 5`), Còn hàng (`SoLuongTon > 5`).
   - Tự động làm nổi bật dòng sản phẩm hết hàng (màu đỏ) và sắp hết (màu cam).
   - Không cho phép người dùng sửa trực tiếp số lượng tồn trên giao diện.

10. **Báo cáo Thống kê (Statistics)**:
    - 4 thẻ KPI nổi bật: Tổng doanh thu, Tổng số hóa đơn, Tổng số loại sản phẩm, Tổng lượng hàng tồn.
    - Lọc thống kê theo khoảng thời gian tùy chọn, Tháng này, hoặc Tất cả.
    - Bảng thống kê chi tiết doanh thu theo từng ngày.
    - Bảng Top 5 sản phẩm bán chạy nhất theo số lượng và doanh số.
