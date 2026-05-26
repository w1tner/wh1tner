using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SalesApp
{
    public class SaleManager
    {
        public List<Sale> Sales { get; private set; }
        private bool useFileStorage = true; // флаг для тестов

        // Основной конструктор (использует файл)
        public SaleManager()
        {
            Sales = new List<Sale>();
            if (File.Exists("sales.txt"))
            {
                LoadSales();
            }
        }

        // Новый конструктор для тестов (не использует файл)
        public SaleManager(bool useFile)
        {
            Sales = new List<Sale>();
            this.useFileStorage = useFile;
            if (useFile && File.Exists("sales.txt"))
            {
                LoadSales();
            }
        }

        public void AddSale(Sale sale)
        {
            if (sale == null)
                throw new ArgumentNullException(nameof(sale));

            Sales.Add(sale);
            if (useFileStorage) SaveSales();
        }

        public void RemoveSale(Sale sale)
        {
            if (sale == null)
                throw new ArgumentNullException(nameof(sale));

            Sales.Remove(sale);
            if (useFileStorage) SaveSales();
        }


        public decimal TotalRevenue
        {
            get { return Sales.Sum(s => s.TotalRevenue); }
        }

        private void SaveSales()
        {
            var lines = Sales.Select(s => $"{s.ProductName}|{s.Price}|{s.Quantity}|{s.Date:yyyy-MM-dd HH:mm:ss}");
            File.WriteAllLines("sales.txt", lines);
        }

        private void LoadSales()
        {
            if (File.Exists("sales.txt"))
            {
                var lines = File.ReadAllLines("sales.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        if (decimal.TryParse(parts[1], out decimal price) &&
                            int.TryParse(parts[2], out int quantity) &&
                            DateTime.TryParse(parts[3], out DateTime date))
                        {
                            Sales.Add(new Sale(parts[0], price, quantity, date));
                        }
                    }
                }
            }
        }

        public string GenerateReport()
        {
            if (Sales.Count == 0)
                return "No sales to generate report.";

            string report = "SALES REPORT\n";
            report += "==================\n\n";

            foreach (var sale in Sales)
            {
                report += $"Product: {sale.ProductName}\n";
                report += $"Price: {sale.Price:C}\n";
                report += $"Quantity: {sale.Quantity}\n";
                report += $"Date: {sale.Date:dd.MM.yyyy}\n";
                report += $"Revenue: {sale.TotalRevenue:C}\n";
                report += "------------------\n";
            }

            report += $"\nTOTAL REVENUE: {TotalRevenue:C}";

            File.WriteAllText("sales_report.txt", report);
            return report;
        }
    }
}