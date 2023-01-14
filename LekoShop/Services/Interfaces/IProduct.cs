using LekoShop.Models;

namespace LekoShop.Services.Interfaces
{
    public interface IProduct
    {
        List<Product> ViewProductList();
        Product ViewProductById(int productId);
        Product CreateNewProduct(Product product);
        Product DeleteProduct();
        Product DeleteProductById(int productId);
        Product UpdateProduct(Product product);

    }
}
