using System.ComponentModel.DataAnnotations;

namespace WebshopCL
{
    public class Contact
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Country { get; set; }
        [MaxLength(100)]
        public string Message { get; set; }
  


        public Contact()
        {
    
        }

        public Contact(string firstname, string lastname, string email, string country, string message)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Email = email;
            this.Country = country;
            this.Message = message;
        }

    }
}

