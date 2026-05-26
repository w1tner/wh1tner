using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesApp;  

namespace SalesApp.Tests 
{
    [TestClass]
    public class SaleManagerTests
    {
        private SaleManager CreateManager()
        {
            return new SaleManager(false);
        }

        [TestMethod]
        public void AddSale_ValidSale_AddsSaleToList()
        {
            SaleManager manager = CreateManager();
            Sale sale = new Sale("Phone", 30000m, 1, DateTime.Now);

            manager.AddSale(sale);

            Assert.AreEqual(1, manager.Sales.Count);
            Assert.IsTrue(manager.Sales.Contains(sale));
        }

        [TestMethod]
        public void RemoveSale_ExistingSale_RemovesFromList()
        {
            SaleManager manager = CreateManager();
            Sale sale = new Sale("Headphones", 5000m, 1, DateTime.Now);
            manager.AddSale(sale);

            manager.RemoveSale(sale);

            Assert.AreEqual(0, manager.Sales.Count);
        }

        [TestMethod]
        public void TotalRevenue_WithMultipleSales_ReturnsSum()
        {
            SaleManager manager = CreateManager();
            manager.AddSale(new Sale("ProductA", 100m, 2, DateTime.Now));
            manager.AddSale(new Sale("ProductB", 200m, 3, DateTime.Now));

            decimal total = manager.TotalRevenue;

            Assert.AreEqual(800m, total);
        }

        [TestMethod]
        public void TotalRevenue_WithNoSales_ReturnsZero()
        {
            SaleManager manager = CreateManager();
            decimal total = manager.TotalRevenue;
            Assert.AreEqual(0m, total);
        }

        [TestMethod]
        public void AddSale_AfterRemoving_WorksCorrectly()
        {
            SaleManager manager = CreateManager();
            Sale firstSale = new Sale("First", 100m, 1, DateTime.Now);
            Sale secondSale = new Sale("Second", 200m, 1, DateTime.Now);

            manager.AddSale(firstSale);
            manager.RemoveSale(firstSale);
            manager.AddSale(secondSale);

            Assert.AreEqual(1, manager.Sales.Count);
            Assert.AreEqual("Second", manager.Sales[0].ProductName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddSale_NullSale_ThrowsArgumentNullException()
        {
            SaleManager manager = CreateManager();
            manager.AddSale(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveSale_NullSale_ThrowsArgumentNullException()
        {
            SaleManager manager = CreateManager();
            manager.RemoveSale(null);
        }

        [TestMethod]
        public void RemoveSale_NonExistentSale_DoesNothing()
        {
            SaleManager manager = CreateManager();
            Sale existingSale = new Sale("Existing", 100m, 1, DateTime.Now);
            Sale nonExistentSale = new Sale("NonExistent", 100m, 1, DateTime.Now);
            manager.AddSale(existingSale);
            int initialCount = manager.Sales.Count;

            manager.RemoveSale(nonExistentSale);

            Assert.AreEqual(initialCount, manager.Sales.Count);
        }

        [TestMethod]
        public void GenerateReport_WithNoSales_ReturnsEmptyMessage()
        {
            SaleManager manager = CreateManager();
            string report = manager.GenerateReport();
            Assert.IsTrue(report.Contains("No sales"));
        }
    }
}