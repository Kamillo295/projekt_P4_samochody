using AutoMapper;
using Car_Rental.Data;
using CarRental.DTOs;
using CarRental.Models;

namespace Car_Rental.Services;

public class CustomerService : ICustomerService
{
    private readonly IMapper _mapper;

    public CustomerService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void AddCustomer(CustomerDto customerDto)
    {
        using (var context = new CarRentalContext())
        {
            var entity = _mapper.Map<Customer>(customerDto);
            context.Customers.Add(entity);
            context.SaveChanges();
        }
    }

    public void UpdateCustomer(CustomerDto customerDto)
    {
        using (var context = new CarRentalContext())
        {
            var entity = _mapper.Map<Customer>(customerDto);
            context.Customers.Update(entity);
            context.SaveChanges();
        }
    }

    public void DeleteCustomer(CustomerDto customerDto)
    {
        using (var context = new CarRentalContext())
        {
            var entity = _mapper.Map<Customer>(customerDto);
            context.Customers.Remove(entity);
            context.SaveChanges();
        }
    }

    public List<CustomerDto> GetAllCustomers()
    {
        using (var context = new CarRentalContext())
        {
            var customersFromDb = context.Customers.ToList();
            return _mapper.Map<List<CustomerDto>>(customersFromDb);
        }
    }
}