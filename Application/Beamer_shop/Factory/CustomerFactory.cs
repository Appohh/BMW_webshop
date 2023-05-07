using Data;
using Factory.Interfaces;
using Logic;
using Logic.Interfaces;

namespace Factory
{
    public class CustomerFactory : ICustomerFactory
    {
        public ICustomerService CustomerService { get; }

        public CustomerFactory(ICustomerService customerService)
        {
            CustomerService = customerService;
        }
    }
}