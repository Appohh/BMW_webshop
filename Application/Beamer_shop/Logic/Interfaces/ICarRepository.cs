using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICarRepository
    {
        public List<Product> GetAllCars();
        public void refreshCarData();
        public List<string> GetProductImages(int carId);
        public bool CreateCar(Car car);
    }
}
