using DAL;
using LogicLayer.Manager;
using LogicLayer.Object;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WebApp.Pages
{
    [Authorize]
    public class PastOrdersModel : PageModel
    {
        private static readonly OrderDAL orderDAL = new OrderDAL();
        private OrderManager orderManager = new OrderManager(orderDAL);

        [BindProperty]
        public List<Order> Orders { get; set; }
        [BindProperty]
        public Order Order { get; set; }
        [BindProperty]
        public int OrderId { get; set; }
        public double Total { get; set; }

        public void OnGet()
        {
            Orders = new List<Order>();
            Orders = orderManager.GetOrders(Convert.ToInt32(User.FindFirst("id").Value));
        }

        public void OnPost()
        {
            Order = orderManager.GetOrderById(OrderId);
            Order.Basket = orderManager.GetProductsOfOrder(OrderId);
            foreach (OrderRecord b in Order.Basket)
                Total += b.Price * b.Quantity;
            Total = Math.Round(Total, 2);
            OnGet();
        }
    }
}
