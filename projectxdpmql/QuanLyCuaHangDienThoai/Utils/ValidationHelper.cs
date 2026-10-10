using System;
using System.Text.RegularExpressions;

namespace QuanLyCuaHangDienThoai.Utils
{
    public static class ValidationHelper
    {
        /// <summary>
        /// Kiểm tra chuỗi có bị rỗng hoặc chỉ toàn khoảng trắng
        /// </summary>
        public static bool IsNullOrWhiteSpace(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Kiểm tra định dạng số điện thoại Việt Nam (10 chữ số, bắt đầu bằng 03, 05, 07, 08, 09 hoặc 02x)
        /// </summary>
        public static bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Hỗ trợ số điện thoại di động (10 chữ số) và số máy bàn cố định (10-11 chữ số)
            string pattern = @"^(0|\+84)[1-9][0-9]{7,9}$";
            return Regex.IsMatch(phone.Trim(), pattern);
        }

        /// <summary>
        /// Kiểm tra định dạng email
        /// </summary>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email.Trim(), pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Kiểm tra số nguyên không âm
        /// </summary>
        public static bool IsNonNegativeInt(string value, out int result)
        {
            if (int.TryParse(value, out result))
            {
                return result >= 0;
            }
            result = 0;
            return false;
        }

        /// <summary>
        /// Kiểm tra số thực decimal không âm (cho đơn giá, thành tiền)
        /// </summary>
        public static bool IsNonNegativeDecimal(string value, out decimal result)
        {
            if (decimal.TryParse(value, out result))
            {
                return result >= 0;
            }
            result = 0;
            return false;
        }
    }
}
