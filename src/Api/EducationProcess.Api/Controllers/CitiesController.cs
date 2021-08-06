using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ILogger<CitiesController> _logger;
        private readonly ICityService _cityService;

        public CitiesController(ILogger<CitiesController> logger, ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(City), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            City city = await _cityService.GetCityByIdAsync(id);
            if (city is null)
                return NotFound();
            return Ok(city);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(City[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            City[] cities = await _cityService.GetAllCitiesAsync();
            if (cities.Length == 0)
                return NotFound();
            return Ok(cities);
        }

        [HttpPost]
        [ProducesResponseType(typeof(City), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> City([FromBody] City city)
        {
            City addedCity = await _cityService.AddCityAsync(city);
            if (addedCity is null)
                return NotFound();
            return Ok(addedCity);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(City[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> CityRange([FromBody] City[] cities)
        {
            City[] addedCities = await _cityService.AddRangeCityAsync(cities);
            if (addedCities is null)
                return NotFound();
            return Ok(addedCities);
        }

        [HttpPut]
        [ProducesResponseType(typeof(City), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] City city)
        {
            City updatedCity = await _cityService.UpdateCityAsync(city);
            if (updatedCity is null)
                return NotFound();
            return Ok(updatedCity);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(City[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] City[] cities)
        {
            City[] updatedCities = await _cityService.UpdateRangeCityAsync(cities);
            if (updatedCities is null)
                return NotFound();
            return Ok(updatedCities);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] City city)
        {
            await _cityService.DeleteCityAsync(city);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] City[] cities)
        {
            await _cityService.DeleteRangeCityAsync(cities);
            return Ok();
        }
    }
}
