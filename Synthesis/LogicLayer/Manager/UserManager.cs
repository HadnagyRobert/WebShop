using LogicLayer.Interface;
using LogicLayer.Object;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Manager
{
    public class UserManager
    {
        private IUserDAL iuser;

        public UserManager(IUserDAL iuser)
        {
            this.iuser = iuser;
        }

        public bool CreateUser(string username, string password, string email, string firstName, string lastName)
        {
            if(username == "" || password == "" || email == "" || firstName == "" || lastName == "")
                return false;
            if (CheckUsername(username))
                return false;

            string salt = GenerateSalt();
            User user = new User(username, PasswordHasher(password,salt), salt, email, firstName, lastName);

            try
            {
                iuser.CreateUser(user);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool CheckLogin(string username, string password)
        {
            if(username == "" || password == "")
                return false;

            User user = GetUserByUsername(username);

            if (user != null && user.Password == PasswordHasher(password, user.Salt))
                return true;

            return false;
        }

        public bool CheckLoginAdmin(string username, string password)
        {
            if (username == "" || password == "")
                return false;

            User user = GetUserByUsername(username);

            if (user != null && user.Password == PasswordHasher(password, user.Salt) && user.Role == "admin")
                return true;

            return false;
        }

        public bool UpdateUser(User user)
        { 
            if (user == null) 
                return false;
            if(user.Id <= 0 || user.Username == "" || user.Password == "" || user.Salt == "" || user.Role == ""|| user.Email == "" || user.FirstName == "" || user.LastName == "")
                return false;    
            if(CheckUsername(user.Username))
                return false;

            try
            {
                iuser.UpdateUser(user);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return iuser.GetAllUsers();
        }

        public bool CheckUsername(string username)
        {
            if(username == "")
                return false;

            try
            {
                return iuser.CheckUsername(username);
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public User GetUserByUsername(string username)
        {
            if (username == "")
                return null;

            try
            {
                return iuser.GetUserByUsername(username);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User GetUserById(int id)
        {
            if (id <= 0)
                return null;

            try
            {
                return iuser.GetUserById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static string PasswordHasher(string password, string salt)
        {
            var charPassword = BCrypt.PasswordToByteArray(password.ToCharArray());
            var charSalt = BCrypt.PasswordToByteArray(salt.ToCharArray());
            return Encoding.UTF8.GetString(BCrypt.Generate(charPassword, charSalt, 5));
        }

        private static string GenerateSalt()
        {
            Random rnd = new Random();
            Byte[] b = new Byte[15];
            for (int i = 0; i < 15; i++)
                b[i] = Convert.ToByte(rnd.Next(33, 126));
            string salt = Encoding.UTF8.GetString(b);

            return salt;
        }
    }
}
