using Car_Rental.Services;
using CarRental.DTOs;
using CarRental.Services;
using FluentValidation; 
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CarRental.ViewModels
{
    public class RentalViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly IRentalService _rentalService;
        private readonly ICarService _carService;
        private readonly ICustomerService _customerService;
        private readonly IValidator<RentalDto> _validator; 

        public RentalDto RentalRecord { get; set; } = new RentalDto();
        public ObservableCollection<CarDto> ListaSamochodow { get; set; }
        public ObservableCollection<CustomerDto> ListaKlientow { get; set; }
        public ObservableCollection<RentalDto> ListaWynajmow { get; set; }

        private List<string> _dotknietePola = new List<string>();
        private bool _pokazujWszystkieBledy = false;

        public RentalViewModel(IRentalService rentalService, ICarService carService, ICustomerService customerService, IValidator<RentalDto> validator)
        {
            _rentalService = rentalService;
            _carService = carService;
            _customerService = customerService;
            _validator = validator;

            ListaSamochodow = new ObservableCollection<CarDto>();
            ListaKlientow = new ObservableCollection<CustomerDto>(); 
            ListaWynajmow = new ObservableCollection<RentalDto>();

            RentalRecord.StartDate = DateTime.Today;
            RentalRecord.EndDate = DateTime.Today.AddDays(1);

            WczytajListyDoComboBoxow();
            PrzeliczCene();
            WczytajWynajmy();
        }

        private void WczytajListyDoComboBoxow()
        {
            var auta = _carService.GetAllCars().Where(a => a.IsAvailable == true).ToList();
            ListaSamochodow.Clear();
            foreach (var auto in auta)
            {
                ListaSamochodow.Add(auto);
            }

            var klienci = _customerService.GetAllCustomers();
            ListaKlientow.Clear();
            foreach (var klient in klienci)
            {
                ListaKlientow.Add(klient);
            }
        }

        public void WczytajWynajmy()
        {
            var wynajmyZBazy = _rentalService.GetAllRentals();
            ListaWynajmow.Clear();
            foreach (var wynajem in wynajmyZBazy)
            {
                ListaWynajmow.Add(wynajem);
            }
        }

        public int CarId
        {
            get { return RentalRecord.CarId; }
            set
            {
                RentalRecord.CarId = value;
                _dotknietePola.Add("CarId");
                OnPropertyChanged("CarId");
                PrzeliczCene();
            }
        }

        public int CustomerId
        {
            get { return RentalRecord.CustomerId; }
            set
            {
                RentalRecord.CustomerId = value;
                _dotknietePola.Add("CustomerId");
                OnPropertyChanged("CustomerId");
            }
        }

        public DateTime StartDate
        {
            get { return RentalRecord.StartDate; }
            set
            {
                RentalRecord.StartDate = value;
                _dotknietePola.Add("StartDate");
                OnPropertyChanged("StartDate");
                PrzeliczCene();
            }
        }

        public DateTime EndDate
        {
            get { return RentalRecord.EndDate; }
            set
            {
                RentalRecord.EndDate = value;
                _dotknietePola.Add("EndDate");
                OnPropertyChanged("EndDate");
                PrzeliczCene();
            }
        }

        public decimal TotalPrice
        {
            get { return RentalRecord.TotalPrice; }
            set { RentalRecord.TotalPrice = value; OnPropertyChanged("TotalPrice"); }
        }

        private void PrzeliczCene()
        {
            if (CarId > 0 && EndDate > StartDate)
            {
                var wybraneAuto = ListaSamochodow.FirstOrDefault(c => c.Id == CarId);

                if (wybraneAuto != null)
                {
                    int dni = (EndDate - StartDate).Days;
                    if (dni <= 0) dni = 1;

                    TotalPrice = dni * wybraneAuto.PricePerDay;
                }
            }
            else
            {
                TotalPrice = 0;
            }
        }

        public bool Validate()
        {
            _pokazujWszystkieBledy = true;

            OnPropertyChanged("CarId");
            OnPropertyChanged("CustomerId");
            OnPropertyChanged("StartDate");
            OnPropertyChanged("EndDate");
            OnPropertyChanged("TotalPrice");

            var result = _validator.Validate(RentalRecord);

            return result.IsValid;
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (_pokazujWszystkieBledy == false && _dotknietePola.Contains(columnName) == false)
                {
                    return null;
                }

                var result = _validator.Validate(RentalRecord);

                foreach (var error in result.Errors)
                {
                    if (error.PropertyName == columnName)
                    {
                        return error.ErrorMessage;
                    }
                }

                return null;
            }
        }

        public void ZapiszWynajem()
        {
            _rentalService.AddRental(RentalRecord);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}