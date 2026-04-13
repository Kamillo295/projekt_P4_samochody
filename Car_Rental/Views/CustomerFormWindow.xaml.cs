using System.Windows;
using Car_Rental.Services;
using Car_Rental.ViewModels;
using CarRental.DTOs; 
using FluentValidation; 

namespace Car_Rental.Views;

public partial class CustomerFormWindow : Window
{
    public CustomerViewModel ViewModel { get; set; }
    private bool _isEditMode;

    public CustomerFormWindow(ICustomerService customerService, IValidator<CustomerDto> validator, CustomerDto customerToEdit = null)
    {
        InitializeComponent();

        ViewModel = new CustomerViewModel(customerService, validator);

        if (customerToEdit != null)
        {
            ViewModel.CustomerRecord = customerToEdit;
            _isEditMode = true;
            Title = "Edycja Klienta";
        }
        else
        {
            _isEditMode = false;
            Title = "Dodaj Nowego Klienta";
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
                    ViewModel.AktualizujKlienta();
                    MessageBox.Show("Zaktualizowano pomyślnie!");
                }
                else
                {
                    ViewModel.ZapiszKlienta();
                    MessageBox.Show("Dodano nowego Klienta!");
                }
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisu: {ex.Message}");
            }
        }
    }
}