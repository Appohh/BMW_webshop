using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopCL
{
    public abstract class User
    {
        protected int Id { get; private set; }
        protected string Firstname { get; private set; }
        protected string Lastname { get; private set; }
        protected DateTime Birthdate { get; private set; }
        protected string Email { get; private set; }
        protected string Password { get; private set; }
        protected int Role { get; private set; }

        protected User(int id, string firstname, string lastname, DateTime birthdate, string email, string password, int role)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Birthdate = birthdate;
            Email = email;
            Password = password;
            Role = role;
        }

        public abstract string getDetails();
  
    }
}
