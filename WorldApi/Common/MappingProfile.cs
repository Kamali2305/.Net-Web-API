using AutoMapper;
using WorldApi.DTO.Country;
using WorldApi.DTO.States;
using WorldApi.Models;

namespace WorldApi.Common
{
    public class MappingProfile : Profile
    { 

        public MappingProfile()
        {
            //Source,Destination,reverse mapping

            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();


            CreateMap<States, CreateStateDto>().ReverseMap();
            CreateMap<States, StateDto>().ReverseMap();
            CreateMap<States, UpdateStateDto>().ReverseMap();
        }
    }
}
