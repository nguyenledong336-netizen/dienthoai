using System;
using System.Collections.Generic;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Repositories;
using QuanLyCuaHangDienThoai.Utils;

namespace QuanLyCuaHangDienThoai.Services
{
    public class SupplierService
    {
        private readonly SupplierRepository _repo = new SupplierRepository();

        public List<Supplier> GetAll() => _repo.GetAll();

        public Supplier GetById(int id) => _repo.GetById(id);

        public bool Add(Supplier s, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (ValidationHelper.IsNullOrWhiteSpace(s.TenNhaCungCap))
            {
                errorMessage = "Tên nhà cung cấp không được để trống!";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(s.SoDienThoai) && !ValidationHelper.IsValidPhoneNumber(s.SoDienThoai))
            {
                errorMessage = "Số điện thoại không đúng định dạng!";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(s.Email) && !ValidationHelper.IsValidEmail(s.Email))
            {
                errorMessage = "Địa chỉ email không đúng định dạng!";
                return false;
            }

            return _repo.Add(s);
        }

        public bool Update(Supplier s, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (ValidationHelper.IsNullOrWhiteSpace(s.TenNhaCungCap))
            {
                errorMessage = "Tên nhà cung cấp không được để trống!";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(s.SoDienThoai) && !ValidationHelper.IsValidPhoneNumber(s.SoDienThoai))
            {
                errorMessage = "Số điện thoại không đúng định dạng!";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(s.Email) && !ValidationHelper.IsValidEmail(s.Email))
            {
                errorMessage = "Địa chỉ email không đúng định dạng!";
                return false;
            }

            return _repo.Update(s);
        }

        public bool Delete(int id, out string errorMessage)
        {
            return _repo.Delete(id, out errorMessage);
        }

        public List<Supplier> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _repo.GetAll();
            return _repo.Search(keyword);
        }
    }
}
