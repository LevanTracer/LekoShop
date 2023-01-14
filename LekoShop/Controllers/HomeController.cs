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
            var item = (from x in _context.Products
                        where x.CategoryId == id
                        select x).ToList();            
            _context.SaveChanges();
            return View(item);
        }
        public IActionResult AllProductsView()
        {
            return View();
        }
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