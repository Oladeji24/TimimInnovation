using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.SearchResults
{
    public class PropertyCategoryModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public PropertyCategoryModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string PropertyTypeString { get; set; } = string.Empty;

        public IList<TimimBCProperties> TimimProperties { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Assigning the value from the request query to the PropertyTypeString
            PropertyTypeString = Request.Query["propertyType"].ToString();

            if (!string.IsNullOrEmpty(PropertyTypeString)
                && Enum.TryParse<PropertyType>(PropertyTypeString, out var propertyTypeEnum))
            {
                TimimProperties = await _context.TimimProperties
                                              .Where(p => p.PropertyType == propertyTypeEnum)
                                              .ToListAsync();
            }
            else
            {
                // If PropertyTypeString is invalid or empty, fetch all properties
                TimimProperties = await _context.TimimProperties.ToListAsync();
            }
        }
    }
}
