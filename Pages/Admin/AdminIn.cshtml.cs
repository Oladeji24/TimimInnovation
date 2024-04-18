using System;  // Ensure this namespace is added for DateTime
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TimimInnovation.Pages.Admin
{
    public class AdminInModel : PageModel
    {
        public string CurrentUser { get; set; }
        public DateTime CurrentDateTime { get; set; }

        public void OnGet()
        {
            CurrentUser = User?.Identity?.Name;
            CurrentDateTime = DateTime.Now;
        }
    }
}
