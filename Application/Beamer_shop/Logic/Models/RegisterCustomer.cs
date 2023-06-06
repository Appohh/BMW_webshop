using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class RegisterCustomer
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string BirthDate { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]

        public string Password { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }
    }
}
