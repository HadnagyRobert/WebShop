using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interface
{
    public interface IAddressDAL
    {
        void CreateAddress(Address address);

        bool CheckAddress(Address address);

        Address GetAddress(Address address);
    }
}
