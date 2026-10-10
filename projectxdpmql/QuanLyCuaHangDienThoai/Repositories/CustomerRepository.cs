using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyCuaHangDienThoai.Data;
using QuanLyCuaHangDienThoai.Models;

namespace QuanLyCuaHangDienThoai.Repositories
{
    public class CustomerRepository
    {
        public List<Customer> GetAll()
        {
            var list = new List<Customer>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, HoTen, SoDienThoai, DiaChi, Email FROM Customers ORDER BY Id DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReadCustomer(reader));
                        }
                    }
                }
            }
            return list;
        }

        public Customer GetById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, HoTen, SoDienThoai, DiaChi, Email FROM Customers WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ReadCustomer(reader);
                        }
                    }
                }
            }
            return null;
        }

        public bool Add(Customer c)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Customers (HoTen, SoDienThoai, DiaChi, Email) VALUES (@HoTen, @SoDienThoai, @DiaChi, @Email)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", c.HoTen.Trim());
                    cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrWhiteSpace(c.SoDienThoai) ? (object)DBNull.Value : c.SoDienThoai.Trim());
                    cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrWhiteSpace(c.DiaChi) ? (object)DBNull.Value : c.DiaChi.Trim());
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(c.Email) ? (object)DBNull.Value : c.Email.Trim());
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(Customer c)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Customers SET HoTen = @HoTen, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, Email = @Email WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", c.Id);
                    cmd.Parameters.AddWithValue("@HoTen", c.HoTen.Trim());
                    cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrWhiteSpace(c.SoDienThoai) ? (object)DBNull.Value : c.SoDienThoai.Trim());
                    cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrWhiteSpace(c.DiaChi) ? (object)DBNull.Value : c.DiaChi.Trim());
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(c.Email) ? (object)DBNull.Value : c.Email.Trim());
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
                string checkQuery = "SELECT COUNT(*) FROM Invoices WHERE CustomerId = @Id";
                using (var checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Id", id);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        errorMessage = $"Không thể xóa khách hàng này vì đang có {count} hóa đơn mua hàng liên kết!";
                        return false;
                    }
                }

                string deleteQuery = "DELETE FROM Customers WHERE Id = @Id";
                using (var cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Customer> Search(string keyword)
        {
            var list = new List<Customer>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, HoTen, SoDienThoai, DiaChi, Email FROM Customers " +
                               "WHERE HoTen LIKE @Keyword OR SoDienThoai LIKE @Keyword OR DiaChi LIKE @Keyword OR Email LIKE @Keyword " +
                               "ORDER BY Id DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", $"%{keyword.Trim()}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReadCustomer(reader));
                        }
                    }
                }
            }
            return list;
        }

        private Customer ReadCustomer(SqlDataReader reader)
        {
            return new Customer
            {
                Id = reader.GetInt32(0),
                HoTen = reader.GetString(1),
                SoDienThoai = reader.IsDBNull(2) ? "" : reader.GetString(2),
                DiaChi = reader.IsDBNull(3) ? "" : reader.GetString(3),
                Email = reader.IsDBNull(4) ? "" : reader.GetString(4)
            };
        }
    }
}
