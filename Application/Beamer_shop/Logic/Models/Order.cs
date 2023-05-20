using Geocoding;
using Logic.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public IShoppingCart Items { get; set; }
        public Customer Customer { get; set; }
        public int PaymentType { get; set; }
        public int Paid { get; set; }
        public int? DiscountId { get; set; }
        public DateTime? Shipped { get; set; }
        public int EstimatedDeliveryA { get; set; }
        public int EstimatedDeliveryB { get; set; }
        public Address DeliveryAddress { get; set; }
        public double TotalTax { get; set; }
        public double TotalShipping { get; set; }
        public double TotalTotal { get; set; }
        public DateTime? TimeStamp { get; set; }

        //Prep order
        [JsonConstructor]
        public Order(IShoppingCart items, Customer customer, int estimatedDeliveryA, int estimatedDeliveryB, Address deliveryAddress, double totalShipping)
        {
            Items = items;
            Customer = customer;
            EstimatedDeliveryA = estimatedDeliveryA;
            EstimatedDeliveryB = estimatedDeliveryB;
            DeliveryAddress = deliveryAddress;
            TotalShipping = totalShipping;
        }

        //Full order
        public Order(int id, IShoppingCart items, Customer customer, int paymentType, int paid, int? discountId, DateTime? shipped, int estimatedDeliveryA, int estimatedDeliveryB, Address deliveryAddress, double totalTax, double totalShipping, double totalTotal, DateTime timeStamp)
        {
            Id = id;
            Items = items;
            Customer = customer;
            PaymentType = paymentType;
            Paid = paid;
            DiscountId = discountId;
            Shipped = shipped;
            EstimatedDeliveryA = estimatedDeliveryA;
            EstimatedDeliveryB = estimatedDeliveryB;
            DeliveryAddress = deliveryAddress;
            TotalTax = totalTax;
            TotalShipping = totalShipping;
            TotalTotal = totalTotal;
            TimeStamp = timeStamp;
        }


        public void CalculateTotalTax()
        {
            double tax = Items.Taxes + (TotalShipping / (21 + 100) * 21);
            TotalTax = Math.Round(tax, 2);
        }

        public void CalculateTotalTotal()
        {
            TotalTotal = Items.Total + TotalShipping;
        }
        public bool ApplyDiscounts(IEnumerable<IDiscount> discounts, [Optional] string coupon)
        {
            double discounted = 0;

            foreach (IDiscount discount in discounts)
            {

                double x = discount.ApplyDiscount(this);
                TotalTotal -= x;
                discounted += x;
            }

            if (!string.IsNullOrEmpty(coupon))
            {
                IDiscount? validCoupon = discounts.OfType<ICouponDiscount>().FirstOrDefault(d => d.CouponCode == coupon);
                if(validCoupon != null)
                {
                    double x = validCoupon.ApplyDiscount(this);
                    TotalTotal -= x;
                    discounted += x;
                }
            }

            return discounted > 0;
        }



    }
}
