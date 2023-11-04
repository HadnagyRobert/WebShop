using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Object
{
    public class OrderRecord
    {
        private Product product;
        private double price;
        private int quantity;

        public OrderRecord(Product product, int quantity)
        {
            this.product = product;
            this.price = product.Price;
            this.quantity = quantity;
        }

        public OrderRecord(Product product, double price, int quantity)
        {
            this.product = product;
            this.price = price;
            this.quantity = quantity;
        }

        public Product Product { get { return product; } }
        public double Price { get { return price; } }
        public int Quantity { get { return quantity; } }
    }
}
