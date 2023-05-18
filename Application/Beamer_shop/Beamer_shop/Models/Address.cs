using Microsoft.Build.Framework;

namespace Beamer_shop.Models
{
    public class Address
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
