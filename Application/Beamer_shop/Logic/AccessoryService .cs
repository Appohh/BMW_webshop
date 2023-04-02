using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class AccessoryService
    {
        private readonly IAccessoryRepository accessoryRepository;

        public AccessoryService(IAccessoryRepository accessoryRepository)
        {
            this.accessoryRepository = accessoryRepository
                ?? throw new ArgumentNullException(nameof(accessoryRepository));
        }

        public List<Product> GetAllAccessories()
        {
            return accessoryRepository.GetAllAccessories();
        }
    }
}
