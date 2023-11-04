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
    public class ProductManagerTest
    {
        byte[] data = null;

        [TestMethod]
        public void CreateProduct()
        {
            ProductManager productManager = new ProductManager(new MockProductDAL());

            string name1 = "product3";
            string name2 = "product4";
            double price1 = 123.45;
            double price2 = 123.45;
            string unit1 = "1pcs";
            string unit2 = "2pcs";
            string description1 = "Description";
            string description2 = "nope";
            Category category = new Category(1,"orange",null);

            bool result1 = productManager.CreateProduct(name1, price1, unit1, description1, data, category);
            bool result2 = productManager.CreateProduct(name2, price2,unit2,description2,data,category);

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void CreateProductWithSameName()
        {
            ProductManager productManager = new ProductManager(new MockProductDAL());

            string name1 = "product3";
            double price1 = 123.45;
            string unit1 = "1pcs";
            string description1 = "Description";
            Category category = new Category(1, "orange", null);

            bool result1 = productManager.CreateProduct(name1, price1, unit1, description1, data, category);
            bool result2 = productManager.CreateProduct(name1, price1, unit1, description1, data, category);

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void CheckProductName()
        {
            ProductManager productManager = new ProductManager(new MockProductDAL());

            bool result = productManager.CheckProductName("product");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckSameProductName()
        {
            ProductManager productManager = new ProductManager(new MockProductDAL());

            bool result = productManager.CheckProductName("product1");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetAllProducts()
        {
            MockProductDAL mockDAL = new MockProductDAL();
            ProductManager productManager = new ProductManager(mockDAL);

            List<Product> products = productManager.GetAllProducts();
            List<Product> expectedProducts = mockDAL.GetAllProducts();

            CollectionAssert.AreEquivalent(expectedProducts, products);
        }

        [TestMethod]
        public void GetAllProductsAdd()
        {
            MockProductDAL mockDAL = new MockProductDAL();
            ProductManager productManager = new ProductManager(mockDAL);

            productManager.CreateProduct("product0", 100, "1pcs", "no", data, new Category(1, "orange", 2));
            productManager.CreateProduct("product1", 101, "2pcs", "nah", data, new Category(2, "oranges", 3));

            List<Product> products = productManager.GetAllProducts();
            List<Product> expectedProducts = mockDAL.GetAllProducts();

            CollectionAssert.AreEquivalent(expectedProducts, products);
        }

        [TestMethod]
        public void GetProductByName()
        {
            MockProductDAL mockProductDAL = new MockProductDAL();
            ProductManager productManager = new ProductManager(mockProductDAL);

            Product product = productManager.GetProductByName("product1");
            Product product1 = mockProductDAL.GetProductByName("product1");

            Assert.IsNotNull(product);
            Assert.AreEqual(product1, product);
        }

        [TestMethod]
        public void GetProductByNameAdd()
        {
            MockProductDAL mockProductDAL = new MockProductDAL();
            ProductManager productManager = new ProductManager(mockProductDAL);

            productManager.CreateProduct("product10", 101, "2pcs", "nope", data, new Category(1, "orange", 2));

            Product product = mockProductDAL.GetProductByName("product10");
            Product product1 = productManager.GetProductByName("product10");

            Assert.AreEqual(product, product1);
        }

        [TestMethod]
        public void GetProductByNameNonisting()
        {
            ProductManager productManager = new ProductManager(new MockProductDAL());

            Product product = productManager.GetProductByName("product");

            Assert.IsNull(product);
        }
    }
}
