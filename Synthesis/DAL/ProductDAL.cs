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
    public class ProductDAL : IProductDAL
    {
        public bool CheckProductName(string name)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string checkProductName = DBQueries.CheckProductName;
            MySqlCommand commandDatabase = new MySqlCommand(checkProductName, databaseConnection);

            try
            {
                commandDatabase.Parameters.AddWithValue("@name", name);
                databaseConnection.Open();

                MySqlDataReader reader = commandDatabase.ExecuteReader();

                if (reader is null)
                {
                    return false;
                }
                while (reader.Read())
                {
                    return true;
                }

                return false;
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

        public void CreateProduct(Product product)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string createProduct = DBQueries.CreateProduct;
            MySqlCommand commandDatabase = new MySqlCommand(createProduct, databaseConnection);

            try
            {
                commandDatabase.Parameters.AddWithValue("@name", product.Name);
                commandDatabase.Parameters.AddWithValue("@price", product.Price);
                commandDatabase.Parameters.AddWithValue("@unit", product.Unit);
                commandDatabase.Parameters.AddWithValue("@description", product.Description);
                commandDatabase.Parameters.AddWithValue("@image", product.Image);
                commandDatabase.Parameters.AddWithValue("@categoryId", product.Category.Id);
                commandDatabase.Parameters.AddWithValue("@active", product.Active);

                databaseConnection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();

                if (reader is null)
                {
                    return;
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

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllActiveProducts()
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getAllProducts = DBQueries.GetAllActiveProducts;
            MySqlCommand commandDatabase = new MySqlCommand(getAllProducts, databaseConnection);

            List<Product> products = new List<Product>();

            try
            {
                databaseConnection.Open();

                MySqlDataReader reader = commandDatabase.ExecuteReader();
                if (reader is null)
                {
                    return null;
                }
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string name = Convert.ToString(reader["name"]);
                    double price = Convert.ToDouble(reader["price"]);
                    string unit = Convert.ToString(reader["unit"]);
                    string description = Convert.ToString(reader["description"]);
                    byte[] image = (byte[])reader["image"];
                    bool active = Convert.ToBoolean(reader["active"]);
                    int cId = Convert.ToInt32(reader["categoryId"]);
                    string cName = Convert.ToString(reader["categoryName"]);
                    int? sId = Convert.ToInt32(reader["subcategoryId"]);

                    products.Add(new Product(id, name, price, unit, description, image, new Category(cId, cName, sId), active));
                }
                return products;
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

        public List<Product> GetAllProducts()
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getAllProducts = DBQueries.GetAllProducts;
            MySqlCommand commandDatabase = new MySqlCommand(getAllProducts, databaseConnection);

            List<Product> products = new List<Product>();

            try
            {
                databaseConnection.Open();

                MySqlDataReader reader = commandDatabase.ExecuteReader();
                if (reader is null)
                {
                    return null;
                }
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string name = Convert.ToString(reader["name"]);
                    double price = Convert.ToDouble(reader["price"]);
                    string unit = Convert.ToString(reader["unit"]);
                    string description = Convert.ToString(reader["description"]);
                    byte[] image = (byte[])reader["image"];
                    bool active = Convert.ToBoolean(reader["active"]);
                    int cId = Convert.ToInt32(reader["categoryId"]);
                    string cName = Convert.ToString(reader["categoryName"]);
                    int? sId = Convert.ToInt32(reader["subcategoryId"]);

                    products.Add(new Product(id, name, price, unit, description, image, new Category(cId, cName, sId),active));
                }
                return products;
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

        public Product GetProductByName(string name)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getProductByName = DBQueries.GetProductByName;
            MySqlCommand commandDatabase = new MySqlCommand(getProductByName, databaseConnection);

            Product product;

            try
            {
                commandDatabase.Parameters.AddWithValue("@name", name);
                databaseConnection.Open();

                MySqlDataReader reader = commandDatabase.ExecuteReader();

                if (reader is null)
                {
                    return null;
                }

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        double price = Convert.ToDouble(reader["price"]);
                        string unit = Convert.ToString(reader["unit"]);
                        string description = Convert.ToString(reader["description"]);
                        byte[] image = (byte[])reader["image"];
                        bool active = Convert.ToBoolean(reader["active"]);
                        int cId = Convert.ToInt32(reader["categoryId"]);
                        string cName = Convert.ToString(reader["categoryName"]);
                        int? sId = Convert.ToInt32(reader["subcategoryId"]);

                        product = new Product(id, name, price, unit, description, image, new Category(cId, cName, sId),active);
                        return product;
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

        public void UpdateProduct(Product product)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string updateProduct = DBQueries.UpdateProduct;
            MySqlCommand commandDatabase = new MySqlCommand(updateProduct, databaseConnection);

            try
            {
                commandDatabase.Parameters.AddWithValue("@id", product.Id);
                commandDatabase.Parameters.AddWithValue("@name", product.Name);
                commandDatabase.Parameters.AddWithValue("@price", product.Price);
                commandDatabase.Parameters.AddWithValue("@unit", product.Unit);
                commandDatabase.Parameters.AddWithValue("@description", product.Description);
                commandDatabase.Parameters.AddWithValue("@image", product.Image);
                commandDatabase.Parameters.AddWithValue("@active", product.Active);
                commandDatabase.Parameters.AddWithValue("@categoryId", product.Category.ParentId);

                databaseConnection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();


                if (reader is null)
                {
                    return;
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
    }
}
