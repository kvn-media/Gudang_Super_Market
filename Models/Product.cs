using System;
using System.ComponentModel.DataAnnotations;

namespace Gudang_Super_Market.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama Produk harus diisi.")]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Harga Produk harus lebih dari 0.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Jumlah Produk harus lebih dari atau sama dengan 0.")]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

       
    }
}