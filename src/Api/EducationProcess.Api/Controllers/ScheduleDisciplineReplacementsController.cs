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
    public class ScheduleDisciplineReplacementsController : ControllerBase
    {
        private readonly ILogger<ScheduleDisciplineReplacementsController> _logger;
        private readonly IScheduleDisciplineReplacementService _scheduleDisciplineReplacementService;

        public ScheduleDisciplineReplacementsController(ILogger<ScheduleDisciplineReplacementsController> logger, IScheduleDisciplineReplacementService scheduleDisciplineReplacementService)
        {
            _logger = logger;
            _scheduleDisciplineReplacementService = scheduleDisciplineReplacementService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ScheduleDisciplineReplacement), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            ScheduleDisciplineReplacement scheduleDisciplineReplacement = await _scheduleDisciplineReplacementService.GetScheduleDisciplineReplacementByIdAsync(id);
            if (scheduleDisciplineReplacement is null)
                return NotFound();
            return Ok(scheduleDisciplineReplacement);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(ScheduleDisciplineReplacement[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            ScheduleDisciplineReplacement[] scheduleDisciplineReplacements = await _scheduleDisciplineReplacementService.GetAllScheduleDisciplineReplacementsAsync();
            if (scheduleDisciplineReplacements.Length == 0)
                return NotFound();
            return Ok(scheduleDisciplineReplacements);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ScheduleDisciplineReplacement), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ScheduleDisciplineReplacement([FromBody] ScheduleDisciplineReplacement scheduleDisciplineReplacement)
        {
            ScheduleDisciplineReplacement addedScheduleDisciplineReplacement = await _scheduleDisciplineReplacementService.AddScheduleDisciplineReplacementAsync(scheduleDisciplineReplacement);
            if (addedScheduleDisciplineReplacement is null)
                return NotFound();
            return Ok(addedScheduleDisciplineReplacement);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(ScheduleDisciplineReplacement[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ScheduleDisciplineReplacementRange([FromBody] ScheduleDisciplineReplacement[] scheduleDisciplineReplacements)
        {
            ScheduleDisciplineReplacement[] addedScheduleDisciplineReplacements = await _scheduleDisciplineReplacementService.AddRangeScheduleDisciplineReplacementAsync(scheduleDisciplineReplacements);
            if (addedScheduleDisciplineReplacements is null)
                return NotFound();
            return Ok(addedScheduleDisciplineReplacements);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ScheduleDisciplineReplacement), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] ScheduleDisciplineReplacement scheduleDisciplineReplacement)
        {
            ScheduleDisciplineReplacement updatedScheduleDisciplineReplacement = await _scheduleDisciplineReplacementService.UpdateScheduleDisciplineReplacementAsync(scheduleDisciplineReplacement);
            if (updatedScheduleDisciplineReplacement is null)
                return NotFound();
            return Ok(updatedScheduleDisciplineReplacement);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(ScheduleDisciplineReplacement[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] ScheduleDisciplineReplacement[] scheduleDisciplineReplacements)
        {
            ScheduleDisciplineReplacement[] updatedScheduleDisciplineReplacements = await _scheduleDisciplineReplacementService.UpdateRangeScheduleDisciplineReplacementAsync(scheduleDisciplineReplacements);
            if (updatedScheduleDisciplineReplacements is null)
                return NotFound();
            return Ok(updatedScheduleDisciplineReplacements);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] ScheduleDisciplineReplacement scheduleDisciplineReplacement)
        {
            await _scheduleDisciplineReplacementService.DeleteScheduleDisciplineReplacementAsync(scheduleDisciplineReplacement);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] ScheduleDisciplineReplacement[] scheduleDisciplineReplacements)
        {
            await _scheduleDisciplineReplacementService.DeleteRangeScheduleDisciplineReplacementAsync(scheduleDisciplineReplacements);
            return Ok();
        }
    }
}
