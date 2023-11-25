using AutoMapper;
using registrationapp.DTO;
using registrationapp_core.Models;

namespace registrationapp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();

            CreateMap<User, CreatedUserDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<CountryRegion, CountryRegionDto>();
        }
    }
}