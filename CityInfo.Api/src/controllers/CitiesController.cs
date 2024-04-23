using Microsoft.AspNetCore.Mvc;
using CityInfo.Api.src.models;
using CityInfo.Api.src.services;
using AutoMapper;
using System.Text.Json;

namespace CityInfo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class citiesController : ControllerBase
{
    private readonly ICityInfoRepository _cityInfoRepository;
    private readonly IMapper _mapper;
    const int maxPageSize = 20;
    public citiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
    {
        _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityWitoutpointOfInterstDto>>> GetCities([FromQuery] string? name, [FromQuery] string? searchQuery, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        if (pageSize > maxPageSize)
        {
            pageSize = maxPageSize;
        }
        var (cityEntities, paginationMetaData) = await _cityInfoRepository.GetCitiesAsync(name, searchQuery, pageNumber, pageSize);
        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetaData));
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