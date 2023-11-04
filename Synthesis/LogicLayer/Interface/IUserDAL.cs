using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interface
{
    public interface IUserDAL
    {
        void CreateUser(User user);

        void UpdateUser(User user);

        bool CheckUsername(string username);

        List<User> GetAllUsers();

        User GetUserByUsername(string username);

        User GetUserById(int id);
    }
}
