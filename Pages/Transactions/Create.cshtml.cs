using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Transactions
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

        [BindProperty(SupportsGet = true)]
        public string PropertyName { get; set; } = string.Empty; // New Property

        [BindProperty(SupportsGet = true)]
        public decimal Price { get; set; } // New Property

        public IActionResult OnGet()
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                TimimTransaction = new TimimTransaction(); // Initialize it
                TimimTransaction.Username = User.Identity.Name;
                TimimTransaction.TransactionCode = TransactionCode; // Set from URL parameter
                TimimTransaction.PropertyCode = PropertyCode;       // Set from URL parameter
                TimimTransaction.PropertyName = PropertyName;       // Set from URL parameter
                TimimTransaction.Price = Price;                     // Set from URL parameter

                // Combine the values and set to ReceiptNo
                TimimTransaction.ReceiptNo = $"{TransactionCode}-{PropertyCode}";
            }

            return Page();
        }

        [BindProperty]
        public TimimTransaction TimimTransaction { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.TimimTransactions == null || TimimTransaction == null)
            {
                return Page();
            }

            // Ensure ReceiptNo is set correctly before saving
            TimimTransaction.ReceiptNo = $"{TimimTransaction.TransactionCode}-{TimimTransaction.PropertyCode}";

            _context.TimimTransactions.Add(TimimTransaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Preview");
        }
    }
}
