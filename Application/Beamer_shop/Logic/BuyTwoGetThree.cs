using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GetThreePayTwo : IDiscount
    {
        public int ProductId { get; private set; }
        private int Discount;
        private double Price;

        public GetThreePayTwo(int productId)
        {
            ProductId = productId;
        }

        public double ApplyDiscount(Order order)
        {

            if (IsApplicable(order))
            {
                return CalculateDiscount();
            }
            else return 0;
        }

        public double CalculateDiscount()
        {
            return Discount * Price;
        }

        public bool IsApplicable(Order order)
        {
            if (order.DiscountsApplied?.Find(d => d.Equals(this)) != null) { return false; }
            

            List<CartItem> items = new List<CartItem>();

            items = order.Items.GetItems().FindAll(p => p.Product.Id == ProductId);

            if(items.Count < 1) return false;

            int matches = items.Sum(p => p.Quantity);
            int count = 0;
            int discount = 0;
            for(int i = 0; i < matches; i++)
            {
                count++;

                if (count % 3 == 0)
                {
                    discount++;
                }
            }

            if(discount < 1) return false; 

            Discount = discount;
            Price = items.Find(p => p.Product.Id == ProductId).Product.Price;


            if (order.TotalTotal - CalculateDiscount() < 1) { return false; }

            return true;

        }

        public override bool Equals(object? obj)
        {
            return obj is GetThreePayTwo two &&
                   ProductId == two.ProductId;
        }
    }
}
