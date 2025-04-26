using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SupplierOrdersAdd
{
    public partial class MainWindow : Window
    {
        private SuppliersAndOrdersEntities _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new SuppliersAndOrdersEntities();
            LoadSuppliersData();
            LoadOrdersData();
        }

        private void LoadSuppliersData()
        {
            var suppliers = _context.Supplier.ToList();
            SuppliersDataGrid.ItemsSource = suppliers;
        }

        private void LoadOrdersData()
        {
            var orders = _context.PurchaseOrder.Include("Supplier").ToList();
            OrdersDataGrid.ItemsSource = orders;
        }

        private void AddSupplier_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddEditSupplierWindow(new Supplier());
            if (addWindow.ShowDialog() == true)
            {
                _context.Supplier.Add(addWindow.Supplier);
                _context.SaveChanges();
                LoadSuppliersData();
            }
        }

        private void EditSupplier_Click(object sender, RoutedEventArgs e)
        {
            var selectedSupplier = SuppliersDataGrid.SelectedItem as Supplier;
            if (selectedSupplier == null)
            {
                MessageBox.Show("Выберите поставщика для редактирования.");
                return;
            }

            var editWindow = new AddEditSupplierWindow(selectedSupplier);
            if (editWindow.ShowDialog() == true)
            {
                _context.SaveChanges();
                LoadSuppliersData();
            }
        }

        private void DeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            var selectedSupplier = SuppliersDataGrid.SelectedItem as Supplier;
            if (selectedSupplier == null)
            {
                MessageBox.Show("Выберите поставщика для удаления.");
                return;
            }

            _context.Supplier.Remove(selectedSupplier);
            _context.SaveChanges();
            LoadSuppliersData();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddEditOrderWindow(new PurchaseOrder(), _context.Supplier.ToList());
            if (addWindow.ShowDialog() == true)
            {
                _context.PurchaseOrder.Add(addWindow.Order);
                _context.SaveChanges();
                LoadOrdersData();
            }
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = OrdersDataGrid.SelectedItem as PurchaseOrder;
            if (selectedOrder == null)
            {
                MessageBox.Show("Выберите заказ для редактирования.");
                return;
            }

            var editWindow = new AddEditOrderWindow(selectedOrder, _context.Supplier.ToList());
            if (editWindow.ShowDialog() == true)
            {
                _context.SaveChanges();
                LoadOrdersData();
            }
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = OrdersDataGrid.SelectedItem as PurchaseOrder;
            if (selectedOrder == null)
            {
                MessageBox.Show("Выберите заказ для удаления.");
                return;
            }

            _context.PurchaseOrder.Remove(selectedOrder);
            _context.SaveChanges();
            LoadOrdersData();
        }
    }
}