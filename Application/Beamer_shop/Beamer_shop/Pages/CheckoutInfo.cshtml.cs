using Factory;
using Logic.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using Logic.Interfaces;
using Factory.Interfaces;
using Beamer_shop.Services;
using Beamer_shop.Interfaces;

namespace Beamer_shop.Pages
{
    public class CheckoutInfoModel : PageModel
    {
        private ICustomerFactory _customerFactory;
        private ICustomerService _customerService;
        private IShoppingCartService _shoppingCartService;

        [BindProperty]
        public Register newCustomer { get; set; }

        [BindProperty]
        public Login login { get; set; }

        public Customer? LoggedCustomer { get; set; }

        public IShoppingCart? ShoppingCart { get; set; }


        public CheckoutInfoModel(ICustomerFactory customerFactory, IShoppingCartService shoppingCartService)
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



        public IActionResult OnPostCheckoutRegisterUser()
        {
            ModelState.Remove("Email");
            ModelState.Remove("Password");

            //filters
            if (ModelState.IsValid)
            {
                //Hash
                (string Salt, string HashedPassword) output = Security.CreateSaltAndHash(newCustomer.Password);
                newCustomer.Salt = output.Salt;
                newCustomer.Hash = output.HashedPassword;
                //Send
                _customerService.RegisterCustomer(newCustomer);

                return Page();
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostCheckoutLoginUser()
        {

            Customer? validCustomer = null;
            (string hash, string salt, int id)? output = _customerService.GetHashSalt(login.Email);

            if (output != null)
            {
                //validate input hash
                string inputHash = Security.CreateHash(output.Value.salt, login.Password);
                if (output.Value.hash == inputHash)
                {
                    //User validated
                    validCustomer = _customerService.GetCustomerById(output.Value.id);
                }

                int validModel = 0;
                if(login.Email == null) { validModel =+ 1; }
                if (login.Password == null) { validModel =+ 1; }


                // Make claims
                if (validModel == 0 && validCustomer != null)
                {
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                        new Claim[]
                        {
                        new Claim("id", validCustomer.Id.ToString()),
                        new Claim(ClaimTypes.Name, validCustomer.FirstName + " " + validCustomer.LastName),
                        new Claim(ClaimTypes.Role, "Customer"),
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return RedirectToPage("/CheckoutInfo");
                }

            }
            await HttpContext.ForbidAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Page();

        }
    }
}
