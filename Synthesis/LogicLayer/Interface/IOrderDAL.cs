using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interface
{
    public interface IOrderDAL
    {
        void CreateOrder(Order order);

        bool UpdateOrderStatus(int orderId, Status status);

        List<Order> GetOrders(int UserId);
        
        List<Order> GetAllOrders();

        Order GetOrderById(int orderId);

        List<OrderRecord> GetProductsOfOrder(int orderId);

        int GetOrderDatesAddress(DateTime orderDate);

        int GetOrderDatesPickup(DateTime orderDate);
    }
}
