using Logic.Interfaces;

namespace Factory.Interfaces
{
    public interface IOrderFactory
    {
        IOrderService OrderService { get; }
    }
}