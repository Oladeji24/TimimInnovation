using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.DashboardClient
{
    public class MyProfileModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public MyProfileModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TimimTransaction> TimimTransaction { get; set; } = new List<TimimTransaction>();

        public async Task OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var username = User.Identity.Name;
                TimimTransaction = await _context.TimimTransactions
                    .Where(t => t.Username == username)
                    .ToListAsync();
            }
        }
    }
}
