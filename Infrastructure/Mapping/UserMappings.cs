using AutoMapper;
using UserViewBack.Domain.Dto;
using UserViewBack.Domain.Models;

namespace UserViewBack.Infrastructure.Mapping
{
    public class UserMappings: Profile
    {
        public UserMappings() {
            // Mapeo bidireccional
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            // Mapeo una direccion
            CreateMap<User, UserReadDto>();
            // Mapeo bidireccional
            CreateMap<Address, AddressCreateDto>().ReverseMap();
            CreateMap<Address, AddressUpdateDto>().ReverseMap();
            // Mapeo una direccion
            CreateMap<Address, AddressReadDto>();
            // Mapeo bidireccional
            CreateMap<Geo, GeoCreateDto>().ReverseMap();
            CreateMap<Geo, GeoUpdateDto>().ReverseMap();
            // Mapeo una direccion
            CreateMap<Geo, GeoReadDto>();
            // Mapeo bidireccional
            CreateMap<Company, CompanyCreateDto>().ReverseMap();
            CreateMap<Company, CompanyUpdateDto>().ReverseMap();
            // Mapeo una direccion
            CreateMap<Company, CompanyReadDto>();
        }
    }
}
