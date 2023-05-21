using Factory.Interfaces;
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
        private ICustomerFactory _customerFactory;
        private ICustomerService _customerService;

        private IDiscountFactory _discountFactory;
        private IDiscountService _discountService;

        public Customer? LoggedCustomer { get; set; }
        public Order? Order { get; set; }

        private JsonSerializerSettings settings = new JsonSerializerSettings
        {
            //Type hinting
            TypeNameHandling = TypeNameHandling.Auto
        };

        public CheckoutReviewModel(ICustomerFactory customerFactory, IDiscountFactory discountFactory)
        {
            _customerFactory = customerFactory;
            _customerService = _customerFactory.CustomerService;

            _discountFactory = discountFactory;
            _discountService = discountFactory.DiscountService;
        }
        public IActionResult OnGet()
        {
            setupPage();

            Order.CalculateTotalTax();
            Order.CalculateTotalTotal();
            _=Order.ApplyDiscounts(_discountService.GetAllActiveDiscounts());

            //serialize order object
            var json = JsonConvert.SerializeObject(Order, settings);
            TempData["preparedOrder"] = json;

            return Page();


        }


        public IActionResult OnPostApplyCoupon()
        {
            var validationResult = setupPage();
            if(validationResult != null)
            {
                return validationResult;
            }

            if (Request.Form.TryGetValue("CouponCode", out var value))
            {
                string coupon = value.ToString();

                if (!Order.ApplyDiscounts(_discountService.GetAllActiveDiscounts(), coupon))
                {
                    Order.DiscountsApplied.Clear();

                    //serialize order object
                    var json_ = JsonConvert.SerializeObject(Order, settings);
                    TempData["preparedOrder"] = json_;

                    TempData["ErrorMessage"] = "Coupon not applicable.";
                    return Redirect("/CheckoutReview");
                }

                //serialize order object
                var json = JsonConvert.SerializeObject(Order, settings);
                TempData["preparedOrder"] = json;

                return Page();
            }

            TempData["ErrorMessage"] = "Please enter coupon code.";
            return Redirect("/CheckoutReview");
        }


        private IActionResult? setupPage()
        {
            if (TempData.ContainsKey("preparedOrder"))
            {
                Order = JsonConvert.DeserializeObject<Order>(TempData["preparedOrder"].ToString(), settings);
            }

            if (Order == null) { TempData["ErrorMessage"] = "Order not found."; return Redirect("/CheckoutInfo"); }

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

            if (!LoggedCustomer.Equals(_customerService.GetCustomerById(idValue)))
            {
                TempData["ErrorMessage"] = "Failed to match user with order.";
                return Redirect("/CheckoutInfo");
            }

            return null;
        }

    }
}

