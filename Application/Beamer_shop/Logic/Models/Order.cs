﻿using Geocoding;
using Logic.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Order
    {
        public int? Id { get; set; }
        [Required]
        public IShoppingCart Items { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int PaymentType { get; set; }
        public int Paid { get; set; }
        [Required]
        public double? Discount { get; set; }
        public DateTime? Shipped { get; set; }
        [Required]
        public int EstimatedDeliveryA { get; set; }
        [Required]
        public int EstimatedDeliveryB { get; set; }
        [Required]
        public Address DeliveryAddress { get; set; }
        [Required]
        public double TotalTax { get; set; }
        [Required]
        public double TotalShipping { get; set; }
        [Required]
        public double TotalTotal { get; set; }
        public DateTime? TimeStamp { get; set; }
        public List<IDiscount>? DiscountsApplied { get; set; }


        public Order()
        {

        }

        //Prep order
        [JsonConstructor]
        public Order(IShoppingCart items, int customerId, int paymentType, int estimatedDeliveryA, int estimatedDeliveryB, Address deliveryAddress, double totalShipping,[Optional] List<IDiscount> discountsApplied)
        {
            Items = items;
            CustomerId = customerId;
            PaymentType = paymentType;
            EstimatedDeliveryA = estimatedDeliveryA;
            EstimatedDeliveryB = estimatedDeliveryB;
            DeliveryAddress = deliveryAddress;
            TotalShipping = totalShipping;
            if(discountsApplied != null)
            {
                DiscountsApplied = discountsApplied;
            } else DiscountsApplied = new List<IDiscount>();

        }

        //Full order
        public Order(int id, IShoppingCart items, int customerId, int paymentType, int paid, double? discount, DateTime? shipped, int estimatedDeliveryA, int estimatedDeliveryB, Address deliveryAddress, double totalTax, double totalShipping, double totalTotal, DateTime timeStamp, List<IDiscount> discountsApplied)
        {
            Id = id;
            Items = items;
            CustomerId = customerId;
            PaymentType = paymentType;
            Paid = paid;
            Discount = discount;
            Shipped = shipped;
            EstimatedDeliveryA = estimatedDeliveryA;
            EstimatedDeliveryB = estimatedDeliveryB;
            DeliveryAddress = deliveryAddress;
            TotalTax = totalTax;
            TotalShipping = totalShipping;
            TotalTotal = totalTotal;
            TimeStamp = timeStamp;
            if (discountsApplied != null)
            {
                DiscountsApplied = discountsApplied;
            }
            else DiscountsApplied = new List<IDiscount>();
            if (discount != null)
            {
                Discount = discount;
            }
            else Discount = 0;

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
            if(Discount != null)
            {
                discounted += (double)Discount;
            }

            foreach (IDiscount discount in discounts)
            {
                if(discount is CouponDiscount) { continue; }

                double x = discount.ApplyDiscount(this);
                if (x > 0)
                {
                    TotalTotal -= x;
                    discounted += x;
                    this.DiscountsApplied.Add(discount);
                }
            }

            if (!string.IsNullOrEmpty(coupon))
            {
                IDiscount? validCoupon = discounts.OfType<CouponDiscount>().FirstOrDefault(d => d.CouponCode == coupon);
                if(validCoupon != null)
                {
                    double x = validCoupon.ApplyDiscount(this);
                    if (x > 0)
                    {
                        TotalTotal -= x;
                        discounted += x;
                        this.DiscountsApplied.Add(validCoupon);
                    }
                }
            }

            this.Discount = discounted;
            return discounted > 0;
        }



    }
}
