using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Object
{
    public class Product
    {
        private int id;
        private string name;
        private Category category;
        private double price;
        private string unit;
        private string description;
        private byte[] image;
        private bool active;

        public Product(int id, string name, double price, string unit, string description, byte[] image, Category category, bool active)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.unit = unit;
            this.description = description;
            this.image = image;
            this.category = category;
            this.active = active;
        }

        public Product(string name, double price, string unit, string description, byte[] image, Category category, bool active)
        {
            this.name = name;
            this.price = price;
            this.unit = unit;
            this.description = description;
            this.image = image;
            this.category = category;
            this.Active = active;
        }

        // I need this constructor for the deserialization of the json in the basket form
        public Product()
        {

        }

        public string ToString()
        {
            return $"{name} - €{price}";
        }

        #region Properties
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public Category Category { get => category; set => category = value; }
        public double Price { get { return price; } set { price = value; } }
        public string Unit { get { return unit; } set { unit = value; } }
        public string Description { get { return description; } set { description = value; } }
        public byte[] Image { get { return image; } set { image = value; } }
        public bool Active { get { return active; } set { active = value; } }
        #endregion
    }
}
