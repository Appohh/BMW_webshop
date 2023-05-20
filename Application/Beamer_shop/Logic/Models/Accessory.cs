using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Logic.Models
{
    public class Accessory : Product
    {
        public string Type { get; set; }


        public Accessory() : base(0, "", 0, "", "", "", 0, 0)
        {
        }
        public Accessory(string type, int id, string name, double price, string description, string imageUrl, string keyword, int taxrate, int weight) : base(id, name, price, description, imageUrl, keyword, taxrate, weight)
        {
            Type = type;
        }
        public override string getDetails()
        {
            return base.getDetails() + $"Type of accessory: {Type}\n";
        }
    }
}

