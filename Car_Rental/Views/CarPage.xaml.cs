using Car_Rental.Data;
using Car_Rental.ViewModels;
using CarRental.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CarRental.Views
{
    public partial class CarPage : Page
    {
        public CarViewModel ViewModel { get; set; }

        public CarPage()
        {
            InitializeComponent();
            ViewModel = new CarViewModel();
            this.DataContext = ViewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Validate())
            {
                try
                {
                    // 1. Otwieramy połączenie z bazą danych
                    using (var context = new CarRentalContext())
                    {
                        // 2. Dodajemy nasz sprawdzony samochód z ViewModelu do tabeli Cars
                        context.Cars.Add(ViewModel.CarRecord);

                        // 3. Wysłanie komendy zapisu do serwera SQL
                        context.SaveChanges();
                    }

                    MessageBox.Show("Samochód został pomyślnie zapisany w bazie!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Czyścimy formularz przygotowując go na kolejne auto
                    ViewModel = new CarViewModel();
                    this.DataContext = ViewModel;
                }
                catch (Exception ex)
                {
                    // Jeśli coś pójdzie nie tak (np. brak połączenia z bazą), pokażemy błąd
                    MessageBox.Show($"Wystąpił błąd podczas zapisu do bazy: {ex.Message}", "Błąd Bazy Danych", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Formularz zawiera błędy. Popraw zaznaczone na czerwono pola.", "Błąd Walidacji", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}