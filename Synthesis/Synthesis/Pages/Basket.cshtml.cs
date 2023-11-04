using LogicLayer.Object;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Bcpg;
using System.Text.Json;
using WebApp.View_Model;

namespace WebApp.Pages
{
    [Authorize]
    public class BasketModel : PageModel
    {
        public List<ProductVM> Products { get; set; }
        public double Total { get; set; }

        private void LoadBasket()
        {
            Products = new List<ProductVM>();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("basket")))
                Products = JsonSerializer.Deserialize<List<ProductVM>>(HttpContext.Session.GetString("basket"));
        }

        private void UpdateTotal()
        {
            foreach (ProductVM p in Products)
            {
                Total += p.Quantity * p.Price;
            }
            Total = Math.Round(Total, 2);
        }

        public void OnGet()
        {
            LoadBasket();
            UpdateTotal();
        }

        public IActionResult OnPost()
        {
            LoadBasket();

            if (Products.Count != 0)
            {
                return RedirectToPage("/DeliveryOptions");
            }
            return Page();
        }

        public void OnPostMinus(int id)
        {
            LoadBasket();
            ProductVM product = Products.Find(x => x.Id == id);
            if (product.Quantity > 1)
            {
                product.Quantity--;
                UpdateTotal();
                HttpContext.Session.SetString("basket", JsonSerializer.Serialize(Products));
            }
        }

        public void OnPostPlus(int id)
        {
            LoadBasket();
            ProductVM product = Products.Find(x => x.Id == id);
            product.Quantity++;
            UpdateTotal();
            HttpContext.Session.SetString("basket", JsonSerializer.Serialize(Products));
        }

        public void OnPostDelete(int id)
        {
            LoadBasket();
            ProductVM product = Products.Find(x => x.Id == id);
            Products.Remove(product);
            UpdateTotal();
            HttpContext.Session.SetString("basket", JsonSerializer.Serialize(Products));
        }

    }
}
