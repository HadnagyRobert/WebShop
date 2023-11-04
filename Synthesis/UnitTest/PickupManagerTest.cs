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
    public class PickupManagerTest
    {
        [TestMethod]
        public void GetPickupLocations()
        {
            MockPickupDAL mockPickupDAL = new MockPickupDAL();
            PickupManager pickupManager = new PickupManager(mockPickupDAL);

            List<Pickup> pickups= pickupManager.GetPickupLocations();
            List<Pickup> pickups1 = mockPickupDAL.GetPickupLocations();

            CollectionAssert.AreEquivalent(pickups1, pickups);
        }

        [TestMethod]
        public void GetPickupById()
        {
            int i = 1;
            MockPickupDAL mockPickupDAL = new MockPickupDAL();
            PickupManager pickupManager = new PickupManager(mockPickupDAL);

            Pickup pickup = pickupManager.GetPickupById(i);
            Pickup pickup1 = mockPickupDAL.GetPickupById(i);

            Assert.AreEqual(pickup,pickup1);
            Assert.IsNotNull(pickup);
            Assert.IsNotNull(pickup1);
        }

        [TestMethod]
        public void GetPickupByWrongId()
        {
            int i = 10;
            MockPickupDAL mockPickupDAL = new MockPickupDAL();
            PickupManager pickupManager = new PickupManager(mockPickupDAL);

            Pickup pickup = pickupManager.GetPickupById(i);
            Pickup pickup1 = mockPickupDAL.GetPickupById(i);

            Assert.AreEqual(pickup, pickup1);
            Assert.IsNull(pickup);
            Assert.IsNull(pickup1);
        }
    }
}
