using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimimInnovation.Data;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.Agent
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TimimAgent TimimAgent { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.TimimAgents == null || TimimAgent == null)
            {
                return Page();
            }

            // Assign the Username of TimimAgent to the current user's username.
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                TimimAgent.Username = currentUser.UserName;
            }

            // Automatically set the CreatedDate and UpdatedDate.
            TimimAgent.CreatedDate = DateTime.Now;
            TimimAgent.UpdatedDate = DateTime.Now;

            _context.TimimAgents.Add(TimimAgent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
