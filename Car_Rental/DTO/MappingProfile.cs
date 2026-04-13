using AutoMapper;
using CarRental.DTOs;
using CarRental.Models;

namespace CarRental.Profiles   // spójna i czytelna przestrzeń nazw
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
        }
    }
}