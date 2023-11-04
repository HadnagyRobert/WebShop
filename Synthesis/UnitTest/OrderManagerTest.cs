using LogicLayer.Manager;
using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.DAL;

namespace UnitTest
{
    [TestClass]
    public class OrderManagerTest
    {
        [TestMethod]
        public void CreateOrderAddress()
        {
            byte[] data = null;
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);
            List<OrderRecord> orderRecords = new List<OrderRecord>()
            {
                new OrderRecord(new Product(1,"a",10,"a","a",data,new Category(1,"a",2),true),1)
            };

            Order order = new Order(1,new User("a", "a", "a", "a", "a", "a"),orderRecords,Status.Delivered, new Address("a", "a", "a", "a", 1), DateTime.Now.AddDays(1));

            bool result = orderManager.CreateOrder(order);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateOrderPickup()
        {
            byte[] data = null;
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);
            List<OrderRecord> orderRecords = new List<OrderRecord>()
            {
                new OrderRecord(new Product(1,"a",10,"a","a",data,new Category(1,"a",2),true),1)
            };

            Order order = new Order(1, new User("a", "a", "a", "a", "a", "a"), orderRecords, Status.Delivered, new Pickup(1,"a", "a", "a", "a", 1), DateTime.Now.AddDays(1));

            bool result = orderManager.CreateOrder(order);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateOrderAddressNull()
        {
            byte[] data = null;
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);
            List<OrderRecord> orderRecords = new List<OrderRecord>()
            {
                new OrderRecord(new Product(1,"a",10,"a","a",data,new Category(1,"a",2),true),1)
            };

            Order order = new Order(1, new User("a", "a", "a", "a", "a", "a"), orderRecords, Status.Delivered, new Address("a", "a", "a", "a", 1), DateTime.Now.AddDays(1));
            order.Adress = null;

            bool result = orderManager.CreateOrder(order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateOrderPickupNull()
        {
            byte[] data = null;
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);
            List<OrderRecord> orderRecords = new List<OrderRecord>()
            {
                new OrderRecord(new Product(1,"a",10,"a","a",data,new Category(1,"a",2),true),1)
            };

            Order order = new Order(1, new User("a", "a", "a", "a", "a", "a"), orderRecords, Status.Delivered, new Pickup(1, "a", "a", "a", "a", 1), DateTime.Now.AddDays(1));
            order.Pickup = null;

            bool result = orderManager.CreateOrder(order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateOrderEmptyBasket()
        {
            byte[] data = null;
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);
            List<OrderRecord> orderRecords = new List<OrderRecord>();

            Order order = new Order(1, new User("a", "a", "a", "a", "a", "a"), orderRecords, Status.Delivered, new Address("a", "a", "a", "a", 1), DateTime.Now.AddDays(1));

            bool result = orderManager.CreateOrder(order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateOrderWrongDate()
        {
            byte[] data = null;
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);
            List<OrderRecord> orderRecords = new List<OrderRecord>();

            Order order = new Order(1, new User("a", "a", "a", "a", "a", "a"), orderRecords, Status.Delivered, new Address("a", "a", "a", "a", 1), DateTime.Now.AddDays(-1));

            bool result = orderManager.CreateOrder(order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateOrderStatus()
        {
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);

            bool result = orderManager.UpdateOrderStatus(1, Status.Delivering);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateOrderStatusWrongId()
        {
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);

            bool result = orderManager.UpdateOrderStatus(0, Status.Delivering);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetOrders()
        {
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);

            List<Order> orders = mockOrderDAL.GetOrders(1);
            List<Order> orders1 = orderManager.GetOrders(1);

            Assert.IsNotNull(orders);
            CollectionAssert.AreEquivalent(orders, orders1);
        }

        [TestMethod]
        public void GetOrdersWrongId()
        {
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);

            List<Order> orders1 = orderManager.GetOrders(0);

            Assert.IsNull(orders1);
        }

        [TestMethod]
        public void GetAllOrders()
        {
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);

            List<Order> orders = mockOrderDAL.GetAllOrders();
            List<Order> orders1 = orderManager.GetAllOrders();

            Assert.IsNotNull(orders);
            CollectionAssert.AreEquivalent(orders, orders1);
        }

        [TestMethod]
        public void GetOrdersById()
        {
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);

            Order orders = mockOrderDAL.GetOrderById(1);
            Order orders1 = orderManager.GetOrderById(1);

            Assert.IsNotNull(orders);
            Assert.AreEqual(orders, orders1);
        }

        [TestMethod]
        public void GetOrdersByIdWrong()
        {
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);

            Order orders1 = orderManager.GetOrderById(0);

            Assert.IsNull(orders1);
        }

        [TestMethod]
        public void GetProductsOfOrder()
        {
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);

            List<OrderRecord> orders = mockOrderDAL.GetProductsOfOrder(1);
            List<OrderRecord> orders1 = orderManager.GetProductsOfOrder(1);

            Assert.IsNotNull(orders);
            CollectionAssert.AreEquivalent(orders, orders1);
        }

        [TestMethod]
        public void GetProductsOfOrderWrongId()
        {
            MockOrderDAL mockOrderDAL = new MockOrderDAL();
            OrderManager orderManager = new OrderManager(mockOrderDAL);

            List<OrderRecord> orders1 = orderManager.GetProductsOfOrder(0);

            Assert.IsNull(orders1);
        }
    }
}
