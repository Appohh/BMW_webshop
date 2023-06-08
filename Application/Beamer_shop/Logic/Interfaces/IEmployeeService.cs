using Logic.Models;

namespace Logic.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee? GetEmployeeById(int id);
        (string hash, string salt, int id)? GetHashSalt(string email);
        bool RegisterEmployee(RegisterEmployee employee);
        bool DeleteEmployee(Employee employee);
    }
}