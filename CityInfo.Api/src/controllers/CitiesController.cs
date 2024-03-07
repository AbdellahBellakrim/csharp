using Microsoft.AspNetCore.Mvc;
using CityInfo.Api.src.dataStores;
using CityInfo.Api.src.models;

namespace CityInfo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class citiesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CityDto>> GetCities()
    {
        return Ok(CitiesDataStore.Current.Cities);
    }

    [HttpGet("{id}")]
    public ActionResult<CityDto> GetCity(int id)
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
        if (city == null) return NotFound();
        return Ok(city);
    }
}