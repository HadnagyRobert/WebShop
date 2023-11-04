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
    public class CategoryManagerTest
    {
        [TestMethod]
        public void GetCategories()
        {
            MockCategoryDAL mockCategoryDAL = new MockCategoryDAL();
            CategoryManager categoryManager = new CategoryManager(mockCategoryDAL);

            List<Category> categories= categoryManager.GetCategories();
            List<Category> categories1= mockCategoryDAL.GetCategories();

            Assert.IsNotNull(categories);
            Assert.IsNotNull(categories1);
            CollectionAssert.AreEquivalent(categories1, categories);
        }

        [TestMethod]
        public void GetCategoryByName()
        {
            string name = "orange";

            MockCategoryDAL mockCategoryDAL = new MockCategoryDAL();
            CategoryManager categoryManager = new CategoryManager(mockCategoryDAL);

            Category category = categoryManager.GetCategoryByName(name);
            Category category1 = mockCategoryDAL.GetCategoryByName(name);

            Assert.IsNotNull(category);
            Assert.IsNotNull(category1);
            Assert.AreEqual(category, category1);
        }

        [TestMethod]
        public void GetCategoryByWrongName()
        {
            string name = "orangee";

            MockCategoryDAL mockCategoryDAL = new MockCategoryDAL();
            CategoryManager categoryManager = new CategoryManager(mockCategoryDAL);

            Category category = categoryManager.GetCategoryByName(name);
            Category category1 = mockCategoryDAL.GetCategoryByName(name);

            Assert.IsNull(category);
            Assert.IsNull(category1);
            Assert.AreEqual(category, category1);
        }
    }
}
