using AutoMapper.Configuration;
using Factory.Interfaces;
using Logic;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NuGet.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Beamer_shop.Pages
{
    [Authorize]
    public class CheckoutReviewModel : PageModel
    {
        private ICustomerFactory _customerFactory;
        private ICustomerService _customerService;

        private IDiscountFactory _discountFactory;
        private IDiscountService _discountService;

        private IOrderFactory _orderFactory;
        private IOrderService _orderService;

        public Customer? LoggedCustomer { get; set; }
        public Order? Order { get; set; }

        private JsonSerializerSettings settings = new JsonSerializerSettings
        {
            //Type hinting
            TypeNameHandling = TypeNameHandling.Auto
        };

        public CheckoutReviewModel(ICustomerFactory customerFactory, IDiscountFactory discountFactory, IOrderFactory orderFactory)
        {
            _customerFactory = customerFactory;
            _customerService = _customerFactory.CustomerService;

            _discountFactory = discountFactory;
            _discountService = _discountFactory.DiscountService;

            _orderFactory = orderFactory;
            _orderService = orderFactory.OrderService;
        }
        public IActionResult OnGet()
        {
            setupPage();

            Order.CalculateTotalTax();
            Order.CalculateTotalTotal();
            _=Order.ApplyDiscounts(_discountService.GetAllActiveDiscounts());

            tempOrder();

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

                if(string.IsNullOrEmpty(coupon))
                {

                    tempOrder();

                    return throwError("/CheckoutReview", "Please enter a coupon code.");

                }

                if (!Order.ApplyDiscounts(_discountService.GetAllActiveDiscounts(), coupon))
                {
                    Order.DiscountsApplied.Clear();

                    tempOrder();

                    return throwError("/CheckoutReview", "Coupon not applicable.");

                }

                tempOrder();

                return Page();
            }

            tempOrder();

            return throwError("/CheckoutReview", "Please enter coupon code.");
        }

        public IActionResult OnPostCheckoutOrder()
        {
            var validationResult = setupPage();
            if (validationResult != null)
            {
                return validationResult;
            }

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(Order);
            Validator.TryValidateObject(Order, validationContext, validationResults);

            if (validationResults.Any()) { return throwError("/CheckoutInfo", "There has occured an error, please try again or contact us."); }

            int orderId;
            switch (Order.PaymentType)
            {
                case 0:
                    orderId = _orderService.MakeOrder(Order);
                    if (orderId > 0)
                    {
                        Order.Id = orderId;
                        tempOrder();
                        return Redirect("/PayCC");
                    }
                    else return throwError("/CheckoutInfo", "There has occured an error, please try again or contact us.");
   
                case 1:
                    orderId = _orderService.MakeOrder(Order);
                    if (orderId > 0)
                    {
                        Order.Id = orderId;
                        tempOrder();
                        return Redirect("/Account");
                    }
                    else return throwError("/CheckoutInfo", "There has occured an error, please try again or contact us.");

                default:
                    return throwError("/CheckoutInfo", "There has occured an error, please try again or contact us.");
            }

        }

        public IActionResult OnPostPaymentMethodCreditCard()
        {
            var validationResult = setupPage();
            if (validationResult != null)
            {
                return validationResult;
            }

            Order.PaymentType = 0;

            tempOrder();

            return Page();
        }

        public IActionResult OnPostPaymentMethodKlarna()
        {
            var validationResult = setupPage();
            if (validationResult != null)
            {
                return validationResult;
            }

            Order.PaymentType = 1;

            tempOrder();

            return Page();
        }

        private IActionResult? setupPage()
        {
            if (TempData.ContainsKey("preparedOrder"))
            {
                Order = JsonConvert.DeserializeObject<Order>(TempData["preparedOrder"].ToString(), settings);
            }
            

            if (Order == null) { return throwError("/CheckoutInfo", "Order not found."); }

            //check if user is logged in
            if (User?.Identity?.IsAuthenticated == false)
            {
                return throwError("/CheckoutInfo", "No user logged in.");
            }

            //get id of logged in user
            var idClaim = User.FindFirst("id");
            if (idClaim == null)
            {
                return throwError("/CheckoutInfo", "User not found.");
            }

            int idValue = Convert.ToInt32(idClaim.Value);

            //get user
            if ((LoggedCustomer = _customerService.GetCustomerById(idValue)) == null)
            {
                return throwError("/CheckoutInfo", "User not found.");
            }

            if (!LoggedCustomer.Equals(_customerService.GetCustomerById(idValue)))
            {
                return throwError("/CheckoutInfo", "Failed to match user with order.");
            }

            return null;
        }

        private void tempOrder()
        {
            //serialize order object
            var json = JsonConvert.SerializeObject(Order, settings);
            TempData["preparedOrder"] = json;
        }

        private IActionResult throwError(string page, string error)
        {
            TempData["ErrorMessage"] = error;
            return Redirect(page);
        }

    }
}

