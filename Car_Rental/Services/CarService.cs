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

    public void AddCar(CarDto carDto)
    {
        using (var context = new CarRentalContext())
        {
            var entity = _mapper.Map<Car>(carDto);
            context.Cars.Add(entity);
            context.SaveChanges();
        }
    }

    public void UpdateCar(CarDto carDto)
    {
        using (var context = new CarRentalContext())
        {
            var entity = _mapper.Map<Car>(carDto);
            context.Cars.Update(entity);
            context.SaveChanges();
        }
    }

    public void DeleteCar(CarDto carDto)
    {
        using (var context = new CarRentalContext())
        {
            var entity = _mapper.Map<Car>(carDto);
            context.Cars.Remove(entity);
            context.SaveChanges();
        }
    }

    public List<CarDto> GetAllCars()
    {
        using (var context = new CarRentalContext())
        {
            var cars = context.Cars.ToList();
            return _mapper.Map<List<CarDto>>(cars);
        }
    }
}