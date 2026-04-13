using Car_Rental.Services;
using CarRental.Services;
using CarRental.ViewModels;
using System;
using System.Windows;

namespace CarRental.Views
{
    public partial class RentalFormWindow : Window
    {
        public RentalViewModel ViewModel { get; set; }

        public RentalFormWindow(IRentalService rentalService, ICarService carService, ICustomerService customerService)
        {
            InitializeComponent();
            ViewModel = new RentalViewModel(rentalService, carService, customerService);
            this.DataContext = ViewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Tutaj sprawdzamy, czy wybrano auto i klienta
                if (ViewModel.CarId == 0 || ViewModel.CustomerId == 0)
                {
                    MessageBox.Show("Musisz wybrać klienta oraz samochód!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                ViewModel.ZapiszWynajem();

                MessageBox.Show("Wynajem został zapisany! Samochód jest teraz niedostępny dla innych.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }
    }
}