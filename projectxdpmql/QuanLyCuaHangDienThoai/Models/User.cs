namespace QuanLyCuaHangDienThoai.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Admin" hoặc "NhanVien"
        public bool TrangThai { get; set; } = true; // true: Hoạt động, false: Khóa

        public string TrangThaiHienThi => TrangThai ? "Hoạt động" : "Đã khóa";
    }
}
