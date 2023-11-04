using LogicLayer.Interface;
using LogicLayer.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.DAL
{
    public class MockProductDAL : IProductDAL
    {
        private List<Product> products;
        private int i = 0;
        byte[] data = null;

        public MockProductDAL()
        {
            products = new List<Product>();
            AddDummyData();
        }

        public void AddDummyData()
        {
            products.Add(new Product(i++, "product0", 100, "1pcs", "no", data, new Category(1, "orange", 2), true));
            products.Add(new Product(i++, "product1", 101, "2pcs", "nope", data, new Category(1, "orange", 2), false));
            products.Add(new Product(i++, "product2", 1002, "3pcs", "nah", data, new Category(1, "orange", 2), true));
        }

        public bool CheckProductName(string name)
        {
            foreach (Product product in products)
                if (product.Name == name)
                    return true;
            return false;
        }

        public void CreateProduct(Product product)
        {
            product.Id = i++;
            products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            foreach(Product p in products)
                if(p.Id == product.Id)
                    p.Active= false;
        }

        public List<Product> GetAllActiveProducts()
        {
            List<Product> prod = new List<Product>();
            foreach(Product p in products)
                if(p.Active == true)
                    prod.Add(p);
            return prod;
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductByName(string name)
        {
            foreach (Product product in products)
                if (product.Name == name)
                    return product;
            return null;
        }

        public void UpdateProduct(Product product)
        {
            foreach (Product product1 in products)
                if (product1.Id == product.Id)
                {
                    product1.Name = product.Name;
                    product1.Price = product.Price;
                }
        }
    }
}
