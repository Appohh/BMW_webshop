using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Logic
{
    public class ProductFilter
    {
        public string? Keyword { get; set; }
        public string? ProductType { get; set; }
        public string? Model { get; set; }
        public string? Make { get; set; }
        public int? Fuel { get; set; }
        public int? StartPrice { get; set; }
        public int? EndPrice { get; set; }


        public List<Product> FilterProducts(List<Product> products)
        {
            List<Product> FilteredProducts = new List<Product>();
            FilteredProducts.AddRange(products);

            if (!string.IsNullOrEmpty(Keyword))
            {
                if (Keyword.Length > 0)
                {
                    FilteredProducts = FilteredProducts.Where(product =>
                        product.Name.Contains(Keyword)).ToList();
                }
            }
            if (!string.IsNullOrEmpty(ProductType))
            {
                FilteredProducts = FilteredProducts.Where(product => product.GetType().Name == ProductType).ToList();
            }

            //car specific filters
            if (ProductType == typeof(Car).Name || string.IsNullOrEmpty(ProductType))
            {
                if (!string.IsNullOrEmpty(Model))
                {
                    FilteredProducts = FilteredProducts.Where(product =>
                        product is Car car && car.Model.Contains(Model)).ToList();
                }
                if (!string.IsNullOrEmpty(Make))
                {
                    FilteredProducts = FilteredProducts.Where(product =>
                        product is Car car && car.Make.Contains(Make)).ToList();
                }
                if (Fuel.HasValue)
                {
                    FilteredProducts = FilteredProducts.Where(product =>
                        product is Car car && car.Fuel == Fuel).ToList();
                }

                if (string.IsNullOrEmpty(ProductType))
                {
                    FilteredProducts = FilteredProducts.Where(product => product.GetType().ToString() == typeof(Car).ToString()).ToList();
                }
            }

            if (StartPrice.HasValue)
            {
                FilteredProducts = FilteredProducts.Where(product =>
                product.Price >= Convert.ToDouble(StartPrice)).ToList();
            }
            if (EndPrice.HasValue)
            {
                FilteredProducts = FilteredProducts.Where(product =>
                product.Price <= Convert.ToDouble(EndPrice)).ToList();
            }

            return FilteredProducts;

        }
    }
}



