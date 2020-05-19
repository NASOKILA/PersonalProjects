using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp1.Pages
{
    [Authorize(Policy = "Man")]
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}