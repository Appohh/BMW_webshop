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
            Customer validCustomer = customerService.ValidateCredentials(login);

            // Validate
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
            else
            {
                await HttpContext.ForbidAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Page();
            }
        }


    }
}
