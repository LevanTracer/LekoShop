using LekoShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace LekoShop.ViewModels
{
	public class CreateProductViewModel
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public decimal Price { get; set; }
		
		public string Description { get; set; }
		public int AvailableQuantity { get; set; }
		public List<SelectListItem>? SelectCategory { get; set; }
		public string CategoryId { get; set; }
		[Required]
		public IFormFile File { get; set; }
	}
}
