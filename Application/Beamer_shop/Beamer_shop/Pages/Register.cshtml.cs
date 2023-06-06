using Factory;
using Factory.Interfaces;
using Logic;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;


namespace Beamer_shop.Pages
{
    public class RegisterModel : PageModel
    {
        ICustomerFactory _customerFactory;
        ICustomerService _customerService;

        public RegisterModel(ICustomerFactory customerFactory) 
        {
            _customerFactory = customerFactory;
            _customerService = _customerFactory.CustomerService;
        }

        [BindProperty]
        public RegisterCustomer newCustomer { get; set; }

        public IActionResult OnPost()
        {
            //filters
            if (ModelState.IsValid)
            {
                //Hash
                (string Salt, string HashedPassword) output = Security.CreateSaltAndHash(newCustomer.Password);
                newCustomer.Salt = output.Salt;
                newCustomer.Hash = output.HashedPassword;
                //Send
                _customerFactory.CustomerService.RegisterCustomer(newCustomer);

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
