using LekoShop.Data;
using Microsoft.AspNetCore.Mvc;
using LekoShop.Models;
using Microsoft.CodeAnalysis;

namespace LekoShop.Controllers
{
    public class CartController : Controller
    {
        private readonly LekoContext _context;

        public CartController(LekoContext context)
        {
            _context=context;
        }


        public IActionResult CartList()
        {
            var cartList = _context.Carts.ToList();
            
            
            if (cartList != null)
            {
                Product newProduct;
                foreach (var item in cartList)
                {
                    newProduct = _context.Products.Find(item.ProductId);
                    item.Product = newProduct;
                }
                return View(cartList);
            }
            return BadRequest("Not available");
        }

        [HttpPost]
        public IActionResult AddToCart(int? id)
        {
            var objForAdd = _context.Products.Find(id);
            if (objForAdd!=null)
            {
                
                Cart cartObj = new Cart()
                {
                    Image=objForAdd.Image,
                    Quantity = 1,
                    Product = objForAdd,
                    SumPrice = objForAdd.Price,
                    ProductId = objForAdd.Id
                };
                var availableObj = _context.Carts.FirstOrDefault(x=> x.ProductId==cartObj.ProductId);

                if (objForAdd != null)
                {                  

                    if (availableObj == null)
                    {                                                 
                         
                    _context.Carts.Add(cartObj);
                    _context.SaveChanges();
                }
                    else
                    {
                        availableObj.Quantity++;
                        //_context.Carts.Update(availableObj);
                        _context.SaveChanges();
                    }

                }
                

                return RedirectToAction("ProductsAtCategoryId", "Home", new { id = objForAdd.CategoryId });
                }
            else { return BadRequest("Not Found"); }
            
        }

        [HttpPost]
        public IActionResult AddToCartForAllProduct(int? id)
        {
            var objForAdd = _context.Products.Find(id);
            if (objForAdd != null)
            {

                Cart cartObj = new Cart()
                {
                    Image= objForAdd.Image,
                    Quantity = 1,
                    Product = objForAdd,
                    SumPrice = objForAdd.Price,
                    ProductId = objForAdd.Id
                };
                var availableObj = _context.Carts.FirstOrDefault(x => x.ProductId == cartObj.ProductId);

                if (objForAdd != null)
                {

                    if (availableObj == null)
                    {

                        _context.Carts.Add(cartObj);
                        _context.SaveChanges();
                    }
                    else
                    {
                        availableObj.Quantity++;
                        //_context.Carts.Update(availableObj);
                        _context.SaveChanges();
                    }

                }


                return RedirectToAction("AllProductsView", "Home");
            }
            else { return BadRequest("Not Found"); }

        }

        [HttpPost]
        public IActionResult AddToCartFromView(Product model)
        {

            
            var useModel = model;
                        
            if (useModel != null)
            {
                Cart cartObj = new Cart()
                {
                    Image = useModel.Image,
                    Quantity = useModel.AvailableQuantity,
                    //Product = useModel,
                    SumPrice = useModel.Price,
                    ProductId = useModel.Id
                };
                _context.Carts.Add(cartObj);
                _context.SaveChanges();
                return RedirectToAction("ShopItemView", "Home", new { id = useModel.Id });
            }

            return BadRequest("Not Found");
        }

        [HttpPost]
        public IActionResult DeleteCartItem(int? id)
        {
            if (id!=null)
            {
                var objforDelete = _context.Carts.Find(id);
                if (objforDelete!=null)
                {
                    _context.Carts.Remove(objforDelete);
                    _context.SaveChanges();
                    return RedirectToAction("CartList");
                }
            }

            return BadRequest("Not Found");
        }


        [HttpPost]
        public IActionResult UpdateCartItem(int? id, int newQuantity)
        {

            var modelForUpdate = _context.Carts.Find(id);
            if (modelForUpdate != null)
            {

            }

            if (id != null)
            {
                var objforDelete = _context.Carts.Find(id);
                if (objforDelete != null)
                {
                    _context.Carts.Remove(objforDelete);
                    _context.SaveChanges();
                    return RedirectToAction("CartList");
                }
            }

            return BadRequest("Not Found");
        }

    }
}
