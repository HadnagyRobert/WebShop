using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    [Authorize]
    public class PersonalInfoModel : PageModel
    {
        public void OnGet()
        {
        
        }

        public IActionResult OnPost()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}
