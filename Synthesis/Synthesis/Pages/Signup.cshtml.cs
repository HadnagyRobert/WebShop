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
    public class SignupModel : PageModel
    {

        private static readonly UserDAL userDAL = new UserDAL();
        private UserManager userManager = new UserManager(userDAL);

        [BindProperty]
        public UserSignupVM UserVM { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPostAsync()
        {
            if (ModelState.IsValid)
                return HandleSignUp();

            return new PageResult();
        }

        private IActionResult HandleSignUp()
        {
            if (userManager.CreateUser(UserVM.Username, UserVM.Password, UserVM.Email, UserVM.FirstName, UserVM.LastName) == false)
                return RedirectToPage("/UsernameTaken");

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
