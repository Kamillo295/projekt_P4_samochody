using System.Windows;
using Car_Rental.Services;
using Car_Rental.ViewModels;
using CarRental.Models;

namespace Car_Rental.Views
{
    public partial class CustomerFormWindow : Window
    {
        public CustomerViewModel ViewModel { get; set; }
        private bool _isEditMode;

        public CustomerFormWindow(ICustomerService customerService, Customer customerToEdit = null)
        {
            InitializeComponent();

            ViewModel = new CustomerViewModel(customerService);

            if(customerToEdit != null )
            {
                ViewModel.CustomerRecord = customerToEdit;
                _isEditMode = true;
                Title = "Edycja Klienta";
            }
            else
            {
                _isEditMode = false;
                Title = "Dodaj Nowego Klienta";
            }

            DataContext = ViewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(ViewModel.Validate())
            {
                try
                {
                    if(_isEditMode)
                    {
                        ViewModel.AktualizujKliena();
                        MessageBox.Show("Zaktualizowano pomyślnie!");
                    }
                    else
                    {
                        ViewModel.ZapiszKlienta();
                        MessageBox.Show("Dodano nowego Klienta!");
                    }
                    DialogResult = true;
                    Close();
                }   
                catch(Exception ex)
                {
                    MessageBox.Show($"Błąd zapisu: {ex.Message}");
                }
            }
        }
    }
}
