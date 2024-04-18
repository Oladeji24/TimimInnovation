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
    public class DeleteModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DeleteModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TenantComplains == null)
            {
                return NotFound();
            }
            var tenantcomplain = await _context.TenantComplains.FindAsync(id);

            if (tenantcomplain != null)
            {
                TenantComplain = tenantcomplain;
                _context.TenantComplains.Remove(TenantComplain);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
