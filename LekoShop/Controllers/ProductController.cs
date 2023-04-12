using LekoShop.Data;
using LekoShop.Models;
using LekoShop.Services.Interfaces;
using LekoShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Text.RegularExpressions;

namespace LekoShop.Controllers
{
    public class ProductController : Controller
    {
		private readonly IPhotoService _photoService;
		private readonly LekoContext _context;

        public ProductController(LekoContext context, IPhotoService photoService)
        {
            _photoService = photoService;
            _context = context;
        }

        public IActionResult ProductList()
        {
            var productList = _context.Products.ToList();

            return View(productList);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            var model = new CreateProductViewModel();
			var allData = _context.Categorys.ToList();
            model.SelectCategory = new List<SelectListItem>();
            if (allData!=null)
            {
				foreach (var item in allData)
				{
					model.SelectCategory.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString()});
				}
			}                          
               

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(CreateProductViewModel productVm)
        {
            if (ModelState.IsValid)
            {
				var photoresult = _photoService.AddPhotoAsync(productVm.File);
				var newProduct = new Product
				{
					Name = productVm.Name,
					Image = photoresult.Result.Url.ToString(),
					Price = productVm.Price,
					Description = productVm.Description,
					AvailableQuantity = productVm.AvailableQuantity,
					CategoryId = Convert.ToInt32(productVm.CategoryId)
				};
                _context.Products.Add(newProduct);
                _context.SaveChanges();
				return RedirectToAction("ProductList");
			}

            else
            {
                return View(productVm);
            }
            
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var productAtId=_context.Products.FirstOrDefault(x=>x.Id== id);
            if (productAtId == null) return BadRequest("Not Found");
            else
            {
                var modelVM = new UpdateProductVM
                {
                    Id = id,
                    Name = productAtId.Name,
                    ImageView = productAtId.Image,
                    Price = productAtId.Price,
                    Description = productAtId.Description,
                    AvailableQuantiry = productAtId.AvailableQuantity,
                    CategoryId = productAtId.CategoryId
                };
                modelVM.CategorySelect = new List<SelectListItem>();
                var categoryList = _context.Categorys.ToList();
                foreach (var category in categoryList)
                {
                    modelVM.CategorySelect.Add(new SelectListItem 
                    { 
                        Text=category.Name,
                        Value=category.Id.ToString()                       
                    });
                }
                
                return View(modelVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProductAsync(UpdateProductVM updatemOdel)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit Product");
            }

            var photoResult = _photoService.AddPhotoAsync(updatemOdel.NewPhoto);
            if (photoResult== null)
            {
                ModelState.AddModelError("", "Photoresult is Empty");
                return View("Error");

            }

            var userProduct = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == updatemOdel.Id);

            if (userProduct==null)
            {
                return View("Product isn't Available");
            }

            if (userProduct.Image!=null)
            {
                await _photoService.DeletePhotoAsync(userProduct.Image);
            }

            var product = new Product
            {
                Image = photoResult.Result.Url.ToString(),
                Id = updatemOdel.Id,
                Name = updatemOdel.Name,

                Price = updatemOdel.Price,
                Description = updatemOdel.Description,
                AvailableQuantity = updatemOdel.AvailableQuantiry,
                CategoryId = updatemOdel.CategoryId
            };
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
            
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var objForDelete = _context.Products.Find(id);
            if (objForDelete!=null)
            {
                _context.Products.Remove(objForDelete);
                _context.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return BadRequest("Doesn't Exist");
        }




    }
}

