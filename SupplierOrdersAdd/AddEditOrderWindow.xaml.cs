using System.Windows;

namespace SupplierOrdersAdd
{
    public partial class AddEditSupplierWindow : Window
    {
        public Supplier Supplier { get; private set; }

        public AddEditSupplierWindow(Supplier supplier)
        {
            InitializeComponent();
            Supplier = supplier;

            SupplierNameTextBox.Text = supplier.SupplierName;
            ContactNameTextBox.Text = supplier.ContactName;
            PhoneNumberTextBox.Text = supplier.PhoneNumber;
            EmailAddressTextBox.Text = supplier.EmailAddress;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Supplier.SupplierName = SupplierNameTextBox.Text;
            Supplier.ContactName = ContactNameTextBox.Text;
            Supplier.PhoneNumber = PhoneNumberTextBox.Text;
            Supplier.EmailAddress = EmailAddressTextBox.Text;

            DialogResult = true;
            Close();
        }
    }
}