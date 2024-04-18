using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Dashboards
{
    public class AgentDashboardModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public AgentDashboardModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TimimAgent> TimimAgent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TimimAgents != null)
            {
                TimimAgent = await _context.TimimAgents.ToListAsync();
            }
        }
    }
}
