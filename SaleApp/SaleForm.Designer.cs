using System.Drawing;
using System.Windows.Forms;

namespace SalesApp
{
    partial class SaleForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox productNameTextBox;
        private TextBox priceTextBox;
        private TextBox quantityTextBox;
        private DateTimePicker datePicker;
        private Button addSaleButton;
        private Button removeSaleButton;
        private Button generateReportButton;
        private ListBox salesListBox;
        private Label totalRevenueLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.productNameTextBox = new TextBox();
            this.priceTextBox = new TextBox();
            this.quantityTextBox = new TextBox();
            this.datePicker = new DateTimePicker();
            this.addSaleButton = new Button();
            this.removeSaleButton = new Button();
            this.generateReportButton = new Button();
            this.salesListBox = new ListBox();
            this.totalRevenueLabel = new Label();
            this.SuspendLayout();

            // productNameTextBox
            this.productNameTextBox.Location = new Point(20, 20);
            this.productNameTextBox.Size = new Size(150, 23);
            this.productNameTextBox.TabIndex = 0;

            // priceTextBox
            this.priceTextBox.Location = new Point(180, 20);
            this.priceTextBox.Size = new Size(100, 23);
            this.priceTextBox.TabIndex = 1;

            // quantityTextBox
            this.quantityTextBox.Location = new Point(290, 20);
            this.quantityTextBox.Size = new Size(80, 23);
            this.quantityTextBox.TabIndex = 2;

            // datePicker
            this.datePicker.Location = new Point(380, 20);
            this.datePicker.Size = new Size(180, 23);
            this.datePicker.TabIndex = 3;
            this.datePicker.Format = DateTimePickerFormat.Short;

            // addSaleButton
            this.addSaleButton.Location = new Point(20, 60);
            this.addSaleButton.Size = new Size(100, 30);
            this.addSaleButton.Text = "Добавить";
            this.addSaleButton.UseVisualStyleBackColor = true;
            this.addSaleButton.Click += new System.EventHandler(this.AddSaleButton_Click);

            // removeSaleButton
            this.removeSaleButton.Location = new Point(130, 60);
            this.removeSaleButton.Size = new Size(100, 30);
            this.removeSaleButton.Text = "Удалить";
            this.removeSaleButton.UseVisualStyleBackColor = true;
            this.removeSaleButton.Click += new System.EventHandler(this.RemoveSaleButton_Click);

            // generateReportButton
            this.generateReportButton.Location = new Point(240, 60);
            this.generateReportButton.Size = new Size(150, 30);
            this.generateReportButton.Text = "Сформировать отчёт";
            this.generateReportButton.UseVisualStyleBackColor = true;
            this.generateReportButton.Click += new System.EventHandler(this.GenerateReportButton_Click);

            // salesListBox
            this.salesListBox.Location = new Point(20, 100);
            this.salesListBox.Size = new Size(540, 250);
            this.salesListBox.Font = new Font("Consolas", 10);
            this.salesListBox.TabIndex = 4;

            // totalRevenueLabel
            this.totalRevenueLabel.Location = new Point(20, 360);
            this.totalRevenueLabel.Size = new Size(300, 30);
            this.totalRevenueLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            this.totalRevenueLabel.Text = "Общий доход: 0 ₽";

            // SaleForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(580, 400);
            this.Controls.Add(this.productNameTextBox);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.addSaleButton);
            this.Controls.Add(this.removeSaleButton);
            this.Controls.Add(this.generateReportButton);
            this.Controls.Add(this.salesListBox);
            this.Controls.Add(this.totalRevenueLabel);
            this.Text = "Управление продажами";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ResumeLayout(false);
            this.PerformLayout();

            // Цвета для кнопок
            this.addSaleButton.BackColor = Color.FromArgb(76, 175, 80);    // Зеленый
            this.removeSaleButton.BackColor = Color.FromArgb(244, 67, 54); // Красный
            this.generateReportButton.BackColor = Color.FromArgb(33, 150, 243); // Синий

            // Цвет фона формы
            this.BackColor = Color.FromArgb(240, 240, 245);

            // Цвет и рамка для списка
            this.salesListBox.BackColor = Color.FromArgb(250, 250, 255);
            this.salesListBox.BorderStyle = BorderStyle.FixedSingle;

            // Жирный шрифт для общего дохода
            this.totalRevenueLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            this.totalRevenueLabel.ForeColor = Color.FromArgb(76, 175, 80);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}