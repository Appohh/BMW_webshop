using Factory.Interfaces;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class DiscountFactory : IDiscountFactory
    {
        public IDiscountService DiscountService { get; }

        public DiscountFactory(IDiscountService discountService)
        {
            DiscountService = discountService;
        }

        public int CreateDiscount(string type)
        {
            switch (type)
            {
                case "coupon":
                    return 1;
                case "2+1":
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
