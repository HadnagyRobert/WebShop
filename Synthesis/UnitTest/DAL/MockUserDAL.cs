using LogicLayer.Interface;
using LogicLayer.Manager;
using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.DAL
{
    public class MockUserDAL : IUserDAL
    {
        private List<User> users;
        private int i = 0;

        public MockUserDAL()
        {
            users = new List<User>
            {
                new User(i++, "bob0", "123", "YZ2td.]Z'*`t5nc", "admin", "bob0@gmail.com", "bob", "0"),
                new User(i++, "bob1", "123", "YZ2td.]Z'*`t5nc", "user", "bob1@gmail.com", "bob", "1"),
                new User(i++, "bob2", "123", "YZ2td.]Z'*`t5nc", "user", "bob2@gmail.com", "bob", "2"),
                new User(i++, "bobobo", "�\v���V.fе(�RP'\u007fM\u0012\u0018�4\u0004�K", "YZ2td.]Z'*`t5nc", "user", "bobobo@gmail.com", "bob", "obo"),
                new User(i++, "bobobo2", "�\v���V.fе(�RP'\u007fM\u0012\u0018�4\u0004�K", "YZ2td.]Z'*`t5nc", "admin", "bobobo@gmail.com", "bob", "obo")
            };
        }

        public bool CheckUsername(string username)
        {
            foreach (User user in users)
                if (user.Username == username)
                    return true;
            return false;
        }

        public void CreateUser(User user)
        {
            user.Id = i++;
            users.Add(user);
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserById(int id)
        {
            foreach (User user in users)
                if (user.Id == id)
                    return user;
            return null;
        }

        public User GetUserByUsername(string username)
        {
            foreach (User user in users)
                if (user.Username == username)
                    return user;
            return null;
        }

        public void UpdateUser(User user)
        {
            foreach (User user1 in users)
                if (user1.Id == user.Id)
                {
                    user1.Username = user.Username;
                    user1.Password = user.Password;
                    user1.Salt = user.Salt;
                }
        }
    }
}
