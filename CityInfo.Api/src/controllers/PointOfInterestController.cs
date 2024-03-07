
using CityInfo.Api.src.dataStores;
using CityInfo.Api.src.models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.src.controllers;

[ApiController]
[Route("api/cities/{cityId}/[controller]")]
public class pointofinterestController : ControllerBase
{
    private readonly ILogger<pointofinterestController> _logger;

    public pointofinterestController(ILogger<pointofinterestController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public ActionResult<IEnumerable<PointsOfInterestDto>> GetPointsOfInterest(int cityId)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
        if (city == null)
        {
            _logger.LogWarning($"City with id {cityId} wasn't found when accessing points of interest.");
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

    [HttpPut("{pointOfInterestId}")]
    public ActionResult<PointsOfInterestDto> UpdatepointofInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdatingDto pointOfInterest)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
        if (city == null)
            return NotFound();
        var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
        if (pointOfInterestFromStore == null)
            return NotFound();
        pointOfInterestFromStore.Name = pointOfInterest.Name;
        pointOfInterestFromStore.Description = pointOfInterest.Description;
        return NoContent();
    }

    [HttpPatch("{pointOfInterestId}")]
    public ActionResult<PointsOfInterestDto> PatchPointOfInterest(int cityId, int pointOfInterestId, [FromBody] JsonPatchDocument<PointOfInterestForUpdatingDto> patchDocument)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
        if (city == null)
            return NotFound();
        var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
        if (pointOfInterestFromStore == null)
            return NotFound();
        var pointOfInterestToPatch = new PointOfInterestForUpdatingDto()
        {
            Name = pointOfInterestFromStore.Name,
            Description = pointOfInterestFromStore.Description
        };
        patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (!TryValidateModel(pointOfInterestToPatch))
            return BadRequest(ModelState);
        pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
        pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;
        return NoContent();
    }

    [HttpDelete("{pointOfInterestId}")]
    public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
        if (city == null)
            return NotFound();
        var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
        if (pointOfInterestFromStore == null)
            return NotFound();
        city.PointsOfInterest.Remove(pointOfInterestFromStore);
        return NoContent();
    }
}