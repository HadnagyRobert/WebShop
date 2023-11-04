using LogicLayer.Interface;
using LogicLayer.Object;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class UserDAL : IUserDAL
    {
        public void CreateUser(User user)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string createUser = DBQueries.CreateUser;
            MySqlCommand commandDatabase = new MySqlCommand(createUser, databaseConnection);

            try
            {
                commandDatabase.Parameters.AddWithValue("@username", user.Username);
                commandDatabase.Parameters.AddWithValue("@password", user.Password);
                commandDatabase.Parameters.AddWithValue("@salt", user.Salt);
                commandDatabase.Parameters.AddWithValue("@role", user.Role);
                commandDatabase.Parameters.AddWithValue("@email", user.Email);
                commandDatabase.Parameters.AddWithValue("@firstName", user.FirstName);
                commandDatabase.Parameters.AddWithValue("@lastName", user.LastName);

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

        public void UpdateUser(User user)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string updateUser = DBQueries.UpdateUser;
            MySqlCommand commandDatabase = new MySqlCommand(updateUser, databaseConnection);

            try
            {
                commandDatabase.Parameters.AddWithValue("@id", user.Id);
                commandDatabase.Parameters.AddWithValue("@username", user.Username);
                commandDatabase.Parameters.AddWithValue("@password", user.Password);
                commandDatabase.Parameters.AddWithValue("@salt", user.Salt);
                commandDatabase.Parameters.AddWithValue("@role", user.Role);
                commandDatabase.Parameters.AddWithValue("@email", user.Email);
                commandDatabase.Parameters.AddWithValue("@firstName", user.FirstName);
                commandDatabase.Parameters.AddWithValue("@lastName", user.LastName);

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

        public bool CheckUsername(string username)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string checkUsername = DBQueries.CheckUsername;
            MySqlCommand commandDatabase = new MySqlCommand(checkUsername, databaseConnection);

            try
            {
                commandDatabase.Parameters.AddWithValue("@username", username);
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

        public List<User> GetAllUsers()
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getAllUsers = DBQueries.GetAllUsers;
            MySqlCommand commandDatabase = new MySqlCommand(getAllUsers, databaseConnection);

            List<User> users = new List<User>();
            try
            {
                databaseConnection.Open();

                MySqlDataReader reader = commandDatabase.ExecuteReader();

                if (reader is null)
                {
                    return null;
                }

                while(reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string username = Convert.ToString(reader["username"]);
                    string password = Convert.ToString(reader["password"]);
                    string salt = Convert.ToString(reader["salt"]);
                    string role = Convert.ToString(reader["role"]);
                    string email = Convert.ToString(reader["email"]);
                    string firstName = Convert.ToString(reader["firstName"]);
                    string lastName = Convert.ToString(reader["lastName"]);

                    users.Add(new User(id, username, password, salt, role, email, firstName, lastName));
                }

                return users;
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

        public User GetUserByUsername(string username)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getUserByUsername = DBQueries.GetUserByUsername;
            MySqlCommand commandDatabase = new MySqlCommand(getUserByUsername, databaseConnection);

            User user;

            try
            {
                commandDatabase.Parameters.AddWithValue("@username", username);
                databaseConnection.Open();

                MySqlDataReader reader = commandDatabase.ExecuteReader();

                if (reader is null)
                {
                    return null;
                }

                while(reader.Read())
                {
                    if(reader.HasRows)
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string password = Convert.ToString(reader["password"]);
                        string salt = Convert.ToString(reader["salt"]);
                        string role = Convert.ToString(reader["role"]);
                        string email = Convert.ToString(reader["email"]);
                        string firstName = Convert.ToString(reader["firstName"]);
                        string lastName = Convert.ToString(reader["lastName"]);

                        user = new User(id, username, password, salt, role, email, firstName, lastName);
                        return user;
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

        public User GetUserById(int id)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DBQueries.Connection);
            string getUserByUsername = DBQueries.GetUserById;
            MySqlCommand commandDatabase = new MySqlCommand(getUserByUsername, databaseConnection);

            User user;

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
                        string username = Convert.ToString(reader["username"]);
                        string password = Convert.ToString(reader["password"]);
                        string salt = Convert.ToString(reader["salt"]);
                        string role = Convert.ToString(reader["role"]);
                        string email = Convert.ToString(reader["email"]);
                        string firstName = Convert.ToString(reader["firstName"]);
                        string lastName = Convert.ToString(reader["lastName"]);

                        user = new User(id, username, password, salt, role, email, firstName, lastName);
                        return user;
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

        //private static string PasswordHasher(string password, string salt)
        //{
        //    var charPassword = BCrypt.PasswordToByteArray(password.ToCharArray());
        //    var charSalt = BCrypt.PasswordToByteArray(salt.ToCharArray());
        //    return Encoding.UTF8.GetString(BCrypt.Generate(charPassword, charSalt, 5));
        //}

        //MySqlConnection con = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi497144;Database=dbi497144;Pwd=1207;");
        //MySqlCommand cmd = new MySqlCommand();

        //public void CreateUser(User user)
        //{
        //    try
        //    {
        //        con.Open();

        //        using (con)
        //        {
        //            cmd = con.CreateCommand();
        //            cmd.CommandText = "INSERT INTO users (username,password,salt) " +
        //                                "VALUES(@username,@password,@salt)";

        //            cmd.Parameters.AddWithValue("@username", user.Username);
        //            cmd.Parameters.AddWithValue("@password", PasswordHasher(user.Password, user.Salt));
        //            cmd.Parameters.AddWithValue("@salt", user.Salt);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void UpdateUser(User user)
        //{
        //    try
        //    {
        //        con.Open();

        //        using (con)
        //        {
        //            cmd = con.CreateCommand();

        //            cmd.CommandText = "UPDATE users SET username = @username, password = @password, salt = @salt WHERE id= @id";

        //            cmd.Parameters.AddWithValue("@id", user.Id);
        //            cmd.Parameters.AddWithValue("@username", user.Username);
        //            cmd.Parameters.AddWithValue("@password", user.Password);
        //            cmd.Parameters.AddWithValue("@salt", user.Salt);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //}

        //public List<User> GetAllUsers()
        //{
        //    try
        //    {
        //        List<User> users = new List<User>();

        //        cmd = con.CreateCommand();
        //        cmd.CommandText = "SELECT * FROM users";

        //        con.Open();

        //        using (con)
        //        {
        //            MySqlDataReader reader = cmd.ExecuteReader();
        //            using (reader)
        //            {
        //                while (reader.Read())
        //                {
        //                    int id = Convert.ToInt32(reader["id"]);
        //                    string username = Convert.ToString(reader["username"]);
        //                    string password = Convert.ToString(reader["password"]);
        //                    string salt = Convert.ToString(reader["salt"]);

        //                    users.Add(new User(id, username, password, salt));
        //                }
        //            }
        //        }
        //        return users;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public User GetUserByUsername(string username)
        //{
        //    try
        //    {
        //        User user;

        //        con.Open();

        //        using (con)
        //        {
        //            cmd = con.CreateCommand();
        //            cmd.CommandText = "SELECT * FROM users WHERE username = @username";

        //            cmd.Parameters.AddWithValue("@username", username);

        //            MySqlDataReader reader = cmd.ExecuteReader();
        //            using (reader)
        //            {
        //                while(reader.Read())
        //                {
        //                    int id = Convert.ToInt32(reader["id"]);
        //                    string password = Convert.ToString(reader["password"]);
        //                    string salt = Convert.ToString(reader["salt"]);

        //                    user = new User(id, username, password, salt);
        //                    return user;
        //                }
        //            }
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
