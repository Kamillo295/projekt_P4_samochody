using Car_Rental.Data;
using Car_Rental.ViewModels;
using CarRental.ViewModels;
using System.Windows;
using System.Windows.Controls;
using CarRental.Services;

namespace CarRental.Views
{
    public partial class CarPage : Page
    {
        public CarViewModel ViewModel { get; set; }

        public CarPage()
        {
            InitializeComponent();
            // 1. Tworzymy fizyczny serwis do bazy danych
            ICarService mojSerwis = new CarService();

            // 2. Przekazujemy ten serwis do ViewModelu
            ViewModel = new CarViewModel(mojSerwis);

            // 3. Przypinamy ViewModel do widoku
            this.DataContext = ViewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Validate())
            {
                try
                {
                    ViewModel.ZapiszSamochod();

                    MessageBox.Show("Samochód został pomyślnie zapisany w bazie!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Czyścimy formularz przygotowując go na kolejne auto
                    ViewModel = new CarViewModel(new CarService());
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