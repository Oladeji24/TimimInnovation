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

namespace TimimInnovation.Pages.Admin.ComplaintBox
{
    public class EditModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public EditModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TimimComplaintBox TimimComplaintBox { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TimimComplaintBoxes == null)
            {
                return NotFound();
            }

            var timimcomplaintbox =  await _context.TimimComplaintBoxes.FirstOrDefaultAsync(m => m.TimimComplaintBoxId == id);
            if (timimcomplaintbox == null)
            {
                return NotFound();
            }
            TimimComplaintBox = timimcomplaintbox;
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

            _context.Attach(TimimComplaintBox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimimComplaintBoxExists(TimimComplaintBox.TimimComplaintBoxId))
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

        private bool TimimComplaintBoxExists(int id)
        {
          return (_context.TimimComplaintBoxes?.Any(e => e.TimimComplaintBoxId == id)).GetValueOrDefault();
        }
    }
}
