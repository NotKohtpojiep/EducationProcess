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
    public class RegionsController : ControllerBase
    {
        private readonly ILogger<RegionsController> _logger;
        private readonly IRegionService _regionService;

        public RegionsController(ILogger<RegionsController> logger, IRegionService regionService)
        {
            _logger = logger;
            _regionService = regionService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Region), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Region region = await _regionService.GetRegionByIdAsync(id);
            if (region is null)
                return NotFound();
            return Ok(region);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(Region[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            Region[] regions = await _regionService.GetAllRegionsAsync();
            if (regions.Length == 0)
                return NotFound();
            return Ok(regions);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Region), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Region([FromBody] Region region)
        {
            Region addedRegion = await _regionService.AddRegionAsync(region);
            if (addedRegion is null)
                return NotFound();
            return Ok(addedRegion);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(Region[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> RegionRange([FromBody] Region[] regions)
        {
            Region[] addedRegions = await _regionService.AddRangeRegionAsync(regions);
            if (addedRegions is null)
                return NotFound();
            return Ok(addedRegions);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Region), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] Region region)
        {
            Region updatedRegion = await _regionService.UpdateRegionAsync(region);
            if (updatedRegion is null)
                return NotFound();
            return Ok(updatedRegion);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(Region[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] Region[] regions)
        {
            Region[] updatedRegions = await _regionService.UpdateRangeRegionAsync(regions);
            if (updatedRegions is null)
                return NotFound();
            return Ok(updatedRegions);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] Region region)
        {
            await _regionService.DeleteRegionAsync(region);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] Region[] regions)
        {
            await _regionService.DeleteRangeRegionAsync(regions);
            return Ok();
        }
    }
}
