using LogicLayer.Interface;
using LogicLayer.Object;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.DAL
{
    public class MockOrderDAL : IOrderDAL
    {
        private List<Order> orders;
        private int i = 1;
        private List<OrderRecord> basket;
        private byte[] basketBytes;
        private Status status = Status.Placed;
        private Address address = new Address(1, "a", "a", "a", "a", 1);
        private Pickup pickup = new Pickup(1, "a", "a", "a", "a", 1);
        private User user = new User(1, "bob1", "123", "abc", "user", "bob1@gmail.com", "bob", "1");
        private DateTime dateTime = DateTime.Now.AddDays(1);


        public MockOrderDAL()
        {
            basket = new List<OrderRecord>()
            {
                new OrderRecord(new Product(1,"orange",101.01,"1pcs","none",basketBytes,new Category(1,"orange",2),true),1),
                new OrderRecord(new Product(2,"oranges",101.01,"1pcs","none",basketBytes,new Category(1,"orange",2),true),2)
            };
            orders = new List<Order>()
            {
                new Order(i++,user,basket,status,address,dateTime),
                new Order(i++,user,basket,status,address,dateTime),
                new Order(i++,user,basket,status,address,dateTime),
                new Order(i++,user,basket,status,address,dateTime),
                new Order(i++,user,basket,status,address,dateTime),
                new Order(i++,user,basket,status,pickup,dateTime.AddDays(-1))
            };
            foreach(Order o in orders)
            {
                if(o.Adress == address)
                    o.Pickup = null;
            }
        }
        public void CreateOrder(Order order)
        {
            orders.Add(order);
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }

        public Order GetOrderById(int orderId)
        {
            foreach(Order o in orders)
                if(o.Id == orderId)
                    return o;
            return null;
        }

        public int GetOrderDatesAddress(DateTime orderDate)
        {
            int i =0;
            foreach (Order o in orders)
                if (o.Date == orderDate && o.Pickup == null)
                    i++;
            return i;
        }

        public int GetOrderDatesPickup(DateTime orderDate)
        {
            int i = 0;
            foreach (Order o in orders)
                if (o.Date == orderDate && o.Adress == null)
                    i++;
            return i;
        }

        public List<Order> GetOrders(int UserId)
        {
            List<Order> orderList = new List<Order>();
            foreach (Order o in orders)
                if(o.User.Id == UserId)
                    orderList.Add(o);
            return orderList;
        }

        public List<OrderRecord> GetProductsOfOrder(int orderId)
        {
            List < OrderRecord > recordList= new List<OrderRecord>();
            foreach (Order o in orders)
                if (o.Id == orderId)
                    foreach(OrderRecord b in basket)
                        recordList.Add(b);
            return recordList;
        }

        public bool UpdateOrderStatus(int orderId, Status status)
        {
            foreach (Order o in orders)
                if (o.Id == orderId)
                {
                    o.Status = status;
                    return true;
                }
            return false;
        }
    }
}
