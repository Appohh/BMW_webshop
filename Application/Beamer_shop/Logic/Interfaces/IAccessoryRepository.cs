using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IAccessoryRepository
    {
        public List<Product> GetAllAccessories();
        public List<Product> GetProductAccessories(int productId);
        public void refreshAccessoryData();
        public List<string> GetProductImages(int carId);
        public bool CreateAccessory(Accessory accessory);
        bool DeleteAccessory(int Id);


    }
}
