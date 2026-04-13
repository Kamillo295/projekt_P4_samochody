using CarRental.Models;

namespace Car_Rental.Services
{
    public interface IRentalService
    {
        void AddRental(Rental rental);
        List<Rental> GetAllRentals();
        void DeleteRental(Rental rental);
    }
}
