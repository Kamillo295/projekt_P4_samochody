using System.ComponentModel;
using CarRental.Models;
using CarRental.Validators;

namespace Car_Rental.ViewModels
{
    public class CustomerViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        public Customer CustomerRecord { get; set; } = new Customer();

        private List<string> _dotknietePola = new List<string>();
        private bool _pokazujWszystkieBledy = false;

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

            CustomerValidator validator = new CustomerValidator();
            var result = validator.Validate(CustomerRecord);
            return result.IsValid;
        }

        public string Error => null;
        public string this[string columnName]
        {
            get
            {
                if (!_pokazujWszystkieBledy && !_dotknietePola.Contains(columnName)) return null;

                CustomerValidator validator = new CustomerValidator();
                var result = validator.Validate(CustomerRecord);

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
}
