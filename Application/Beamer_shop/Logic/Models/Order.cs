using Geocoding;
using Logic.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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


    }
}
