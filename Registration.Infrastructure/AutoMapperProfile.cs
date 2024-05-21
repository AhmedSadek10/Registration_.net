using AutoMapper;
using Registration.Application.Commands;
using Registration.Application.DTO;
using Registration.Domain.Entities;

namespace Presentation
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddressDto, Address>();
            CreateMap<UserCreateCommand, User>();
            CreateMap<CityEntity, CityDto>();
            CreateMap<GovernateEntity, GovernateDto>();
        }
    }
}
