using System;
using System.Windows.Forms;
using QuanLyCuaHangDienThoai.Data;
using QuanLyCuaHangDienThoai.Forms;

namespace QuanLyCuaHangDienThoai
{
    internal static class Program
    {
        /// <summary>
        /// Điểm vào chính của ứng dụng Windows Forms.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Kiểm tra kết nối SQL Server trước khi khởi chạy form
            if (!DatabaseConnection.TestConnection(out string errorMessage))
            {
                DialogResult retry = MessageBox.Show(
                    "Không thể kết nối đến Microsoft SQL Server!\n\n" +
                    $"Chi tiết lỗi:\n{errorMessage}\n\n" +
                    "Vui lòng kiểm tra:\n" +
                    "1. Dịch vụ SQL Server (MSSQLSERVER hoặc SQLEXPRESS) đã được bật chưa.\n" +
                    "2. Database 'QuanLyCuaHangDienThoai' đã được tạo qua file Database.sql chưa.\n" +
                    "3. Chuỗi kết nối trong Data/DatabaseConnection.cs có phù hợp với máy của bạn không.\n\n" +
                    "Bạn có muốn tiếp tục mở ứng dụng không?",
                    "Cảnh báo kết nối Database",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (retry == DialogResult.No)
                {
                    return;
                }
            }

            // Mở LoginForm đầu tiên
            Application.Run(new LoginForm());
        }
    }
}