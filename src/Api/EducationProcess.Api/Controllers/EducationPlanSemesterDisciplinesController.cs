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
    public class EducationPlanSemesterDisciplinesController : ControllerBase
    {
        private readonly ILogger<EducationPlanSemesterDisciplinesController> _logger;
        private readonly IEducationPlanSemesterDisciplineService _educationPlanSemesterDisciplineService;

        public EducationPlanSemesterDisciplinesController(ILogger<EducationPlanSemesterDisciplinesController> logger, IEducationPlanSemesterDisciplineService educationPlanSemesterDisciplineService)
        {
            _logger = logger;
            _educationPlanSemesterDisciplineService = educationPlanSemesterDisciplineService;
        }

        [HttpGet("range/by-education-plan/{id:int}")]
        [ProducesResponseType(typeof(EducationPlanSemesterDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByEducationPlanId([FromRoute] int id)
        {
            EducationPlanSemesterDiscipline[] educationPlanSemesterDisciplines = await _educationPlanSemesterDisciplineService.GetEducationPlanSemesterDisciplineByEducationPlanIdAsync(id);
            if (educationPlanSemesterDisciplines is null)
                return NotFound();
            return Ok(educationPlanSemesterDisciplines);
        }

        [HttpGet("range/by-semester-discipline/{id:int}")]
        [ProducesResponseType(typeof(EducationPlanSemesterDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetBySemesterDisciplineId([FromRoute] int id)
        {
            EducationPlanSemesterDiscipline[] educationPlanSemesterDisciplines = await _educationPlanSemesterDisciplineService.GetEducationPlanSemesterDisciplineBySemesterDisciplineIdAsync(id);
            if (educationPlanSemesterDisciplines is null)
                return NotFound();
            return Ok(educationPlanSemesterDisciplines);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(EducationPlanSemesterDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            EducationPlanSemesterDiscipline[] educationPlanSemesterDisciplines = await _educationPlanSemesterDisciplineService.GetAllEducationPlanSemesterDisciplinesAsync();
            if (educationPlanSemesterDisciplines.Length == 0)
                return NotFound();
            return Ok(educationPlanSemesterDisciplines);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EducationPlanSemesterDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EducationPlanSemesterDiscipline([FromBody] EducationPlanSemesterDiscipline educationPlanSemesterDiscipline)
        {
            EducationPlanSemesterDiscipline addedEducationPlanSemesterDiscipline = await _educationPlanSemesterDisciplineService.AddEducationPlanSemesterDisciplineAsync(educationPlanSemesterDiscipline);
            if (addedEducationPlanSemesterDiscipline is null)
                return NotFound();
            return Ok(addedEducationPlanSemesterDiscipline);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(EducationPlanSemesterDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EducationPlanSemesterDisciplineRange([FromBody] EducationPlanSemesterDiscipline[] educationPlanSemesterDisciplines)
        {
            EducationPlanSemesterDiscipline[] addedEducationPlanSemesterDisciplines = await _educationPlanSemesterDisciplineService.AddRangeEducationPlanSemesterDisciplineAsync(educationPlanSemesterDisciplines);
            if (addedEducationPlanSemesterDisciplines is null)
                return NotFound();
            return Ok(addedEducationPlanSemesterDisciplines);
        }

        [HttpPut]
        [ProducesResponseType(typeof(EducationPlanSemesterDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] EducationPlanSemesterDiscipline educationPlanSemesterDiscipline)
        {
            EducationPlanSemesterDiscipline updatedEducationPlanSemesterDiscipline = await _educationPlanSemesterDisciplineService.UpdateEducationPlanSemesterDisciplineAsync(educationPlanSemesterDiscipline);
            if (updatedEducationPlanSemesterDiscipline is null)
                return NotFound();
            return Ok(updatedEducationPlanSemesterDiscipline);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(EducationPlanSemesterDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] EducationPlanSemesterDiscipline[] educationPlanSemesterDisciplines)
        {
            EducationPlanSemesterDiscipline[] updatedEducationPlanSemesterDisciplines = await _educationPlanSemesterDisciplineService.UpdateRangeEducationPlanSemesterDisciplineAsync(educationPlanSemesterDisciplines);
            if (updatedEducationPlanSemesterDisciplines is null)
                return NotFound();
            return Ok(updatedEducationPlanSemesterDisciplines);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] EducationPlanSemesterDiscipline educationPlanSemesterDiscipline)
        {
            await _educationPlanSemesterDisciplineService.DeleteEducationPlanSemesterDisciplineAsync(educationPlanSemesterDiscipline);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] EducationPlanSemesterDiscipline[] educationPlanSemesterDisciplines)
        {
            await _educationPlanSemesterDisciplineService.DeleteRangeEducationPlanSemesterDisciplineAsync(educationPlanSemesterDisciplines);
            return Ok();
        }
    }
}
