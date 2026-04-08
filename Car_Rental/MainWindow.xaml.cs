using System.Windows;
using Car_Rental.Views;
using CarRental.Views;

namespace CarRental
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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