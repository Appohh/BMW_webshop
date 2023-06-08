using Logic;
using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
                return "SELECT Product.[Id] ,[Name] ,[Price] ,[Description] ,[ImageUrl], [Product-Taxes].[Percentage] as 'Taxrate',[Weight], [Type] FROM [Product] INNER JOIN [Accessory] ON Product.[Id] = Accessory.[Id] INNER JOIN [Product-Taxes] ON Product.TaxId = [Product-Taxes].Id";
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

        public bool CreateAccessory(Accessory accessory)
        {
            string query = $"INSERT INTO Product (Name, Price, Description, ImageUrl, Weight) OUTPUT INSERTED.Id " +
            $"VALUES ('{accessory.Name}', {Convert.ToInt32(accessory.Price)}, '{accessory.Description}', '{accessory.ImageUrl}', {accessory.Weight} );";
            int createdId = executeIdScalar(query);
            if (createdId > 0)
            {
                string followQuery = $"INSERT INTO Accessory (Id, Type) VALUES " +
                $"({createdId}, '{accessory.Type}')";

                refreshAccessoryData();
                return executeQuery(followQuery) == 0 ? false : true;
            }
            else return false;
        }

        public bool DeleteAccessory(int Id)
        {
            refreshAccessoryData();
            var firstCar = _accessoryList.FirstOrDefault();
            if (firstCar == null) return false;

            string query = $"DELETE FROM Accessory WHERE Id = {Id}";
            if (executeQuery(query) > 0)
            {
                string followQuery = $"DELETE FROM Product WHERE Id = {Id}";
                return executeQuery(followQuery) == 0 ? false : true;
            }
            else { return false; }
        }
    }
}
