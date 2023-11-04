using LogicLayer.Interface;
using LogicLayer.Object;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LogicLayer.Manager
{
    public class ProductManager
    {
        private IProductDAL iproduct;

        public ProductManager(IProductDAL iproduct)
        {
            this.iproduct = iproduct;
        }

        public bool CreateProduct(string name, double price, string unit, string description, byte[] image, Category category)
        {
            Product product = new Product(name, price, unit, description, image, category, true);

            if (CheckProductName(name) == true)
                return false;

            try
            {
                iproduct.CreateProduct(product);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                // I want to make a check to see if there is more than one product with that name
                //
                //if (CheckProductName(product.Name) == true)
                //{
                //    return false;
                //}
                    iproduct.UpdateProduct(product);
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                return iproduct.GetAllProducts();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Product> GetAllActiveProducts()
        {
            try
            {
                return iproduct.GetAllActiveProducts();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CheckProductName(string name)
        {
            try
            {
                return iproduct.CheckProductName(name);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Product GetProductByName(string name)
        {
            try
            {
                return iproduct.GetProductByName(name);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
