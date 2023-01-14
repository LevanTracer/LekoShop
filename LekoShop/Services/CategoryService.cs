using LekoShop.Data;
using LekoShop.Models;
using LekoShop.Services.Interfaces;

namespace LekoShop.Services
{
    public class CategoryService : ICategory
    {
        private readonly LekoContext _context;

        public CategoryService(LekoContext context)
        {
            _context = context;
        }
        public void CreateNewCategory(Category category)
        {
            _context.Categorys.Add(category);
            
            _context.SaveChanges();           
        }

        

        public void DeleteCategoryById(int categoryId)
        {
            var item=_context.Categorys.Find(categoryId);
            if(item != null) { _context.Categorys.Remove(item); }
            
            _context.SaveChanges();
        }

        public void UpdateCategory(int categoryId, Category category)
        {
            var item=_context.Categorys.Find(categoryId);
            if (item != null)
            {
                item.Id = category.Id;
               item.Name=category.Name;
            }
            _context.SaveChanges();
        }

        public Category? ViewCategoryById(int categoryId)
        {
            return _context.Categorys.Find(categoryId);
        }

        public List<Category>? ViewCategoryList(List<Category> category)
        {
            return _context.Categorys.ToList();
        }
    }
}
