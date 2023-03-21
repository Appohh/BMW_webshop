using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebshopCL.Forms;

namespace Beamer_shop.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact contact { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
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
