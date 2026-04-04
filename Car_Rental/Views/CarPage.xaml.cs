using System.Windows.Controls;
using System.Windows;
using CarRental.ViewModels;
using Car_Rental.ViewModels;

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
                MessageBox.Show("Klient został pomyślnie zapisany w bazie!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                // Czyścimy formularz poprzez zresetowanie ViewModelu
                ViewModel = new CarViewModel();
                this.DataContext = ViewModel;
            }
            else
            {
                MessageBox.Show("Formularz zawiera błędy. Popraw zaznaczone na czerwono pola.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}