using System.ComponentModel.DataAnnotations;

namespace Gudang_Super_Market.Models
{
    public class Gudang
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama Gudang harus diisi.")]
        public string NamaGudang { get; set; }
        
    }
}
