using Car_Rental.Services;
using Car_Rental.ViewModels;
using System.Windows;
using System.Windows.Controls;
using CarRental.Models;

namespace Car_Rental.Views
{
    public partial class CustomerListPage : Page
    {
        public CustomerViewModel ViewModel { get; set; }
        private readonly ICustomerService _customerService;

        public CustomerListPage()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            ViewModel = new CustomerViewModel(_customerService);
            DataContext = ViewModel;
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerFormWindow okienko = new CustomerFormWindow(_customerService);
            okienko.ShowDialog();
            ViewModel.WczytajKlientow();
        }

        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is Customer zaznaczonyKlient)
            {
                CustomerFormWindow okienko = new CustomerFormWindow(_customerService, zaznaczonyKlient);
                okienko.ShowDialog();
                ViewModel.WczytajKlientow();
            }
            else
            {
                MessageBox.Show("Wybierz Klienta z listy, aby go edytować.");
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is Customer zaznaczonyKlient)
            {
                var odpowiedz = MessageBox.Show($"Czy na pewno chcesz usunąć {zaznaczonyKlient.FirstName} {zaznaczonyKlient.LastName}?", "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (odpowiedz == MessageBoxResult.Yes)
                {
                    _customerService.DeleteCustomer(zaznaczonyKlient);
                    ViewModel.WczytajKlientow();
                }
            }
            else
            {
                MessageBox.Show("Wybierz Klienta z listy, aby go edytować.");
            }
        }
    }
}
