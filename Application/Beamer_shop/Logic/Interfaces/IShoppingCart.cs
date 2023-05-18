using Logic.Models;

namespace Logic.Interfaces
{
    public interface IShoppingCart
    {
        void AddItem(Product product);
        void RemoveItem(Product product);
        void CalculatePrices();
        List<CartItem> GetItems();
        void Clear();
    }
}