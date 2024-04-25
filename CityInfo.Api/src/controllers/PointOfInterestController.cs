

using CityInfo.Api.src.services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CityInfo.Api.src.models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace CityInfo.Api.src.controllers;

[ApiController]
[Route("api/cities/{cityId}/[controller]")]
[Authorize(Policy = "MustBeFromAntewrp")]
public class pointofinterestController : ControllerBase
{
    private readonly ILogger<pointofinterestController> _logger;
    private readonly IMailService _mailService;
    private readonly ICityInfoRepository _cityInfoRepository;
    private readonly IMapper _mapper;

    public pointofinterestController(ILogger<pointofinterestController> logger, IMailService mailService, ICityInfoRepository cityInfoRepository, IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PointsOfInterestDto>>> GetPointsOfInterest(int cityId)
    {
        var cityName = User.Claims.FirstOrDefault(c => c.Type == "city")?.Value;
        if (!await _cityInfoRepository.CityNameMatchesId(cityId, cityName))
        {
            return Forbid();
        }
        if (!await _cityInfoRepository.CityExistsAsync(cityId))
        {
            _logger.LogInformation($"City with id {cityId} wasn't found when accessing points of interest.");
            return NotFound();
        }
        var pointOfInterestForCity = await _cityInfoRepository.GetPointOfInterestsAsync(cityId);
        return Ok(_mapper.Map<IEnumerable<PointsOfInterestDto>>(pointOfInterestForCity));
    }

    [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
    public async Task<ActionResult<PointsOfInterestDto>> GetPointOfInterest(int cityId, int pointOfInterestId)
    {
        if (!await _cityInfoRepository.CityExistsAsync(cityId))
        {
            return NotFound();
        }
        var pointOfInterest = await _cityInfoRepository.GetPointOfInterestAsync(cityId, pointOfInterestId);
        if (pointOfInterest == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<PointsOfInterestDto>(pointOfInterest));
    }

    [HttpPost]
    public async Task<ActionResult<PointsOfInterestDto>> CreatePointofInterst([FromRoute] int cityId, PointOfInterestForCreatingDto pointOfInterest)
    {
        if (!await _cityInfoRepository.CityExistsAsync(cityId))
        {
            return NotFound();
        }
        var finalPointOfInterest = _mapper.Map<entities.PointOfInterest>(pointOfInterest);
        await _cityInfoRepository.AddPointOfInterestForCityAsync(cityId, finalPointOfInterest);
        await _cityInfoRepository.SaveChangesAsync();
        var CreatedPointOfInterestToReturn = _mapper.Map<models.PointsOfInterestDto>(finalPointOfInterest);
        return CreatedAtRoute("GetPointOfInterest", new
        {
            cityId = cityId,
            pointOfInterestId = CreatedPointOfInterestToReturn.Id
        }, CreatedPointOfInterestToReturn);
    }

    [HttpPut("{pointOfInterestId}")]
    public async Task<ActionResult<PointsOfInterestDto>> UpdatepointofInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdatingDto pointOfInterest)
    {
        if (!await _cityInfoRepository.CityExistsAsync(cityId))
        {
            return NotFound();
        }
        var pointOfInterestEntity = await _cityInfoRepository.GetPointOfInterestAsync(cityId, pointOfInterestId);
        if (pointOfInterestEntity == null)
        {
            return NotFound();
        }

        _mapper.Map(pointOfInterest, pointOfInterestEntity);
        await _cityInfoRepository.SaveChangesAsync();
        return NoContent();
    }

    [HttpPatch("{pointOfInterestId}")]
    public async Task<ActionResult<PointsOfInterestDto>> PatchPointOfInterest(int cityId, int pointOfInterestId, [FromBody] JsonPatchDocument<PointOfInterestForUpdatingDto> patchDocument)
    {
        if (!await _cityInfoRepository.CityExistsAsync(cityId))
        {
            return NotFound();
        }
        var pointOfInterestEntity = await _cityInfoRepository.GetPointOfInterestAsync(cityId, pointOfInterestId);
        if (pointOfInterestEntity == null)
        {
            return NotFound();
        }
        var pointOfInterestToPatch = _mapper.Map<PointOfInterestForUpdatingDto>(pointOfInterestEntity);
        patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (!TryValidateModel(pointOfInterestToPatch))
            return BadRequest(ModelState);
        _mapper.Map(pointOfInterestToPatch, pointOfInterestEntity);
        await _cityInfoRepository.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{pointOfInterestId}")]
    public async Task<ActionResult> DeletePointOfInterest(int cityId, int pointOfInterestId)
    {
        if (!await _cityInfoRepository.CityExistsAsync(cityId))
        {
            return NotFound();
        }
        var pointOfInterestEntity = await _cityInfoRepository.GetPointOfInterestAsync(cityId, pointOfInterestId);
        if (pointOfInterestEntity == null)
        {
            return NotFound();
        }
        _cityInfoRepository.DeletePointOfInterest(pointOfInterestEntity);
        _mailService.send("Point of interest deleted.", $"Point of interest {pointOfInterestEntity.Name} with id {pointOfInterestEntity.Id} was deleted.");
        return NoContent();
    }
}