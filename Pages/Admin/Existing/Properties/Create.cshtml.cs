using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Admin.Existing.Properties
{
    public class CreateModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        // Enum SelectList Properties
        public SelectList PropertyTypes { get; set; } = default!;
        public SelectList TransactionPurposes { get; set; } = default!;
        public SelectList TransactionStatuses { get; set; } = default!;

        [TempData]
        public string UploadedPropertyImage1 { get; set; }

        public CreateModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Populate SelectList properties for enums
            PropertyTypes = new SelectList(Enum.GetValues(typeof(PropertyType)));
            TransactionPurposes = new SelectList(Enum.GetValues(typeof(TransactionPurpose)));
            TransactionStatuses = new SelectList(Enum.GetValues(typeof(TransactionStatus)));

            TimimBCProperties = new TimimBCProperties();  // Initialize the object

            // Set the username, generate codes, and set image URL
            TimimBCProperties.Username = User.Identity.Name;
            TimimBCProperties.PropertyCode = GenerateAlphanumericCode(12);
            TimimBCProperties.TransactionCode = GenerateAlphanumericCode(12);
            TimimBCProperties.PropertyImage1 = UploadedPropertyImage1;

            return Page();
        }

        [BindProperty]
        public TimimBCProperties TimimBCProperties { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.TimimProperties == null || TimimBCProperties == null)
            {
                return Page();
            }

            _context.TimimProperties.Add(TimimBCProperties);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private string GenerateAlphanumericCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
