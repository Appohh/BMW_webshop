using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Beamer_shop.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact contact { get; set; }

        public IActionResult OnPost()
        {
            //filters
            if (ModelState.IsValid)
            {
                TempData["Contact"] = JsonSerializer.Serialize(contact);
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
