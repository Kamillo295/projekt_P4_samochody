using System;
using System.Windows;
using CarRental.ViewModels;
using CarRental.Services;
using CarRental.DTOs;
using FluentValidation;
using AutoMapper;

namespace CarRental.Views
{
    public partial class CarFormWindow : Window
    {
        public CarViewModel ViewModel { get; set; }
        private bool _isEditMode;

        // Przyjmujemy wszystkie niezbędne serwisy i opcjonalne DTO
        public CarFormWindow(ICarService carService, IValidator<CarDto> validator, IMapper mapper, CarDto carToEdit = null)
        {
            InitializeComponent();

            ViewModel = new CarViewModel(carService, validator, mapper);

            if (carToEdit != null)
            {
                ViewModel.CarRecord = carToEdit;
                _isEditMode = true;
                Title = "Edycja Samochodu";
            }
            else
            {
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
                    if (_isEditMode)
                    {
                        ViewModel.AktualizujSamochod();
                        MessageBox.Show("Zaktualizowano pomyślnie!");
                    }
                    else
                    {
                        ViewModel.ZapiszSamochod();
                        MessageBox.Show("Dodano nowy samochód!");
                    }

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