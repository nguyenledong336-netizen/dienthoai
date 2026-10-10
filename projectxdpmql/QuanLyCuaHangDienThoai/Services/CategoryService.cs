using System;
using System.Collections.Generic;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Repositories;
using QuanLyCuaHangDienThoai.Utils;

namespace QuanLyCuaHangDienThoai.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _repo = new CategoryRepository();

        public List<Category> GetAll() => _repo.GetAll();

        public Category GetById(int id) => _repo.GetById(id);

        public bool Add(Category cat, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (ValidationHelper.IsNullOrWhiteSpace(cat.TenDanhMuc))
            {
                errorMessage = "Tên danh mục không được để trống!";
                return false;
            }

            return _repo.Add(cat);
        }

        public bool Update(Category cat, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (ValidationHelper.IsNullOrWhiteSpace(cat.TenDanhMuc))
            {
                errorMessage = "Tên danh mục không được để trống!";
                return false;
            }

            return _repo.Update(cat);
        }

        public bool Delete(int id, out string errorMessage)
        {
            return _repo.Delete(id, out errorMessage);
        }

        public List<Category> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _repo.GetAll();
            return _repo.Search(keyword);
        }
    }
}
