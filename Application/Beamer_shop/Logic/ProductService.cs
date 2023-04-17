using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProductService
    {
        private readonly ICarRepository carRepository;
        private readonly IAccessoryRepository accessoryRepository;


        public ProductService(ICarRepository carRepository, IAccessoryRepository accessoryRepository)
        {
            this.carRepository = carRepository
                ?? throw new ArgumentNullException(nameof(carRepository));
            this.accessoryRepository = accessoryRepository
                ?? throw new ArgumentNullException(nameof(accessoryRepository));
        }

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            products.AddRange(carRepository.GetAllCars());
            products.AddRange(accessoryRepository.GetAllAccessories());

            return products;
        }
    }
}
