using System;
using Microsoft.Data.SqlClient;

namespace QuanLyCuaHangDienThoai.Data
{
    public static class DatabaseConnection
    {
        // Chuỗi kết nối SQL Server tập trung duy nhất tại đây.
        // Có thể thay đổi server name hoặc tài khoản SQL nếu dùng máy khác (ví dụ: Server=.\\SQLEXPRESS hoặc Server=DESKTOP-XXXX).
        public static string ConnectionString { get; set; } = 
            @"Server=localhost;Database=QuanLyCuaHangDienThoai;Integrated Security=True;TrustServerCertificate=True;";

        /// <summary>
        /// Tạo và trả về đối tượng SqlConnection mới
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Kiểm tra xem kết nối tới SQL Server có thành công hay không
        /// </summary>
        public static bool TestConnection(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
