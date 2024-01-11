using System.ComponentModel.DataAnnotations;

namespace Gudang_Super_Market.Models
{
    public class Barang
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama Barang harus diisi.")]
        public string NamaBarang { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Harga Barang harus lebih dari 0.")]
        public decimal HargaBarang { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Jumlah Barang harus lebih dari atau sama dengan 0.")]
        public int JumlahBarang { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpiredDate { get; set; }

        public int GudangId { get; set; }
        public Gudang Gudang { get; set; }

    }
}
