using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Object
{
    public class Order
    {
        private int id;
        private User user;
        private List<OrderRecord> basket;
        private Status status;
        private Address? address;
        private Pickup? pickup;
        private DateTime date;

        public Order(User user, Pickup pickup, DateTime date)
        {
            this.user = user;
            this.basket = new List<OrderRecord>();
            this.status = 0;
            this.pickup = pickup;
            this.address = null;
            this.date = date;
        }

        public Order(User user, Address address, DateTime date)
        {
            this.user = user;
            this.basket = new List<OrderRecord>();
            this.status = 0;
            this.address = address;
            this.pickup = null;
            this.date = date;
        }

        public Order(int id, User user, List<OrderRecord> basket, Status status, Address address, DateTime date)
        {
            this.id = id;
            this.user = user;
            this.basket = basket;
            this.status = status;
            this.address = address;
            this.pickup = null;
            this.date = date;
        }
        public Order(int id, User user, List<OrderRecord> basket, Status status, Pickup pickup, DateTime date)
        {
            this.id = id;
            this.user = user;
            this.basket = basket;
            this.status = status;
            this.address = null;
            this.pickup = pickup;
            this.date = date;
        }

        //constructor for deserializeation
        public Order()
        {

        }

        public void AddItemToBasket(Product product, int quantity)
        {
            basket.Add(new OrderRecord(product, quantity));
        }

        public string ToString()
        {
            return $"{id} - {status} {date}";
        }

        public int Id { get { return id; } }
        public List<OrderRecord> Basket { get { return basket; } set { basket = value; } }
        public Status Status { get { return status; } set { status = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public User User { get { return user; } set { user = value; } }
        public Address Adress { get { return address; } set { address = value; } }
        public Pickup Pickup { get { return pickup; } set { pickup = value; } }
    }
}
