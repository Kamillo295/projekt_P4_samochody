using Car_Rental.Services;
using CarRental.Models;
using CarRental.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace CarRental.ViewModels
{
    public class RentalViewModel : INotifyPropertyChanged
    {
        private readonly IRentalService _rentalService;
        private readonly ICarService _carService;
        private readonly ICustomerService _customerService;

        public Rental RentalRecord { get; set; } = new Rental();
        public ObservableCollection<Car> ListaSamochodow { get; set; }
        public ObservableCollection<Customer> ListaKlientow { get; set; }
        public ObservableCollection<Rental> ListaWynajmow { get; set; }

        public RentalViewModel(IRentalService rentalService, ICarService carService, ICustomerService customerService)
        {
            _rentalService = rentalService;
            _carService = carService;
            _customerService = customerService;

            ListaSamochodow = new ObservableCollection<Car>();
            ListaKlientow = new ObservableCollection<Customer>();
            ListaWynajmow = new ObservableCollection<Rental>();

            RentalRecord.StartDate = DateTime.Today;
            RentalRecord.EndDate = DateTime.Today.AddDays(1);

            WczytajListyDoComboBoxow();
            PrzeliczCene();
            WczytajWynajmy();
        }

        private void WczytajListyDoComboBoxow()
        {
            var auta = _carService.GetAllCars();
            foreach (var auto in auta)
            {
                if (auto.IsAvailable)
                {
                    ListaSamochodow.Add(auto);
                }
            }

            var klienci = _customerService.GetAllCustomers();
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
                OnPropertyChanged("CarId");
                PrzeliczCene(); 
            }
        }

        public int CustomerId
        {
            get { return RentalRecord.CustomerId; }
            set { RentalRecord.CustomerId = value; OnPropertyChanged("CustomerId"); }
        }

        public DateTime StartDate
        {
            get { return RentalRecord.StartDate; }
            set
            {
                RentalRecord.StartDate = value;
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