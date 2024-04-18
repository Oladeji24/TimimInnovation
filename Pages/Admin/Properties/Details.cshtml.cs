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
    public class DetailsModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DetailsModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
