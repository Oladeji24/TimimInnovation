using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;
using Microsoft.AspNetCore.Http;

namespace TimimInnovation.Pages.Accords
{
    public class IndexModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public IndexModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Concord> Concord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var selectedCountry = HttpContext.Session.GetString("selectedCountry");
            var selectedStateOrRegion = HttpContext.Session.GetString("selectedStateOrRegion");

            var query = _context.Concords.AsQueryable();

            // Filter the records based on session values
            if (!string.IsNullOrEmpty(selectedCountry))
            {
                query = query.Where(x => x.ConcordCountry == selectedCountry);
            }

            if (!string.IsNullOrEmpty(selectedStateOrRegion))
            {
                query = query.Where(x => x.ConcordState == selectedStateOrRegion);
            }

            if (_context.Concords != null)
            {
                Concord = await query.ToListAsync();
            }

            return Page();
        }

        public IActionResult OnPostAccept()
        {
            // Logic to proceed to the service page
            return RedirectToPage("/Agreement/Create"); // replace with the correct path
        }

        public IActionResult OnPostDecline()
        {
            // Logic to redirect to home page
            return RedirectToPage("/Index"); // replace with the path to your home page
        }
    }
}
