using System;

namespace QuanLyCuaHangDienThoai.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string MaHoaDon { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public DateTime NgayLap { get; set; } = DateTime.Now;
        public decimal TongTien { get; set; }

        // Bổ sung thông tin hiển thị trên DataGridView
        public string TenKhachHang { get; set; }
        public string SoDienThoaiKhachHang { get; set; }
        public string TenNhanVien { get; set; }
    }
}
