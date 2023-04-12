using LekoShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LekoShop.ViewComponents
{
    [ViewComponent (Name ="CategoryList")]
    public class CategoryNames:ViewComponent
    {
        private readonly LekoContext _context;

        public CategoryNames(LekoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list =await _context.Categorys.ToListAsync();

            return View("Category", list);
                }
    }
}
