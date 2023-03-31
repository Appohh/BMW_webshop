using Data;
using Logic;

namespace Factory
{
    public class CustomerFactory
    {
        public static CustomerService CustomerService { get; } =
            new CustomerService(new CustomerRepository());
    }
}