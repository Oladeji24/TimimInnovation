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
    public class DetailsModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DetailsModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
