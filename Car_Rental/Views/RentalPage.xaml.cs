using Car_Rental.Data;
using Car_Rental.ViewModels;
using CarRental.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Car_Rental.Views
{

    public partial class RentalPage : Page
    {
        public RentalViewModel ViewModel { get; set; }
        public RentalPage()
        {
            InitializeComponent();
            ViewModel = new RentalViewModel();
            DataContext = ViewModel;
        }

        private void SaveRental_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Validate())
            {
                try
                {
                    using (var context = new CarRentalContext())
                    {
                        context.Rentals.Add(ViewModel.RentalRecord);
                        context.SaveChanges();
                    }

                    MessageBox.Show("Wynajem został pomyślnie zarejestrowany w bazie!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                    ViewModel = new RentalViewModel();
                    this.DataContext = ViewModel;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas zapisu do bazy: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Formularz zawiera błędy. Sprawdź czerwone komunikaty.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
