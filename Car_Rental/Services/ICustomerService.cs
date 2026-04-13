using CarRental.DTOs;

namespace Car_Rental.Services;

public interface ICustomerService
{
    void AddCustomer(CustomerDto customer);
    void UpdateCustomer(CustomerDto customer);
    void DeleteCustomer(CustomerDto customer);
    List<CustomerDto> GetAllCustomers();
}
