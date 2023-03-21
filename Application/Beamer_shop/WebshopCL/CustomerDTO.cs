using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopCL
{
    public class CustomerDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        public CustomerDTO(string firstname, string lastname, DateTime birthdate, string email, string address, string city, string zipcode)
        {
            Firstname = firstname;
            Lastname = lastname;
            Birthdate = birthdate;
            Email = email;
            Address = address;
            City = city;
            Zipcode = zipcode;
        }

    }
}
