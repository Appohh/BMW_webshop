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

namespace Beamer_shop.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login login { get; set; }

        CustomerService customerService = CustomerFactory.CustomerService;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            Customer? validCustomer = null;
            (string hash, string salt, int id)? output = customerService.GetHashSalt(login.Email);

            if (output != null)
            {
                //validate input hash
                string inputHash = Security.CreateHash(output.Value.salt, login.Password);
                if (output.Value.hash == inputHash)
                {
                    //User validated
                    validCustomer = customerService.GetCustomerById(output.Value.id);
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
                    return Page();
             
        }

    }
}
