using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Admin.Securities.Activity
{
    public class DeleteModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DeleteModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public LastActivity LastActivity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LastActivities == null)
            {
                return NotFound();
            }

            var lastactivity = await _context.LastActivities.FirstOrDefaultAsync(m => m.LastActivityId == id);

            if (lastactivity == null)
            {
                return NotFound();
            }
            else 
            {
                LastActivity = lastactivity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.LastActivities == null)
            {
                return NotFound();
            }
            var lastactivity = await _context.LastActivities.FindAsync(id);

            if (lastactivity != null)
            {
                LastActivity = lastactivity;
                _context.LastActivities.Remove(LastActivity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
