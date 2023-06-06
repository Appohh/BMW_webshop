using Logic.Interfaces;
using Logic.Models;

namespace Logic
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository
                ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }

        public bool RegisterEmployee(RegisterEmployee employee)
        {
            return employeeRepository.RegisterEmployee(employee);
        }

        public (string hash, string salt, int id)? GetHashSalt(string email)
        {
            return employeeRepository.GetHashSalt(email);
        }
        public Employee? GetEmployeeById(int id)
        {
            return employeeRepository.GetEmployeeById(id);
        }


    }
}