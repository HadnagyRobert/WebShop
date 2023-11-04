using LogicLayer.Interface;
using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.DAL
{
    public class MockPickupDAL : IPickupDAL
    {
        private List<Pickup> pickups;
        private int i = 0;
        public MockPickupDAL() 
        {
            pickups= new List<Pickup>()
            {
                new Pickup(i++, "Netherlands","Eindhoven","1111AA","Straat",1),
                new Pickup(i++, "Romani","Arad","123ABC","Strada",2),
                new Pickup(i++, "Bulgaria","Varna","1A2B3C","Ulitsa",3)
            };
        }
        public Pickup GetPickupById(int id)
        {
            foreach(Pickup p in pickups)
                if(p.Id == id)
                    return p;
            return null;
        }

        public List<Pickup> GetPickupLocations()
        {
            return pickups;
        }
    }
}
