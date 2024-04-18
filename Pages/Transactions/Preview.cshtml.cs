// PreviewModel.cshtml.cs

using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Transactions
{
    public class PreviewModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public PreviewModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TimimTransaction LastTransaction { get; set; }

        public void OnGet()
        {
            LastTransaction = _context.TimimTransactions
                .OrderByDescending(t => t.TransactionId)
                .FirstOrDefault();
        }
    }
}
