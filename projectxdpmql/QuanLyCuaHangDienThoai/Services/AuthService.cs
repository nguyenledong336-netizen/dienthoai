using System;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Repositories;
using QuanLyCuaHangDienThoai.Utils;

namespace QuanLyCuaHangDienThoai.Services
{
    public class AuthService
    {
        private static AuthService _instance;
        public static AuthService Instance => _instance ??= new AuthService();

        private readonly UserRepository _userRepo;

        public User CurrentUser { get; private set; }

        public AuthService()
        {
            _userRepo = new UserRepository();
        }

        public bool Login(string username, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (ValidationHelper.IsNullOrWhiteSpace(username))
            {
                errorMessage = "Vui lòng nhập tên đăng nhập!";
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "Vui lòng nhập mật khẩu!";
                return false;
            }

            var user = _userRepo.GetByUsername(username);
            if (user == null)
            {
                errorMessage = "Tên đăng nhập không tồn tại trong hệ thống!";
                return false;
            }

            if (!user.TrangThai)
            {
                errorMessage = "Tài khoản này hiện đang bị khóa. Vui lòng liên hệ Quản trị viên!";
                return false;
            }

            if (!PasswordHelper.VerifyPassword(password, user.Password))
            {
                errorMessage = "Mật khẩu không chính xác!";
                return false;
            }

            CurrentUser = user;
            return true;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public bool IsAdmin()
        {
            return CurrentUser != null && string.Equals(CurrentUser.Role, "Admin", StringComparison.OrdinalIgnoreCase);
        }

        public bool IsLoggedIn()
        {
            return CurrentUser != null;
        }
    }
}
