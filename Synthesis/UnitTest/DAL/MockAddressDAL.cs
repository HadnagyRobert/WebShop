using LogicLayer.Interface;
using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.DAL
{
    public class MockAddressDAL : IAddressDAL
    {
        private List<Address> addresses;
        private int i = 0;

        public MockAddressDAL()
        {
            addresses = new List<Address>()
            {
                new Address(i++, "Netherlands","Eindhoven","1111AA","Straat",1),
                new Address(i++, "Romani","Arad","123ABC","Strada",2),
                new Address(i++, "Bulgaria","Varna","1A2B3C","Ulitsa",3)
            };
        }

        public bool CheckAddress(Address address)
        {
            foreach(Address a in addresses)
                if(a.Country == address.Country && a.City == address.City && a.PostalCode == address.PostalCode && a.Street == address.Street && a.Number == address.Number)
                    return true;
            return false;
        }

        public void CreateAddress(Address address)
        {
            addresses.Add(address);
        }

        public Address GetAddress(Address address)
        {
            foreach(Address a in addresses)
                if (a.Country == address.Country && a.City == address.City && a.PostalCode == address.PostalCode && a.Street == address.Street && a.Number == address.Number)
                    return a;
            return null;
        }

        public Address GetAddressById(int id)
        {
            foreach(Address a in addresses)
                if(a.Id == id)
                    return a;
            return null;
        }
    }
}
