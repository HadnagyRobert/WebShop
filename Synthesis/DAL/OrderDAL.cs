using LogicLayer.Interface;
using LogicLayer.Object;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class OrderDAL : IOrderDAL
    {
        public void CreateOrder(Order order)
        {
            int orderId = 0;
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string crateOrder = DBQueries.CreateOrder;
            string addProductToOrder = DBQueries.AddProductToOrder;
            MySqlCommand createOrder = new MySqlCommand(crateOrder, databaseConnection);
            MySqlCommand addProduct = new MySqlCommand(addProductToOrder, databaseConnection);

            try
            {
                createOrder.Parameters.AddWithValue("@userId", order.User.Id);
                createOrder.Parameters.AddWithValue("@statusId", 1);
                createOrder.Parameters.AddWithValue("@date", order.Date);
                if(order.Adress == null)
                {
                    createOrder.Parameters.AddWithValue("@pickupId", order.Pickup.Id);
                    createOrder.Parameters.AddWithValue("@addressId", null);
                }
                else
                {
                    createOrder.Parameters.AddWithValue("@pickupId", null);
                    createOrder.Parameters.AddWithValue("@addressId", order.Adress.Id);
                }

                databaseConnection.Open();
                MySqlDataReader reader = createOrder.ExecuteReader();

                orderId = Convert.ToInt32(createOrder.LastInsertedId);

                reader.Close(); 

                foreach (var p in order.Basket)
                {
                    if(orderId == 0)
                        return;

                    addProduct.Parameters.AddWithValue("@orderId",orderId);
                    addProduct.Parameters.AddWithValue("@productId",p.Product.Id);
                    addProduct.Parameters.AddWithValue("@priceAtTimeOfOrder",p.Price);
                    addProduct.Parameters.AddWithValue("@quantity",p.Quantity);

                    reader = addProduct.ExecuteReader();
                    reader.Close();
                    addProduct.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        public List<Order> GetAllOrders()
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getordersAddress = DBQueries.GetOrdersAddress;
            string getordersPickup = DBQueries.GetOrdersPickup;
            MySqlCommand getOrdersAddress = new MySqlCommand(getordersAddress, databaseConnection);
            MySqlCommand getOrdersPickup = new MySqlCommand(getordersPickup, databaseConnection);

            List<Order> orders = new List<Order>();

            try
            {
                databaseConnection.Open();

                MySqlDataReader reader = getOrdersAddress.ExecuteReader();
                if (reader is null)
                {
                    return null;
                }
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    Status statusId = (Status)Convert.ToInt32(reader["statusId"]);
                    DateTime date = Convert.ToDateTime(reader["date"]);
                    int address_id = Convert.ToInt32(reader["address_id"]);
                    string country = Convert.ToString(reader["country"]);
                    string city = Convert.ToString(reader["city"]);
                    string postalcode = Convert.ToString(reader["postalcode"]);
                    string street = Convert.ToString(reader["street"]);
                    int number = Convert.ToInt32(reader["number"]);
                    int user_id = Convert.ToInt32(reader["user_id"]);
                    string username = Convert.ToString(reader["username"]);
                    string password = Convert.ToString(reader["password"]);
                    string salt = Convert.ToString(reader["salt"]);
                    string role = Convert.ToString(reader["role"]);
                    string email = Convert.ToString(reader["email"]);
                    string firstName = Convert.ToString(reader["firstName"]);
                    string lastName = Convert.ToString(reader["lastName"]);

                    List<OrderRecord> basket = new List<OrderRecord>();
                    orders.Add(new Order(id, new User(user_id, username, password, salt, role, email, firstName, lastName), basket, statusId, new Address(country, city, postalcode, street, number), date));
                }

                reader.Close();
                reader = getOrdersPickup.ExecuteReader();
                if (reader is null)
                {
                    return null;
                }
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    Status statusId = (Status)Convert.ToInt32(reader["statusId"]);
                    DateTime date = Convert.ToDateTime(reader["date"]);
                    int user_id = Convert.ToInt32(reader["user_id"]);
                    string username = Convert.ToString(reader["username"]);
                    string password = Convert.ToString(reader["password"]);
                    string salt = Convert.ToString(reader["salt"]);
                    string role = Convert.ToString(reader["role"]);
                    string email = Convert.ToString(reader["email"]);
                    string firstName = Convert.ToString(reader["firstName"]);
                    string lastName = Convert.ToString(reader["lastName"]);
                    int pickup_id = Convert.ToInt32(reader["pickup_id"]);
                    string country_pickup = Convert.ToString(reader["pickup_country"]);
                    string city_pickup = Convert.ToString(reader["pickup_city"]);
                    string postalcode_pickup = Convert.ToString(reader["pickup_postalcode"]);
                    string street_pickup = Convert.ToString(reader["pickup_street"]);
                    int number_pickup = Convert.ToInt32(reader["pickup_number"]);

                    List<OrderRecord> basket = new List<OrderRecord>();
                    orders.Add(new Order(id, new User(user_id, username, password, salt, role, email, firstName, lastName), basket, statusId, new Pickup(pickup_id, country_pickup, city_pickup, postalcode_pickup, street_pickup, number_pickup), date));
                }
                return orders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        public Order GetOrderById(int orderId)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string GetOrderByIdAddress = DBQueries.GetOrderByIdAddress;
            string getOrderByIdPickup = DBQueries.GetOrderByIdPickup;
            MySqlCommand getAddress = new MySqlCommand(GetOrderByIdAddress, databaseConnection);
            MySqlCommand getPickup = new MySqlCommand(getOrderByIdPickup, databaseConnection);

            try
            {
                getAddress.Parameters.AddWithValue("@orderId", orderId);
                getPickup.Parameters.AddWithValue("@orderId", orderId);
                databaseConnection.Open();

                MySqlDataReader reader = getAddress.ExecuteReader();

                if (reader is null)
                {
                    return null;
                }


                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Status statusId = (Status)Convert.ToInt32(reader["statusId"]);
                        DateTime date = Convert.ToDateTime(reader["date"]);
                        int address_id = Convert.ToInt32(reader["address_id"]);
                        string country = Convert.ToString(reader["country"]);
                        string city = Convert.ToString(reader["city"]);
                        string postalcode = Convert.ToString(reader["postalcode"]);
                        string street = Convert.ToString(reader["street"]);
                        int number = Convert.ToInt32(reader["number"]);
                        int user_id = Convert.ToInt32(reader["user_id"]);
                        string username = Convert.ToString(reader["username"]);
                        string password = Convert.ToString(reader["password"]);
                        string salt = Convert.ToString(reader["salt"]);
                        string role = Convert.ToString(reader["role"]);
                        string email = Convert.ToString(reader["email"]);
                        string firstName = Convert.ToString(reader["firstName"]);
                        string lastName = Convert.ToString(reader["lastName"]);

                        List<OrderRecord> basket = new List<OrderRecord>();
                        return new Order(orderId, new User(user_id, username, password, salt, role, email, firstName, lastName), basket, statusId, new Address(country, city, postalcode, street, number), date);
                    }
                }

                reader.Close();
                reader = getPickup.ExecuteReader();

                if (reader is null)
                {
                    return null;
                }


                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Status statusId = (Status)Convert.ToInt32(reader["statusId"]);
                        DateTime date = Convert.ToDateTime(reader["date"]);
                        int user_id = Convert.ToInt32(reader["user_id"]);
                        string username = Convert.ToString(reader["username"]);
                        string password = Convert.ToString(reader["password"]);
                        string salt = Convert.ToString(reader["salt"]);
                        string role = Convert.ToString(reader["role"]);
                        string email = Convert.ToString(reader["email"]);
                        string firstName = Convert.ToString(reader["firstName"]);
                        string lastName = Convert.ToString(reader["lastName"]);
                        int pickup_id = Convert.ToInt32(reader["pickup_id"]);
                        string country_pickup = Convert.ToString(reader["pickup_country"]);
                        string city_pickup = Convert.ToString(reader["pickup_city"]);
                        string postalcode_pickup = Convert.ToString(reader["pickup_postalcode"]);
                        string street_pickup = Convert.ToString(reader["pickup_street"]);
                        int number_pickup = Convert.ToInt32(reader["pickup_number"]);

                        List<OrderRecord> basket = new List<OrderRecord>();
                        return new Order(orderId, new User(user_id, username, password, salt, role, email, firstName, lastName), basket, statusId, new Pickup(pickup_id, country_pickup, city_pickup, postalcode_pickup, street_pickup, number_pickup), date);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        public int GetOrderDatesAddress(DateTime orderDate)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getOrderDates = DBQueries.GetOrderDateAddress;
            MySqlCommand getDates = new MySqlCommand(getOrderDates, databaseConnection);
            
            int dateCount = 0;

            try
            {
                getDates.Parameters.AddWithValue("@date", orderDate);
                databaseConnection.Open();

                MySqlDataReader reader = getDates.ExecuteReader();

                if (reader is null)
                {
                    return 0;
                }
                while (reader.Read())
                {
                    dateCount = Convert.ToInt32(reader["result"]);
                }
                return dateCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        public int GetOrderDatesPickup(DateTime orderDate)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getOrderDates = DBQueries.GetOrderDatePickup;
            MySqlCommand getDates = new MySqlCommand(getOrderDates, databaseConnection);

            int dateCount = 0;

            try
            {
                getDates.Parameters.AddWithValue("@date", orderDate);
                databaseConnection.Open();

                MySqlDataReader reader = getDates.ExecuteReader();

                if (reader is null)
                {
                    return 0;
                }
                while (reader.Read())
                {
                    dateCount = Convert.ToInt32(reader["result"]);
                }
                return dateCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        public List<Order> GetOrders(int userId)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getOrdersAddressByUserId = DBQueries.GetOrdersAddressByUserId;
            string getOrdersPickupByUserId = DBQueries.GetOrdersPickupByUserId;
            MySqlCommand getAddress = new MySqlCommand(getOrdersAddressByUserId, databaseConnection);
            MySqlCommand getPickup = new MySqlCommand(getOrdersPickupByUserId, databaseConnection);

            List<Order> orders = new List<Order>();

            try
            {
                getAddress.Parameters.AddWithValue("@userId", userId);
                getPickup.Parameters.AddWithValue("@userId", userId);
                databaseConnection.Open();

                MySqlDataReader reader = getAddress.ExecuteReader();

                if (reader is null)
                {
                    return null;
                }


                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        Status statusId = (Status)Convert.ToInt32(reader["statusId"]);
                        DateTime date = Convert.ToDateTime(reader["date"]);
                        int address_id = Convert.ToInt32(reader["address_id"]);
                        string country = Convert.ToString(reader["country"]);
                        string city = Convert.ToString(reader["city"]);
                        string postalcode = Convert.ToString(reader["postalcode"]);
                        string street = Convert.ToString(reader["street"]);
                        int number = Convert.ToInt32(reader["number"]);
                        string username = Convert.ToString(reader["username"]);
                        string password = Convert.ToString(reader["password"]);
                        string salt = Convert.ToString(reader["salt"]);
                        string role = Convert.ToString(reader["role"]);
                        string email = Convert.ToString(reader["email"]);
                        string firstName = Convert.ToString(reader["firstName"]);
                        string lastName = Convert.ToString(reader["lastName"]);

                        List<OrderRecord> basket = new List<OrderRecord>();
                        orders.Add(new Order(id, new User(userId, username, password, salt, role, email, firstName, lastName), basket, statusId, new Address(country, city, postalcode, street, number), date));
                    }
                }

                reader.Close();
                reader = getPickup.ExecuteReader();

                if (reader is null)
                {
                    return orders;
                }


                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        Status statusId = (Status)Convert.ToInt32(reader["statusId"]);
                        DateTime date = Convert.ToDateTime(reader["date"]);
                        string username = Convert.ToString(reader["username"]);
                        string password = Convert.ToString(reader["password"]);
                        string salt = Convert.ToString(reader["salt"]);
                        string role = Convert.ToString(reader["role"]);
                        string email = Convert.ToString(reader["email"]);
                        string firstName = Convert.ToString(reader["firstName"]);
                        string lastName = Convert.ToString(reader["lastName"]);
                        int pickup_id = Convert.ToInt32(reader["pickup_id"]);
                        string country_pickup = Convert.ToString(reader["pickup_country"]);
                        string city_pickup = Convert.ToString(reader["pickup_city"]);
                        string postalcode_pickup = Convert.ToString(reader["pickup_postalcode"]);
                        string street_pickup = Convert.ToString(reader["pickup_street"]);
                        int number_pickup = Convert.ToInt32(reader["pickup_number"]);

                        List<OrderRecord> basket = new List<OrderRecord>();
                        orders.Add(new Order(id, new User(userId, username, password, salt, role, email, firstName, lastName), basket, statusId, new Pickup(pickup_id, country_pickup, city_pickup, postalcode_pickup, street_pickup, number_pickup), date));
                    }
                }
                return orders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        public List<OrderRecord> GetProductsOfOrder(int orderId)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getProductsPerOrder = DBQueries.GetProductsPerOrder;
            MySqlCommand getProducts = new MySqlCommand(getProductsPerOrder, databaseConnection);

            List<OrderRecord> orderrecords = new List<OrderRecord>();

            try
            {
                getProducts.Parameters.AddWithValue("@orderId", orderId);
                databaseConnection.Open();

                MySqlDataReader reader = getProducts.ExecuteReader();

                if (reader is null)
                {
                    return null;
                }


                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        double priceAtTimeOfOrder = Convert.ToDouble(reader["priceAtTimeOfOrder"]);
                        int quantity = Convert.ToInt32(reader["quantity"]);
                        int productId = Convert.ToInt32(reader["productId"]);
                        string name = Convert.ToString(reader["name"]);
                        double price = Convert.ToDouble(reader["price"]);
                        string unit = Convert.ToString(reader["unit"]);
                        string descriptiion = Convert.ToString(reader["description"]);
                        byte[] image = (byte[])reader["image"];
                        bool active = Convert.ToBoolean(reader["active"]);
                        int categoryId = Convert.ToInt32(reader["categoryId"]);
                        string categoryName = Convert.ToString(reader["categoryName"]);
                        int subcategoryId = Convert.ToInt32(reader["subcategoryId"]);

                        orderrecords.Add(new OrderRecord(new Product(productId,name,price,unit,descriptiion,image,new Category(subcategoryId,categoryName,categoryId),active),priceAtTimeOfOrder,quantity));
                    }
                }
                return orderrecords;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        public bool UpdateOrderStatus(int orderId, Status status)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string updateOrder = DBQueries.UpdateOrderStatus;
            MySqlCommand commandDatabase = new MySqlCommand(updateOrder, databaseConnection);

            try
            {
                commandDatabase.Parameters.AddWithValue("@id", orderId);
                commandDatabase.Parameters.AddWithValue("@statusId", (int)status);
                databaseConnection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();


                if (reader is null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }
        }
    }
}