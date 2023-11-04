using LogicLayer.Interface;
using LogicLayer.Object;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDAL : ICategory
    {

        public List<Category> GetCategories()
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getAllCategorys = DBQueries.GetCategorys;
            string getAllCategorysNull = DBQueries.GetCategorysNull;
            MySqlCommand commandDatabase = new MySqlCommand(getAllCategorys, databaseConnection);
            MySqlCommand category = new MySqlCommand(getAllCategorysNull, databaseConnection);

            List<Category> categories = new List<Category>();

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
                    int? sId = Convert.ToInt32(reader["parentCategory"]);

                    categories.Add(new Category(id, name, sId));
                }

                reader.Close();
                reader = category.ExecuteReader();
                if (reader is null)
                {
                    return null;
                }
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string name = Convert.ToString(reader["name"]);

                    categories.Add(new Category(id, name, null));
                }
                return categories;
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

        public Category GetCategoryByName(string name)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getCategoryByName = DBQueries.GetCategoryByName;
            MySqlCommand commandDatabase = new MySqlCommand(getCategoryByName, databaseConnection);

            Category category;

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
                        int? sId = Convert.ToInt32(reader["parentCategory"]);

                        category = new Category(id, name, sId);
                        return category;
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
    }
}
