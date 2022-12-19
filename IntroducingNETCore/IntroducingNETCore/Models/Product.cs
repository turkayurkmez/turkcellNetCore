using System.ComponentModel.DataAnnotations;

namespace IntroducingNETCore.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün adını boş bırakamazsınız")]
        [MinLength(3, ErrorMessage = "Ürünm adı en az üç karakter olmalıdır")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ürün fiyatını boş bırakamazsınız")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
