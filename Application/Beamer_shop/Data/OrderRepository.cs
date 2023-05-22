using Logic;
using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data
{
    public class OrderRepository : DataHandler, IOrderRepository
    {
        protected override string Cmd
        {
            get
            {
                return "SELECT [Id] ,[CustomerId] ,[PaymentType] ,[Paid] ,[Discount] ,[Shipped] ,[EstimatedDeliveryA] ,[EstimatedDeliveryB] ,[Street], [Housenumber], [City] ,[Zipcode] ,[Country] ,[TotalTax] ,[TotalShipping] ,[TotalTotal] ,[Timestamp] FROM [Order]";
            }
        }

        private List<Order> _orderList = new List<Order>();

        public OrderRepository()
        {
            _orderList = GetAllOrders();
        }

        public List<Order> GetAllOrders()
        {
            OrderAutoMapper orderDataRowMapper = new OrderAutoMapper();

            List<Order> Orders = new List<Order>();

            //get datatable of queried data
            DataTable table = base.ReadData();

            if (table == null) { return Orders; }

            //itterate trough all datarows, validate and convert to objects
            foreach (DataRow dr in table.Rows)
            {
               Orders.Add(orderDataRowMapper.MapDataRowToObject(dr));
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
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

            string query = $"INSERT INTO [Order] (CustomerId, PaymentType, Discount, EstimatedDeliveryA, EstimatedDeliveryB, Street, Housenumber, City, Zipcode, Country, TotalTax, TotalShipping, TotalTotal) OUTPUT INSERTED.Id " +
                           $"VALUES ('{order.CustomerId}', '{order.PaymentType}', '{order.Discount.Value.ToString("0.00", culture)}', '{order.EstimatedDeliveryA}', '{order.EstimatedDeliveryB}', '{order.DeliveryAddress.Street}', '{order.DeliveryAddress.HouseNumber}', '{order.DeliveryAddress.City}', '{order.DeliveryAddress.Zipcode}', '{order.DeliveryAddress.Country}', '{order.TotalTax.ToString("0.00", culture)}', '{order.TotalShipping.ToString("0.00", culture)}', '{order.TotalTotal.ToString("0.00", culture)}' );";

            int createdId = executeIdScalar(query);
            if(createdId > 0)
            {
                int x = 0;
                int y = 0;

                foreach(CartItem item in order.Items.GetItems())
                {
                    x++;
                    string followQuery = $"INSERT INTO Order_row (OrderId, ProductId, Quantity) VALUES " +
                        $"({createdId}, '{item.Product.Id}', '{item.Quantity}')";

                    y += executeQuery(followQuery);
                }


                refreshOrderData();
                return x == y;


            }
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
