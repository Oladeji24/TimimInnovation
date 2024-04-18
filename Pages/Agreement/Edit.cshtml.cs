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

namespace TimimInnovation.Pages.Agreement
{
    public class EditModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public EditModel(TimimInnovation.Data.ApplicationDbContext context)
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

            var termandcondition =  await _context.TermAndConditions.FirstOrDefaultAsync(m => m.TermAndConditionId == id);
            if (termandcondition == null)
            {
                return NotFound();
            }
            TermAndCondition = termandcondition;
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

            _context.Attach(TermAndCondition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TermAndConditionExists(TermAndCondition.TermAndConditionId))
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

        private bool TermAndConditionExists(int id)
        {
          return (_context.TermAndConditions?.Any(e => e.TermAndConditionId == id)).GetValueOrDefault();
        }
    }
}
