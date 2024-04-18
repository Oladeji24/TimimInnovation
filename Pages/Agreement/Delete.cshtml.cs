using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Agreement
{
    public class DeleteModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DeleteModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TermAndCondition TermAndCondition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TermAndConditions == null)
            {
                return NotFound();
            }

            var termandcondition = await _context.TermAndConditions.FirstOrDefaultAsync(m => m.TermAndConditionId == id);

            if (termandcondition == null)
            {
                return NotFound();
            }
            else 
            {
                TermAndCondition = termandcondition;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TermAndConditions == null)
            {
                return NotFound();
            }
            var termandcondition = await _context.TermAndConditions.FindAsync(id);

            if (termandcondition != null)
            {
                TermAndCondition = termandcondition;
                _context.TermAndConditions.Remove(TermAndCondition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
