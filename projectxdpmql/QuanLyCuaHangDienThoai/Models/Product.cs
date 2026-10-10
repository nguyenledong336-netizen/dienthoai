namespace QuanLyCuaHangDienThoai.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int CategoryId { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public string DonViTinh { get; set; } = "Chiếc";
        public bool TrangThai { get; set; } = true;

        // Bổ sung thuộc tính hiển thị thuận tiện cho DataGridView
        public string TenDanhMuc { get; set; }
        public string TrangThaiHienThi => TrangThai ? "Đang kinh doanh" : "Ngừng kinh doanh";

        public override string ToString()
        {
            return $"{MaSanPham} - {TenSanPham}";
        }
    }
}
