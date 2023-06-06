using Logic.Interfaces;
using Logic.Models;

namespace Logic
{
    public class CustomerService : ICustomerService
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

        public bool RegisterCustomer(RegisterCustomer customer)
        {
            return customerRepository.RegisterCustomer(customer);
        }

        public (string hash, string salt, int id)? GetHashSalt(string email)
        {
            return customerRepository.GetHashSalt(email);
        }
        public Customer? GetCustomerById(int id)
        {
            return customerRepository.GetCustomerById(id);
        }


    }
}