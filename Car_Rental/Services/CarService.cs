using System.Collections.Generic;
using System.Linq;
using CarRental.Models;
using Car_Rental.Data;
using CarRental.DTOs;
using AutoMapper;

namespace CarRental.Services;

public class CarService : ICarService
{
    private readonly IMapper _mapper;
    public CarService(IMapper mapper)
    {
        _mapper = mapper;
    }
    public void AddCar(Car car)
    {
        using (var context = new CarRentalContext())
        {
            context.Cars.Add(car);
            context.SaveChanges();
        }
    }

    public void UpdateCar(Car car)
    {
        using (var context = new CarRentalContext())
        {
            context.Cars.Update(car);
            context.SaveChanges();
        }
    }

    public void DeleteCar(Car car)
    {
        using (var context = new CarRentalContext())
        {
            context.Cars.Remove(car);
            context.SaveChanges();
        }
    }

    public List<Car> GetAllCars()
    {
        using (var context = new CarRentalContext())
        {
            return context.Cars.ToList();
        }
    }
}