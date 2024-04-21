using AutoMapper;

namespace CityInfo.Api.src.profiles;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<entities.City, models.CityWitoutpointOfInterstDto>();
        CreateMap<entities.City, models.CityDto>();
    }
}