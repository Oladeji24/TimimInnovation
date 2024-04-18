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

namespace TimimInnovation.Pages.AgreedClient
{
    public class EditModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public EditModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClientTermAndCondition ClientTermAndCondition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ClientTermAndConditions == null)
            {
                return NotFound();
            }

            var clienttermandcondition =  await _context.ClientTermAndConditions.FirstOrDefaultAsync(m => m.ClientTermAndConditionId == id);
            if (clienttermandcondition == null)
            {
                return NotFound();
            }
            ClientTermAndCondition = clienttermandcondition;
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

            _context.Attach(ClientTermAndCondition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientTermAndConditionExists(ClientTermAndCondition.ClientTermAndConditionId))
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

        private bool ClientTermAndConditionExists(int id)
        {
          return (_context.ClientTermAndConditions?.Any(e => e.ClientTermAndConditionId == id)).GetValueOrDefault();
        }
    }
}
