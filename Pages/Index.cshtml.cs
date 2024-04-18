using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TimimInnovation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public string SearchKeyword { get; set; }

        [BindProperty]
        public string PropertyType { get; set; }

        [BindProperty]
        public string Location { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid) // Check if the model state is valid
            {
                // Store data in session
                HttpContext.Session.SetString("SearchKeyword", SearchKeyword ?? string.Empty);
                HttpContext.Session.SetString("PropertyType", PropertyType ?? string.Empty);
                HttpContext.Session.SetString("Location", Location ?? string.Empty);

                // Optional: Log any other information if required
                _logger.LogInformation($"Search initiated for keyword: {SearchKeyword}");

                // Redirect to the DisplayResultOne page to display results
                return RedirectToPage("/SearchResults/DisplayResultOne");
            }

            return Page(); // If model state is invalid, just return the current page
        }
    }
}
