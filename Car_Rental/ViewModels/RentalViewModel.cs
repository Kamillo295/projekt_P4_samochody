using System;
using System.Collections.Generic;
using System.ComponentModel;
using CarRental.Models;
using CarRental.Validators;

namespace Car_Rental.ViewModels
{
    public class RentalViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        public Rental RentalRecord { get; set; }

        private List<string> _dotknietePola = new List<string>();
        private bool _pokazujWszystkieBledy = false;

        public RentalViewModel()
        {
            RentalRecord = new Rental
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1),
            };
        }

        public DateTime StartDate
        {
            get { return RentalRecord.StartDate; }
            set { RentalRecord.StartDate = value; _dotknietePola.Add("StartDate"); OnPropertyChanged("StartDate"); }
        }
        public DateTime EndDate
        {
            get { return RentalRecord.EndDate; }
            set { RentalRecord.EndDate = value; _dotknietePola.Add("EndDate"); OnPropertyChanged("EndDate"); }
        }
        public decimal TotalPrice
        {
            get { return RentalRecord.TotalPrice; }
            set { RentalRecord.TotalPrice = value; _dotknietePola.Add("TotalPrice"); OnPropertyChanged("TotalPrice"); }
        }
        public int CarId
        {
            get { return RentalRecord.CarId; }
            set { RentalRecord.CarId = value; _dotknietePola.Add("CarId"); OnPropertyChanged("CarId"); }
        }
        public int CustomerId
        {
            get { return RentalRecord.CustomerId; }
            set { RentalRecord.CustomerId = value; _dotknietePola.Add("CustomerId"); OnPropertyChanged("CustomerId"); }
        }

        public bool Validate()
        {
            _pokazujWszystkieBledy = true;
            OnPropertyChanged("StartDate");
            OnPropertyChanged("EndDate");
            OnPropertyChanged("TotalPrice");
            OnPropertyChanged("CarId");
            OnPropertyChanged("CustomerId");

            RentalValidator validator = new RentalValidator();
            var result = validator.Validate(RentalRecord);
            return result.IsValid;
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (!_pokazujWszystkieBledy && !_dotknietePola.Contains(columnName))
                    return null;

                RentalValidator validator = new RentalValidator();
                var result = validator.Validate(RentalRecord);

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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
