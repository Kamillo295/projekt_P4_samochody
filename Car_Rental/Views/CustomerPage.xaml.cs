using System.Windows;
using System.Windows.Controls; // Wymagane dla obiektu Page
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
                MessageBox.Show("Klient został pomyślnie zapisany w bazie!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                // Czyścimy formularz poprzez zresetowanie ViewModelu
                ViewModel = new CustomerViewModel();
                this.DataContext = ViewModel;
            }
            else
            {
                MessageBox.Show("Formularz zawiera błędy. Popraw zaznaczone na czerwono pola.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}