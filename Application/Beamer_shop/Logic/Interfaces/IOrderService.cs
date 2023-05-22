using Logic.Models;

namespace Logic.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order? GetOrderById(int id);
        bool MakeOrder(Order order);
    }
}