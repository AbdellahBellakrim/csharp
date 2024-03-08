using Microsoft.AspNetCore.Mvc;
using CityInfo.Api.src.dataStores;
using CityInfo.Api.src.models;

namespace CityInfo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class citiesController : ControllerBase
{
    private readonly CitiesDataStore _citiesDataStore;
    public citiesController(CitiesDataStore citiesDataStore)
    {
        _citiesDataStore = citiesDataStore ?? throw new ArgumentNullException(nameof(citiesDataStore));
    }
    [HttpGet]
    public ActionResult<IEnumerable<CityDto>> GetCities()
    {
        return Ok(_citiesDataStore.Cities);
    }

    [HttpGet("{id}")]
    public ActionResult<CityDto> GetCity(int id)
    {
        var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == id);
        if (city == null) return NotFound();
        return Ok(city);
    }
}