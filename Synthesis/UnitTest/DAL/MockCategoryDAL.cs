using LogicLayer.Interface;
using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.DAL
{
    public class MockCategoryDAL : ICategory
    {
        private List<Category> categories;
        private int i = 0;

        public MockCategoryDAL() 
        {
            categories = new List<Category>()
            {
                new Category(i++,"fruit",null),
                new Category(i++,"orange",1),
                new Category(i++,"banana",1),
                new Category(i++,"meat",null),
                new Category(i++,"chicken",4)
            };
        }

        public List<Category> GetCategories()
        {
            return categories;
        }

        public Category GetCategoryByName(string categoryName)
        {
            foreach(Category c in categories)
                if(c.Name == categoryName)
                    return c;
            return null;
        }
    }
}
