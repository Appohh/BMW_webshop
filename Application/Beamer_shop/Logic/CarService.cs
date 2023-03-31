using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CarService
    {
        private readonly ICarRepository carRepository;

        public CarService(ICarRepository carRepository)
        {
            this.carRepository = carRepository
                ?? throw new ArgumentNullException(nameof(carRepository));
        }

        public List<Product> GetAllCars()
        {
            return carRepository.GetAllCars();
        }
    }
}
