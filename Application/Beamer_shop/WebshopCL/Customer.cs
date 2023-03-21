using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopCL
{
    public class Customer : User
    {
        private string Address;
        private string City;
        private string Zipcode;
        private int? Cardnumber;
        private int? CVS;

        public Customer(int id, string firstname, string lastname, DateTime birthdate, string email, string password, int role, string address, string city, string zipcode, int? cardnumber, int? cvs) : base(id, firstname, lastname, birthdate, email, password, role)
        {
            Address = address;
            City = city;
            Zipcode = zipcode;
            Cardnumber = cardnumber;
            CVS = cvs;
        }

        public override string getDetails()
        {

            return $"Name: {Firstname} {Lastname} Email: {Email} Birthdate: {Birthdate} Address: {Address} City: {City} Zipcode: {Zipcode}";
        }

        public void makePayment()
        {
            throw new NotImplementedException();
        }

        public dynamic getOrderHistory()
        {
            throw new NotImplementedException();
        }



    }
}
