using System.ComponentModel.DataAnnotations;

namespace WebshopCL.Forms
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
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Country = country;
            Message = message;
        }

    }
}

