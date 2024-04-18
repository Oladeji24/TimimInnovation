using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Admin.Properties
{
    public class DeleteModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DeleteModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TimimBCProperties TimimBCProperties { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TimimProperties == null)
            {
                return NotFound();
            }

            var timimbcproperties = await _context.TimimProperties.FirstOrDefaultAsync(m => m.PropertyId == id);

            if (timimbcproperties == null)
            {
                return NotFound();
            }
            else 
            {
                TimimBCProperties = timimbcproperties;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TimimProperties == null)
            {
                return NotFound();
            }
            var timimbcproperties = await _context.TimimProperties.FindAsync(id);

            if (timimbcproperties != null)
            {
                TimimBCProperties = timimbcproperties;
                _context.TimimProperties.Remove(TimimBCProperties);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
