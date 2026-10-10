using System;
using System.Collections.Generic;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Repositories;
using QuanLyCuaHangDienThoai.Utils;

namespace QuanLyCuaHangDienThoai.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repo = new ProductRepository();

        public List<Product> GetAll() => _repo.GetAll();

        public Product GetById(int id) => _repo.GetById(id);

        public Product GetByCode(string code) => _repo.GetByCode(code);

        public bool Add(Product p, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (ValidationHelper.IsNullOrWhiteSpace(p.MaSanPham))
            {
                errorMessage = "Mã sản phẩm không được để trống!";
                return false;
            }

            if (ValidationHelper.IsNullOrWhiteSpace(p.TenSanPham))
            {
                errorMessage = "Tên sản phẩm không được để trống!";
                return false;
            }

            if (p.CategoryId <= 0)
            {
                errorMessage = "Vui lòng chọn danh mục cho sản phẩm!";
                return false;
            }

            if (p.GiaNhap < 0)
            {
                errorMessage = "Giá nhập không được âm!";
                return false;
            }

            if (p.GiaBan < 0)
            {
                errorMessage = "Giá bán không được âm!";
                return false;
            }

            if (p.SoLuongTon < 0)
            {
                errorMessage = "Số lượng tồn không được âm!";
                return false;
            }

            if (_repo.IsCodeExists(p.MaSanPham))
            {
                errorMessage = $"Mã sản phẩm '{p.MaSanPham}' đã tồn tại! Vui lòng chọn mã khác.";
                return false;
            }

            return _repo.Add(p);
        }

        public bool Update(Product p, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (ValidationHelper.IsNullOrWhiteSpace(p.MaSanPham))
            {
                errorMessage = "Mã sản phẩm không được để trống!";
                return false;
            }

            if (ValidationHelper.IsNullOrWhiteSpace(p.TenSanPham))
            {
                errorMessage = "Tên sản phẩm không được để trống!";
                return false;
            }

            if (p.CategoryId <= 0)
            {
                errorMessage = "Vui lòng chọn danh mục cho sản phẩm!";
                return false;
            }

            if (p.GiaNhap < 0)
            {
                errorMessage = "Giá nhập không được âm!";
                return false;
            }

            if (p.GiaBan < 0)
            {
                errorMessage = "Giá bán không được âm!";
                return false;
            }

            if (_repo.IsCodeExists(p.MaSanPham, p.Id))
            {
                errorMessage = $"Mã sản phẩm '{p.MaSanPham}' đã tồn tại ở sản phẩm khác!";
                return false;
            }

            return _repo.Update(p);
        }

        public bool Delete(int id, out string errorMessage)
        {
            return _repo.Delete(id, out errorMessage);
        }

        public List<Product> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _repo.GetAll();
            return _repo.Search(keyword);
        }

        public List<Product> FilterStock(string filterType, string keyword = "")
        {
            return _repo.FilterStock(filterType, keyword);
        }
    }
}
