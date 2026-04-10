using CarRental.Models;

namespace Car_Rental.Services
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void UpadteCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        List<Customer> GetAllCustomers();
    }
}
