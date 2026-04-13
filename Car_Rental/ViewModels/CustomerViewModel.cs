using System.ComponentModel;
using System.Collections.ObjectModel;
using CarRental.DTOs;
using Car_Rental.Services;
using FluentValidation;

namespace Car_Rental.ViewModels;

public class CustomerViewModel : IDataErrorInfo, INotifyPropertyChanged
{
    private readonly ICustomerService _customerService;
    private readonly IValidator<CustomerDto> _validator;

    public CustomerDto CustomerRecord { get; set; } = new CustomerDto();
    public ObservableCollection<CustomerDto> ListaKlientow { get; set; }

    private List<string> _dotknietePola = new List<string>();
    private bool _pokazujWszystkieBledy = false;

    public CustomerViewModel(ICustomerService customerService, IValidator<CustomerDto> validator)
    {
        _customerService = customerService;
        _validator = validator;

        ListaKlientow = new ObservableCollection<CustomerDto>();
        WczytajKlientow();
    }

    public void WczytajKlientow()
    {
        var klienciZBazy = _customerService.GetAllCustomers();

        ListaKlientow.Clear();
        foreach (var k in klienciZBazy)
        {
            ListaKlientow.Add(k);
        }
    }

    public void AktualizujKlienta()
    {
        _customerService.UpdateCustomer(CustomerRecord);
    }

    public void ZapiszKlienta()
    {
        _customerService.AddCustomer(CustomerRecord);
    }

    public string FirstName
    {
        get { return CustomerRecord.FirstName; }
        set { CustomerRecord.FirstName = value; _dotknietePola.Add("FirstName"); OnPropertyChanged("FirstName"); }
    }

    public string LastName
    {
        get { return CustomerRecord.LastName; }
        set { CustomerRecord.LastName = value; _dotknietePola.Add("LastName"); OnPropertyChanged("LastName"); }
    }

    public string Email
    {
        get { return CustomerRecord.Email; }
        set { CustomerRecord.Email = value; _dotknietePola.Add("Email"); OnPropertyChanged("Email"); }
    }

    public string PhoneNumber
    {
        get { return CustomerRecord.PhoneNumber; }
        set { CustomerRecord.PhoneNumber = value; _dotknietePola.Add("PhoneNumber"); OnPropertyChanged("PhoneNumber"); }
    }

    public string DrivingLicenseNumber
    {
        get { return CustomerRecord.DrivingLicenseNumber; }
        set { CustomerRecord.DrivingLicenseNumber = value; _dotknietePola.Add("DrivingLicenseNumber"); OnPropertyChanged("DrivingLicenseNumber"); }
    }

    public bool Validate()
    {
        _pokazujWszystkieBledy = true;
        OnPropertyChanged("FirstName");
        OnPropertyChanged("LastName");
        OnPropertyChanged("Email");
        OnPropertyChanged("PhoneNumber");
        OnPropertyChanged("DrivingLicenseNumber");

        var result = _validator.Validate(CustomerRecord);
        return result.IsValid;
    }

    public string Error => null;
    public string this[string columnName]
    {
        get
        {
            if (!_pokazujWszystkieBledy && !_dotknietePola.Contains(columnName)) return null;

            var result = _validator.Validate(CustomerRecord);

            foreach (var error in result.Errors)
            {
                if (error.PropertyName == columnName) return error.ErrorMessage;
            }
            return null;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}