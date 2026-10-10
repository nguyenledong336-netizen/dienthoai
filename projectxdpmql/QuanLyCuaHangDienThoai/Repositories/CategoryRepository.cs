using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyCuaHangDienThoai.Data;
using QuanLyCuaHangDienThoai.Models;

namespace QuanLyCuaHangDienThoai.Repositories
{
    public class CategoryRepository
    {
        public List<Category> GetAll()
        {
            var list = new List<Category>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, TenDanhMuc, MoTa FROM Categories ORDER BY Id ASC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Category
                            {
                                Id = reader.GetInt32(0),
                                TenDanhMuc = reader.GetString(1),
                                MoTa = reader.IsDBNull(2) ? "" : reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public Category GetById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, TenDanhMuc, MoTa FROM Categories WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Category
                            {
                                Id = reader.GetInt32(0),
                                TenDanhMuc = reader.GetString(1),
                                MoTa = reader.IsDBNull(2) ? "" : reader.GetString(2)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool Add(Category cat)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Categories (TenDanhMuc, MoTa) VALUES (@TenDanhMuc, @MoTa)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenDanhMuc", cat.TenDanhMuc.Trim());
                    cmd.Parameters.AddWithValue("@MoTa", string.IsNullOrWhiteSpace(cat.MoTa) ? (object)DBNull.Value : cat.MoTa.Trim());
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(Category cat)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Categories SET TenDanhMuc = @TenDanhMuc, MoTa = @MoTa WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", cat.Id);
                    cmd.Parameters.AddWithValue("@TenDanhMuc", cat.TenDanhMuc.Trim());
                    cmd.Parameters.AddWithValue("@MoTa", string.IsNullOrWhiteSpace(cat.MoTa) ? (object)DBNull.Value : cat.MoTa.Trim());
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
                // Kiểm tra xem có sản phẩm thuộc danh mục này không
                string checkQuery = "SELECT COUNT(*) FROM Products WHERE CategoryId = @Id";
                using (var checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Id", id);
                    int productCount = (int)checkCmd.ExecuteScalar();
                    if (productCount > 0)
                    {
                        errorMessage = $"Không thể xóa danh mục này vì đang có {productCount} sản phẩm liên kết!";
                        return false;
                    }
                }

                string deleteQuery = "DELETE FROM Categories WHERE Id = @Id";
                using (var cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Category> Search(string keyword)
        {
            var list = new List<Category>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, TenDanhMuc, MoTa FROM Categories WHERE TenDanhMuc LIKE @Keyword OR MoTa LIKE @Keyword ORDER BY Id ASC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", $"%{keyword.Trim()}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Category
                            {
                                Id = reader.GetInt32(0),
                                TenDanhMuc = reader.GetString(1),
                                MoTa = reader.IsDBNull(2) ? "" : reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
