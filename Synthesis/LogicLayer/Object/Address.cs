using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Object
{
    public class Address
    {
        private int id;
        private string country;
        private string city;
        private string postalCode;
        private string street;
        private int number;

        public Address(int id, string country, string city, string postalCode, string street, int number)
        {
            this.id = id;
            this.country = country;
            this.city = city;
            this.postalCode = postalCode;
            this.street = street;
            this.number = number;
        }

        public Address(string country, string city, string postalCode, string street, int number)
        {
            this.country = country;
            this.city = city;
            this.postalCode = postalCode;
            this.street = street;
            this.number = number;
        }

        public string ToString()
        {
            return $"{country} {city} {postalCode} {street} {number}";
        }

        public int Id { get { return id; } }
        public string Country { get { return country; } }
        public string City { get { return city; } }
        public string PostalCode { get { return postalCode; } }
        public string Street { get { return street; } }
        public int Number { get { return number; } }
    }
}
