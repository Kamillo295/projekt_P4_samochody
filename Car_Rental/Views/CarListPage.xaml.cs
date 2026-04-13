using System.Windows;
using System.Windows.Controls;
using CarRental.ViewModels;
using CarRental.Services;
using CarRental.DTOs;
using CarRental.Validators;
using FluentValidation;
using AutoMapper;

namespace CarRental.Views
{
    public partial class CarListPage : Page
    {
        private readonly IMapper _mapper;
        public CarViewModel ViewModel { get; set; }
        private readonly ICarService _carService;
        private readonly IValidator<CarDto> _carValidator;


        public CarListPage()
        {
            InitializeComponent();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = config.CreateMapper();


            _carService = new CarService(_mapper);
            _carValidator = new CarValidator();

            ViewModel = new CarViewModel(_carService, _carValidator, _mapper);
            this.DataContext = ViewModel;
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            CarFormWindow okienko = new CarFormWindow(_carService, _carValidator, _mapper);
            okienko.ShowDialog();
            ViewModel.WczytajSamochody();
        }

        private void EditCar_Click(object sender, RoutedEventArgs e)
        {
            if (CarsDataGrid.SelectedItem is CarDto zaznaczoneAuto)
            {
                CarFormWindow okienko = new CarFormWindow(_carService, _carValidator, _mapper, zaznaczoneAuto);
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
            if (CarsDataGrid.SelectedItem is CarDto zaznaczoneAuto)
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