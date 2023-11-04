using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interface
{
    public interface ICategory
    {
        List<Category> GetCategories();

        Category GetCategoryByName(string categoryName);
    }
}
