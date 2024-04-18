using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TimimInnovation.Pages.Admin
{
    public class AuthModel : PageModel
    {
        public IActionResult OnGet()
        {
            return RedirectToPage("/Admin/Securities/Activity/Create");
        }
    }
}
