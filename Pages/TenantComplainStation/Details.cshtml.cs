using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.TenantComplainStation
{
    public class DetailsModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DetailsModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public TenantComplain TenantComplain { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TenantComplains == null)
            {
                return NotFound();
            }

            var tenantcomplain = await _context.TenantComplains.FirstOrDefaultAsync(m => m.TenantComplainId == id);
            if (tenantcomplain == null)
            {
                return NotFound();
            }
            else 
            {
                TenantComplain = tenantcomplain;
            }
            return Page();
        }
    }
}
