using Car_Rental.Services;
using Car_Rental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Car_Rental.Views
{
    public partial class CustomerListPage : Page
    {
        public CustomerViewModel ViewModel { get; set; }
        private readonly ICustomerService _customerService;

        public CustomerListPage()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            ViewModel = new CustomerViewModel(_customerService);
            DataContext = ViewModel;
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditCar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
