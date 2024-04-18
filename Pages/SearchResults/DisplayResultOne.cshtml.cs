using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Models;
using System.Collections.Generic;

namespace TimimInnovation.Pages.SearchResults
{
    public class DisplayResultOneModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DisplayResultOneModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TimimBCProperties> TimimProperties { get; set; } = new List<TimimBCProperties>();

        public async Task OnGetAsync()
        {
            // 1. Get values from session
            string? propertyType = HttpContext.Session.GetString("PropertyType");
            string? location = HttpContext.Session.GetString("Location");
            string? searchKeyword = HttpContext.Session.GetString("SearchKeyword");

            bool isCriteriaProvided = !string.IsNullOrEmpty(propertyType)
                            || !string.IsNullOrEmpty(location)
                            || !string.IsNullOrEmpty(searchKeyword);

            if (!isCriteriaProvided)
            {
                // If no criteria provided, return an empty list without querying the database.
                return;
            }

            var query = _context.TimimProperties.AsQueryable();

            if (!string.IsNullOrEmpty(propertyType))
            {
                if (Enum.TryParse(propertyType, out PropertyType type))
                {
                    query = query.Where(p => p.PropertyType == type);
                }
            }

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(p => p.State.Contains(location));
            }

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                query = query.Where(p => p.PropertyName.Contains(searchKeyword)
                                      || p.Street.Contains(searchKeyword)
                                      || p.City.Contains(searchKeyword)
                                      || p.Description.Contains(searchKeyword));
            }

            TimimProperties = await query.ToListAsync();
        }
    }
}
