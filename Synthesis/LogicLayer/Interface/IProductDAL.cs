using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interface
{
    public interface IProductDAL
    {
        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);

        bool CheckProductName(string name);

        List<Product> GetAllProducts();

        List<Product> GetAllActiveProducts();

        Product GetProductByName(string name);
    }
}
