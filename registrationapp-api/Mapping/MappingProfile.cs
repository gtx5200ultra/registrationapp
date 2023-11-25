using AutoMapper;
using registrationapp.DTO;
using registrationapp_core.Models;

namespace registrationapp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(x => x.Login, x => x.MapFrom(i => i.Login))
                .ForMember(x => x.Password, x => x.MapFrom(i => i.Password))
                .ForMember(x => x.CountryRegionId, x => x.MapFrom(i => i.CountryRegionId));

            CreateMap<User, CreatedUserDto>()
                .ForMember(x => x.Id, x => x.MapFrom(i => i.Id))
                .ForMember(x => x.Login, x => x.MapFrom(i => i.Login))
                .ForMember(x => x.Province, x => x.MapFrom(i => i.CountryRegion.Name))
                .ForMember(x => x.Country, x => x.MapFrom(i => i.CountryRegion.Country.Name));
        }
    }
}