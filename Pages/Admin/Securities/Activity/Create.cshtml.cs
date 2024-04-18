using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Admin.Securities.Activity
{
    public class CreateModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public CreateModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public LastActivity LastActivity { get; set; } = new LastActivity();

        public async Task<IActionResult> OnGetAsync()
        {
            LastActivity.Username = User.Identity?.Name ?? "Anonymous";
            LastActivity.LastSeen = DateTime.Now;

            if (_context != null)
            {
                _context.LastActivities.Add(LastActivity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Admin/AdminIn");
        }
    }
}
