using Microsoft.AspNetCore.Mvc;
using CityInfo.Api.src.models;
using CityInfo.Api.src.services;
using AutoMapper;

namespace CityInfo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class citiesController : ControllerBase
{
    private readonly ICityInfoRepository _cityInfoRepository;
    private readonly IMapper _mapper;
    public citiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
    {
        _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityWitoutpointOfInterstDto>>> GetCities()
    {
        var cityEntities = await _cityInfoRepository.GetCitiesAsync();
        return Ok(_mapper.Map<IEnumerable<CityWitoutpointOfInterstDto>>(cityEntities));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCity(int id, bool includePointOfInterest = false)
    {
        var city = await _cityInfoRepository.GetCityAsync(id, includePointOfInterest);
        if (city == null)
        {
            return NotFound();
        }
        if (includePointOfInterest)
        {
            return Ok(_mapper.Map<CityDto>(city));
        }
        return Ok(_mapper.Map<CityWitoutpointOfInterstDto>(city));
    }
}