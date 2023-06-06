using Data;
using Factory.Interfaces;
using Logic;
using Logic.Interfaces;

namespace Factory
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public IEmployeeService EmployeeService { get; }

        public EmployeeFactory(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }
    }
}