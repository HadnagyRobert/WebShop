using LogicLayer.Object;

namespace WebApp.View_Model
{
    public class ProductVM
    {
        int id;
        string name;
        Category category;
        double price;
        string unit;
        string description;
        byte[] image;
        bool active;
        int quantity;

        public ProductVM()
        {

        }

        public ProductVM(int id, string name, double price, string unit, string description, byte[] image, Category category, bool active, int quantity)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.unit = unit;
            this.description = description;
            this.image = image;
            this.category = category;
            this.Active = active;
            this.quantity = quantity;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Category Category { get => category; set => category = value; }
        public double Price { get => price; set => price = value; }
        public string Unit { get => unit; set => unit = value; }
        public string Description { get => description; set => description = value; }
        public byte[] Image { get => image; set => image = value; }
        public bool Active { get => active; set => active = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
