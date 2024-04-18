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
    public class DetailsModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DetailsModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
