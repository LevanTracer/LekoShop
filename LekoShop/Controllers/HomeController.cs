using LekoShop.Data;
using LekoShop.Models;
using LekoShop.Services;
using LekoShop.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace LekoShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LekoContext _context;

        public HomeController(ILogger<HomeController> logger, LekoContext context)
        {
            _logger = logger;
            _context= context;
        }

        

        public IActionResult Index()
        {
            var item=_context.Categorys.ToList();
            return View(item);
        }
        public IActionResult ProductsAtCategoryId(int id)
        {
            
            var item = _context.Products.Where(x => x.CategoryId == id).ToList();
            if (item!=null)
            {
                return View(item);
            }
            else
            {
                return NotFound("There are no Products");
            }
        }

        public IActionResult AllProductsView()
        {
            var productList = _context.Products.ToList();
            return View(productList);
        }
        
       

		public IActionResult ShopItemView(int id)
        {
            var item = _context.Products.Find(id);
            if (item!=null)
            {
                return View(item);
            }

            return View();
        }    
        
       
        


        


        //_________________________________________________________
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}