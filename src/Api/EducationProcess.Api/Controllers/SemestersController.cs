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
    public class SemestersController : ControllerBase
    {
        private readonly ILogger<SemestersController> _logger;
        private readonly ISemesterService _semesterService;

        public SemestersController(ILogger<SemestersController> logger, ISemesterService semesterService)
        {
            _logger = logger;
            _semesterService = semesterService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Semester), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Semester semester = await _semesterService.GetSemesterByIdAsync(id);
            if (semester is null)
                return NotFound();
            return Ok(semester);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(Semester[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            Semester[] semesters = await _semesterService.GetAllSemestersAsync();
            if (semesters.Length == 0)
                return NotFound();
            return Ok(semesters);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Semester), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Semester([FromBody] Semester semester)
        {
            Semester addedSemester = await _semesterService.AddSemesterAsync(semester);
            if (addedSemester is null)
                return NotFound();
            return Ok(addedSemester);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(Semester[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SemesterRange([FromBody] Semester[] semesters)
        {
            Semester[] addedSemesters = await _semesterService.AddRangeSemesterAsync(semesters);
            if (addedSemesters is null)
                return NotFound();
            return Ok(addedSemesters);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Semester), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] Semester semester)
        {
            Semester updatedSemester = await _semesterService.UpdateSemesterAsync(semester);
            if (updatedSemester is null)
                return NotFound();
            return Ok(updatedSemester);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(Semester[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] Semester[] semesters)
        {
            Semester[] updatedSemesters = await _semesterService.UpdateRangeSemesterAsync(semesters);
            if (updatedSemesters is null)
                return NotFound();
            return Ok(updatedSemesters);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] Semester semester)
        {
            await _semesterService.DeleteSemesterAsync(semester);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] Semester[] semesters)
        {
            await _semesterService.DeleteRangeSemesterAsync(semesters);
            return Ok();
        }
    }
}
