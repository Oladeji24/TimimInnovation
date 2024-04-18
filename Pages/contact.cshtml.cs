using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimimInnovation.Email;

namespace TimimInnovation.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IEmailSender _emailSender;

        public ContactModel(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Subject { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validate and process the form data

            // Send email using the injected email sender
            await _emailSender.SendEmailAsync("info@timimbackgroundcheck.com", $"Contact Form Submission - {Subject}", $"Name: {Name}\nEmail: {Email}\nSubject: {Subject}\nMessage: {Message}");

            // Redirect or return a response as needed
            return RedirectToPage("/ThankYou");
        }
    }
}
