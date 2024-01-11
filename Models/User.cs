using System.ComponentModel.DataAnnotations;

namespace Gudang_Super_Market.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username harus diisi.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password harus diisi.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
