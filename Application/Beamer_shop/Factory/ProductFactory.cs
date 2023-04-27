using Data;
using Factory.Interfaces;
using Logic;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class ProductFactory : IProductFactory
    {
        public IProductService ProductService { get; }

        public ProductFactory(IProductService productService)
        {
            ProductService = productService;
        }

        public int CreateProduct(string type)
        {
            switch (type)
            {
                case "car":
                    return 1;
                case "accessory":
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
