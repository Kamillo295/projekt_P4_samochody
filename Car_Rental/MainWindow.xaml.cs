using System.Windows;
using Car_Rental.Views;
using CarRental.Views; // Upewnij się, że masz tu folder Views

namespace CarRental
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Opcjonalnie: Załaduj od razu stronę z samochodami po uruchomieniu aplikacji
            // (zakomentowałem to na razie, dopóki nie utworzysz CarPage)
            // MainFrame.Navigate(new CarPage());
        }

        // Kiedy klikniesz "Samochody", Ramka ładuje nową stronę z samochodami
        private void NavCars_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CarPage());
        }

        private void NavCustomers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CustomerPage());
        }

        private void NavRentals_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RentalPage());
        }
    }
}