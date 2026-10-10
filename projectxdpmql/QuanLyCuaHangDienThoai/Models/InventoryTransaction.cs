using System;

namespace QuanLyCuaHangDienThoai.Models
{
    public class InventoryTransaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string LoaiGiaoDich { get; set; } // "NHAP", "BAN"
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public DateTime NgayGiaoDich { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public string GhiChu { get; set; }

        // Bổ sung thông tin hiển thị
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string Username { get; set; }
    }
}
