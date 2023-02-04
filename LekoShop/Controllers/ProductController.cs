using LekoShop.Data;
using LekoShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LekoShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly LekoContext _context;

        public ProductController(LekoContext context)
        {
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

            var selectCategory = _context.Categorys.ToList();
            
            
                ViewBag.SelectCategory = selectCategory;            
                
             return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product model)
        {
            
                
            
            
        if (ModelState.IsValid) {
				model.CategoryId = model.Category.Id;
				_context.Products.Add(model);
                _context.SaveChanges();
                return RedirectToAction("ProductList");  }
                                  
            return View(model);

}
}}
