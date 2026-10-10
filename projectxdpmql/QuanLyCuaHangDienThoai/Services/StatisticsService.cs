using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyCuaHangDienThoai.Data;

namespace QuanLyCuaHangDienThoai.Services
{
    public class StatisticsService
    {
        public class OverallStats
        {
            public decimal TotalRevenue { get; set; }
            public int TotalInvoices { get; set; }
            public int TotalProducts { get; set; }
            public int TotalInventoryQuantity { get; set; }
        }

        public OverallStats GetOverallStats(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var stats = new OverallStats();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // 1. Thống kê Hóa đơn và Doanh thu
                string invoiceQuery = "SELECT ISNULL(COUNT(*), 0), ISNULL(SUM(TongTien), 0) FROM Invoices WHERE 1=1 ";
                if (fromDate.HasValue) invoiceQuery += " AND NgayLap >= @FromDate";
                if (toDate.HasValue) invoiceQuery += " AND NgayLap <= @ToDate";

                using (var cmd = new SqlCommand(invoiceQuery, conn))
                {
                    if (fromDate.HasValue) cmd.Parameters.AddWithValue("@FromDate", fromDate.Value.Date);
                    if (toDate.HasValue) cmd.Parameters.AddWithValue("@ToDate", toDate.Value.Date.AddDays(1).AddTicks(-1));

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stats.TotalInvoices = reader.GetInt32(0);
                            stats.TotalRevenue = reader.GetDecimal(1);
                        }
                    }
                }

                // 2. Thống kê Sản phẩm và Tồn kho
                string productQuery = "SELECT ISNULL(COUNT(*), 0), ISNULL(SUM(SoLuongTon), 0) FROM Products WHERE TrangThai = 1";
                using (var cmd = new SqlCommand(productQuery, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stats.TotalProducts = reader.GetInt32(0);
                            stats.TotalInventoryQuantity = reader.GetInt32(1);
                        }
                    }
                }
            }
            return stats;
        }

        public DataTable GetRevenueByDate(DateTime fromDate, DateTime toDate)
        {
            var dt = new DataTable();
            dt.Columns.Add("Ngay", typeof(string));
            dt.Columns.Add("SoHoaDon", typeof(int));
            dt.Columns.Add("DoanhThu", typeof(decimal));

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT CONVERT(VARCHAR(10), NgayLap, 103) AS NgayStr,
                           CAST(NgayLap AS DATE) AS NgayGoc,
                           COUNT(*) AS SoHoaDon,
                           SUM(TongTien) AS DoanhThu
                    FROM Invoices
                    WHERE NgayLap >= @FromDate AND NgayLap <= @ToDate
                    GROUP BY CONVERT(VARCHAR(10), NgayLap, 103), CAST(NgayLap AS DATE)
                    ORDER BY NgayGoc ASC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddTicks(-1));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(reader.GetString(0), reader.GetInt32(2), reader.GetDecimal(3));
                        }
                    }
                }
            }
            return dt;
        }

        public DataTable GetTopSellingProducts(DateTime? fromDate = null, DateTime? toDate = null, int top = 5)
        {
            var dt = new DataTable();
            dt.Columns.Add("MaSanPham", typeof(string));
            dt.Columns.Add("TenSanPham", typeof(string));
            dt.Columns.Add("SoLuongDaBan", typeof(int));
            dt.Columns.Add("TongTienBan", typeof(decimal));

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = $@"
                    SELECT TOP ({top}) p.MaSanPham, p.TenSanPham, 
                           SUM(d.SoLuong) AS SoLuongDaBan, 
                           SUM(d.ThanhTien) AS TongTienBan
                    FROM InvoiceDetails d
                    INNER JOIN Invoices i ON d.InvoiceId = i.Id
                    INNER JOIN Products p ON d.ProductId = p.Id
                    WHERE 1 = 1 ";

                if (fromDate.HasValue) query += " AND i.NgayLap >= @FromDate";
                if (toDate.HasValue) query += " AND i.NgayLap <= @ToDate";

                query += @"
                    GROUP BY p.MaSanPham, p.TenSanPham
                    ORDER BY SoLuongDaBan DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    if (fromDate.HasValue) cmd.Parameters.AddWithValue("@FromDate", fromDate.Value.Date);
                    if (toDate.HasValue) cmd.Parameters.AddWithValue("@ToDate", toDate.Value.Date.AddDays(1).AddTicks(-1));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetDecimal(3));
                        }
                    }
                }
            }
            return dt;
        }
    }
}
