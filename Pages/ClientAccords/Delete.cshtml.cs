using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.ClientAccords
{
    public class DeleteModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DeleteModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ClientConcord ClientConcord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ClientConcords == null)
            {
                return NotFound();
            }

            var clientconcord = await _context.ClientConcords.FirstOrDefaultAsync(m => m.ClientConcordId == id);

            if (clientconcord == null)
            {
                return NotFound();
            }
            else 
            {
                ClientConcord = clientconcord;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ClientConcords == null)
            {
                return NotFound();
            }
            var clientconcord = await _context.ClientConcords.FindAsync(id);

            if (clientconcord != null)
            {
                ClientConcord = clientconcord;
                _context.ClientConcords.Remove(ClientConcord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
