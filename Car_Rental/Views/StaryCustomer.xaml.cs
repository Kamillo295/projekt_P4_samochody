using System.Windows;
using System.Windows.Controls;
using Car_Rental.Data;
using Car_Rental.Services;
using Car_Rental.ViewModels;
using CarRental.ViewModels;

namespace CarRental.Views
{
    public partial class CustomerPage : Page
    {
        public CustomerViewModel ViewModel { get; set; }

        public CustomerPage()
        {
            InitializeComponent();
            ViewModel = new CustomerViewModel();
            this.DataContext = ViewModel;
        }

        private void SaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Validate())
            {
                try
                {
                    using (var context = new CarRentalContext())
                    {
                        context.Customers.Add(ViewModel.CustomerRecord);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Klient został pomyślnie zapisany w bazie!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                    ViewModel = new CustomerViewModel();
                    this.DataContext = ViewModel;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas zapisu do bazy: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Formularz zawiera błędy. Popraw zaznaczone na czerwono pola.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}