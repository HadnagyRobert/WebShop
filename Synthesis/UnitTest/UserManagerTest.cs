using LogicLayer.Manager;
using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.DAL;

namespace UnitTest
{
    [TestClass]
    public class UserManagerTest
    {
        [TestMethod]
        public void CreateUser()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            string username1 = "bob";
            string password1 = "123";
            string email1 = "bob@gmail.com";
            string firstName1 = "bob";
            string lastName1 = "bob";
            string username2 = "abc123";
            string password2 = "123";
            string email2 = "abc@gmail.com";
            string firstName2 = "abc";
            string lastName2 = "abc";

            bool result1 = userManager.CreateUser(username1, password1, email1, firstName1, lastName1);
            bool result2 = userManager.CreateUser(username2, password2, email2, firstName2, lastName2);

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void CreateEmptyUser()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            string username1 = null;
            string password1 = "";
            string email1 = "";
            string firstName1 = "";
            string lastName1 = "";

            bool result1 = userManager.CreateUser(username1, password1, email1, firstName1, lastName1);

            Assert.IsFalse(result1);
        }

        [TestMethod]
        public void CreateUserWithSameUsername()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            string username1 = "bob";
            string password1 = "123";
            string email1 = "bob@gmail.com";
            string firstName1 = "bob";
            string lastName1 = "bob";


            bool result1 = userManager.CreateUser(username1, password1, email1, firstName1, lastName1);
            bool result2 = userManager.CreateUser(username1, password1, email1, firstName1, lastName1);

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void CheckLogin()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            string username = "bobobo";
            string password = "bobobo";

            bool result = userManager.CheckLogin(username, password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckWrongLogin()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            string username = "bobobo";
            string password = "bobobob";

            bool result = userManager.CheckLogin(username, password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckEmptyLogin()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            string username = "";
            string password = "";

            bool result = userManager.CheckLogin(username, password);

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void CheckLoginAdmin()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            string username = "bobobo2";
            string password = "bobobo";

            bool result = userManager.CheckLogin(username, password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckWrongLoginAdmin()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            string username = "bobobo2";
            string password = "bobobob";

            bool result = userManager.CheckLogin(username, password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckEmptyLoginAdmin()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            string username = "";
            string password = "";

            bool result = userManager.CheckLogin(username, password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateUser()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            User user = new User(1, "bobo", "1234", "abcd", "user", "bobo@gmail.com", "bob", "o");

            bool result = userManager.UpdateUser(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateUserEmpty()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            User user = new User(1, "", "", "", "", "", "", "");

            bool result = userManager.UpdateUser(user);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateUserNonExisting()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            User user = new User(1, "bob0", "1234", "abcd", "user", "bobo@gmail.com", "bob", "o");

            bool result = userManager.UpdateUser(user);

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void CheckUsername()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            bool result = userManager.CheckUsername("bob");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckSameUsername()
        {
            UserManager userManager = new UserManager(new MockUserDAL());

            bool result = userManager.CheckUsername("bob1");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetUserByUsername()
        {
            MockUserDAL mockUserDAL = new MockUserDAL();
            UserManager userManager = new UserManager(mockUserDAL);

            User user = userManager.GetUserByUsername("bob1");
            User user1 = mockUserDAL.GetUserByUsername("bob1");

            Assert.IsNotNull(user);
            Assert.AreEqual(user1, user1);
        }

        [TestMethod]
        public void GetUserByUsernameNonExisting()
        {
            MockUserDAL mockUserDAL = new MockUserDAL();
            UserManager userManager = new UserManager(mockUserDAL);

            User user = userManager.GetUserByUsername("bob");
            User user1 = mockUserDAL.GetUserByUsername("bob");

            Assert.IsNull(user);
            Assert.AreEqual(user1, user1);
        }

        [TestMethod]
        public void GetUserById()
        {
            MockUserDAL mockUserDAL = new MockUserDAL();
            UserManager userManager = new UserManager(mockUserDAL);

            User user = userManager.GetUserById(1);
            User user1 = mockUserDAL.GetUserById(1);

            Assert.IsNotNull(user);
            Assert.AreEqual(user1, user1);
        }

        [TestMethod]
        public void GetUserByIdNonExisting()
        {
            MockUserDAL mockUserDAL = new MockUserDAL();
            UserManager userManager = new UserManager(mockUserDAL);

            User user = userManager.GetUserById(10);
            User user1 = mockUserDAL.GetUserById(10);

            Assert.IsNull(user);
            Assert.AreEqual(user1, user1);
        }
    }
}
