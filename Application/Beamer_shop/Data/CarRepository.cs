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
    public class CarRepository : DataHandler, ICarRepository
    {
        protected override string Cmd
        {
            get
            {
                return "SELECT Product.[Id] ,[Name] ,[Price] ,[Description] ,[ImageUrl] ,[Chassisnumber] ,[Plate] ,[Brand] ,[Model] ,[Make] ,[Milage] ,[Engine] ,[Fuel] ,[Horsepower] ,[Torque] ,[Time0to60] ,[Topspeed] ,[Weight] FROM [Product] INNER JOIN [Car] ON Product.[Id] = Car.[Id]";
            }
        }

        private List<Product> _carList = new List<Product>();

        public CarRepository()
        {
            _carList = GetAllCars();
        }

        public List<Product> GetAllCars()
        {
            CarAutoMapper carDataRowMapper = new CarAutoMapper();

            List<Product> Cars = new List<Product>();

            //get datatable of queried data
            DataTable table = base.ReadData();

            //itterate trough all datarows, validate and convert to objects
            foreach (DataRow dr in table.Rows)
            {
                Cars.Add(carDataRowMapper.MapDataRowToObject(dr));
            }

            //return collection of objects
            return Cars;
        }

        public void refreshCustomerData()
        {
            _carList.Clear();
            _carList.AddRange(GetAllCars());
        }
    }
}
