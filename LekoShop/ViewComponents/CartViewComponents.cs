using LekoShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LekoShop.ViewComponents
{
    [ViewComponent(Name = "Cart")]
    public class CartViewComponents: ViewComponent
    {
        private readonly LekoContext _context;

        public CartViewComponents(LekoContext context)
        {

            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartList = await _context.Carts.ToListAsync();
            return View("Index", cartList);
        }
        



    }
}
