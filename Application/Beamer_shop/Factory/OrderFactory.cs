using Data;
using Factory.Interfaces;
using Logic;
using Logic.Interfaces;

namespace Factory
{
    public class OrderFactory : IOrderFactory
    {
        public IOrderService OrderService { get; }

        public OrderFactory(IOrderService orderService)
        {
            OrderService = orderService;
        }
    }
}