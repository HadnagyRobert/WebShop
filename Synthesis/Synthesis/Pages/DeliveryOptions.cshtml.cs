using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    [Authorize]
    public class DeliveryOptionsModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}
