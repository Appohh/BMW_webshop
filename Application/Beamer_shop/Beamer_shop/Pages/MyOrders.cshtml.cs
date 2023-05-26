using Factory.Interfaces;
using Logic;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Beamer_shop.Pages
{
    [Authorize]
    public class MyOrdersModel : PageModel
    {
        private IOrderFactory _orderFactory;
        private ICustomerFactory _customerFactory;
        private IOrderService _orderService;
        private ICustomerService _customerService;

        public Customer LoggedCustomer { get; set; }
        public List<Order> orders;
        public MyOrdersModel(IOrderFactory orderFactory, ICustomerFactory customerFactory)
        {
            _orderFactory = orderFactory;
            _customerFactory = customerFactory;
            _orderService = _orderFactory.OrderService;
            _customerService = _customerFactory.CustomerService;

            orders = new List<Order>();
        }

        public IActionResult OnGet()
        {
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

            orders = _orderService.GetCustomerOrders(LoggedCustomer);

            return Page();
        }

        private IActionResult throwError(string page, string error)
        {
            TempData["ErrorMessage"] = error;
            return Redirect(page);
        }
    }
}
