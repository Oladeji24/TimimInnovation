using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Transaction
{
    public class CreateModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public CreateModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string TransactionCode { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string PropertyCode { get; set; } = string.Empty;

        public IActionResult OnGet()
        {
            // The properties TransactionCode and PropertyCode will be automatically 
            // populated from the route/query parameters because of the [BindProperty(SupportsGet = true)] attribute.

            // Check if user is authenticated and set username
            if (User?.Identity?.IsAuthenticated == true)
            {
                TimimTransaction.Username = User.Identity.Name;
            }

            return Page();
        }

        [BindProperty]
        public TimimTransaction TimimTransaction { get; set; } = new TimimTransaction();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TimimTransactions.Add(TimimTransaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
