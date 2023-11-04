using DAL;
using LogicLayer.Manager;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WebApp.View_Model;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        public static readonly UserDAL userDAL = new UserDAL();
        public UserManager userManager = new UserManager(userDAL);

        [BindProperty]
        public UserLoginVM UserVM { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
                return HandleLogin();

            return new PageResult();
        }

        private IActionResult HandleLogin()
        {

            if (userManager.CheckLogin(UserVM.Username, UserVM.Password) == false)
                return Page();

            SetupSessionCookie(userManager.GetUserByUsername(UserVM.Username).Id);
            return new RedirectToPageResult("Index");
        }

        private void SetupSessionCookie(int id)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("id", id.ToString()));
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(new ClaimsPrincipal(claimIdentity));
        }
    }
}
