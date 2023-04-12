using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LekoShop.Models
{
    public class Cart
    {
       

        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal SumPrice { get; set; }
        public string Image { get; set; }
    }
}
