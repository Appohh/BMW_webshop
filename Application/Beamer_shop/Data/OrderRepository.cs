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
    public class OrderRepository : DataHandler, IOrderRepository
    {
        protected override string Cmd
        {
            get
            {
                return "SELECT * FROM Order";
            }
        }

        private List<Order> _orderList = new List<Order>();

        public OrderRepository()
        {
            _orderList = GetAllOrders();
        }

        public List<Order> GetAllOrders()
        {
            List<Order> Orders = new List<Order>();

            //get datatable of queried data
            DataTable table = base.ReadData();

            if (table == null) { return Orders; }

            //itterate trough all datarows, validate and convert to objects
            foreach (DataRow dr in table.Rows)
            {
               // Orders.Add(DataConvertingMethods.ConvertDataRowToObject<Order>(dr));
            }

            //return collection of objects
            return Orders;
        }

        public void refreshOrderData()
        {
            _orderList.Clear();
            _orderList.AddRange(GetAllOrders());
        }

        public bool MakeOrder(Order order)
        {
            //if(string.IsNullOrEmpty(customer.Salt) || string.IsNullOrEmpty(customer.Hash)) { return false; }

            //string query = $"INSERT INTO Order (Id, Lastname, Email, Birthdate, Street, HouseNumber, Zipcode, City, Country) OUTPUT INSERTED.Id " +
            //               $"VALUES ('{customer.FirstName}', '{customer.LastName}', '{customer.Email}', '{customer.BirthDate}', '{customer.Street}', '{customer.HouseNumber}', '{customer.ZipCode}', '{customer.City}', '{customer.Country}' );";
            //int createdId = executeIdScalar(query);
            //if(createdId > 0)
            //{               
            //    string followQuery = $"INSERT INTO Auth_credential (customer_id, username, password_hash, salt) VALUES " +
            //        $"({createdId}, '{customer.Email}', '{customer.Hash}', '{customer.Salt}')";
            //    refreshCustomerData();
            //    return executeQuery(followQuery) == 0 ? false : true;
            //}
            //else return false;
            return false;
        }

        public Order? GetOrderById(int id)
        {
            refreshOrderData();
            Order? foundOrder = _orderList.Find(order => order.Id == id);
            return foundOrder;
        }
    }
}
