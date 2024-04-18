using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TimimInnovation.Pages.PropertyConnect
{
    public class GetAgentPersonnelCodeModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public GetAgentPersonnelCodeModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public string UserAgentCode { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await EnsureUserDataInCookiesAsync();

            UserEmail = Request.Cookies["UserEmail"];
            UserAgentCode = Request.Cookies["UserCode"];

            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                bool hasRole = await _userManager.IsInRoleAsync(user, "Propertyloader");

                if (!hasRole)
                {
                    await _userManager.AddToRoleAsync(user, "Propertyloader");
                }

                UserRole = "Propertyloader";
            }

            return Page();
        }

        private async Task EnsureUserDataInCookiesAsync()
        {
            UserEmail = Request.Cookies["UserEmail"];
            UserAgentCode = Request.Cookies["UserCode"];

            if (string.IsNullOrEmpty(UserEmail) || string.IsNullOrEmpty(UserAgentCode))
            {
                var user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    UserEmail = user.Email;

                    // Check if the user has a code in the cookies
                    if (string.IsNullOrEmpty(UserAgentCode))
                    {
                        UserAgentCode = GenerateAlphanumericCode(12);
                        // Set cookies for user email and user code
                        Response.Cookies.Append("UserEmail", UserEmail, new CookieOptions { Expires = DateTime.Now.AddYears(1) });
                        Response.Cookies.Append("UserCode", UserAgentCode, new CookieOptions { Expires = DateTime.Now.AddYears(1) });
                    }
                }
            }
        }

        private string GenerateAlphanumericCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
