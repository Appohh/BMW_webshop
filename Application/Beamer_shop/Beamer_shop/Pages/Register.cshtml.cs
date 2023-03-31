using Factory;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;


namespace Beamer_shop.Pages
{
    public class RegisterModel : PageModel
    {
        CustomerService customerService = CustomerFactory.CustomerService;

        [BindProperty]
        public Register newCustomer { get; set; }

        public IActionResult OnPost()
        {
            //filters
            if (ModelState.IsValid)
            {
                customerService.RegisterCustomer(newCustomer);
                TempData["Contact"] = JsonSerializer.Serialize(newCustomer);
                return new RedirectToPageResult("Index");
            }
            else
            {
                return Page();
            }
        }

        public void OnGet()
        {

        }
    }
}
