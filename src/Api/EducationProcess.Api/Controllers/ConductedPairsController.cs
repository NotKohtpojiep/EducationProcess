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
    public class ConductedPairsController : ControllerBase
    {
        private readonly ILogger<ConductedPairsController> _logger;
        private readonly IConductedPairService _conductedPairService;

        public ConductedPairsController(ILogger<ConductedPairsController> logger, IConductedPairService conductedPairService)
        {
            _logger = logger;
            _conductedPairService = conductedPairService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ConductedPair), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            ConductedPair conductedPair = await _conductedPairService.GetConductedPairByIdAsync(id);
            if (conductedPair is null)
                return NotFound();
            return Ok(conductedPair);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(ConductedPair[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            ConductedPair[] conductedPairs = await _conductedPairService.GetAllConductedPairsAsync();
            if (conductedPairs.Length == 0)
                return NotFound();
            return Ok(conductedPairs);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ConductedPair), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ConductedPair([FromBody] ConductedPair conductedPair)
        {
            ConductedPair addedConductedPair = await _conductedPairService.AddConductedPairAsync(conductedPair);
            if (addedConductedPair is null)
                return NotFound();
            return Ok(addedConductedPair);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(ConductedPair[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ConductedPairRange([FromBody] ConductedPair[] conductedPairs)
        {
            ConductedPair[] addedConductedPairs = await _conductedPairService.AddRangeConductedPairAsync(conductedPairs);
            if (addedConductedPairs is null)
                return NotFound();
            return Ok(addedConductedPairs);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ConductedPair), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] ConductedPair conductedPair)
        {
            ConductedPair updatedConductedPair = await _conductedPairService.UpdateConductedPairAsync(conductedPair);
            if (updatedConductedPair is null)
                return NotFound();
            return Ok(updatedConductedPair);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(ConductedPair[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] ConductedPair[] conductedPairs)
        {
            ConductedPair[] updatedConductedPairs = await _conductedPairService.UpdateRangeConductedPairAsync(conductedPairs);
            if (updatedConductedPairs is null)
                return NotFound();
            return Ok(updatedConductedPairs);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] ConductedPair conductedPair)
        {
            await _conductedPairService.DeleteConductedPairAsync(conductedPair);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] ConductedPair[] conductedPairs)
        {
            await _conductedPairService.DeleteRangeConductedPairAsync(conductedPairs);
            return Ok();
        }
    }
}
