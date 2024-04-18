﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.TenantComplainStation
{
    public class IndexModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;

        public IndexModel(TimimInnovation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TenantComplain> TenantComplain { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TenantComplains != null)
            {
                TenantComplain = await _context.TenantComplains.ToListAsync();
            }
        }
    }
}
