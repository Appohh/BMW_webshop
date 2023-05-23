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
        private IProductFactory _productFactory;
        private IProductService _productService;
        public Customer LoggedCustomer { get; set; }
        public List<Order> orders;
        public MyOrdersModel(IOrderFactory orderFactory, ICustomerFactory customerFactory, IProductFactory productFactory)
        {
            _orderFactory = orderFactory;
            _customerFactory = customerFactory;
            _orderService = _orderFactory.OrderService;
            _customerService = _customerFactory.CustomerService;
            _productFactory = productFactory;
            _productService = _productFactory.ProductService;



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
            getOrderProducts();

            return Page();
        }

        private IActionResult throwError(string page, string error)
        {
            TempData["ErrorMessage"] = error;
            return Redirect(page);
        }

        private void getOrderProducts()
        {
            List<Order> filledOrders = new List<Order>();

            foreach (Order order in orders)
            {
                List<Tuple<int,int>> Cart = _orderService.GetOrderItems(order);
                order.Items = new ShoppingCart();
                foreach(Tuple<int,int> Product in Cart)
                {
                    for (int i = 0; i < Product.Item2; i++)
                    {
                        order.Items.AddItem(_productService.getProductById(Product.Item1));
                    }
                }
                filledOrders.Add(order);
            }
            orders = filledOrders;
        }
    }
}
