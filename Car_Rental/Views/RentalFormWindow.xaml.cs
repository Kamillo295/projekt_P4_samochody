using System.Windows;
using Car_Rental.Services;
using CarRental.Services;
using CarRental.ViewModels;
using CarRental.DTOs;
using FluentValidation;

namespace CarRental.Views;

public partial class RentalFormWindow : Window
{
    public RentalViewModel ViewModel { get; set; }

    public RentalFormWindow(
        IRentalService rentalService,
        ICarService carService,
        ICustomerService customerService,
        IValidator<RentalDto> validator)
    {
        InitializeComponent();

        ViewModel = new RentalViewModel(rentalService, carService, customerService, validator);
        this.DataContext = ViewModel;
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
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
                MessageBox.Show($"Wystąpił błąd podczas zapisu: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else
        {
            MessageBox.Show("Formularz zawiera błędy. Sprawdź czerwone komunikaty przy polach.", "Błąd Walidacji", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}