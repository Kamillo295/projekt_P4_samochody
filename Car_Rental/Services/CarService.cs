using System.Collections.Generic;
using System.Linq;
using CarRental.Models;
using Car_Rental.Data;
using CarRental.DTOs;

namespace CarRental.Services
{
    // Wykonuje czarną robotę z bazą danych
    public class CarService : ICarService
    {
        public void AddCar(Car car)
        {
            using (var context = new CarRentalContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }

        public List<CarDisplayDto> GetAllCars()
        {
            using (var context = new CarRentalContext())
            {
                return context.Cars.Select(c => new CarDisplayDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    RegistrationNumber = c.RegistrationNumber,
                    PricePerDay = c.PricePerDay,
                    IsAvailable = c.IsAvailable
                }).ToList();
            }
        }
    }
}