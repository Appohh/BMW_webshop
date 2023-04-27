using Logic.Models;

namespace Logic.Interfaces
{
    public interface IShoppingCart
    {
        void AddItem(Product product);
        void Clear();
        List<CartItem> GetItems();
        decimal GetTotal();
        void RemoveItem(Product product);
    }
}