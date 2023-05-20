using Logic;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NuGet.Configuration;

namespace Beamer_shop.Pages
{
    [Authorize]
    public class CheckoutReviewModel : PageModel
    {
        private ICustomerService _customerService;
        public Customer? LoggedCustomer { get; set; }
        public Order? Order { get; set; }

        private JsonSerializerSettings settings = new JsonSerializerSettings
        {
            //Type hinting
            TypeNameHandling = TypeNameHandling.Auto
        };

        public CheckoutReviewModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult OnGet()
        {
            if (TempData.ContainsKey("preparedOrder"))
            {
               Order = JsonConvert.DeserializeObject<Order>(TempData["preparedOrder"].ToString(), settings);
            }
            
            if(Order == null) { TempData["preparedOrder"] = "Order not found."; return Redirect("/CheckoutInfo"); }

            //check if user is logged in
            if (User?.Identity?.IsAuthenticated == false)
            {
                TempData["ErrorMessage"] = "No user logged in."; return Redirect("/CheckoutInfo");
            }

            //get id of logged in user
            var idClaim = User.FindFirst("id");
            if (idClaim == null)
            {
                TempData["ErrorMessage"] = "User not found."; return Redirect("/CheckoutInfo");
            }
            int idValue = Convert.ToInt32(idClaim.Value);

            //get user
            if ((LoggedCustomer = _customerService.GetCustomerById(idValue)) == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return Redirect("/CheckoutInfo");
            }

            if(!LoggedCustomer.Equals(_customerService.GetCustomerById(idValue)))
            {
                TempData["ErrorMessage"] = "Failed to match user with order.";
                return Redirect("/CheckoutInfo");
            }

            Order.CalculateTotalTax();
            Order.CalculateTotalTotal();
            //Order.ApplyDiscounts();

            return Page();


        }





    }
}

