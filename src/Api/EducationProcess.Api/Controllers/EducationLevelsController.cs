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
    public class EducationLevelsController : ControllerBase
    {
        private readonly ILogger<EducationLevelsController> _logger;
        private readonly IEducationLevelService _educationLevelService;

        public EducationLevelsController(ILogger<EducationLevelsController> logger, IEducationLevelService educationLevelService)
        {
            _logger = logger;
            _educationLevelService = educationLevelService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(EducationLevel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            EducationLevel educationLevel = await _educationLevelService.GetEducationLevelByIdAsync(id);
            if (educationLevel is null)
                return NotFound();
            return Ok(educationLevel);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(EducationLevel[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            EducationLevel[] educationLevels = await _educationLevelService.GetAllEducationLevelsAsync();
            if (educationLevels.Length == 0)
                return NotFound();
            return Ok(educationLevels);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EducationLevel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EducationLevel([FromBody] EducationLevel educationLevel)
        {
            EducationLevel addedEducationLevel = await _educationLevelService.AddEducationLevelAsync(educationLevel);
            if (addedEducationLevel is null)
                return NotFound();
            return Ok(addedEducationLevel);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(EducationLevel[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EducationLevelRange([FromBody] EducationLevel[] educationLevels)
        {
            EducationLevel[] addedEducationLevels = await _educationLevelService.AddRangeEducationLevelAsync(educationLevels);
            if (addedEducationLevels is null)
                return NotFound();
            return Ok(addedEducationLevels);
        }

        [HttpPut]
        [ProducesResponseType(typeof(EducationLevel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] EducationLevel educationLevel)
        {
            EducationLevel updatedEducationLevel = await _educationLevelService.UpdateEducationLevelAsync(educationLevel);
            if (updatedEducationLevel is null)
                return NotFound();
            return Ok(updatedEducationLevel);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(EducationLevel[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] EducationLevel[] educationLevels)
        {
            EducationLevel[] updatedEducationLevels = await _educationLevelService.UpdateRangeEducationLevelAsync(educationLevels);
            if (updatedEducationLevels is null)
                return NotFound();
            return Ok(updatedEducationLevels);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] EducationLevel educationLevel)
        {
            await _educationLevelService.DeleteEducationLevelAsync(educationLevel);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] EducationLevel[] educationLevels)
        {
            await _educationLevelService.DeleteRangeEducationLevelAsync(educationLevels);
            return Ok();
        }
    }
}
