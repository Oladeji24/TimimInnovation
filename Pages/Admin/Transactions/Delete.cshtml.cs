using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Admin.Transactions
{
    public class DeleteModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DeleteModel(TimimInnovation.Data.ApplicationDbContext context)
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

            var timimtransaction = await _context.TimimTransactions.FirstOrDefaultAsync(m => m.TransactionId == id);

            if (timimtransaction == null)
            {
                return NotFound();
            }
            else 
            {
                TimimTransaction = timimtransaction;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TimimTransactions == null)
            {
                return NotFound();
            }
            var timimtransaction = await _context.TimimTransactions.FindAsync(id);

            if (timimtransaction != null)
            {
                TimimTransaction = timimtransaction;
                _context.TimimTransactions.Remove(TimimTransaction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
