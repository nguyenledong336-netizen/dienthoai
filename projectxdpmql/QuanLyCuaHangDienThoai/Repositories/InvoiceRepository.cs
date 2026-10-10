using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyCuaHangDienThoai.Data;
using QuanLyCuaHangDienThoai.Models;

namespace QuanLyCuaHangDienThoai.Repositories
{
    public class InvoiceRepository
    {
        public List<Invoice> GetAll()
        {
            var list = new List<Invoice>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT i.Id, i.MaHoaDon, i.CustomerId, i.UserId, i.NgayLap, i.TongTien,
                           c.HoTen, c.SoDienThoai, u.Username
                    FROM Invoices i
                    INNER JOIN Customers c ON i.CustomerId = c.Id
                    INNER JOIN Users u ON i.UserId = u.Id
                    ORDER BY i.Id DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReadInvoice(reader));
                        }
                    }
                }
            }
            return list;
        }

        public Invoice GetById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT i.Id, i.MaHoaDon, i.CustomerId, i.UserId, i.NgayLap, i.TongTien,
                           c.HoTen, c.SoDienThoai, u.Username
                    FROM Invoices i
                    INNER JOIN Customers c ON i.CustomerId = c.Id
                    INNER JOIN Users u ON i.UserId = u.Id
                    WHERE i.Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ReadInvoice(reader);
                        }
                    }
                }
            }
            return null;
        }

        public List<InvoiceDetail> GetDetailsByInvoiceId(int invoiceId)
        {
            var list = new List<InvoiceDetail>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT d.Id, d.InvoiceId, d.ProductId, d.SoLuong, d.DonGia, d.ThanhTien,
                           p.MaSanPham, p.TenSanPham, p.DonViTinh
                    FROM InvoiceDetails d
                    INNER JOIN Products p ON d.ProductId = p.Id
                    WHERE d.InvoiceId = @InvoiceId";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new InvoiceDetail
                            {
                                Id = reader.GetInt32(0),
                                InvoiceId = reader.GetInt32(1),
                                ProductId = reader.GetInt32(2),
                                SoLuong = reader.GetInt32(3),
                                DonGia = reader.GetDecimal(4),
                                ThanhTien = reader.GetDecimal(5),
                                MaSanPham = reader.GetString(6),
                                TenSanPham = reader.GetString(7),
                                DonViTinh = reader.GetString(8)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public string GenerateNewInvoiceCode()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT ISNULL(MAX(Id), 0) + 1 FROM Invoices";
                using (var cmd = new SqlCommand(query, conn))
                {
                    int nextId = (int)cmd.ExecuteScalar();
                    return $"HD{nextId:D6}";
                }
            }
        }

        /// <summary>
        /// Thanh toán bán hàng hoàn chỉnh với SQL TRANSACTION:
        /// 1. Kiểm tra tồn kho cho tất cả sản phẩm
        /// 2. Tạo Hóa đơn
        /// 3. Thêm Chi tiết hóa đơn
        /// 4. Giảm số lượng tồn kho của từng sản phẩm
        /// 5. Ghi lịch sử giao dịch bán hàng (LoaiGiaoDich = 'BAN')
        /// </summary>
        public bool CreateSaleInvoice(Invoice invoice, List<InvoiceDetail> details, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (details == null || details.Count == 0)
            {
                errorMessage = "Hóa đơn phải có ít nhất 1 sản phẩm!";
                return false;
            }

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Kiểm tra tồn kho trước
                        foreach (var item in details)
                        {
                            string checkStockQuery = "SELECT SoLuongTon, TenSanPham FROM Products WITH (UPDLOCK) WHERE Id = @ProductId";
                            using (var checkCmd = new SqlCommand(checkStockQuery, conn, tran))
                            {
                                checkCmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                                using (var reader = checkCmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        int stock = reader.GetInt32(0);
                                        string name = reader.GetString(1);
                                        if (stock < item.SoLuong)
                                        {
                                            reader.Close();
                                            tran.Rollback();
                                            errorMessage = $"Sản phẩm '{name}' chỉ còn {stock} trong kho, không đủ để bán {item.SoLuong}!";
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        reader.Close();
                                        tran.Rollback();
                                        errorMessage = $"Không tìm thấy sản phẩm có mã ID={item.ProductId}!";
                                        return false;
                                    }
                                }
                            }
                        }

                        // 2. Chèn Hóa Đơn
                        string insertInvoiceQuery = @"
                            INSERT INTO Invoices (MaHoaDon, CustomerId, UserId, NgayLap, TongTien)
                            OUTPUT INSERTED.Id
                            VALUES (@MaHoaDon, @CustomerId, @UserId, @NgayLap, @TongTien)";
                        int newInvoiceId;
                        using (var cmd = new SqlCommand(insertInvoiceQuery, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaHoaDon", invoice.MaHoaDon);
                            cmd.Parameters.AddWithValue("@CustomerId", invoice.CustomerId);
                            cmd.Parameters.AddWithValue("@UserId", invoice.UserId);
                            cmd.Parameters.AddWithValue("@NgayLap", invoice.NgayLap);
                            cmd.Parameters.AddWithValue("@TongTien", invoice.TongTien);
                            newInvoiceId = (int)cmd.ExecuteScalar();
                        }
                        invoice.Id = newInvoiceId;

                        // 3, 4, 5. Thêm Chi tiết, Trừ tồn kho, Ghi InventoryTransactions
                        foreach (var item in details)
                        {
                            // 3. Chèn InvoiceDetail
                            string insertDetailQuery = @"
                                INSERT INTO InvoiceDetails (InvoiceId, ProductId, SoLuong, DonGia, ThanhTien)
                                VALUES (@InvoiceId, @ProductId, @SoLuong, @DonGia, @ThanhTien)";
                            using (var cmd = new SqlCommand(insertDetailQuery, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@InvoiceId", newInvoiceId);
                                cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                                cmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                                cmd.Parameters.AddWithValue("@DonGia", item.DonGia);
                                cmd.Parameters.AddWithValue("@ThanhTien", item.ThanhTien);
                                cmd.ExecuteNonQuery();
                            }

                            // 4. Trừ số lượng tồn kho
                            string updateStockQuery = @"
                                UPDATE Products 
                                SET SoLuongTon = SoLuongTon - @SoLuong 
                                WHERE Id = @ProductId";
                            using (var cmd = new SqlCommand(updateStockQuery, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                                cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                                cmd.ExecuteNonQuery();
                            }

                            // 5. Ghi lịch sử giao dịch kho
                            string insertTransQuery = @"
                                INSERT INTO InventoryTransactions (ProductId, LoaiGiaoDich, SoLuong, DonGia, NgayGiaoDich, UserId, GhiChu)
                                VALUES (@ProductId, N'BAN', @SoLuong, @DonGia, @NgayGiaoDich, @UserId, @GhiChu)";
                            using (var cmd = new SqlCommand(insertTransQuery, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                                cmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                                cmd.Parameters.AddWithValue("@DonGia", item.DonGia);
                                cmd.Parameters.AddWithValue("@NgayGiaoDich", invoice.NgayLap);
                                cmd.Parameters.AddWithValue("@UserId", invoice.UserId);
                                cmd.Parameters.AddWithValue("@GhiChu", $"Xuất bán theo hóa đơn {invoice.MaHoaDon}");
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tran.Rollback(); } catch { }
                        errorMessage = "Lỗi khi xử lý giao dịch hóa đơn: " + ex.Message;
                        return false;
                    }
                }
            }
        }

        public List<Invoice> Search(string keyword, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var list = new List<Invoice>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT i.Id, i.MaHoaDon, i.CustomerId, i.UserId, i.NgayLap, i.TongTien,
                           c.HoTen, c.SoDienThoai, u.Username
                    FROM Invoices i
                    INNER JOIN Customers c ON i.CustomerId = c.Id
                    INNER JOIN Users u ON i.UserId = u.Id
                    WHERE 1 = 1 ";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query += " AND (i.MaHoaDon LIKE @Keyword OR c.HoTen LIKE @Keyword OR c.SoDienThoai LIKE @Keyword OR u.Username LIKE @Keyword)";
                }

                if (fromDate.HasValue)
                {
                    query += " AND i.NgayLap >= @FromDate";
                }

                if (toDate.HasValue)
                {
                    query += " AND i.NgayLap <= @ToDate";
                }

                query += " ORDER BY i.Id DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        cmd.Parameters.AddWithValue("@Keyword", $"%{keyword.Trim()}%");
                    }
                    if (fromDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate.Value.Date);
                    }
                    if (toDate.HasValue)
                    {
                        // Đến hết ngày 23:59:59
                        cmd.Parameters.AddWithValue("@ToDate", toDate.Value.Date.AddDays(1).AddTicks(-1));
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReadInvoice(reader));
                        }
                    }
                }
            }
            return list;
        }

        private Invoice ReadInvoice(SqlDataReader reader)
        {
            return new Invoice
            {
                Id = reader.GetInt32(0),
                MaHoaDon = reader.GetString(1),
                CustomerId = reader.GetInt32(2),
                UserId = reader.GetInt32(3),
                NgayLap = reader.GetDateTime(4),
                TongTien = reader.GetDecimal(5),
                TenKhachHang = reader.GetString(6),
                SoDienThoaiKhachHang = reader.IsDBNull(7) ? "" : reader.GetString(7),
                TenNhanVien = reader.GetString(8)
            };
        }
    }
}
