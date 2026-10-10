using System;
using System.Collections.Generic;
using QuanLyCuaHangDienThoai.Models;
using QuanLyCuaHangDienThoai.Repositories;

namespace QuanLyCuaHangDienThoai.Services
{
    public class InvoiceService
    {
        private readonly InvoiceRepository _repo = new InvoiceRepository();

        public List<Invoice> GetAll() => _repo.GetAll();

        public Invoice GetById(int id) => _repo.GetById(id);

        public List<InvoiceDetail> GetDetails(int invoiceId) => _repo.GetDetailsByInvoiceId(invoiceId);

        public string GenerateNewCode() => _repo.GenerateNewInvoiceCode();

        public bool CreateSale(Invoice invoice, List<InvoiceDetail> details, out string errorMessage)
        {
            return _repo.CreateSaleInvoice(invoice, details, out errorMessage);
        }

        public List<Invoice> Search(string keyword, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return _repo.Search(keyword, fromDate, toDate);
        }
    }
}
