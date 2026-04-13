using AutoMapper;
using CarRental.DTOs;
using CarRental.Models;

namespace CarRental.Profiles;   

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, CarDto>()
            .ForMember(c => c.FullCar, opt => opt.MapFrom(src => $"{src.Make} {src.Model}"))
            .ReverseMap();
        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ReverseMap();
        CreateMap<Rental, RentalDto>()
            .ForMember(dest => dest.CarFullName, opt => opt.MapFrom(src => $"{src.Car.Make} {src.Car.Model}"))
            .ForMember(dest => dest.CustomerFullName, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}"))
            .ReverseMap();
    }
}