using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Agent
{
    public class EditModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public EditModel(TimimInnovation.Data.ApplicationDbContext context)
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

            var timimagent =  await _context.TimimAgents.FirstOrDefaultAsync(m => m.AgentId == id);
            if (timimagent == null)
            {
                return NotFound();
            }
            TimimAgent = timimagent;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TimimAgent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimimAgentExists(TimimAgent.AgentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TimimAgentExists(int id)
        {
          return (_context.TimimAgents?.Any(e => e.AgentId == id)).GetValueOrDefault();
        }
    }
}
