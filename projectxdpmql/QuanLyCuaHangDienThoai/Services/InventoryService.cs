using System;
using System.Collections.Generic;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Repositories;

namespace QuanLyCuaHangDienThoai.Services
{
    public class InventoryService
    {
        private readonly InventoryRepository _repo = new InventoryRepository();

        public List<InventoryTransaction> GetAllTransactions() => _repo.GetAllTransactions();

        public List<InventoryTransaction> GetProductTransactions(int productId) => _repo.GetTransactionsByProductId(productId);

        public bool ImportProduct(int productId, int quantity, decimal importPrice, int userId, string note, out string errorMessage)
        {
            return _repo.ProcessImport(productId, quantity, importPrice, userId, note, out errorMessage);
        }
    }
}
