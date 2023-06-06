using Logic.Interfaces;
using Logic.Models;

namespace Factory.Interfaces
{
    public interface IProductFactory
    {
        IProductService ProductService { get; }

        bool CreateProduct(Product product);
    }
}