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
    public class AccessoryRepository : DataHandler, IAccessoryRepository
    {
        protected override string Cmd
        {
            get
            {
                return "SELECT Product.[Id] ,[Name] ,[Price] ,[Description] ,[ImageUrl] ,[Type] FROM [Product] INNER JOIN [Accessory] ON Product.[Id] = Accessory.[Id]";
            }
        }

        private List<Product> _accessoryList = new List<Product>();

        public AccessoryRepository()
        {
            _accessoryList = GetAllAccessories();
        }

        public List<Product> GetAllAccessories()
        {
            AccessoryAutoMapper accessoryDataRowMapper = new AccessoryAutoMapper();

            List<Product> Accessories = new List<Product>();

            //get datatable of queried data
            DataTable table = base.ReadData();

            //!NEEDS BETTER ERROR HANDLING!
            if (table == null) { return Accessories; }

            //itterate trough all datarows, validate and convert to objects
            foreach (DataRow dr in table.Rows)
            {
                Accessories.Add(accessoryDataRowMapper.MapDataRowToObject(dr));
            }

            //return collection of objects
            return Accessories;
        }

        public void refreshAccessoryData()
        {
            _accessoryList.Clear();
            _accessoryList.AddRange(GetAllAccessories());
        }
    }
}
