using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyCuaHangDienThoai.Data;
using QuanLyCuaHangDienThoai.Models;

namespace QuanLyCuaHangDienThoai.Repositories
{
    public class UserRepository
    {
        public List<User> GetAll()
        {
            var list = new List<User>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Username, Password, Role, TrangThai FROM Users ORDER BY Id DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3),
                                TrangThai = reader.GetBoolean(4)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public User GetById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Username, Password, Role, TrangThai FROM Users WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3),
                                TrangThai = reader.GetBoolean(4)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public User GetByUsername(string username)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Username, Password, Role, TrangThai FROM Users WHERE Username = @Username";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.Trim());
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3),
                                TrangThai = reader.GetBoolean(4)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool Add(User user)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Users (Username, Password, Role, TrangThai) VALUES (@Username, @Password, @Role, @TrangThai)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username.Trim());
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@TrangThai", user.TrangThai);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(User user)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Users SET Role = @Role, TrangThai = @TrangThai WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@TrangThai", user.TrangThai);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdatePassword(int id, string hashedPassword)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Users SET Password = @Password WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ToggleStatus(int id, bool status)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Users SET TrangThai = @TrangThai WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@TrangThai", status);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool IsUsernameExists(string username, int? excludeId = null)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username" +
                               (excludeId.HasValue ? " AND Id != @ExcludeId" : "");
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.Trim());
                    if (excludeId.HasValue)
                        cmd.Parameters.AddWithValue("@ExcludeId", excludeId.Value);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public List<User> Search(string keyword)
        {
            var list = new List<User>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Username, Password, Role, TrangThai FROM Users " +
                               "WHERE Username LIKE @Keyword OR Role LIKE @Keyword ORDER BY Id DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", $"%{keyword.Trim()}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3),
                                TrangThai = reader.GetBoolean(4)
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
