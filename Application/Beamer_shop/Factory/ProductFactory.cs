using Data;
using Factory.Interfaces;
using Logic;
using Logic.Interfaces;
using Logic.Models;
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

        public bool CreateProduct(Product product)
        {
            return ProductService.CreateProduct(product);
        }
    }
}
