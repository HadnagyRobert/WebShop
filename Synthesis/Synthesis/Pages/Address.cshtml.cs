using DAL;
using LogicLayer.Manager;
using LogicLayer.Object;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using WebApp.View_Model;

namespace WebApp.Pages
{
    [Authorize]
    public class AddressModel : PageModel
    {
        private static readonly OrderDAL orderDAL = new OrderDAL();
        private OrderManager orderManager = new OrderManager(orderDAL);
        private static readonly UserDAL userDAL = new UserDAL();
        private UserManager userManager = new UserManager(userDAL);
        private static readonly AddressDAL addressDAL = new AddressDAL();
        private AddressManager addressManager = new AddressManager(addressDAL);

        [BindProperty]
        public AddressVM AddressVM { get; set; }

        [BindProperty, Required, DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [BindProperty]
        public int Hour { get; set; }

        [BindProperty]
        public int Minutes { get; set; }

        public List<ProductVM> ProductsVM { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            DateTime deliveryDate = new DateTime(OrderDate.Year, OrderDate.Month, OrderDate.Day, Hour, Minutes, 0);

            if (orderManager.GetOrderDatesAddress(deliveryDate) == false)
                return RedirectToPage("/OrderFailed");

            if (OrderDate.Ticks < DateTime.Now.Ticks)
                return RedirectToPage("/OrderFailed");

            Address address = addressManager.CreateAddress(new Address(AddressVM.Country, AddressVM.City, AddressVM.PostalCode, AddressVM.Street, AddressVM.Number));

            if (address == null)
                return Page();

            int userId = Convert.ToInt32(User.FindFirst("id").Value);

            Order order = new Order(userManager.GetUserById(userId), address, deliveryDate);

            ProductsVM = new List<ProductVM>();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("basket")))
                ProductsVM = JsonSerializer.Deserialize<List<ProductVM>>(HttpContext.Session.GetString("basket"));

            if (ProductsVM.Count > 0)
            {
                foreach (ProductVM p in ProductsVM)
                    order.AddItemToBasket(new Product(p.Id, p.Name, p.Price, p.Unit, p.Description, p.Image, p.Category, p.Active), p.Quantity);

                if(orderManager.CreateOrder(order));
                    return RedirectToPage("/OrderPlaced");
            }
            return RedirectToPage("/OrderFailed");
        }
    }
}
