using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesApp;  

namespace SalesApp.Tests  
{
    [TestClass]
    public class SaleTests
    {
        [TestMethod]
        public void Constructor_ValidParameters()
        {
            string expectedName = "Laptop";
            decimal expectedPrice = 50000m;
            int expectedQuantity = 2;
            DateTime expectedDate = new DateTime(2024, 5, 20);

            Sale sale = new Sale(expectedName, expectedPrice, expectedQuantity, expectedDate);

            Assert.AreEqual(expectedName, sale.ProductName);
            Assert.AreEqual(expectedPrice, sale.Price);
            Assert.AreEqual(expectedQuantity, sale.Quantity);
            Assert.AreEqual(expectedDate, sale.Date);
        }

        [TestMethod]
        public void TotalRevenue_Price()
        {
            Sale sale = new Sale("Mouse", 100m, 5, DateTime.Now);
            decimal revenue = sale.TotalRevenue;
            Assert.AreEqual(500m, revenue);
        }

        [TestMethod]
        public void TotalRevenue_WithDecimalPrice()
        {
            Sale sale = new Sale("Product", 99.99m, 5, DateTime.Now);
            decimal revenue = sale.TotalRevenue;
            Assert.AreEqual(499.95m, revenue);
        }

        [TestMethod]
        public void TotalRevenue_WithZeroQuantity()
        {
            Sale sale = new Sale("Keyboard", 2000m, 0, DateTime.Now);
            decimal revenue = sale.TotalRevenue;
            Assert.AreEqual(0m, revenue);
        }

        [TestMethod]
        public void Constructor_WithEmptyProductName()
        {
            Sale sale = new Sale("", 100m, 1, DateTime.Now);
            Assert.AreEqual("", sale.ProductName);
        }

        [TestMethod]
        public void Constructor_WithNullProductName()
        {
            Sale sale = new Sale(null, 100m, 1, DateTime.Now);
            Assert.IsNull(sale.ProductName);
        }

        [TestMethod]
        public void Constructor_WithNegativePrice()
        {
            Sale sale = new Sale("Product", -500m, 1, DateTime.Now);
            Assert.AreEqual(-500m, sale.Price);
        }

        [TestMethod]
        public void Constructor_WithNegativeQuantity()
        {
            Sale sale = new Sale("Product", 100m, -3, DateTime.Now);
            Assert.AreEqual(-3, sale.Quantity);
        }

        [TestMethod]
        public void TotalRevenue_WithNegativeQuantity()
        {
            Sale sale = new Sale("Product", 100m, -3, DateTime.Now);
            decimal revenue = sale.TotalRevenue;
            Assert.AreEqual(-300m, revenue);
        }
    }
}