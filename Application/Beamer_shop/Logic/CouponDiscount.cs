using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CouponDiscount : ICouponDiscount
    {
        public string CouponCode { get; private set; }

        public int Percentage { get; private set; }

        public double MinimalSpend { get; private set; }

        public double MaxDiscount { get; private set; }

        public CouponDiscount(string couponCode, int percentage)
        {
            CouponCode = couponCode;
            Percentage = percentage;
        }

        public double ApplyDiscount(Order order)
        {
            Order _order = order;

            if (IsApplicable(order))
            {
                return _order.TotalTotal - CalculateDiscount(_order.TotalTotal);
            } else return 0;
            
        }

        public bool IsApplicable(Order order)
        {
            if (order.TotalTotal - CalculateDiscount(order.TotalTotal) < 1) { return false; }
            
            if(CalculateDiscount(order.TotalTotal) > MaxDiscount) { return false; }

            if(order.TotalTotal < MinimalSpend) { return false; }

            return true;

        }

        public double CalculateDiscount(double total)
        {
            return total / 100 * Percentage;
        }

    }
}
