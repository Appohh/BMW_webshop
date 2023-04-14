using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        bool RegisterCustomer(Register customer);
        (string hash, string salt, int id)? GetHashSalt(string email);
        Customer? GetCustomerById(int id);

    }
}
