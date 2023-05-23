using Logic.Models;

namespace Logic.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order? GetOrderById(int id);
        int MakeOrder(Order order);
        bool FinalizeOrderPayment(Order order);
        List<Order>GetCustomerOrders(Customer customer);
        List<Tuple<int, int>> GetOrderItems(Order order);
    }
}