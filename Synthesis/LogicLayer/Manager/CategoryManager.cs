using LogicLayer.Interface;
using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Manager
{
    public class CategoryManager
    {
        private ICategory icategory;

        public CategoryManager(ICategory icategory)
        {
            this.icategory = icategory;
        }

        public List<Category> GetCategories()
        {
            try
            {
                return icategory.GetCategories();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Category GetCategoryByName(string categoryName)
        {
            try
            {
                return icategory.GetCategoryByName(categoryName);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
