using DAL;
using LogicLayer.Manager;
using LogicLayer.Object;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text.Json;
using WebApp.View_Model;

namespace WebApp.Pages
{
    [Authorize]
    public class PickupModel : PageModel
    {
        private static readonly OrderDAL orderDAL = new OrderDAL();
        private OrderManager orderManager = new OrderManager(orderDAL);
        private static readonly UserDAL userDAL = new UserDAL();
        private UserManager userManager = new UserManager(userDAL);
        private static readonly PickupDAL pickupDAL = new PickupDAL();
        private PickupManager pickupManager = new PickupManager(pickupDAL);

        [BindProperty]
        public List<Pickup> Pickups { get; set; }

        [BindProperty, Required, DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [BindProperty]
        public int Hour { get; set; }

        [BindProperty]
        public int Minutes { get; set; }

        public List<ProductVM> ProductsVM { get; set; }

        [BindProperty]
        public int PickupId { get; set; }

        public PickupModel()
        {
            Pickups = new List<Pickup>();
            ProductsVM = new List<ProductVM>();
        }

        public void OnGet()
        {
            Pickups.Clear();
            Pickups = pickupManager.GetPickupLocations();
        }

        public IActionResult OnPost()
        {
            if (orderManager.GetOrderDatesPickup(OrderDate) == false)
                return Page();

            if (OrderDate.Ticks < DateTime.Now.Ticks)
                return Page();

            Pickup pickup = pickupManager.GetPickupById(PickupId);

            if (pickup == null)
            {
                return Page();
            }

            int userId = Convert.ToInt32(User.FindFirst("id").Value);
            DateTime deliveryDate = new DateTime(OrderDate.Year, OrderDate.Month, OrderDate.Day, Hour, Minutes, 0);

            Order order = new Order(userManager.GetUserById(userId) , pickup, deliveryDate);

            ProductsVM = new List<ProductVM>();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("basket")))
                ProductsVM = JsonSerializer.Deserialize<List<ProductVM>>(HttpContext.Session.GetString("basket"));

            if (ProductsVM.Count > 0)
            {
                foreach (ProductVM p in ProductsVM)
                    order.AddItemToBasket(new Product(p.Id, p.Name, p.Price, p.Unit, p.Description, p.Image, p.Category, p.Active), p.Quantity);

                orderManager.CreateOrder(order);
                return RedirectToPage("/OrderPlaced");
            }
            return Page();
        }
    }
}
