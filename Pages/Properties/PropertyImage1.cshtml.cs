using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TimimInnovation.Pages.Properties
{
    public class PropertyImage1Model : PageModel
    {
        [TempData]
        public string UploadedPropertyImage1 { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnGetSetImageUrl(string imageUrl)
        {
            UploadedPropertyImage1 = imageUrl;
            return new EmptyResult();
        }
    }
}
