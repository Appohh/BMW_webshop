using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class ProductFactory
    {
        public ProductService ProductService { get; } =
           new ProductService(new CarRepository(), new AccessoryRepository());

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
