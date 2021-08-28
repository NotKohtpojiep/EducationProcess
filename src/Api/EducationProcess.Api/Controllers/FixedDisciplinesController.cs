using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using EducationProcess.Api.Filters;
using EducationProcess.Api.Wrappers;
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
            FixedDiscipline fixedDiscipline = await _fixedDisciplineService.GetByIdAsync(id);
            if (fixedDiscipline is null)
                return NotFound();
            return Ok(fixedDiscipline);
        }

        [HttpGet]
        [ProducesResponseType(typeof(FixedDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAll()
        {
            FixedDiscipline[] fixedDisciplines = await _fixedDisciplineService.GetAllAsync();
            if (fixedDisciplines.Length == 0)
                return NotFound();
            return Ok(fixedDisciplines);
        }

        [HttpGet("pretty")]
        [ProducesResponseType(typeof(FixedDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRangeWithInclude([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            FixedDiscipline[] fixedDisciplines =
                await _fixedDisciplineService.GetRangeWithIncludeAsync(validFilter.PageNumber, validFilter.PageSize);

            if (fixedDisciplines.Length == 0)
                return NotFound();
            return Ok(fixedDisciplines);
        }

        [HttpGet("pretty/teacher/{fixingEmployeeId:int}")]
        [ProducesResponseType(typeof(FixedDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAllByFixingEmployeeIdWithInclude(int fixingEmployeeId)
        {
            FixedDiscipline[] fixedDisciplines = await _fixedDisciplineService.GetAllByFixingEmployeeIdWithIncludeAsync(fixingEmployeeId);
            if (fixedDisciplines.Length == 0)
                return NotFound();
            return Ok(fixedDisciplines);
        }

        [HttpGet("pretty/group/{groupId:int}")]
        [ProducesResponseType(typeof(FixedDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAllByGroupIdWithInclude(int groupId)
        {
            FixedDiscipline[] fixedDisciplines = await _fixedDisciplineService.GetAllByGroupIdWithIncludeAsync(groupId);
            if (fixedDisciplines.Length == 0)
                return NotFound();
            return Ok(fixedDisciplines);
        }

        [HttpGet("count")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCount()
        {
            return Ok(await _fixedDisciplineService.Count());
        }


        [HttpPost("{id:int}")]
        [ProducesResponseType(typeof(FixedDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Add([FromRoute] int id, [FromBody] FixedDiscipline fixedDiscipline)
        {
            if (id != fixedDiscipline.FixedDisciplineId)
                return BadRequest();
            FixedDiscipline addedFixedDiscipline = await _fixedDisciplineService.AddAsync(fixedDiscipline);
            if (addedFixedDiscipline is null)
                return NotFound();
            return Ok(addedFixedDiscipline);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FixedDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AddRange([FromBody] FixedDiscipline[] fixedDisciplines)
        {
            FixedDiscipline[] addedFixedDisciplines = await _fixedDisciplineService.AddRangeAsync(fixedDisciplines);
            if (addedFixedDisciplines is null)
                return NotFound();
            return Ok(addedFixedDisciplines);
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(FixedDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] FixedDiscipline fixedDiscipline)
        {
            if (id != fixedDiscipline.FixedDisciplineId)
                return BadRequest();
            FixedDiscipline updatedFixedDiscipline = await _fixedDisciplineService.UpdateAsync(fixedDiscipline);
            if (updatedFixedDiscipline is null)
                return NotFound();
            return Ok(updatedFixedDiscipline);
        }

        [HttpPut]
        [ProducesResponseType(typeof(FixedDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateRange([FromBody] FixedDiscipline[] fixedDisciplines)
        {
            FixedDiscipline[] updatedFixedDisciplines = await _fixedDisciplineService.UpdateRangeAsync(fixedDisciplines);
            if (updatedFixedDisciplines is null)
                return NotFound();
            return Ok(updatedFixedDisciplines);
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromBody] FixedDiscipline fixedDiscipline)
        {
            if (id != fixedDiscipline.FixedDisciplineId)
                return BadRequest();
            await _fixedDisciplineService.DeleteAsync(fixedDiscipline);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] FixedDiscipline[] fixedDisciplines)
        {
            await _fixedDisciplineService.DeleteRangeAsync(fixedDisciplines);
            return Ok();
        }
    }
}
