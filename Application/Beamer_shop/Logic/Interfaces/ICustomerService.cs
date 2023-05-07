using Logic.Models;

namespace Logic.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer? GetCustomerById(int id);
        (string hash, string salt, int id)? GetHashSalt(string email);
        bool RegisterCustomer(Register customer);
    }
}