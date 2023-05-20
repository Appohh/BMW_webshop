using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Address
    {

        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }

        public Address(string street, string houseNumber, string city, string zipcode, string country)
        {
            Street = street;
            HouseNumber = houseNumber;
            City = city;
            Zipcode = zipcode;
            Country = country;
        }
    }
}
