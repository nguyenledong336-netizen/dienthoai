using System;
using System.Collections.Generic;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Repositories;
using QuanLyCuaHangDienThoai.Utils;

namespace QuanLyCuaHangDienThoai.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _repo = new CustomerRepository();

        public List<Customer> GetAll() => _repo.GetAll();

        public Customer GetById(int id) => _repo.GetById(id);

        public bool Add(Customer c, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (ValidationHelper.IsNullOrWhiteSpace(c.HoTen))
            {
                errorMessage = "Họ tên khách hàng không được để trống!";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(c.SoDienThoai) && !ValidationHelper.IsValidPhoneNumber(c.SoDienThoai))
            {
                errorMessage = "Số điện thoại không đúng định dạng (yêu cầu 10 chữ số bắt đầu bằng số 0)!";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(c.Email) && !ValidationHelper.IsValidEmail(c.Email))
            {
                errorMessage = "Địa chỉ email không đúng định dạng!";
                return false;
            }

            return _repo.Add(c);
        }

        public bool Update(Customer c, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (ValidationHelper.IsNullOrWhiteSpace(c.HoTen))
            {
                errorMessage = "Họ tên khách hàng không được để trống!";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(c.SoDienThoai) && !ValidationHelper.IsValidPhoneNumber(c.SoDienThoai))
            {
                errorMessage = "Số điện thoại không đúng định dạng (yêu cầu 10 chữ số bắt đầu bằng số 0)!";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(c.Email) && !ValidationHelper.IsValidEmail(c.Email))
            {
                errorMessage = "Địa chỉ email không đúng định dạng!";
                return false;
            }

            return _repo.Update(c);
        }

        public bool Delete(int id, out string errorMessage)
        {
            return _repo.Delete(id, out errorMessage);
        }

        public List<Customer> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _repo.GetAll();
            return _repo.Search(keyword);
        }
    }
}
