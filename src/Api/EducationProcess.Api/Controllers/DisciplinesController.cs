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
    public class DisciplinesController : ControllerBase
    {
        private readonly ILogger<DisciplinesController> _logger;
        private readonly IDisciplineService _disciplineService;

        public DisciplinesController(ILogger<DisciplinesController> logger, IDisciplineService disciplineService)
        {
            _logger = logger;
            _disciplineService = disciplineService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Discipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Discipline discipline = await _disciplineService.GetDisciplineByIdAsync(id);
            if (discipline is null)
                return NotFound();
            return Ok(discipline);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(Discipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            Discipline[] disciplines = await _disciplineService.GetAllDisciplinesAsync();
            if (disciplines.Length == 0)
                return NotFound();
            return Ok(disciplines);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Discipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Discipline([FromBody] Discipline discipline)
        {
            Discipline addedDiscipline = await _disciplineService.AddDisciplineAsync(discipline);
            if (addedDiscipline is null)
                return NotFound();
            return Ok(addedDiscipline);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(Discipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DisciplineRange([FromBody] Discipline[] disciplines)
        {
            Discipline[] addedDisciplines = await _disciplineService.AddRangeDisciplineAsync(disciplines);
            if (addedDisciplines is null)
                return NotFound();
            return Ok(addedDisciplines);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Discipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] Discipline discipline)
        {
            Discipline updatedDiscipline = await _disciplineService.UpdateDisciplineAsync(discipline);
            if (updatedDiscipline is null)
                return NotFound();
            return Ok(updatedDiscipline);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(Discipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] Discipline[] disciplines)
        {
            Discipline[] updatedDisciplines = await _disciplineService.UpdateRangeDisciplineAsync(disciplines);
            if (updatedDisciplines is null)
                return NotFound();
            return Ok(updatedDisciplines);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] Discipline discipline)
        {
            await _disciplineService.DeleteDisciplineAsync(discipline);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] Discipline[] disciplines)
        {
            await _disciplineService.DeleteRangeDisciplineAsync(disciplines);
            return Ok();
        }
    }
}
