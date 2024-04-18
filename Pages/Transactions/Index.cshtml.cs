using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Transactions
{
    public class IndexModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [BindProperty]
        public string ServiceType { get; set; }

        public bool IsServiceTypeSet => !string.IsNullOrEmpty(Request.Cookies["ServiceType"]);

        public IndexModel(TimimInnovation.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public TimimTransaction? LatestTimimTransaction { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.TimimTransactions != null)
            {
                LatestTimimTransaction = await _context.TimimTransactions
                    .OrderByDescending(t => t.CreatedDate)
                    .FirstOrDefaultAsync();
            }

            ServiceType = Request.Cookies["ServiceType"];
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(ServiceType))
            {
                Response.Cookies.Append("ServiceType", ServiceType);

                LatestTimimTransaction = await _context.TimimTransactions
                    .OrderByDescending(t => t.CreatedDate)
                    .FirstOrDefaultAsync();

                if (LatestTimimTransaction != null)
                {
                    Response.Cookies.Append("TransactionFirstname", LatestTimimTransaction.FirstName);
                    Response.Cookies.Append("TransactionLastname", LatestTimimTransaction.LastName);
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
