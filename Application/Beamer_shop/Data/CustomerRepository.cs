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
    public class CustomerRepository : DataHandler, ICustomerRepository
    {
        protected override string Cmd
        {
            get
            {
                return "SELECT * FROM Customer";
            }
        }

        private List<Customer> _customerList = new List<Customer>();

        public CustomerRepository()
        {
            _customerList = GetAllCustomers();
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> Customers = new List<Customer>();

            //get datatable of queried data
            DataTable table = base.ReadData();

            //itterate trough all datarows, validate and convert to objects
            foreach (DataRow dr in table.Rows)
            {
                Customers.Add(DataConvertingMethods.ConvertDataRowToObject<Customer>(dr));
            }

            //return collection of objects
            return Customers;
        }

        public void refreshCustomerData()
        {
            _customerList.Clear();
            _customerList.AddRange(GetAllCustomers());
        }

        public bool RegisterCustomer(Register customer)
        {
            string query = $"INSERT INTO Customer (Firstname, Lastname, Email, Birthdate, Address, Zipcode, City) OUTPUT INSERTED.Id " +
                           $"VALUES ('{customer.FirstName}', '{customer.LastName}', '{customer.Email}', '{customer.BirthDate}', '{customer.Address}', '{customer.ZipCode}', '{customer.City}' );";
            int createdId = executeIdScalar(query);
            if(createdId > 0)
            {
                (string Salt, string HashedPassword) output = Security.CreateSaltAndHash(customer.Password);
               
                string followQuery = $"INSERT INTO Auth_credential (customer_id, username, password_hash, salt) VALUES " +
                    $"({createdId}, '{customer.Email}', '{output.HashedPassword}', '{output.Salt}')";
                refreshCustomerData();
                return executeQuery(followQuery) == 0 ? false : true;
            }
            else return false;
        }

        public Customer? ValidateCredentials(Login customer)
        {

            string query = $"SELECT [customer_id], [password_hash], [salt] FROM Auth_credential WHERE [username] = '{customer.Email}'";
            DataTable? table = ReadData(query);
            if(table.Rows.Count == 0) { return null; }

            DataRow row = table.Rows[0];
            int storedId = Convert.ToInt32(row["customer_id"]);
            string? storedHash = row["password_hash"].ToString();
            string? storedSalt = row["salt"].ToString();

            //validate input hash
            string inputHash = Security.CreateHash(storedSalt, customer.Password);
            if(storedHash == inputHash)
            {
                //User validated
                Customer? validCustomer = _customerList.Find(customer => customer.Id == storedId);
                if (validCustomer == null) { return null; }
                return validCustomer;
            }
            return null;    

        }
    }
}
