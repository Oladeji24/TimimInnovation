using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Admin.Securities.Activity
{
    public class EditModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public EditModel(TimimInnovation.Data.ApplicationDbContext context)
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

            var lastactivity =  await _context.LastActivities.FirstOrDefaultAsync(m => m.LastActivityId == id);
            if (lastactivity == null)
            {
                return NotFound();
            }
            LastActivity = lastactivity;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LastActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LastActivityExists(LastActivity.LastActivityId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LastActivityExists(int id)
        {
          return (_context.LastActivities?.Any(e => e.LastActivityId == id)).GetValueOrDefault();
        }
    }
}
