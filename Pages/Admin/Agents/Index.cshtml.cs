using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Admin.Agents
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
            TimimAgent = new List<TimimAgent>();
        }

        // This property will hold the list of agents from the database.
        public IList<TimimAgent> TimimAgent { get; set; }

        // This property will fetch the distinct agency names for the dropdown.
        public IList<string> AgencyNames => _context.TimimAgents.Select(t => t.AgencyName).Distinct().ToList();

        // This property will hold the selected agency name from the dropdown.
        [BindProperty(SupportsGet = true)]
        public string SelectedAgencyName { get; set; } = string.Empty;

        // This method will be called when the page loads.
        public async Task OnGetAsync()
        {
            IQueryable<TimimAgent> query = _context.TimimAgents;

            if (!string.IsNullOrEmpty(SelectedAgencyName))
            {
                query = query.Where(t => t.AgencyName == SelectedAgencyName);
            }

            TimimAgent = await query.ToListAsync();
        }
    }
}
