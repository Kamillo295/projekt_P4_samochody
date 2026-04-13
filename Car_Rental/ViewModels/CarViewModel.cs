using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using CarRental.DTOs;
using CarRental.Services;
using FluentValidation;
using AutoMapper;

namespace CarRental.ViewModels;

public class CarViewModel : IDataErrorInfo, INotifyPropertyChanged
{
    private readonly ICarService _carService;
    private readonly IValidator<CarDto> _validator;
    private readonly IMapper _mapper;

    public CarDto CarRecord { get; set; } = new CarDto();
    public ObservableCollection<CarDto> ListaSamochodow { get; set; }

    private List<string> _dotknietePola = new List<string>();
    private bool _pokazujWszystkieBledy = false;

    public CarViewModel(ICarService carService, IValidator<CarDto> validator, IMapper mapper)
    {
        _carService = carService;
        _validator = validator;
        _mapper = mapper;

        ListaSamochodow = new ObservableCollection<CarDto>();
        WczytajSamochody();
    }

    public void WczytajSamochody()
    {
        var samochodyZBazy = _carService.GetAllCars();
        ListaSamochodow.Clear();
        foreach (var auto in samochodyZBazy)
        {
            ListaSamochodow.Add(auto);
        }
    }

    public void AktualizujSamochod() => _carService.UpdateCar(CarRecord);
    public void ZapiszSamochod() => _carService.AddCar(CarRecord);

    public string Make
    {
        get => CarRecord.Make;
        set { CarRecord.Make = value; _dotknietePola.Add("Make"); OnPropertyChanged("Make"); }
    }

    public string Model
    {
        get => CarRecord.Model;
        set { CarRecord.Model = value; _dotknietePola.Add("Model"); OnPropertyChanged("Model"); }
    }

    public int Year
    {
        get => CarRecord.Year;
        set { CarRecord.Year = value; _dotknietePola.Add("Year"); OnPropertyChanged("Year"); }
    }

    public string RegistrationNumber
    {
        get => CarRecord.RegistrationNumber;
        set { CarRecord.RegistrationNumber = value; _dotknietePola.Add("RegistrationNumber"); OnPropertyChanged("RegistrationNumber"); }
    }

    public decimal PricePerDay
    {
        get => CarRecord.PricePerDay;
        set { CarRecord.PricePerDay = value; _dotknietePola.Add("PricePerDay"); OnPropertyChanged("PricePerDay"); }
    }

    public bool IsAvailable
    {
        get => CarRecord.IsAvailable;
        set { CarRecord.IsAvailable = value; _dotknietePola.Add("IsAvailable"); OnPropertyChanged("IsAvailable"); }
    }

    public bool Validate()
    {
        _pokazujWszystkieBledy = true;
        OnPropertyChanged("Make"); OnPropertyChanged("Model"); OnPropertyChanged("Year");
        OnPropertyChanged("RegistrationNumber"); OnPropertyChanged("PricePerDay");

        return _validator.Validate(CarRecord).IsValid;
    }

    public string Error => null;

    public string this[string columnName]
    {
        get
        {
            if (!_pokazujWszystkieBledy && !_dotknietePola.Contains(columnName)) return null;

            var result = _validator.Validate(CarRecord);
            foreach (var error in result.Errors)
            {
                if (error.PropertyName == columnName) return error.ErrorMessage;
            }
            return null;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}