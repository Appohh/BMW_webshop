using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public string Keyword { get; set; }
        public int Taxrate { get; set; }
        public int Weight { get; set; }


        protected Product(int id, string name, double price, string? description, string imageUrl, string keyword, int taxrate, int weight)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            ImageUrl = imageUrl;
            Keyword = keyword;
            Taxrate = taxrate;
            Weight = weight;
        }

        public virtual string getDetails()
        {
            return $"Weight: {Weight}kg\n";
        }
    }

}
