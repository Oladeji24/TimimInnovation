using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Admin.ComplaintBox
{
    public class DeleteModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DeleteModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TimimComplaintBox TimimComplaintBox { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TimimComplaintBoxes == null)
            {
                return NotFound();
            }

            var timimcomplaintbox = await _context.TimimComplaintBoxes.FirstOrDefaultAsync(m => m.TimimComplaintBoxId == id);

            if (timimcomplaintbox == null)
            {
                return NotFound();
            }
            else 
            {
                TimimComplaintBox = timimcomplaintbox;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TimimComplaintBoxes == null)
            {
                return NotFound();
            }
            var timimcomplaintbox = await _context.TimimComplaintBoxes.FindAsync(id);

            if (timimcomplaintbox != null)
            {
                TimimComplaintBox = timimcomplaintbox;
                _context.TimimComplaintBoxes.Remove(TimimComplaintBox);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
