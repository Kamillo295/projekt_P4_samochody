using System.Windows;
using System.Windows.Controls;
using CarRental.ViewModels;
using CarRental.Services;
using CarRental.Models;
using FluentValidation;
using CarRental.Validators;

namespace CarRental.Views
{
    public partial class CarListPage : Page
    {
        public CarViewModel ViewModel { get; set; }
        private readonly ICarService _carService;
        private readonly IValidator<Car> _carValidator;z

        public CarListPage()
        {
            InitializeComponent();
            _carService = new CarService();

            _carValidator = new CarValidator();
            ViewModel = new CarViewModel(_carService, _carValidator);
            this.DataContext = ViewModel;
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            // 1. Otwieramy nasze nowe okienko formularza w trybie DODAWANIA (nie dajemy auta)
            CarFormWindow okienko = new CarFormWindow(_carService);

            // 2. Program czeka w tej linijce, aż zamkniesz okienko!
            okienko.ShowDialog();

            // 3. Po zamknięciu okienka, odświeżamy tabelę
            ViewModel.WczytajSamochody();
        }

        private void EditCar_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzamy, czy użytkownik zaznaczył coś w tabeli
            if (CarsDataGrid.SelectedItem is Car zaznaczoneAuto)
            {
                // Otwieramy okienko w trybie EDYCJI (przekazujemy zaznaczoneAuto)
                CarFormWindow okienko = new CarFormWindow(_carService, zaznaczoneAuto);
                okienko.ShowDialog();
                ViewModel.WczytajSamochody();
            }
            else
            {
                MessageBox.Show("Wybierz samochód z listy, aby go edytować.");
            }
        }

        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            if (CarsDataGrid.SelectedItem is Car zaznaczoneAuto)
            {
                var odpowiedz = MessageBox.Show($"Czy na pewno chcesz usunąć {zaznaczoneAuto.Make}?", "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (odpowiedz == MessageBoxResult.Yes)
                {
                    _carService.DeleteCar(zaznaczoneAuto);
                    ViewModel.WczytajSamochody();
                }
            }
            else
            {
                MessageBox.Show("Wybierz samochód z listy, aby go usunąć.");
            }
        }
    }
}