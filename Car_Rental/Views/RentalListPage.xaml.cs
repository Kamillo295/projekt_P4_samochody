using Car_Rental.Services;
using Car_Rental.ViewModels;
using CarRental.Models;
using CarRental.Services;
using CarRental.ViewModels;
using CarRental.Views;
using System.Windows;
using System.Windows.Controls;

namespace Car_Rental.Views
{
    public partial class RentalListPage : Page
    {
        public RentalViewModel ViewModel { get; set; }

        private readonly IRentalService _rentalService;
        private readonly ICarService _carService;
        private readonly ICustomerService _customerService;

        public RentalListPage()
        {
            InitializeComponent();

            // Inicjalizujemy wszystkie 3 "silniki" potrzebne do wynajmów
            _rentalService = new RentalService();
            _carService = new CarService();
            _customerService = new CustomerService();

            ViewModel = new RentalViewModel(_rentalService, _carService, _customerService);
            this.DataContext = ViewModel;
        }

        private void AddRental_Click(object sender, RoutedEventArgs e)
        {
            // Otwieramy okienko dodawania
            RentalFormWindow okienko = new RentalFormWindow(_rentalService, _carService, _customerService);
            okienko.ShowDialog();

            // Po zamknięciu odświeżamy listę
            ViewModel.WczytajWynajmy();
        }

        private void ReturnCar_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzamy czy coś zaznaczono w tabeli
            if (RentalsDataGrid.SelectedItem is Rental zaznaczonyWynajem)
            {
                var odpowiedz = MessageBox.Show($"Czy klient na pewno zwrócił pojazd? Spowoduje to usunięcie wpisu i przywrócenie auta do dostępnych.", "Potwierdzenie Zwrotu", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (odpowiedz == MessageBoxResult.Yes)
                {
                    _rentalService.DeleteRental(zaznaczonyWynajem);
                    ViewModel.WczytajWynajmy();
                    MessageBox.Show("Pojazd został zwrócony i jest ponownie dostępny do wynajmu!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Wybierz wynajem z listy, aby zwrócić pojazd.");
            }
        }
    }
}