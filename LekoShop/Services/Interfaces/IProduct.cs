using LekoShop.Models;

namespace LekoShop.Services.Interfaces
{
    public interface IProduct
    {
        List<Product> ViewProductList();
        Product ViewProductById(int productId);
        bool CreateNewProduct(Product product);
        
        bool DeleteProduc(int productId);
        Product UpdateProduct(Product product);

    }
}
