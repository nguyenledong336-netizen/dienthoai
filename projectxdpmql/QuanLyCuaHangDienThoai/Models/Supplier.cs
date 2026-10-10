namespace QuanLyCuaHangDienThoai.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string TenNhaCungCap { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return TenNhaCungCap;
        }
    }
}
