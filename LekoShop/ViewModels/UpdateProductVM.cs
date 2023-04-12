using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LekoShop.ViewModels
{
    public class UpdateProductVM
    {
        public int Id { get; set; }
        [MaxLength (100)]
        public string Name { get; set; }
        public string ImageView { get; set; }
        public IFormFile NewPhoto { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int AvailableQuantiry { get; set; }
        public List<SelectListItem> CategorySelect { get; set; }
        
        public int CategoryId { get; set; }
    }
}
