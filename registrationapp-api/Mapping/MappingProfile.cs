using AutoMapper;
using registrationapp.DTO;
using registrationapp_core.Contracts;
using registrationapp_core.Models;

namespace registrationapp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CountryRegionContract, CountryRegionDto>();
            CreateMap<CountryContract, CountryDto>();
            CreateMap<UserContract, CreatedUserDto>();

            CreateMap<CountryRegion, CountryRegionContract>();
            CreateMap<Country, CountryContract>();
            CreateMap<User, UserContract>();

            CreateMap<UserDto, User>();
        }
    }
}