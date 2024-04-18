using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Admin.Search.Properties
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

        public IList<TimimBCProperties> TimimBCProperties { get; set; } = new List<TimimBCProperties>();

        public async Task OnGetAsync()
        {
            // Load all properties into memory (may be inefficient for larger datasets)
            var allProperties = await _context.TimimProperties.ToListAsync();

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                // Filter the loaded data in-memory by NIN or email
                TimimBCProperties = allProperties.Where(p =>
                    p.NIN.Contains(SearchQuery) ||
                    p.ContactEmail.Contains(SearchQuery)
                ).ToList();
            }
            else
            {
                TimimBCProperties = allProperties;
            }
        }
    }
}
