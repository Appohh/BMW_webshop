using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        int MakeOrder(Order order);
        Order? GetOrderById(int id);
        bool FinalizeOrderPayment(int id);
        List<Order>GetCustomerOrders(int customerId);
        List<Tuple<int, int>>GetOrderItems(int orderId);

    }
}
