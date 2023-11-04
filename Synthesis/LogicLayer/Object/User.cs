using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Object
{
    public class User
    {
        private int id;
        private string username;
        private string password;
        private string salt;
        private Address address;
        private string role;
        private string email;
        private string firstName;
        private string lastName;

        public User(int id, string username, string password, string salt, string role, string email, string firstName, string lastName)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.salt = salt;
            this.email = email;
            this.role = role;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public User(string username, string password, string salt, string email, string firstName, string lastName)
        {
            this.username = username;
            this.password = password;
            this.salt = salt;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = "user";
        }

        #region Properties

        public int Id { get { return id; } set { id = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Salt { get { return salt; } set { salt = value; } }
        public Address Address { get { return address; } set { address = value; } }
        public string Role { get { return role; } set { role = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }

        #endregion
    }
}
