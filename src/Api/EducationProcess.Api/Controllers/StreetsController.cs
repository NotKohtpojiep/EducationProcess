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
    public class StreetsController : ControllerBase
    {
        private readonly ILogger<StreetsController> _logger;
        private readonly IStreetService _streetService;

        public StreetsController(ILogger<StreetsController> logger, IStreetService streetService)
        {
            _logger = logger;
            _streetService = streetService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Street), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Street street = await _streetService.GetStreetByIdAsync(id);
            if (street is null)
                return NotFound();
            return Ok(street);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(Street[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            Street[] streets = await _streetService.GetAllStreetsAsync();
            if (streets.Length == 0)
                return NotFound();
            return Ok(streets);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Street), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Street([FromBody] Street street)
        {
            Street addedStreet = await _streetService.AddStreetAsync(street);
            if (addedStreet is null)
                return NotFound();
            return Ok(addedStreet);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(Street[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> StreetRange([FromBody] Street[] streets)
        {
            Street[] addedStreets = await _streetService.AddRangeStreetAsync(streets);
            if (addedStreets is null)
                return NotFound();
            return Ok(addedStreets);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Street), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] Street street)
        {
            Street updatedStreet = await _streetService.UpdateStreetAsync(street);
            if (updatedStreet is null)
                return NotFound();
            return Ok(updatedStreet);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(Street[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] Street[] streets)
        {
            Street[] updatedStreets = await _streetService.UpdateRangeStreetAsync(streets);
            if (updatedStreets is null)
                return NotFound();
            return Ok(updatedStreets);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] Street street)
        {
            await _streetService.DeleteStreetAsync(street);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] Street[] streets)
        {
            await _streetService.DeleteRangeStreetAsync(streets);
            return Ok();
        }
    }
}
