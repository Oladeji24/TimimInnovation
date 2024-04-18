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
    public class IndexModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public IndexModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TimimTransaction> TimimTransaction { get; set; } = default!;
        public List<string> Usernames { get; set; } = new List<string>();

        [BindProperty(SupportsGet = true)]
        public string SelectedUsername { get; set; }

        public async Task OnGetAsync()
        {
            // Retrieve unique usernames
            Usernames = await _context.TimimTransactions
                                      .Select(t => t.Username)
                                      .Distinct()
                                      .ToListAsync();

            if (!string.IsNullOrEmpty(SelectedUsername))
            {
                // Filter transactions by selected username
                TimimTransaction = await _context.TimimTransactions
                                                 .Where(t => t.Username == SelectedUsername)
                                                 .ToListAsync();
            }
            else
            {
                TimimTransaction = await _context.TimimTransactions.ToListAsync();
            }
        }
    }
}
