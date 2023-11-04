using DAL;
using LogicLayer.Manager;
using LogicLayer.Object;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Bcpg;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using WebApp.View_Model;

namespace WebApp.Pages
{
    [Authorize]
    public class OrderPlacedModel : PageModel
    {
        public List<ProductVM> ProductsVM { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            ProductsVM = new List<ProductVM>();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("basket")))
                ProductsVM = JsonSerializer.Deserialize<List<ProductVM>>(HttpContext.Session.GetString("basket"));
            ProductsVM.Clear();
            HttpContext.Session.SetString("basket", JsonSerializer.Serialize(ProductsVM));
            return RedirectToPage("/Index");
        }
    }
}
