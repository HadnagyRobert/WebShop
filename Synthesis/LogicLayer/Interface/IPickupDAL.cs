using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interface
{
    public interface IPickupDAL
    {
        List<Pickup> GetPickupLocations();

        Pickup GetPickupById(int id);
    }
}
