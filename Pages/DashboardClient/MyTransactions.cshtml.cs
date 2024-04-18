using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.DashboardClient
{
    [Authorize]
    public class MyTransactionsModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MyTransactionsModel(TimimInnovation.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<TimimTransaction> TimimTransaction { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                TimimTransaction = await _context.TimimTransactions
                    .Where(t => t.Username == currentUser.UserName)
                    .OrderByDescending(t => t.StartDate)
                    .ToListAsync();
            }
        }
    }
}
