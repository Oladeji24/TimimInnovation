using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TimimInnovation.Pages.Properties
{
    public class PropertyImage2Model : PageModel
    {
        [TempData]
        public string UploadedPropertyImage2 { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnGetSetImageUrl(string imageUrl)
        {
            UploadedPropertyImage2 = imageUrl;
            return new EmptyResult();
        }
    }
}
