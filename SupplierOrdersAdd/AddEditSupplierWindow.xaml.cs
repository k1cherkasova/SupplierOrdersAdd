using System.Collections.Generic;
using System;
using System.Windows;

namespace SupplierOrdersAdd
{
    public partial class AddEditOrderWindow : Window
    {
        public PurchaseOrder Order { get; private set; }

        public AddEditOrderWindow(PurchaseOrder order, List<Supplier> suppliers)
        {
            InitializeComponent();
            Order = order;

            SupplierComboBox.ItemsSource = suppliers;
            SupplierComboBox.SelectedValue = order.SupplierID;

            OrderDatePicker.SelectedDate = order.OrderDate;
            ExpectedDeliveryDatePicker.SelectedDate = order.ExpectedDeliveryDate;
            OrderStatusTextBox.Text = order.OrderStatus;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Order.SupplierID = (int)SupplierComboBox.SelectedValue;
            Order.OrderDate = OrderDatePicker.SelectedDate ?? DateTime.Now;
            Order.ExpectedDeliveryDate = ExpectedDeliveryDatePicker.SelectedDate ?? DateTime.Now;
            Order.OrderStatus = OrderStatusTextBox.Text;

            DialogResult = true;
            Close();
        }
    }
}