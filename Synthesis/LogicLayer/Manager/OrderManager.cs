using LogicLayer.Interface;
using LogicLayer.Object;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Manager
{
    public class OrderManager
    {
        private IOrderDAL iorder;

        public OrderManager(IOrderDAL iorder)
        {
            this.iorder = iorder;
        }

        public bool CreateOrder(Order order)
        {
            if (order.Basket == null || order.Basket.Count == 0)
                return false;
            if (order.Adress == null && order.Pickup == null)
                return false;
            if (order.User == null)
                return false;
            if (order.Date < DateTime.Now)
                return false;

            try
            {
                iorder.CreateOrder(order);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
         }

        public bool UpdateOrderStatus(int orderId, Status status)
        {
            if (orderId <= 0)
                return false;

            try
            {
                return iorder.UpdateOrderStatus(orderId, status);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Order> GetOrders(int userId)
        {
            if (userId <= 0)
                return null;

            try
            {
                return iorder.GetOrders(userId);
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<Order> GetAllOrders()
        {
            try
            {
                return iorder.GetAllOrders();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Order GetOrderById(int orderId)
        {
            if (orderId <= 0)
                return null;

            try
            {
                return iorder.GetOrderById(orderId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<OrderRecord> GetProductsOfOrder(int orderId)
        {
            if (orderId <= 0)
                return null;

            try
            {
                return iorder.GetProductsOfOrder(orderId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool GetOrderDatesAddress(DateTime orderDate)
        {
            if (orderDate < DateTime.Now)
                return false;

            try
            {
                int count = iorder.GetOrderDatesAddress(orderDate);
                if (count < 5)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool GetOrderDatesPickup(DateTime orderDate)
        {
            if (orderDate < DateTime.Now)
                return false;

            try
            {
                int count = iorder.GetOrderDatesPickup(orderDate);
                if (count < 10)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
