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
            // Mapeo bidireccional
            CreateMap<Address, AddressCreateDto>().ReverseMap();
            CreateMap<Address, AddressUpdateDto>().ReverseMap();
            // Mapeo bidireccional
            CreateMap<Geo, GeoCreateDto>().ReverseMap();
            CreateMap<Geo, GeoUpdateDto>().ReverseMap();
            // Mapeo bidireccional
            CreateMap<Company, CompanyCreateDto>().ReverseMap();
            CreateMap<Company, CompanyUpdateDto>().ReverseMap();

            // Definicion de como se debe mapear los datos
            CreateMap<User, UserReadDto>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));
            CreateMap<Address, AddressReadDto>()
                .ForMember(dest => dest.Geo, opt => opt.MapFrom(src => src.Geo));
            CreateMap<Geo, GeoReadDto>();
            CreateMap<Company, CompanyReadDto>();
        }
    }
}
