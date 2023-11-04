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
    public class AddressDAL : IAddressDAL
    {
        public bool CheckAddress(Address address)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string checkAddress = DBQueries.GetAddress;
            MySqlCommand commandDatabase = new MySqlCommand(checkAddress, databaseConnection);

            try
            {
                commandDatabase.Parameters.AddWithValue("@country", address.Country);
                commandDatabase.Parameters.AddWithValue("@city", address.City);
                commandDatabase.Parameters.AddWithValue("@postalcode", address.PostalCode);
                commandDatabase.Parameters.AddWithValue("@street", address.Street);
                commandDatabase.Parameters.AddWithValue("@number", address.Number);
                databaseConnection.Open();

                MySqlDataReader reader = commandDatabase.ExecuteReader();

                if (reader is null)
                {
                    return false;
                }

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);

                        if (id != null)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }

        }

        public void CreateAddress(Address address)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string createAddress = DBQueries.CreateAddress;
            MySqlCommand commandDatabase = new MySqlCommand(createAddress, databaseConnection);

            try
            {
                commandDatabase.Parameters.AddWithValue("@country", address.Country);
                commandDatabase.Parameters.AddWithValue("@city", address.City);
                commandDatabase.Parameters.AddWithValue("@postalcode", address.PostalCode);
                commandDatabase.Parameters.AddWithValue("@street", address.Street);
                commandDatabase.Parameters.AddWithValue("@number", address.Number);

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

        public Address GetAddress(Address address)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getAddress = DBQueries.GetAddress;
            MySqlCommand commandDatabase = new MySqlCommand(getAddress, databaseConnection);

            try
            {
                commandDatabase.Parameters.AddWithValue("@country", address.Country);
                commandDatabase.Parameters.AddWithValue("@city", address.City);
                commandDatabase.Parameters.AddWithValue("@postalcode", address.PostalCode);
                commandDatabase.Parameters.AddWithValue("@street", address.Street);
                commandDatabase.Parameters.AddWithValue("@number", address.Number);
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

                        return new Address(id, address.Country, address.City, address.PostalCode, address.Street, address.Number);
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
