using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.AgreedClient
{
    public class DetailsModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public DetailsModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public ClientTermAndCondition ClientTermAndCondition { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ClientTermAndConditions == null)
            {
                return NotFound();
            }

            var clienttermandcondition = await _context.ClientTermAndConditions.FirstOrDefaultAsync(m => m.ClientTermAndConditionId == id);
            if (clienttermandcondition == null)
            {
                return NotFound();
            }
            else 
            {
                ClientTermAndCondition = clienttermandcondition;
            }
            return Page();
        }
    }
}
