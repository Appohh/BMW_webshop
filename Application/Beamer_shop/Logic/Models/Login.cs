using System.ComponentModel.DataAnnotations;

namespace Logic.Models
{
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }



        public Login()
        {

        }

        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }

    }
}

