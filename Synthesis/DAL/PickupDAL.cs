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
    public class PickupDAL : IPickupDAL
    {
        public Pickup GetPickupById(int id)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getPickupById = DBQueries.GetPickupById;
            MySqlCommand commandDatabase = new MySqlCommand(getPickupById, databaseConnection);

            Pickup pickup;

            try
            {
                commandDatabase.Parameters.AddWithValue("@id", id);
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
                        string country = Convert.ToString(reader["country"]);
                        string city = Convert.ToString(reader["city"]);
                        string postalCode = Convert.ToString(reader["postalcode"]);
                        string street = Convert.ToString(reader["street"]);
                        int number = Convert.ToInt32(reader["number"]);

                        pickup = new Pickup(id, country, city, postalCode, street, number);
                        return pickup;
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

        public List<Pickup> GetPickupLocations()
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getAllPickups = DBQueries.GetAllPickups;
            MySqlCommand commandDatabase = new MySqlCommand(getAllPickups, databaseConnection);

            List<Pickup> pickups = new List<Pickup>();
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
                    string country = Convert.ToString(reader["country"]);
                    string city = Convert.ToString(reader["city"]);
                    string postalCode = Convert.ToString(reader["postalcode"]);
                    string street = Convert.ToString(reader["street"]);
                    int number = Convert.ToInt32(reader["number"]);

                    pickups.Add(new Pickup(id, country, city, postalCode, street, number));
                }

                return pickups;
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
