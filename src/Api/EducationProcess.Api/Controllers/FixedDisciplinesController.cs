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
    public class FixedDisciplinesController : ControllerBase
    {
        private readonly ILogger<FixedDisciplinesController> _logger;
        private readonly IFixedDisciplineService _fixedDisciplineService;

        public FixedDisciplinesController(ILogger<FixedDisciplinesController> logger, IFixedDisciplineService fixedDisciplineService)
        {
            _logger = logger;
            _fixedDisciplineService = fixedDisciplineService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(FixedDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            FixedDiscipline fixedDiscipline = await _fixedDisciplineService.GetFixedDisciplineByIdAsync(id);
            if (fixedDiscipline is null)
                return NotFound();
            return Ok(fixedDiscipline);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(FixedDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            FixedDiscipline[] fixedDisciplines = await _fixedDisciplineService.GetAllFixedDisciplinesAsync();
            if (fixedDisciplines.Length == 0)
                return NotFound();
            return Ok(fixedDisciplines);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FixedDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> FixedDiscipline([FromBody] FixedDiscipline fixedDiscipline)
        {
            FixedDiscipline addedFixedDiscipline = await _fixedDisciplineService.AddFixedDisciplineAsync(fixedDiscipline);
            if (addedFixedDiscipline is null)
                return NotFound();
            return Ok(addedFixedDiscipline);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(FixedDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> FixedDisciplineRange([FromBody] FixedDiscipline[] fixedDisciplines)
        {
            FixedDiscipline[] addedFixedDisciplines = await _fixedDisciplineService.AddRangeFixedDisciplineAsync(fixedDisciplines);
            if (addedFixedDisciplines is null)
                return NotFound();
            return Ok(addedFixedDisciplines);
        }

        [HttpPut]
        [ProducesResponseType(typeof(FixedDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] FixedDiscipline fixedDiscipline)
        {
            FixedDiscipline updatedFixedDiscipline = await _fixedDisciplineService.UpdateFixedDisciplineAsync(fixedDiscipline);
            if (updatedFixedDiscipline is null)
                return NotFound();
            return Ok(updatedFixedDiscipline);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(FixedDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] FixedDiscipline[] fixedDisciplines)
        {
            FixedDiscipline[] updatedFixedDisciplines = await _fixedDisciplineService.UpdateRangeFixedDisciplineAsync(fixedDisciplines);
            if (updatedFixedDisciplines is null)
                return NotFound();
            return Ok(updatedFixedDisciplines);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] FixedDiscipline fixedDiscipline)
        {
            await _fixedDisciplineService.DeleteFixedDisciplineAsync(fixedDiscipline);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] FixedDiscipline[] fixedDisciplines)
        {
            await _fixedDisciplineService.DeleteRangeFixedDisciplineAsync(fixedDisciplines);
            return Ok();
        }
    }
}
