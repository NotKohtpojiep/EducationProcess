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
    public class AcademicYearsController : ControllerBase
    {
        private readonly ILogger<AcademicYearsController> _logger;
        private readonly IAcademicYearService _academicYearService;

        public AcademicYearsController(ILogger<AcademicYearsController> logger, IAcademicYearService academicYearService)
        {
            _logger = logger;
            _academicYearService = academicYearService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AcademicYear), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            AcademicYear academicYear = await _academicYearService.GetAcademicYearByIdAsync(id);
            if (academicYear is null)
                return NotFound();
            return Ok(academicYear);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(AcademicYear[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            AcademicYear[] academicYears = await _academicYearService.GetAllAcademicYearsAsync();
            if (academicYears.Length == 0)
                return NotFound();
            return Ok(academicYears);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AcademicYear), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AcademicYear([FromBody] AcademicYear academicYear)
        {
            AcademicYear addedAcademicYear = await _academicYearService.AddAcademicYearAsync(academicYear);
            if (addedAcademicYear is null)
                return NotFound();
            return Ok(addedAcademicYear);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(AcademicYear[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AcademicYearRange([FromBody] AcademicYear[] academicYears)
        {
            AcademicYear[] addedAcademicYears = await _academicYearService.AddRangeAcademicYearAsync(academicYears);
            if (addedAcademicYears is null)
                return NotFound();
            return Ok(addedAcademicYears);
        }

        [HttpPut]
        [ProducesResponseType(typeof(AcademicYear), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] AcademicYear academicYear)
        {
            AcademicYear updatedAcademicYear = await _academicYearService.UpdateAcademicYearAsync(academicYear);
            if (updatedAcademicYear is null)
                return NotFound();
            return Ok(updatedAcademicYear);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(AcademicYear[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] AcademicYear[] academicYears)
        {
            AcademicYear[] updatedAcademicYears = await _academicYearService.UpdateRangeAcademicYearAsync(academicYears);
            if (updatedAcademicYears is null)
                return NotFound();
            return Ok(updatedAcademicYears);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] AcademicYear academicYear)
        {
            await _academicYearService.DeleteAcademicYearAsync(academicYear);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] AcademicYear[] academicYears)
        {
            await _academicYearService.DeleteRangeAcademicYearAsync(academicYears);
            return Ok();
        }
    }
}
