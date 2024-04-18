using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Admin.Properties
{
    public class IndexModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public IndexModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TimimBCProperties> TimimBCProperties { get; set; } = default!;
        public List<string> NINs { get; set; } = new List<string>();
        [BindProperty(SupportsGet = true)]
        public string SelectedNIN { get; set; }

        public async Task OnGetAsync()
        {
            // Retrieve unique NINs
            NINs = await _context.TimimProperties
                                  .Select(p => p.NIN)
                                  .Distinct()
                                  .ToListAsync();

            if (!string.IsNullOrEmpty(SelectedNIN))
            {
                // Filter properties by selected NIN
                TimimBCProperties = await _context.TimimProperties
                                                  .Where(p => p.NIN == SelectedNIN)
                                                  .ToListAsync();
            }
            else
            {
                TimimBCProperties = await _context.TimimProperties.ToListAsync();
            }
        }
    }
}
