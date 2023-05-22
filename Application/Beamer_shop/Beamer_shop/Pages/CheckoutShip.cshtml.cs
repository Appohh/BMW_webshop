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
using Address = Beamer_shop.Models.Address;
using Beamer_shop.Pages.Components;
using Newtonsoft.Json;
using NuGet.Configuration;

namespace Beamer_shop.Pages
{
    [Authorize]
    public class CheckoutShipModel : PageModel
    {
        private ICustomerFactory _customerFactory;
        private ICustomerService _customerService;
        private IShoppingCartService _shoppingCartService;

        [BindProperty]
        public Address ChangedShippingAddress { get; set; }
        public Address ShippingAddress { get; set; }

        public Customer? LoggedCustomer { get; set; }

        public IShoppingCart? ShoppingCart { get; set; }

        public IShippingCalculator ShippingCalculator { get; set; }


        private JsonSerializerSettings settings = new JsonSerializerSettings
        {
            //Type hinting
            TypeNameHandling = TypeNameHandling.Auto
        };

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

                setAddress();
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
            ShippingAddress = ChangedShippingAddress;
            if(!refreshShippingCost()) { TempData["ErrorMessage"] = "Your cart is empty."; return Redirect("/CheckoutInfo"); };

            var json = JsonConvert.SerializeObject(ShippingAddress, settings);

            TempData["newShippingAddress"] = json;

            return Page();

        }

        public IActionResult OnPostPrepareOrder()
        {
            getUser();
            setAddress();
            var shippingAdress = TempData["newShippingAddress"];
            if(shippingAdress != null)
            {
                ShippingAddress = JsonConvert.DeserializeObject<Address>(shippingAdress.ToString());
            }

            if (LoggedCustomer == null)
            {
                TempData["ErrorMessage"] = "No user logged in."; return Redirect("/CheckoutInfo");
            }

            if(ShoppingCart == null || ShoppingCart.GetItems().Count < 1)
            {
                TempData["ErrorMessage"] = "Your cart is empty."; return Redirect("/CheckoutInfo");
            }

            if (!refreshShippingCost()) { TempData["ErrorMessage"] = "Update your delivery address."; return Redirect("/CheckoutInfo"); };

            Order prepOrder = new Order(ShoppingCart, LoggedCustomer.Id, 0, ShippingCalculator.EstimatedDeliveryTime.Item1, ShippingCalculator.EstimatedDeliveryTime.Item2, new Logic.Models.Address(ShippingAddress.Street, ShippingAddress.HouseNumber, ShippingAddress.City, ShippingAddress.Zipcode, ShippingAddress.Country), ShippingCalculator.TotalShippingCost);

            //serialize order object
            var json = JsonConvert.SerializeObject(prepOrder, settings);

            TempData["preparedOrder"] = json;
            return Redirect("/CheckoutReview");
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

        public void setAddress()
        {
            ShippingAddress = new Address
            {
                Street = LoggedCustomer.Street,
                HouseNumber = LoggedCustomer.HouseNumber,
                City = LoggedCustomer.City,
                Zipcode = LoggedCustomer.ZipCode,
                Country = LoggedCustomer.Country
            };
        }
        
        private bool refreshShippingCost()
        {
            if (ShoppingCart == null) { return false; }
            
                try
                {
                    string address = ShippingAddress.Street + " " + ShippingAddress.HouseNumber;
                    ShippingCalculator = new ShippingCalculator(address, ShoppingCart);
                    return true;
                } catch
                {
                    return false;
                }
            
        }






    }
}
