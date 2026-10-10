using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyCuaHangDienThoai.Data;
using QuanLyCuaHangDienThoai.Models;

namespace QuanLyCuaHangDienThoai.Repositories
{
    public class InventoryRepository
    {
        public List<InventoryTransaction> GetAllTransactions()
        {
            var list = new List<InventoryTransaction>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT t.Id, t.ProductId, t.LoaiGiaoDich, t.SoLuong, t.DonGia, 
                           t.NgayGiaoDich, t.UserId, t.GhiChu,
                           p.MaSanPham, p.TenSanPham, u.Username
                    FROM InventoryTransactions t
                    INNER JOIN Products p ON t.ProductId = p.Id
                    INNER JOIN Users u ON t.UserId = u.Id
                    ORDER BY t.Id DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReadTransaction(reader));
                        }
                    }
                }
            }
            return list;
        }

        public List<InventoryTransaction> GetTransactionsByProductId(int productId)
        {
            var list = new List<InventoryTransaction>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT t.Id, t.ProductId, t.LoaiGiaoDich, t.SoLuong, t.DonGia, 
                           t.NgayGiaoDich, t.UserId, t.GhiChu,
                           p.MaSanPham, p.TenSanPham, u.Username
                    FROM InventoryTransactions t
                    INNER JOIN Products p ON t.ProductId = p.Id
                    INNER JOIN Users u ON t.UserId = u.Id
                    WHERE t.ProductId = @ProductId
                    ORDER BY t.Id DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReadTransaction(reader));
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Thực hiện nhập hàng với SQL TRANSACTION:
        /// 1. Tăng tồn kho: SoLuongTon = SoLuongTon + SoLuongNhap
        /// 2. Cập nhật giá nhập mới cho sản phẩm
        /// 3. Ghi vào InventoryTransactions (LoaiGiaoDich = 'NHAP')
        /// </summary>
        public bool ProcessImport(int productId, int quantity, decimal importPrice, int userId, string note, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (quantity <= 0)
            {
                errorMessage = "Số lượng nhập phải lớn hơn 0!";
                return false;
            }
            if (importPrice < 0)
            {
                errorMessage = "Giá nhập không được âm!";
                return false;
            }

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Tăng tồn kho và cập nhật giá nhập
                        string updateProductQuery = @"
                            UPDATE Products 
                            SET SoLuongTon = SoLuongTon + @Quantity,
                                GiaNhap = @ImportPrice
                            WHERE Id = @ProductId";
                        using (var cmd = new SqlCommand(updateProductQuery, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@ImportPrice", importPrice);
                            cmd.Parameters.AddWithValue("@ProductId", productId);
                            int rows = cmd.ExecuteNonQuery();
                            if (rows == 0)
                            {
                                tran.Rollback();
                                errorMessage = "Không tìm thấy sản phẩm cần nhập kho!";
                                return false;
                            }
                        }

                        // 2. Ghi lịch sử giao dịch kho
                        string insertTransQuery = @"
                            INSERT INTO InventoryTransactions (ProductId, LoaiGiaoDich, SoLuong, DonGia, NgayGiaoDich, UserId, GhiChu)
                            VALUES (@ProductId, N'NHAP', @Quantity, @ImportPrice, GETDATE(), @UserId, @GhiChu)";
                        using (var cmd = new SqlCommand(insertTransQuery, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@ProductId", productId);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@ImportPrice", importPrice);
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrWhiteSpace(note) ? "Nhập hàng từ nhà cung cấp" : note.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tran.Rollback(); } catch { }
                        errorMessage = "Lỗi khi xử lý nhập hàng: " + ex.Message;
                        return false;
                    }
                }
            }
        }

        private InventoryTransaction ReadTransaction(SqlDataReader reader)
        {
            return new InventoryTransaction
            {
                Id = reader.GetInt32(0),
                ProductId = reader.GetInt32(1),
                LoaiGiaoDich = reader.GetString(2),
                SoLuong = reader.GetInt32(3),
                DonGia = reader.GetDecimal(4),
                NgayGiaoDich = reader.GetDateTime(5),
                UserId = reader.GetInt32(6),
                GhiChu = reader.IsDBNull(7) ? "" : reader.GetString(7),
                MaSanPham = reader.GetString(8),
                TenSanPham = reader.GetString(9),
                Username = reader.GetString(10)
            };
        }
    }
}
