using LekoShop.Models;

namespace LekoShop.Services.Interfaces
{
    public interface ICategory
    {
        List<Category>? ViewCategoryList(List<Category> category);
        Category? ViewCategoryById(int categoryId);
        void CreateNewCategory(Category category);
        
        void DeleteCategoryById(int categoryId);
        void UpdateCategory(int categoryId, Category category);

    }
}
