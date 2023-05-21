using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using Logic.Models;
using Logic;
using Factory;
using System.Security.Cryptography.X509Certificates;
using Factory.Interfaces;
using Logic.Interfaces;

namespace Beamer_shop.Pages
{
    public class LoginModel : PageModel
    {

        ICustomerFactory _customerFactory;
        ICustomerService _customerService;

        [BindProperty]
        public Login login { get; set; }

        public LoginModel(ICustomerFactory customerFactory) 
        {
            _customerFactory = customerFactory;
            _customerService = _customerFactory.CustomerService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
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

                // Make claims
                if (ModelState.IsValid && validCustomer != null)
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
                    return RedirectToPage("/Account");
                }
                
                
                
            }

                    await HttpContext.ForbidAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    TempData["ErrorMessage"] = "Wrong credentials.";
                    return Redirect("/Login");
             
        }

    }
}
