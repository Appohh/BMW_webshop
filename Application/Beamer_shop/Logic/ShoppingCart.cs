using Logic.Interfaces;
using Logic.Models;
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
        public IDictionary<int, CartItem> _items;

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
        }

        public List<CartItem> GetItems()
        {
            return _items.Values.ToList();
        }

        public decimal GetTotal()
        {
            decimal total = 0;
            foreach (CartItem item in _items.Values)
            {
                total += item.Product.Price * item.Quantity;
            }
            return total;
        }
        public void Clear()
        {
            _items.Clear();
        }
    }
}
