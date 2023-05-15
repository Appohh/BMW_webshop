using Beamer_shop.Interfaces;
using Beamer_shop.Services;
using Factory;
using Factory.Interfaces;
using Logic;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beamer_shop.Pages
{
    [Authorize]
    public class CheckoutShipModel : PageModel
    {
        private ICustomerFactory _customerFactory;
        private ICustomerService _customerService;
        private IShoppingCartService _shoppingCartService;

        public Customer? LoggedCustomer { get; set; }

        public ShoppingCart? ShoppingCart { get; set; }

        public CheckoutShipModel(ICustomerFactory customerFactory, IShoppingCartService shoppingCartService)
        {
            _customerFactory = customerFactory;
            _customerService = _customerFactory.CustomerService;

            _shoppingCartService = shoppingCartService;
            ShoppingCart = _shoppingCartService.RetrieveShoppingCart();
        }

        public void OnGet()
        {
            //get id of logged in user
            var idClaim = User.FindFirst("id");
            if (idClaim != null)
            {
                int idValue = Convert.ToInt32(idClaim.Value);
                LoggedCustomer = _customerService.GetCustomerById(idValue);
            }
        }


    }
}
