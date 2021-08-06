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
    public class EducationCyclesAndModulesController : ControllerBase
    {
        private readonly ILogger<EducationCyclesAndModulesController> _logger;
        private readonly IEducationCyclesAndModuleService _educationCyclesAndModuleService;

        public EducationCyclesAndModulesController(ILogger<EducationCyclesAndModulesController> logger, IEducationCyclesAndModuleService educationCyclesAndModuleService)
        {
            _logger = logger;
            _educationCyclesAndModuleService = educationCyclesAndModuleService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(EducationCyclesAndModule), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            EducationCyclesAndModule educationCyclesAndModule = await _educationCyclesAndModuleService.GetEducationCyclesAndModuleByIdAsync(id);
            if (educationCyclesAndModule is null)
                return NotFound();
            return Ok(educationCyclesAndModule);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(EducationCyclesAndModule[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            EducationCyclesAndModule[] educationCyclesAndModules = await _educationCyclesAndModuleService.GetAllEducationCyclesAndModulesAsync();
            if (educationCyclesAndModules.Length == 0)
                return NotFound();
            return Ok(educationCyclesAndModules);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EducationCyclesAndModule), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EducationCyclesAndModule([FromBody] EducationCyclesAndModule educationCyclesAndModule)
        {
            EducationCyclesAndModule addedEducationCyclesAndModule = await _educationCyclesAndModuleService.AddEducationCyclesAndModuleAsync(educationCyclesAndModule);
            if (addedEducationCyclesAndModule is null)
                return NotFound();
            return Ok(addedEducationCyclesAndModule);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(EducationCyclesAndModule[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EducationCyclesAndModuleRange([FromBody] EducationCyclesAndModule[] educationCyclesAndModules)
        {
            EducationCyclesAndModule[] addedEducationCyclesAndModules = await _educationCyclesAndModuleService.AddRangeEducationCyclesAndModuleAsync(educationCyclesAndModules);
            if (addedEducationCyclesAndModules is null)
                return NotFound();
            return Ok(addedEducationCyclesAndModules);
        }

        [HttpPut]
        [ProducesResponseType(typeof(EducationCyclesAndModule), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] EducationCyclesAndModule educationCyclesAndModule)
        {
            EducationCyclesAndModule updatedEducationCyclesAndModule = await _educationCyclesAndModuleService.UpdateEducationCyclesAndModuleAsync(educationCyclesAndModule);
            if (updatedEducationCyclesAndModule is null)
                return NotFound();
            return Ok(updatedEducationCyclesAndModule);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(EducationCyclesAndModule[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] EducationCyclesAndModule[] educationCyclesAndModules)
        {
            EducationCyclesAndModule[] updatedEducationCyclesAndModules = await _educationCyclesAndModuleService.UpdateRangeEducationCyclesAndModuleAsync(educationCyclesAndModules);
            if (updatedEducationCyclesAndModules is null)
                return NotFound();
            return Ok(updatedEducationCyclesAndModules);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] EducationCyclesAndModule educationCyclesAndModule)
        {
            await _educationCyclesAndModuleService.DeleteEducationCyclesAndModuleAsync(educationCyclesAndModule);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] EducationCyclesAndModule[] educationCyclesAndModules)
        {
            await _educationCyclesAndModuleService.DeleteRangeEducationCyclesAndModuleAsync(educationCyclesAndModules);
            return Ok();
        }
    }
}
