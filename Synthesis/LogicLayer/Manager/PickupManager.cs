using LogicLayer.Interface;
using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Manager
{
    public class PickupManager
    {
        private IPickupDAL ipickup;

        public PickupManager(IPickupDAL ipickup) 
        {
            this.ipickup = ipickup;
        }

        public List<Pickup> GetPickupLocations()
        {
            try
            {
                return ipickup.GetPickupLocations();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Pickup GetPickupById(int id)
        {
            try
            {
                return ipickup.GetPickupById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
