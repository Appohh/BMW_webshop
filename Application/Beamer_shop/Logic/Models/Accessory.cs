using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Accessory : Product
    {
        public string Type { get; set; }


        public Accessory() : base(0, "", 0, "", "", "")
        {
        }
        public Accessory(string type, int id, string name, decimal price, string description, string imageUrl, string keyword) : base(id, name, price, description, imageUrl, keyword)
        {
            Type = type;
        }
    }

}

