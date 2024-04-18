using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Accords
{
    public class DeleteModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DeleteModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Concord Concord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Concords == null)
            {
                return NotFound();
            }

            var concord = await _context.Concords.FirstOrDefaultAsync(m => m.ConcordId == id);

            if (concord == null)
            {
                return NotFound();
            }
            else 
            {
                Concord = concord;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Concords == null)
            {
                return NotFound();
            }
            var concord = await _context.Concords.FindAsync(id);

            if (concord != null)
            {
                Concord = concord;
                _context.Concords.Remove(Concord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
