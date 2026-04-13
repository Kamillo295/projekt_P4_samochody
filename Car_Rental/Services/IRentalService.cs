using CarRental.DTOs;

namespace Car_Rental.Services;

public interface IRentalService
{
    void AddRental(RentalDto rental);
    List<RentalDto> GetAllRentals();
    void DeleteRental(RentalDto rental);
}
