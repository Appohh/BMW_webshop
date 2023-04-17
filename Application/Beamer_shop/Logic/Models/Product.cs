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
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public string Keyword { get; set; }

        protected Product(int id, string name, decimal price, string? description, string imageUrl, string keyword)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            ImageUrl = imageUrl;
            Keyword = keyword;
        }
    }

}
