using System;
using System.Windows;
using CarRental.ViewModels;
using CarRental.Services;
using CarRental.Models;
using FluentValidation;
using CarRental.Validators;

namespace CarRental.Views
{
    public partial class CarFormWindow : Window
    {
        public CarViewModel ViewModel { get; set; }
        private bool _isEditMode;

        // Konstruktor przyjmuje Serwis oraz (opcjonalnie) Samochód do edycji
        public CarFormWindow(ICarService carService, Car carToEdit = null)
        {
            InitializeComponent();

            // Tworzymy ViewModel i dajemy mu serwis
            IValidator<Car> carValidator = new CarValidator();

            ViewModel = new CarViewModel(carService, carValidator);

            if (carToEdit != null)
            {
                // TRYB EDYCJI: Wrzucamy przekazane auto do ViewModelu
                ViewModel.CarRecord = carToEdit;
                _isEditMode = true;
                Title = "Edycja Samochodu";
            }
            else
            {
                // TRYB DODAWANIA: ViewModel ma już czyste new Car() ze swojego wnętrza
                _isEditMode = false;
                Title = "Dodaj Nowy Samochód";
            }

            DataContext = ViewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Validate())
            {
                try
                {
                    // W zależności od trybu, dodajemy lub aktualizujemy
                    if (_isEditMode)
                    {
                        // Dodaj metodę UpdateCar do swojego CarViewModel! (Wywoła ona _carService.UpdateCar(CarRecord))
                        ViewModel.AktualizujSamochod();
                        MessageBox.Show("Zaktualizowano pomyślnie!");
                    }
                    else
                    {
                        ViewModel.ZapiszSamochod();
                        MessageBox.Show("Dodano nowy samochód!");
                    }

                    // Po udanym zapisie ZAMYKAMY to małe okienko
                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd zapisu: {ex.Message}");
                }
            }
        }
    }
}