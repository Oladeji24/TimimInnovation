using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using TimimInnovation.Models;

namespace TimimInnovation.Pages.AgreedClient
{
    public class CreateModel : PageModel
    {
        private readonly TimimInnovation.Data.ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(TimimInnovation.Data.ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Initialize new instance
            ClientTermAndCondition = new ClientTermAndCondition
            {
                ClientTermAndConditionUsername = _userManager.GetUserName(User) ?? "Unknown",
                ClientTermAndConditionFirstName = _httpContextAccessor.HttpContext.Session.GetString("TransactionFirstname") ?? "Unknown",
                ClientTermAndConditionLastname = _httpContextAccessor.HttpContext.Session.GetString("TransactionLastname") ?? "Unknown",
                ClientTermAndConditionDecision = "Agreed",
                SignDate = DateTime.Now,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _context.ClientTermAndConditions.Add(ClientTermAndCondition);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Payment/PaymentOption");
        }

        [BindProperty]
        public ClientTermAndCondition ClientTermAndCondition { get; set; } = default!;
    }
}
