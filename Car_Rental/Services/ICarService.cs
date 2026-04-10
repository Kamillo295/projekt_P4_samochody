using CarRental.Models;

namespace CarRental.Services
{
    public interface ICarService
    {
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car);
        List<Car> GetAllCars();
    }
}