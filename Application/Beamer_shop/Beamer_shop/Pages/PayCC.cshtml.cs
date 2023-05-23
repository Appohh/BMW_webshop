using Factory.Interfaces;
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
    public class PayCCModel : PageModel
    {
        ICustomerFactory _customerFactory;
        IOrderFactory _orderFactory;
        ICustomerService _customerService;
        IOrderService _orderService;
        Order Order { get; set; }
        Customer LoggedCustomer { get; set; }

        public PayCCModel(ICustomerFactory customerFactory, IOrderFactory orderFactory)
        {
            _customerFactory = customerFactory;
            _orderFactory = orderFactory;
            _customerService = _customerFactory.CustomerService;
            _orderService = _orderFactory.OrderService;
            
        }

        private JsonSerializerSettings settings = new JsonSerializerSettings
        {
            //Type hinting
            TypeNameHandling = TypeNameHandling.Auto
        };

        public IActionResult OnGet()
        {
            var validationResult = setupPage();
            if (validationResult != null)
            {
                return validationResult;
            }

            tempOrder();
            return Page();
        }


        public IActionResult OnPostPay()
        {
            var validationResult = setupPage();
            if (validationResult != null)
            {
                return validationResult;
            }

            if (_orderService.FinalizeOrderPayment(Order))
            {
                Order? paidOrder = _orderService.GetOrderById((int)Order.Id);
                TempData["paidOrder"] = JsonConvert.SerializeObject(paidOrder, settings);
                return Redirect("/Account");
            } else
            {
                return throwError("/Account", "Payment failed, please try again or contact us.");
            }

        }
        private IActionResult? setupPage()
        {
            if (TempData.ContainsKey("preparedOrder"))
            {
                Order = JsonConvert.DeserializeObject<Order>(TempData["preparedOrder"].ToString(), settings);
            }


            if (Order == null) { return throwError("/Account", "Order not found."); }

            //check if user is logged in
            if (User?.Identity?.IsAuthenticated == false)
            {
                return throwError("/Account", "No user logged in.");
            }

            //get id of logged in user
            var idClaim = User.FindFirst("id");
            if (idClaim == null)
            {
                return throwError("/Account", "User not found.");
            }

            int idValue = Convert.ToInt32(idClaim.Value);

            //get user
            if ((LoggedCustomer = _customerService.GetCustomerById(idValue)) == null)
            {
                return throwError("/Account", "User not found.");
            }

            if (Order.CustomerId != LoggedCustomer.Id)
            {
                return throwError("/Account", "Failed to match user with order.");
            }

            if (Order.Id == null || Order.Id < 1)
            {
                return throwError("/Account", "Order Id not found.");
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
