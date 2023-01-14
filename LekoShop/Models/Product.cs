using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LekoShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; }=string.Empty;
        public decimal Price { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public int AvailableQuantity { get; set; } = 0;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }




    }
}
