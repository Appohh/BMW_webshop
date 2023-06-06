using Logic;
using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EmployeeRepository : DataHandler, IEmployeeRepository
    {
        protected override string Cmd
        {
            get
            {
                return "SELECT * FROM Employee";
            }
        }

        private List<Employee> _employeeList = new List<Employee>();

        public EmployeeRepository()
        {
            _employeeList = GetAllEmployees();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> Employees = new List<Employee>();

            //get datatable of queried data
            DataTable table = base.ReadData();

            if (table == null) { return Employees; }

            //itterate trough all datarows, validate and convert to objects
            foreach (DataRow dr in table.Rows)
            {
                Employees.Add(DataConvertingMethods.ConvertDataRowToObject<Employee>(dr));
            }

            //return collection of objects
            return Employees;
        }

        public void refreshEmployeeData()
        {
            _employeeList.Clear();
            _employeeList.AddRange(GetAllEmployees());
        }

        public bool RegisterEmployee(RegisterEmployee employee)
        {
            if(string.IsNullOrEmpty(employee.Salt) || string.IsNullOrEmpty(employee.Hash)) { return false; }

            string query = $"INSERT INTO Employee (Firstname, Lastname, Birthdate, Email, Phone, BSN) OUTPUT INSERTED.Id " +
                           $"VALUES ('{employee.FirstName}', '{employee.LastName}', '{employee.BirthDate}', '{employee.Email}', '{employee.Phone}', '{employee.BSN}' );";
            int createdId = executeIdScalar(query);
            if(createdId > 0)
            {               
                string followQuery = $"INSERT INTO Auth_credential (employee_id, username, password_hash, salt) VALUES " +
                    $"({createdId}, '{employee.Email}', '{employee.Hash}', '{employee.Salt}')";
                refreshEmployeeData();
                return executeQuery(followQuery) == 0 ? false : true;
            }
            else return false;
        }

        public (string hash, string salt, int id)? GetHashSalt(string username)
        {

            string query = $"SELECT [employee_id], [password_hash], [salt] FROM Auth_credential WHERE [username] = '{username}'";
            DataTable? table = ReadData(query);
            if(table.Rows.Count == 0) { return null; }

            DataRow row = table.Rows[0];
            int storedId = Convert.ToInt32(row["employee_id"]);
            string? storedHash = row["password_hash"].ToString();
            string? storedSalt = row["salt"].ToString();

            return (storedHash, storedSalt, storedId);                         
        }

        public Employee? GetEmployeeById(int id)
        {
            refreshEmployeeData();
            Employee? foundEmployee = _employeeList.Find(employee => employee.Id == id);
            return foundEmployee;
        }


    }
}
