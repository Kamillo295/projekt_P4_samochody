using Car_Rental.Data;
using CarRental.Models;

namespace Car_Rental.Services
{
    public class CustomerService : ICustomerService
    {
        public void AddCustomer(Customer customer)
        {
            using (var context = new CarRentalContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void UpadteCustomer(Customer customer)
        {
            using ( var context = new CarRentalContext())
            {
                context.Customers.Update(customer);
                context.SaveChanges();
            }
        }

        public void DeleteCustomer(Customer customer)
        {
            using (var context = new CarRentalContext())
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
        }

        public List<Customer> GetAllCustomers()
        {
            using (var context = new CarRentalContext())
            {
                return context.Customers.ToList();
            }
        }
    }
}
