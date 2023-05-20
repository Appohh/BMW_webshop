using Logic.Models;

namespace Logic.Interfaces
{
    public interface IShoppingCart
    {
        IDictionary<int, CartItem> _items { get; }
        double Taxes { get; }
        double Total { get; }

        void AddItem(Product product);
        void RemoveItem(Product product);
        void CalculatePrices();
        List<CartItem> GetItems();
        void Clear();
    }
}