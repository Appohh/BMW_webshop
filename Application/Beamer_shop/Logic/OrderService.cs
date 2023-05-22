using Logic.Interfaces;
using Logic.Models;

namespace Logic
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository
                ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public List<Order> GetAllOrders()
        {
            return orderRepository.GetAllOrders();
        }

        public bool MakeOrder(Order order)
        {
            return orderRepository.MakeOrder(order);
        }

        public Order? GetOrderById(int id)
        {
            return orderRepository.GetOrderById(id);
        }


    }
}