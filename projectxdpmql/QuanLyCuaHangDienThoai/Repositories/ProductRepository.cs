using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyCuaHangDienThoai.Data;
using QuanLyCuaHangDienThoai.Models;

namespace QuanLyCuaHangDienThoai.Repositories
{
    public class ProductRepository
    {
        public List<Product> GetAll()
        {
            var list = new List<Product>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT p.Id, p.MaSanPham, p.TenSanPham, p.CategoryId, p.GiaNhap, p.GiaBan, 
                           p.SoLuongTon, p.DonViTinh, p.TrangThai, c.TenDanhMuc
                    FROM Products p
                    INNER JOIN Categories c ON p.CategoryId = c.Id
                    ORDER BY p.Id DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReadProduct(reader));
                        }
                    }
                }
            }
            return list;
        }

        public Product GetById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT p.Id, p.MaSanPham, p.TenSanPham, p.CategoryId, p.GiaNhap, p.GiaBan, 
                           p.SoLuongTon, p.DonViTinh, p.TrangThai, c.TenDanhMuc
                    FROM Products p
                    INNER JOIN Categories c ON p.CategoryId = c.Id
                    WHERE p.Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ReadProduct(reader);
                        }
                    }
                }
            }
            return null;
        }

        public Product GetByCode(string maSanPham)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT p.Id, p.MaSanPham, p.TenSanPham, p.CategoryId, p.GiaNhap, p.GiaBan, 
                           p.SoLuongTon, p.DonViTinh, p.TrangThai, c.TenDanhMuc
                    FROM Products p
                    INNER JOIN Categories c ON p.CategoryId = c.Id
                    WHERE p.MaSanPham = @MaSanPham";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", maSanPham.Trim());
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ReadProduct(reader);
                        }
                    }
                }
            }
            return null;
        }

        public bool Add(Product p)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO Products (MaSanPham, TenSanPham, CategoryId, GiaNhap, GiaBan, SoLuongTon, DonViTinh, TrangThai)
                    VALUES (@MaSanPham, @TenSanPham, @CategoryId, @GiaNhap, @GiaBan, @SoLuongTon, @DonViTinh, @TrangThai)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", p.MaSanPham.Trim());
                    cmd.Parameters.AddWithValue("@TenSanPham", p.TenSanPham.Trim());
                    cmd.Parameters.AddWithValue("@CategoryId", p.CategoryId);
                    cmd.Parameters.AddWithValue("@GiaNhap", p.GiaNhap);
                    cmd.Parameters.AddWithValue("@GiaBan", p.GiaBan);
                    cmd.Parameters.AddWithValue("@SoLuongTon", p.SoLuongTon);
                    cmd.Parameters.AddWithValue("@DonViTinh", string.IsNullOrWhiteSpace(p.DonViTinh) ? "Chiếc" : p.DonViTinh.Trim());
                    cmd.Parameters.AddWithValue("@TrangThai", p.TrangThai);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(Product p)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE Products 
                    SET MaSanPham = @MaSanPham, TenSanPham = @TenSanPham, CategoryId = @CategoryId, 
                        GiaNhap = @GiaNhap, GiaBan = @GiaBan, DonViTinh = @DonViTinh, TrangThai = @TrangThai
                    WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", p.Id);
                    cmd.Parameters.AddWithValue("@MaSanPham", p.MaSanPham.Trim());
                    cmd.Parameters.AddWithValue("@TenSanPham", p.TenSanPham.Trim());
                    cmd.Parameters.AddWithValue("@CategoryId", p.CategoryId);
                    cmd.Parameters.AddWithValue("@GiaNhap", p.GiaNhap);
                    cmd.Parameters.AddWithValue("@GiaBan", p.GiaBan);
                    cmd.Parameters.AddWithValue("@DonViTinh", string.IsNullOrWhiteSpace(p.DonViTinh) ? "Chiếc" : p.DonViTinh.Trim());
                    cmd.Parameters.AddWithValue("@TrangThai", p.TrangThai);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id, out string errorMessage)
        {
            errorMessage = string.Empty;
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                // Kiểm tra xem sản phẩm đã có trong hóa đơn hay giao dịch kho chưa
                string checkInvoice = "SELECT COUNT(*) FROM InvoiceDetails WHERE ProductId = @Id";
                using (var checkCmd = new SqlCommand(checkInvoice, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Id", id);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        errorMessage = "Không thể xóa sản phẩm này vì đã có dữ liệu hóa đơn bán hàng liên kết. Bạn có thể chuyển trạng thái sang 'Ngừng kinh doanh'!";
                        return false;
                    }
                }

                string checkTrans = "SELECT COUNT(*) FROM InventoryTransactions WHERE ProductId = @Id";
                using (var checkCmd = new SqlCommand(checkTrans, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Id", id);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        errorMessage = "Không thể xóa sản phẩm này vì đã có lịch sử nhập/xuất kho liên kết. Bạn có thể chuyển trạng thái sang 'Ngừng kinh doanh'!";
                        return false;
                    }
                }

                string deleteQuery = "DELETE FROM Products WHERE Id = @Id";
                using (var cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool IsCodeExists(string maSanPham, int? excludeId = null)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Products WHERE MaSanPham = @MaSanPham" +
                               (excludeId.HasValue ? " AND Id != @ExcludeId" : "");
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", maSanPham.Trim());
                    if (excludeId.HasValue)
                        cmd.Parameters.AddWithValue("@ExcludeId", excludeId.Value);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public List<Product> Search(string keyword)
        {
            var list = new List<Product>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT p.Id, p.MaSanPham, p.TenSanPham, p.CategoryId, p.GiaNhap, p.GiaBan, 
                           p.SoLuongTon, p.DonViTinh, p.TrangThai, c.TenDanhMuc
                    FROM Products p
                    INNER JOIN Categories c ON p.CategoryId = c.Id
                    WHERE p.MaSanPham LIKE @Keyword OR p.TenSanPham LIKE @Keyword OR c.TenDanhMuc LIKE @Keyword
                    ORDER BY p.Id DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", $"%{keyword.Trim()}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReadProduct(reader));
                        }
                    }
                }
            }
            return list;
        }

        public List<Product> FilterStock(string filterType, string keyword = "")
        {
            var list = new List<Product>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT p.Id, p.MaSanPham, p.TenSanPham, p.CategoryId, p.GiaNhap, p.GiaBan, 
                           p.SoLuongTon, p.DonViTinh, p.TrangThai, c.TenDanhMuc
                    FROM Products p
                    INNER JOIN Categories c ON p.CategoryId = c.Id
                    WHERE 1 = 1 ";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query += " AND (p.MaSanPham LIKE @Keyword OR p.TenSanPham LIKE @Keyword OR c.TenDanhMuc LIKE @Keyword)";
                }

                if (filterType == "OUT_OF_STOCK") // Hết hàng
                {
                    query += " AND p.SoLuongTon = 0";
                }
                else if (filterType == "LOW_STOCK") // Sắp hết hàng (dưới hoặc bằng 5 sản phẩm)
                {
                    query += " AND p.SoLuongTon > 0 AND p.SoLuongTon <= 5";
                }
                else if (filterType == "IN_STOCK") // Còn hàng (trên 5 sản phẩm)
                {
                    query += " AND p.SoLuongTon > 5";
                }

                query += " ORDER BY p.SoLuongTon ASC, p.Id DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        cmd.Parameters.AddWithValue("@Keyword", $"%{keyword.Trim()}%");
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReadProduct(reader));
                        }
                    }
                }
            }
            return list;
        }

        private Product ReadProduct(SqlDataReader reader)
        {
            return new Product
            {
                Id = reader.GetInt32(0),
                MaSanPham = reader.GetString(1),
                TenSanPham = reader.GetString(2),
                CategoryId = reader.GetInt32(3),
                GiaNhap = reader.GetDecimal(4),
                GiaBan = reader.GetDecimal(5),
                SoLuongTon = reader.GetInt32(6),
                DonViTinh = reader.GetString(7),
                TrangThai = reader.GetBoolean(8),
                TenDanhMuc = reader.GetString(9)
            };
        }
    }
}
