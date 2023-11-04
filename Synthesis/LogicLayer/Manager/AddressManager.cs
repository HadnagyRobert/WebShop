using LogicLayer.Interface;
using LogicLayer.Object;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Manager
{
    public class AddressManager
    {
        private IAddressDAL iaddress;

        public AddressManager(IAddressDAL iaddress)
        {
            this.iaddress = iaddress;
        }

        public Address CreateAddress(Address address)
        {
            if (CheckAddress(address))
                return GetAddress(address);

            try
            {
                iaddress.CreateAddress(address);
                return GetAddress(address);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Address GetAddress(Address address)
        {
            try 
            {
                return iaddress.GetAddress(address);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool CheckAddress(Address address)
        {
            try
            {
                return iaddress.CheckAddress(address);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
