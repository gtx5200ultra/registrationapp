using AutoMapper;
using RegistrationApp.DTO;
using registrationapp_core.Models;

namespace RegistrationApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(x => x.Login, x => x.MapFrom(i => i.Login))
                .ForMember(x => x.Password, x => x.MapFrom(i => i.Password))
                .ForMember(x => x.CountryRegionId, x => x.MapFrom(i => i.CountryRegionId));
        }
    }
}