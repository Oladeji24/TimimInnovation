using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Admin.Search.Transactions
{
    public class IndexModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public IndexModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; } = string.Empty;

        public IList<TimimTransaction> TimimTransaction { get; set; } = default!;

        public async Task OnGetAsync()
        {
            IQueryable<TimimTransaction> query = _context.TimimTransactions;

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                query = query.Where(t => t.Email.Contains(SearchQuery) ||
                                         t.NIN.Contains(SearchQuery));
                // Remove other search criteria that you don't want (e.g., t.TransactionCode)
            }

            TimimTransaction = await query.ToListAsync();
        }
    }
}
