using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyCuaHangDienThoai.Data;
using QuanLyCuaHangDienThoai.Models;

namespace QuanLyCuaHangDienThoai.Repositories
{
    public class SupplierRepository
    {
        public List<Supplier> GetAll()
        {
            var list = new List<Supplier>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, TenNhaCungCap, SoDienThoai, DiaChi, Email FROM Suppliers ORDER BY Id DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReadSupplier(reader));
                        }
                    }
                }
            }
            return list;
        }

        public Supplier GetById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, TenNhaCungCap, SoDienThoai, DiaChi, Email FROM Suppliers WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ReadSupplier(reader);
                        }
                    }
                }
            }
            return null;
        }

        public bool Add(Supplier s)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Suppliers (TenNhaCungCap, SoDienThoai, DiaChi, Email) VALUES (@TenNhaCungCap, @SoDienThoai, @DiaChi, @Email)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenNhaCungCap", s.TenNhaCungCap.Trim());
                    cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrWhiteSpace(s.SoDienThoai) ? (object)DBNull.Value : s.SoDienThoai.Trim());
                    cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrWhiteSpace(s.DiaChi) ? (object)DBNull.Value : s.DiaChi.Trim());
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(s.Email) ? (object)DBNull.Value : s.Email.Trim());
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(Supplier s)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Suppliers SET TenNhaCungCap = @TenNhaCungCap, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, Email = @Email WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", s.Id);
                    cmd.Parameters.AddWithValue("@TenNhaCungCap", s.TenNhaCungCap.Trim());
                    cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrWhiteSpace(s.SoDienThoai) ? (object)DBNull.Value : s.SoDienThoai.Trim());
                    cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrWhiteSpace(s.DiaChi) ? (object)DBNull.Value : s.DiaChi.Trim());
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(s.Email) ? (object)DBNull.Value : s.Email.Trim());
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
                string deleteQuery = "DELETE FROM Suppliers WHERE Id = @Id";
                using (var cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Supplier> Search(string keyword)
        {
            var list = new List<Supplier>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, TenNhaCungCap, SoDienThoai, DiaChi, Email FROM Suppliers " +
                               "WHERE TenNhaCungCap LIKE @Keyword OR SoDienThoai LIKE @Keyword OR DiaChi LIKE @Keyword " +
                               "ORDER BY Id DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", $"%{keyword.Trim()}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReadSupplier(reader));
                        }
                    }
                }
            }
            return list;
        }

        private Supplier ReadSupplier(SqlDataReader reader)
        {
            return new Supplier
            {
                Id = reader.GetInt32(0),
                TenNhaCungCap = reader.GetString(1),
                SoDienThoai = reader.IsDBNull(2) ? "" : reader.GetString(2),
                DiaChi = reader.IsDBNull(3) ? "" : reader.GetString(3),
                Email = reader.IsDBNull(4) ? "" : reader.GetString(4)
            };
        }
    }
}
