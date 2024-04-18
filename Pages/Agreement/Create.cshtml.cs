using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimimInnovation.Data;
using TimimInnovation.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TimimInnovation.Pages.Agreement
{
    public class CreateModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public CreateModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (TermAndCondition == null)
            {
                TermAndCondition = new TermAndCondition();
            }

            // Fetch the current username
            var currentUsername = User.FindFirstValue(ClaimTypes.Name);

            // Set default values
            TermAndCondition.ClientUsername = currentUsername;
            TermAndCondition.ClientFirstName = HttpContext.Session.GetString("firstname");
            TermAndCondition.ClientLastName = HttpContext.Session.GetString("lastname");
            TermAndCondition.Continent = HttpContext.Session.GetString("selectedContinent");
            TermAndCondition.Country = HttpContext.Session.GetString("selectedCountry");
            TermAndCondition.CountryState = HttpContext.Session.GetString("selectedStateOrRegion");
            TermAndCondition.Agreement = true;
            TermAndCondition.SignDate = DateTime.Now;
            TermAndCondition.CreatedDate = DateTime.Now;
            TermAndCondition.ModifiedDate = DateTime.Now;
            TermAndCondition.TermAndConditionText = "Agreed";

            _context.TermAndConditions.Add(TermAndCondition);
            await _context.SaveChangesAsync();

            return RedirectToPage("/PropertyConnect/RegisterProperty");
        }

        [BindProperty]
        public TermAndCondition TermAndCondition { get; set; } = default!;
    }
}
