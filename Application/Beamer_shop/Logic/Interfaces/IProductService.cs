using Logic.Models;

namespace Logic.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        List<Product> GetProductAccessories(Product product);
        Product? getProductById(int id);
        List<string> GetProductImages(Product product);
    }
}