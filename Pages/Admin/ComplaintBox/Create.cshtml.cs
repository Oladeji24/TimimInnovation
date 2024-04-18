using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Admin.ComplaintBox
{
    public class CreateModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public CreateModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TimimComplaintBox TimimComplaintBox { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TimimComplaintBoxes == null || TimimComplaintBox == null)
            {
                return Page();
            }

            _context.TimimComplaintBoxes.Add(TimimComplaintBox);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
