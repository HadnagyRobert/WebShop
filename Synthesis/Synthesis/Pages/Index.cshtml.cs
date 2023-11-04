using DAL;
using LogicLayer.Manager;
using LogicLayer.Object;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text.Json;
using WebApp.View_Model;

namespace Synthesis.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private static readonly ProductDAL productDAL = new ProductDAL();
        private ProductManager productManager = new ProductManager(productDAL);
        public List<Product> Products { get; set; }
        public List<ProductVM> Basket { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Products = new List<Product>();
            Basket = new List<ProductVM>();
        }

        public void OnGet()
        {
            Products.Clear();
            Products = productManager.GetAllActiveProducts();
        }

        public void OnPost(string pName)
        {
            Product p = productManager.GetProductByName(pName);

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("basket")))
                Basket = JsonSerializer.Deserialize<List<ProductVM>>(HttpContext.Session.GetString("basket"));

            ProductVM product = Basket.Find(x => x.Id == p.Id);

            if (product == null)
            {
                Basket.Add(new ProductVM(p.Id, p.Name, p.Price, p.Unit, p.Description, p.Image, p.Category, p.Active, 1));
                HttpContext.Session.SetString("basket", JsonSerializer.Serialize(Basket));
            }
            else
            {
                product.Quantity++;
                HttpContext.Session.SetString("basket", JsonSerializer.Serialize(Basket));
            }

            OnGet();
        }
    }
}