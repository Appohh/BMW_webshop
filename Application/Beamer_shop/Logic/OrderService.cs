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

        public int MakeOrder(Order order)
        {
            return orderRepository.MakeOrder(order);
        }

        public Order? GetOrderById(int id)
        {
            return orderRepository.GetOrderById(id);
        }

        public bool FinalizeOrderPayment(Order order)
        {
            if (order.Id == null || order.Id < 1)
            {
                return false;
            }

            return orderRepository.FinalizeOrderPayment((int)order.Id);
        }

        public List<Order> GetCustomerOrders(Customer customer)
        {           
            return orderRepository.GetCustomerOrders(customer.Id);
        }

        public List<Tuple<int, int>> GetOrderItems(Order order)
        {
            return orderRepository.GetOrderItems((int)order.Id);
        }




    }
}