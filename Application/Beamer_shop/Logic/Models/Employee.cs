using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BSN { get; set; }
        public int Role { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Employee employee &&
                   Id == employee.Id &&
                   FirstName == employee.FirstName &&
                   LastName == employee.LastName &&
                   BirthDate == employee.BirthDate &&
                   Email == employee.Email &&
                   Phone == employee.Phone &&
                   BSN == employee.BSN &&
                   Role == employee.Role;
        }
    }
}
