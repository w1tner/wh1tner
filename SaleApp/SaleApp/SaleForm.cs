using System;
using System.Windows.Forms;
using System.Linq;

namespace SalesApp
{
    public partial class SaleForm : Form
    {
        private SaleManager saleManager;

        public SaleForm()
        {
            InitializeComponent();
            saleManager = new SaleManager();
            UpdateSalesList();
            UpdateTotalRevenue();
        }

        private void UpdateSalesList()
        {
            salesListBox.Items.Clear();
            foreach (var sale in saleManager.Sales)
            {
                salesListBox.Items.Add($"{sale.ProductName} | {sale.Price:C} x {sale.Quantity} = {sale.TotalRevenue:C} | {sale.Date:dd.MM.yyyy}");
            }
        }

        private void UpdateTotalRevenue()
        {
            totalRevenueLabel.Text = $"Общий доход: {saleManager.TotalRevenue:C}";
        }

        private void AddSaleButton_Click(object sender, EventArgs e)
        {
            // Проверка пустых полей
            if (string.IsNullOrWhiteSpace(productNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(priceTextBox.Text) ||
                string.IsNullOrWhiteSpace(quantityTextBox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка цены
            if (!decimal.TryParse(priceTextBox.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Цена должна быть положительным числом!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка количества
            if (!int.TryParse(quantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Количество должно быть целым положительным числом!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newSale = new Sale(
                    productNameTextBox.Text.Trim(),
                    price,
                    quantity,
                    datePicker.Value
                );

                saleManager.AddSale(newSale);

                // Очистка полей
                productNameTextBox.Clear();
                priceTextBox.Clear();
                quantityTextBox.Clear();
                datePicker.Value = DateTime.Now;

                UpdateSalesList();
                UpdateTotalRevenue();

                MessageBox.Show("Продажа добавлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveSaleButton_Click(object sender, EventArgs e)
        {
            if (salesListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите продажу для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedItem = salesListBox.SelectedItem.ToString();
            string productName = selectedItem.Split('|')[0].Trim();

            var saleToRemove = saleManager.Sales.FirstOrDefault(s => s.ProductName == productName);
            if (saleToRemove != null)
            {
                var result = MessageBox.Show($"Удалить продажу '{productName}'?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    saleManager.RemoveSale(saleToRemove);
                    UpdateSalesList();
                    UpdateTotalRevenue();

                    MessageBox.Show("Продажа удалена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            string report = saleManager.GenerateReport();

            if (report.StartsWith("Нет продаж"))
            {
                MessageBox.Show(report, "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Отчёт сформирован и сохранён в файл sales_report.txt", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}