using Logic.Interfaces;
using Logic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ShoppingCart : IShoppingCart
    {
        public IDictionary<int, CartItem> _items { get; private set;  }
        [JsonProperty]
        public decimal Taxes { get; private set; }
        [JsonProperty]
        public decimal Total { get; private set; }

        public ShoppingCart()
        {
            _items = new Dictionary<int, CartItem>();
        }


        public void AddItem(Product product)
        {
            if (_items.ContainsKey(product.Id))
            {
                _items[product.Id].Quantity++;
            }
            else
            {
                _items.Add(product.Id, new CartItem { Product = product, Quantity = 1 });
            }

            CalculatePrices();
        }

        public void RemoveItem(Product product)
        {
            if (_items.ContainsKey(product.Id))
            {
                if (_items[product.Id].Quantity > 1)
                {
                    _items[product.Id].Quantity--;
                }
                else
                {
                    _items.Remove(product.Id);
                }
            }
            CalculatePrices();
        }

        public void CalculatePrices()
        {
            decimal tax = 0;
            decimal total = 0;
            foreach (CartItem item in _items.Values)
            {
               tax += ((item.Product.Price / (item.Product.Taxrate + 100)) * item.Product.Taxrate) * item.Quantity;
               total += item.Product.Price * item.Quantity;
            }
            Taxes = tax;
            Total = total;

        }

        public List<CartItem> GetItems()
        {
            return _items.Values.ToList();
        }

        public void Clear()
        {
            _items.Clear();
            CalculatePrices();
        }
    }
}
