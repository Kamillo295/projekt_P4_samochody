using System.ComponentModel;
using CarRental.Models;
using CarRental.Validators;
using System.Collections.ObjectModel; // Potrzebne do ObservableCollection
using CarRental.Services;
using CarRental.DTOs;

namespace CarRental.ViewModels
{
    public class CarViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        // Prywatna zmienna, w której przechowujemy "Silnik" przekazany z zewnątrz
        private readonly ICarService _carService;

        public Car CarRecord { get; set; } = new Car();
        public ObservableCollection<CarDisplayDto> ListaSamochodow {  get; set; }

        private List<string> _dostkietePola = new List<string>();
        private bool _pokazujWszystkieBledy = false;

        public CarViewModel(ICarService carService)
        {
            _carService = carService;

            ListaSamochodow = new ObservableCollection<CarDisplayDto>();
            WczytajSamochody();
        }

        public void WczytajSamochody()
        {
            var samochodZBazy = _carService.GetAllCars();

            ListaSamochodow.Clear();
            foreach(var auto in samochodZBazy)
            {
                ListaSamochodow.Add(auto);
            }
        }

        public void ZapiszSamochod()
        {
            _carService.AddCar(CarRecord);
        }

        public string Make
        {
            get { return CarRecord.Make; }
            set
            {
                CarRecord.Make = value;
                _dostkietePola.Add("Make");
                OnPropertyChanged("Make");
            }
        }

        public string Model
        {
            get { return CarRecord.Model; }
            set 
            {
                CarRecord.Model = value;
                _dostkietePola.Add("Model");
                OnPropertyChanged("Model");
            }
        }

        public int Year
        {
            get { return CarRecord.Year; }
            set
            {
                CarRecord.Year = value;
                _dostkietePola.Add("Year");
                OnPropertyChanged("Year");
            }
        }

        public string RegistrationNumber
        {
            get { return CarRecord.RegistrationNumber; }
            set
            {
                CarRecord.RegistrationNumber = value;
                _dostkietePola.Add("RegistrationNumber");
                OnPropertyChanged("RegistrationNumber");
            }
        }

        public decimal PricePerDay
        {
            get { return CarRecord.PricePerDay; }
            set
            {
                CarRecord.PricePerDay = value;
                _dostkietePola.Add("PricePerDay");
                OnPropertyChanged("PricePerDay");
            }
        }

        public bool IsAvailable
        {
            get { return CarRecord.IsAvailable; }
            set
            {
                CarRecord.IsAvailable = value;
                _dostkietePola.Add("IsAvailable");
                OnPropertyChanged("IsAvailable");
            }
        }

        public bool Validate()
        {
            _pokazujWszystkieBledy = true;
            OnPropertyChanged("Make");
            OnPropertyChanged("Model");
            OnPropertyChanged("Year");
            OnPropertyChanged("RegistrationNumber");
            OnPropertyChanged("PricePerDay");

            CarValidator validator = new CarValidator();
            var result = validator.Validate(CarRecord);

            return result.IsValid;
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if(_pokazujWszystkieBledy == false && _dostkietePola.Contains(columnName) == false)
                {
                    return null;
                }

                CarValidator validator = new CarValidator();
                var result = validator.Validate(CarRecord);

                foreach (var error in result.Errors)
                {
                    if(error.PropertyName == columnName)
                    {
                        return error.ErrorMessage;
                    }
                }
                return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}