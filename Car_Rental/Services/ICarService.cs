using CarRental.Models;
using CarRental.DTOs;

namespace CarRental.Services;

public interface ICarService
{
    void AddCar(CarDto car);
    void UpdateCar(CarDto car);
    void DeleteCar(CarDto car);
    List<CarDto> GetAllCars();
}