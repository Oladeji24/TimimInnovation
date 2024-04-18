using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Admin.ComplaintBox
{
    public class IndexModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public IndexModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TimimComplaintBox> TimimComplaintBox { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TimimComplaintBoxes != null)
            {
                TimimComplaintBox = await _context.TimimComplaintBoxes.ToListAsync();
            }
        }
    }
}
