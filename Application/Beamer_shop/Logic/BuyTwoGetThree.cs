using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BuyTwoGetThree : IBuyThreePayTwo
    {
        public int ProductId { get; private set; }

        public BuyTwoGetThree(int productId)
        {
            ProductId = productId;
        }

        public double ApplyDiscount(Order order)
        {
            Order _order = order;

            if (IsApplicable(order))
            {
                return _order.TotalTotal - CalculateDiscount(_order.TotalTotal);
            }
            else return 0;
        }

        public double CalculateDiscount(double total)
        {
            throw new NotImplementedException();
        }

        public bool IsApplicable(Order order)
        {
            int matchesFound = 0;
            foreach(CartItem item in order.Items.GetItems())
            {
            
                if(item.Product.Id == ProductId) { matchesFound++; }


            }

            if (order.DiscountsApplied?.FindAll(d => d.Equals(this)).Count != null) { return false; }

            if (order.TotalTotal - CalculateDiscount(order.TotalTotal) < 1) { return false; }



            return true;
        }
    }
}
