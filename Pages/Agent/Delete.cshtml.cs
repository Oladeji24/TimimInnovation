using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Agent
{
    public class DeleteModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DeleteModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TimimAgent TimimAgent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TimimAgents == null)
            {
                return NotFound();
            }

            var timimagent = await _context.TimimAgents.FirstOrDefaultAsync(m => m.AgentId == id);

            if (timimagent == null)
            {
                return NotFound();
            }
            else 
            {
                TimimAgent = timimagent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TimimAgents == null)
            {
                return NotFound();
            }
            var timimagent = await _context.TimimAgents.FindAsync(id);

            if (timimagent != null)
            {
                TimimAgent = timimagent;
                _context.TimimAgents.Remove(TimimAgent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
