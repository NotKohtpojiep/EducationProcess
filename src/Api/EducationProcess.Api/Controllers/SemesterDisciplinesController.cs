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
    public class SemesterDisciplinesController : ControllerBase
    {
        private readonly ILogger<SemesterDisciplinesController> _logger;
        private readonly ISemesterDisciplineService _semesterDisciplineService;

        public SemesterDisciplinesController(ILogger<SemesterDisciplinesController> logger, ISemesterDisciplineService semesterDisciplineService)
        {
            _logger = logger;
            _semesterDisciplineService = semesterDisciplineService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(SemesterDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            SemesterDiscipline semesterDiscipline = await _semesterDisciplineService.GetSemesterDisciplineByIdAsync(id);
            if (semesterDiscipline is null)
                return NotFound();
            return Ok(semesterDiscipline);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(SemesterDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            SemesterDiscipline[] semesterDisciplines = await _semesterDisciplineService.GetAllSemesterDisciplinesAsync();
            if (semesterDisciplines.Length == 0)
                return NotFound();
            return Ok(semesterDisciplines);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SemesterDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SemesterDiscipline([FromBody] SemesterDiscipline semesterDiscipline)
        {
            SemesterDiscipline addedSemesterDiscipline = await _semesterDisciplineService.AddSemesterDisciplineAsync(semesterDiscipline);
            if (addedSemesterDiscipline is null)
                return NotFound();
            return Ok(addedSemesterDiscipline);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(SemesterDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SemesterDisciplineRange([FromBody] SemesterDiscipline[] semesterDisciplines)
        {
            SemesterDiscipline[] addedSemesterDisciplines = await _semesterDisciplineService.AddRangeSemesterDisciplineAsync(semesterDisciplines);
            if (addedSemesterDisciplines is null)
                return NotFound();
            return Ok(addedSemesterDisciplines);
        }

        [HttpPut]
        [ProducesResponseType(typeof(SemesterDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] SemesterDiscipline semesterDiscipline)
        {
            SemesterDiscipline updatedSemesterDiscipline = await _semesterDisciplineService.UpdateSemesterDisciplineAsync(semesterDiscipline);
            if (updatedSemesterDiscipline is null)
                return NotFound();
            return Ok(updatedSemesterDiscipline);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(SemesterDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] SemesterDiscipline[] semesterDisciplines)
        {
            SemesterDiscipline[] updatedSemesterDisciplines = await _semesterDisciplineService.UpdateRangeSemesterDisciplineAsync(semesterDisciplines);
            if (updatedSemesterDisciplines is null)
                return NotFound();
            return Ok(updatedSemesterDisciplines);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] SemesterDiscipline semesterDiscipline)
        {
            await _semesterDisciplineService.DeleteSemesterDisciplineAsync(semesterDiscipline);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] SemesterDiscipline[] semesterDisciplines)
        {
            await _semesterDisciplineService.DeleteRangeSemesterDisciplineAsync(semesterDisciplines);
            return Ok();
        }
    }
}
