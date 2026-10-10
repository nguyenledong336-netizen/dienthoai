namespace QuanLyCuaHangDienThoai.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string TenDanhMuc { get; set; }
        public string MoTa { get; set; }

        public override string ToString()
        {
            return TenDanhMuc;
        }
    }
}
