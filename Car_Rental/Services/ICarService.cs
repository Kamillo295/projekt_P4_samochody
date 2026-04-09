using System.Collections.Generic;
using CarRental.DTOs;
using CarRental.Models;

namespace CarRental.Services
{
    // Mówi tylko CO robimy (bez wnikania jak)
    public interface ICarService
    {
        void AddCar(Car car);
        List<CarDisplayDto> GetAllCars();
    }
}