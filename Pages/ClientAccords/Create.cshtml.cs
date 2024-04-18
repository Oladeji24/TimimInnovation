using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.ClientAccords
{
    public class CreateModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public CreateModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // Add this property for the ServiceType dropdown list
        public SelectList ServiceTypeList { get; set; }

        public IActionResult OnGet()
        {
            // Populate the ServiceTypeList with values from the ServiceType enum
            ServiceTypeList = new SelectList(Enum.GetValues(typeof(ClientConcord.ServiceType)));

            return Page();
        }

        [BindProperty]
        public ClientConcord ClientConcord { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.ClientConcords == null || ClientConcord == null)
            {
                return Page();
            }

            _context.ClientConcords.Add(ClientConcord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
