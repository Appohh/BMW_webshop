using Logic.Interfaces;

namespace Factory.Interfaces
{
    public interface IProductFactory
    {
        IProductService ProductService { get; }

        int CreateProduct(string type);
    }
}