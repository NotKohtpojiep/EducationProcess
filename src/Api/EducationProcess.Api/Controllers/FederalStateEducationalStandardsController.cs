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
    public class FederalStateEducationalStandardsController : ControllerBase
    {
        private readonly ILogger<FederalStateEducationalStandardsController> _logger;
        private readonly IFederalStateEducationalStandardService _federalStateEducationalStandardService;

        public FederalStateEducationalStandardsController(ILogger<FederalStateEducationalStandardsController> logger, IFederalStateEducationalStandardService federalStateEducationalStandardService)
        {
            _logger = logger;
            _federalStateEducationalStandardService = federalStateEducationalStandardService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(FederalStateEducationalStandard), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            FederalStateEducationalStandard federalStateEducationalStandard = await _federalStateEducationalStandardService.GetFederalStateEducationalStandardByIdAsync(id);
            if (federalStateEducationalStandard is null)
                return NotFound();
            return Ok(federalStateEducationalStandard);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(FederalStateEducationalStandard[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            FederalStateEducationalStandard[] federalStateEducationalStandards = await _federalStateEducationalStandardService.GetAllFederalStateEducationalStandardsAsync();
            if (federalStateEducationalStandards.Length == 0)
                return NotFound();
            return Ok(federalStateEducationalStandards);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FederalStateEducationalStandard), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> FederalStateEducationalStandard([FromBody] FederalStateEducationalStandard federalStateEducationalStandard)
        {
            FederalStateEducationalStandard addedFederalStateEducationalStandard = await _federalStateEducationalStandardService.AddFederalStateEducationalStandardAsync(federalStateEducationalStandard);
            if (addedFederalStateEducationalStandard is null)
                return NotFound();
            return Ok(addedFederalStateEducationalStandard);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(FederalStateEducationalStandard[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> FederalStateEducationalStandardRange([FromBody] FederalStateEducationalStandard[] federalStateEducationalStandards)
        {
            FederalStateEducationalStandard[] addedFederalStateEducationalStandards = await _federalStateEducationalStandardService.AddRangeFederalStateEducationalStandardAsync(federalStateEducationalStandards);
            if (addedFederalStateEducationalStandards is null)
                return NotFound();
            return Ok(addedFederalStateEducationalStandards);
        }

        [HttpPut]
        [ProducesResponseType(typeof(FederalStateEducationalStandard), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] FederalStateEducationalStandard federalStateEducationalStandard)
        {
            FederalStateEducationalStandard updatedFederalStateEducationalStandard = await _federalStateEducationalStandardService.UpdateFederalStateEducationalStandardAsync(federalStateEducationalStandard);
            if (updatedFederalStateEducationalStandard is null)
                return NotFound();
            return Ok(updatedFederalStateEducationalStandard);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(FederalStateEducationalStandard[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] FederalStateEducationalStandard[] federalStateEducationalStandards)
        {
            FederalStateEducationalStandard[] updatedFederalStateEducationalStandards = await _federalStateEducationalStandardService.UpdateRangeFederalStateEducationalStandardAsync(federalStateEducationalStandards);
            if (updatedFederalStateEducationalStandards is null)
                return NotFound();
            return Ok(updatedFederalStateEducationalStandards);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] FederalStateEducationalStandard federalStateEducationalStandard)
        {
            await _federalStateEducationalStandardService.DeleteFederalStateEducationalStandardAsync(federalStateEducationalStandard);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] FederalStateEducationalStandard[] federalStateEducationalStandards)
        {
            await _federalStateEducationalStandardService.DeleteRangeFederalStateEducationalStandardAsync(federalStateEducationalStandards);
            return Ok();
        }
    }
}
