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
            // Teraz odpali się nasza nowa metoda sprawdzająca daty i puste pola!
            if (ViewModel.Validate())
            {
                try
                {
                    ViewModel.ZapiszWynajem();
                    MessageBox.Show("Wynajem został zapisany! Samochód jest teraz niedostępny.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Formularz zawiera błędy. Sprawdź czerwone komunikaty.", "Błąd Walidacji", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}