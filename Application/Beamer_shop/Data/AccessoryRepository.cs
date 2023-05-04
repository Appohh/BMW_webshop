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
                return "SELECT Product.[Id] ,[Name] ,[Price] ,[Description] ,[ImageUrl], [Product-Taxes].[Percentage] as 'Taxrate', [Type] FROM [Product] INNER JOIN [Accessory] ON Product.[Id] = Accessory.[Id] INNER JOIN [Product-Taxes] ON Product.TaxId = [Product-Taxes].Id";
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

        public List<Product> GetProductAccessories(int productId)
        {
            AccessoryAutoMapper accessoryDataRowMapper = new AccessoryAutoMapper();

            List<Product> Accessories = new List<Product>();

            //get datatable of queried data
            DataTable table = base.ReadData($"select AccProduct.Id from Product inner join [Accessory-Product] on Product.Id = [Accessory-Product].OriginalProductId inner join [Product] AS AccProduct on [Accessory-Product].AccessoryProductId = AccProduct.Id where [Accessory-Product].OriginalProductId = {productId};");

            //!NEEDS BETTER ERROR HANDLING!
            if (table == null) { return Accessories; }

            //itterate trough all datarows, validate and convert to objects
            foreach (DataRow dr in table.Rows)
            {
                Accessories.Add(_accessoryList.Find(a => a.Id == Convert.ToInt32(dr["id"])));
            }

            //return collection of objects
            return Accessories;
        }


        public void refreshAccessoryData()
        {
            _accessoryList.Clear();
            _accessoryList.AddRange(GetAllAccessories());
        }

        public List<string> GetProductImages(int productId)
        {
            List<string> images = new List<string>();
            var result = base.ReadData($"SELECT [Image] FROM [Product-Image] WHERE [ProductId] = {productId}");

            if (result == null) { return images; }

            foreach (DataRow dr in result.Rows)
            {
                images.Add(dr["Image"].ToString());
            }
            return images;
        }
    }
}
