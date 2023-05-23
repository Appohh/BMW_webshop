using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Customer customer &&
                   Id == customer.Id &&
                   FirstName == customer.FirstName &&
                   LastName == customer.LastName &&
                   Email == customer.Email &&
                   BirthDate == customer.BirthDate &&
                   Street == customer.Street &&
                   HouseNumber == customer.HouseNumber &&
                   ZipCode == customer.ZipCode &&
                   City == customer.City &&
                   Country == customer.Country;
        }

    }
}
