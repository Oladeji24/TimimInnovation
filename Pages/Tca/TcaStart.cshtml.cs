using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TimimInnovation.Pages.Tca
{
    [Authorize]
    public class TcaStartModel : PageModel
    {
        public string CurrentUserName { get; set; }

        public void OnGet()
        {
            CurrentUserName = User.FindFirstValue(ClaimTypes.Name);
        }

        public IActionResult OnPost(string continentDropdown, string countryDropdown, string stateOrRegionDropdown, string firstname, string lastname)
        {
            // Store the values in session
            HttpContext.Session.SetString("selectedContinent", continentDropdown ?? "none");
            HttpContext.Session.SetString("selectedCountry", countryDropdown ?? "none");
            HttpContext.Session.SetString("selectedStateOrRegion", stateOrRegionDropdown ?? "none");
            HttpContext.Session.SetString("firstname", firstname ?? "none");
            HttpContext.Session.SetString("lastname", lastname ?? "none");

            // Redirect to Me Razor page in the Accords folder
            return RedirectToPage("/Accords/Index");
        }
    }
}
