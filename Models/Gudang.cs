using System.ComponentModel.DataAnnotations;

namespace Gudang_Super_Market.Models
{
    public class Gudang
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama Gudang harus diisi.")]
        public string NamaGudang { get; set; }

        // Navigation property to represent the relationship with Barangs
        public List<Barang> Barangs { get; set; }

    }
}
