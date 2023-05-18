using Beamer_shop.Interfaces;
using Beamer_shop.Models;
using Beamer_shop.Services;
using Factory;
using Factory.Interfaces;
using Logic;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GoogleMaps.LocationServices;


namespace Beamer_shop.Pages
{
    [Authorize]
    public class CheckoutShipModel : PageModel
    {
        private ICustomerFactory _customerFactory;
        private ICustomerService _customerService;
        private IShoppingCartService _shoppingCartService;

        [BindProperty]
        public Address ShippingAddress { get; set; }

        public Customer? LoggedCustomer { get; set; }

        public ShoppingCart? ShoppingCart { get; set; }

        public IShippingCalculator ShippingCalculator { get; set; }

        public string adress = "";
        public string zipcode = "";

        public CheckoutShipModel(ICustomerFactory customerFactory, IShoppingCartService shoppingCartService)
        {
            _customerFactory = customerFactory;
            _customerService = _customerFactory.CustomerService;

            _shoppingCartService = shoppingCartService;
            ShoppingCart = _shoppingCartService.RetrieveShoppingCart();            
        }

        public IActionResult OnGet()
        {
            getUser();
            if (LoggedCustomer != null)
            {
                adress = LoggedCustomer.Address + ", " + LoggedCustomer.City;
                zipcode = LoggedCustomer.ZipCode + ", " + LoggedCustomer.Country;
                if (!refreshShippingCost()) { TempData["ErrorMessage"] = "Your cart is empty."; return Redirect("/CheckoutInfo"); };
                return Page();
            }
            else
            {
                TempData["ErrorMessage"] = "No user logged in."; return Redirect("/CheckoutInfo");
            }


        }

        public IActionResult OnPostChangeShippingAddress()
        {
            getUser();
            adress = ShippingAddress.Street + " " + ShippingAddress.HouseNumber + ", " + ShippingAddress.City;
            zipcode = ShippingAddress.Zipcode + ", " + ShippingAddress.Country;
            if(!refreshShippingCost()) { TempData["ErrorMessage"] = "Your cart is empty."; return Redirect("/CheckoutInfo"); };

            return Page();

        }

        private void getUser()
        {
            //get id of logged in user
            var idClaim = User.FindFirst("id");
            if (idClaim != null)
            {
                int idValue = Convert.ToInt32(idClaim.Value);
                LoggedCustomer = _customerService.GetCustomerById(idValue);
            }
        }
        
        private bool refreshShippingCost()
        {
            if (ShoppingCart == null) { return false; }
            
                try
                {
                    ShippingCalculator = new ShippingCalculator(adress, ShoppingCart);
                    return true;
                } catch
                {
                    return false;
                }
            
        }






    }
}
