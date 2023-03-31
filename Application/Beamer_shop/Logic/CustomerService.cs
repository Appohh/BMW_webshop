using Logic.Interfaces;
using Logic.Models;

namespace Logic
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository
                ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public List<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }

        public bool RegisterCustomer(Register customer)
        {
            return customerRepository.RegisterCustomer(customer);
        }

        public Customer ValidateCredentials(Login customer)
        {
            return customerRepository.ValidateCredentials(customer);
        }

    }
}