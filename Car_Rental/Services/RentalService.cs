using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Car_Rental.Data;
using CarRental.DTOs;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental.Services;

public class RentalService : IRentalService
{
    private readonly IMapper _mapper;
    public RentalService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void AddRental(RentalDto rentalDto)
    {
        using (var context = new CarRentalContext())
        {
            var entity = _mapper.Map<Rental>(rentalDto);
            context.Rentals.Add(entity);
            var autoDoWynajęcia = context.Cars.FirstOrDefault(c => c.Id == entity.CarId);
            if (autoDoWynajęcia != null)
            {
                autoDoWynajęcia.IsAvailable = false;
                context.Cars.Update(autoDoWynajęcia);
            }

            context.SaveChanges();
        }
    }

    public List<RentalDto> GetAllRentals()
    {
        using (var context = new CarRentalContext())
        {
            var rentalsFromDb = context.Rentals
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .ToList();
            return _mapper.Map<List<RentalDto>>(rentalsFromDb);
        }
    }

    public void DeleteRental(RentalDto rentalDto)
    {
        using (var context = new CarRentalContext())
        {
            var entity = _mapper.Map<Rental>(rentalDto);
            context.Rentals.Remove(entity);

            var autoDoZwrotu = context.Cars.FirstOrDefault(c => c.Id == entity.CarId);
            if (autoDoZwrotu != null)
            {
                autoDoZwrotu.IsAvailable = true;
                context.Cars.Update(autoDoZwrotu);
            }

            context.SaveChanges();
        }
    }
}