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

namespace TimimInnovation.Pages.Transactions
{
    public class EditModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public EditModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TimimTransaction TimimTransaction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TimimTransactions == null)
            {
                return NotFound();
            }

            var timimtransaction =  await _context.TimimTransactions.FirstOrDefaultAsync(m => m.TransactionId == id);
            if (timimtransaction == null)
            {
                return NotFound();
            }
            TimimTransaction = timimtransaction;
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

            _context.Attach(TimimTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimimTransactionExists(TimimTransaction.TransactionId))
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

        private bool TimimTransactionExists(int id)
        {
          return (_context.TimimTransactions?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
