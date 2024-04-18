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

namespace TimimInnovation.Pages.ClientAccords
{
    public class IndexModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        // Initialized in the constructor to ensure it's never null
        public IList<ClientConcord> ClientConcord { get; set; }

        public IndexModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
            ClientConcord = new List<ClientConcord>();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var serviceTypeStr = HttpContext.Session.GetString("ServiceType");

            // Check if the context and service type string are not null
            if (_context.ClientConcords != null && !string.IsNullOrEmpty(serviceTypeStr))
            {
                // Try parsing the service type string to the enumeration
                if (Enum.TryParse(serviceTypeStr, out ClientConcord.ServiceType parsedServiceType))
                {
                    // Filter the records based on the parsed service type
                    ClientConcord = await _context.ClientConcords
                        .Where(x => x.ClientConcordServiceType == parsedServiceType)
                        .ToListAsync();
                }
            }

            return Page();
        }

        public IActionResult OnPostAccept()
        {
            // Logic to proceed to the next page or perform an action when accepted
            return RedirectToPage("/AgreedClient/Create"); // Replace with the correct path
        }

        public IActionResult OnPostDecline()
        {
            // Logic to redirect to home page or any other action when declined
            return RedirectToPage("/Index"); // Replace with the path to your home page or any other desired page
        }
    }
}
