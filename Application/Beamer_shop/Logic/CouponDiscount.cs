using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CouponDiscount : IDiscount
    {
        public string CouponCode { get; private set; }

        public int Percentage { get; private set; }

        public double MinimalSpend { get; private set; }

        public double MaxDiscount { get; private set; }

        private double Total;

        public CouponDiscount(string couponCode, int percentage, double minimalSpend, double maxDiscount)
        {
            CouponCode = couponCode;
            Percentage = percentage;
            MinimalSpend = minimalSpend;
            MaxDiscount = maxDiscount;
        }

        public double ApplyDiscount(Order order)
        {
            Order _order = order;

            if (IsApplicable(order))
            {
                return _order.TotalTotal - CalculateDiscount();
            } else return 0;
            
        }

        public bool IsApplicable(Order order)
        {
            Total = order.TotalTotal;

            if (order.DiscountsApplied?.Find(d => d.Equals(this)) != null) { return false; }

            if (order.TotalTotal - CalculateDiscount() < 1) { return false; }
            
            if(CalculateDiscount() > MaxDiscount) { return false; }

            if(order.TotalTotal < MinimalSpend) { return false; }

            return true;

        }

        public double CalculateDiscount()
        {
            return Total / 100 * Percentage;
        }

        public override bool Equals(object? obj)
        {
            return obj is CouponDiscount discount &&
                   CouponCode == discount.CouponCode &&
                   Percentage == discount.Percentage &&
                   MinimalSpend == discount.MinimalSpend &&
                   MaxDiscount == discount.MaxDiscount;
        }
    }
}
