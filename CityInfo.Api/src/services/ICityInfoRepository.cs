using CityInfo.Api.src.entities;

namespace CityInfo.Api.src.services;

public interface ICityInfoRepository
{
    Task<IEnumerable<City>> GetCitiesAsync();
    Task<(IEnumerable<City>, PaginationMetaData)> GetCitiesAsync(string? name, string? searchQuery, int pageNumber, int pageSize);

    Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest);
    Task<IEnumerable<PointOfInterest>> GetPointOfInterestsAsync(int cityId);
    Task<PointOfInterest?> GetPointOfInterestAsync(int cityId, int pointOfInterestId);
    Task<bool> CityExistsAsync(int cityId);
    Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest);
    Task<bool> SaveChangesAsync();
    void DeletePointOfInterest(PointOfInterest pointOfInterest);
}