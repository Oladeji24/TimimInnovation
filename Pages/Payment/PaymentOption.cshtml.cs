using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimimInnovation.Data;

namespace TimimInnovation.Pages.Payment
{
    public class PaymentOptionModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public PaymentOptionModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string CurrentUserName { get; private set; }

        public async Task<IActionResult> OnGet()
        {
            // Check if the user is authenticated
            if (_signInManager.IsSignedIn(User))
            {
                // Get the current user
                var user = await _userManager.GetUserAsync(User);

                // Display the username on the page
                CurrentUserName = user.UserName;

                // Check if the user is not already in the "Client" role
                if (!await _userManager.IsInRoleAsync(user, "Client"))
                {
                    // If not, assign the user to the "Client" role
                    await _userManager.AddToRoleAsync(user, "Client");
                }

                return Page();
            }
            else
            {
                // If the user is not authenticated, redirect to the login page
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }
    }
}
