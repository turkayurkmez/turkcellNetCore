using System.ComponentModel.DataAnnotations;

namespace shop.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen ad alanını boş bırakmayınız")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }

        //Navigation Property
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}