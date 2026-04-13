using AutoMapper;
using CarRental.DTOs;
using CarRental.Models;

namespace Car_Rental.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
        }
    }
}
