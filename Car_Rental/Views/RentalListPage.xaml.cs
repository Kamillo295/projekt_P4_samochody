using System.Windows;
using System.Windows.Controls;
using Car_Rental.Services;
using CarRental.Services;
using CarRental.ViewModels;
using CarRental.Views;
using CarRental.DTOs;
using CarRental.Validators;
using FluentValidation;
using AutoMapper;
using CarRental.Profiles;

namespace Car_Rental.Views;

public partial class RentalListPage : Page
{
    public RentalViewModel ViewModel { get; set; }

    private readonly IRentalService _rentalService;
    private readonly ICarService _carService;
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;
    private readonly IValidator<RentalDto> _rentalValidator;

    public RentalListPage()
    {
        InitializeComponent();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        _mapper = config.CreateMapper();

        _rentalService = new RentalService(_mapper);
        _carService = new CarService(_mapper);
        _customerService = new CustomerService(_mapper);

        _rentalValidator = new RentalValidator();

        ViewModel = new RentalViewModel(_rentalService, _carService, _customerService, _rentalValidator);
        this.DataContext = ViewModel;
    }

    private void AddRental_Click(object sender, RoutedEventArgs e)
    {
        RentalFormWindow okienko = new RentalFormWindow(_rentalService, _carService, _customerService, _rentalValidator);
        okienko.ShowDialog();

        ViewModel.WczytajWynajmy();
    }

    private void ReturnCar_Click(object sender, RoutedEventArgs e)
    {
        if (RentalsDataGrid.SelectedItem is RentalDto zaznaczonyWynajem)
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