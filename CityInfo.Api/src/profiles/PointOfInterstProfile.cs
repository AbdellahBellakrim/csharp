namespace CityInfo.Api.src.profiles;
using AutoMapper;
public class PointOfInterstProfile : Profile
{
    public PointOfInterstProfile()
    {
        CreateMap<entities.PointOfInterest, models.PointsOfInterestDto>();
        CreateMap<models.PointOfInterestForCreatingDto, entities.PointOfInterest>();
        CreateMap<models.PointOfInterestForUpdatingDto, entities.PointOfInterest>();
        CreateMap<entities.PointOfInterest, models.PointOfInterestForUpdatingDto>();
    }
}