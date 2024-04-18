using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace TimimInnovation.Pages.PropertyConnect
{
    public class RegisterPropertyModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterPropertyModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public string Greeting { get; private set; }

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _userManager.GetUserAsync(User).Result;

                if (user != null)
                {
                    // Greet the user
                    Greeting = $"Hi, {user.UserName}!";
                }
            }
            else
            {
                // User is not authenticated, handle accordingly
                Greeting = "Welcome!";
            }
        }

        public async Task<IActionResult> OnPostAsync(string role)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    // Assign roles based on button click
                    switch (role)
                    {
                        case "PropertyOwner":
                            await _userManager.AddToRoleAsync(user, "Property-Owner");
                            break;
                        case "PropertyAgent":
                            await _userManager.AddToRoleAsync(user, "Agent");
                            break;
                    }

                    return RedirectToPage("/PropertyConnect/RegisterPersonnel");
                }
            }

            // Handle authentication failure or other issues
            return RedirectToPage("/Error");
        }
    }
}
