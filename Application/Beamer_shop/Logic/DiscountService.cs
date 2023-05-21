using Data;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository discountRepository;


        public DiscountService(IDiscountRepository discountRepository)
        {
            this.discountRepository = discountRepository
                ?? throw new ArgumentNullException(nameof(discountRepository));
        }

        public List<IDiscount> GetAllDiscounts()
        {
            return discountRepository.GetAllDiscounts();
        }

        public List<IDiscount> GetAllActiveDiscounts()
        {
            return discountRepository.GetAllActiveDiscounts();
        }

    }
}
