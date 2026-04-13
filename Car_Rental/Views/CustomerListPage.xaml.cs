using System.Windows;
using System.Windows.Controls;
using Car_Rental.Services;
using Car_Rental.ViewModels;
using CarRental.DTOs;
using CarRental.Validators;
using FluentValidation;
using AutoMapper;
using CarRental.Profiles;

namespace Car_Rental.Views;

public partial class CustomerListPage : Page
{
    private readonly IMapper _mapper;
    private readonly ICustomerService _customerService;
    private readonly IValidator<CustomerDto> _customerValidator;

    public CustomerViewModel ViewModel { get; set; }

    public CustomerListPage()
    {
        InitializeComponent();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        _mapper = config.CreateMapper();

        _customerService = new CustomerService(_mapper);
        _customerValidator = new CustomerValidator();

        ViewModel = new CustomerViewModel(_customerService, _customerValidator);
        DataContext = ViewModel;
    }

    private void AddCustomer_Click(object sender, RoutedEventArgs e)
    {
        CustomerFormWindow okienko = new CustomerFormWindow(_customerService, _customerValidator);
        okienko.ShowDialog();
        ViewModel.WczytajKlientow();
    }

    private void EditCustomer_Click(object sender, RoutedEventArgs e)
    {
        if (CustomerDataGrid.SelectedItem is CustomerDto zaznaczonyKlient)
        {
            CustomerFormWindow okienko = new CustomerFormWindow(_customerService, _customerValidator, zaznaczonyKlient);
            okienko.ShowDialog();
            ViewModel.WczytajKlientow();
        }
        else
        {
            MessageBox.Show("Wybierz Klienta z listy, aby go edytować.");
        }
    }

    private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
    {
        if (CustomerDataGrid.SelectedItem is CustomerDto zaznaczonyKlient)
        {
            var odpowiedz = MessageBox.Show($"Czy na pewno chcesz usunąć {zaznaczonyKlient.FirstName} {zaznaczonyKlient.LastName}?", "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (odpowiedz == MessageBoxResult.Yes)
            {
                _customerService.DeleteCustomer(zaznaczonyKlient);
                ViewModel.WczytajKlientow();
            }
        }
        else
        {
            MessageBox.Show("Wybierz Klienta z listy, aby go usunąć.");
        }
    }
}