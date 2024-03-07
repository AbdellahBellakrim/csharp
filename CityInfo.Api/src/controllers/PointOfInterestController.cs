
using CityInfo.Api.src.dataStores;
using CityInfo.Api.src.models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.src.controllers;

[ApiController]
[Route("api/cities/{cityId}/[controller]")]
public class pointofinterestController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<PointsOfInterestDto>> GetPointsOfInterest(int cityId)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
        if (city == null)
        {
            return NotFound();
        }
        return Ok(city.PointsOfInterest);
    }

    [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
    public ActionResult<PointsOfInterestDto> GetPointOfInterest(int cityId, int pointOfInterestId)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
        if (city == null)
        {
            return NotFound();
        }
        var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
        if (pointOfInterest == null)
        {
            return NotFound();
        }
        return Ok(pointOfInterest);
    }

    [HttpPost]
    public ActionResult<PointsOfInterestDto> CreatePointofInterst([FromRoute] int cityId, PointOfInterestForCreatingDto pointOfInterest)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
        if (city == null)
            return NotFound();
        var finalPointOfInterest = new PointsOfInterestDto()
        {
            Id = city.NumberOfPointsOfInterest + 1,
            Name = pointOfInterest.Name,
            Description = pointOfInterest.Description
        };
        city.PointsOfInterest.Add(finalPointOfInterest);
        return CreatedAtRoute("GetPointOfInterest", new { cityId = cityId, pointOfInterestId = finalPointOfInterest.Id }, finalPointOfInterest);
    }
}