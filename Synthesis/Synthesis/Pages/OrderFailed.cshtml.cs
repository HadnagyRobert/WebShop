using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    [Authorize]
    public class OrderFailedModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            return RedirectToPage("/DeliveryOptions");
        }

    }
}
