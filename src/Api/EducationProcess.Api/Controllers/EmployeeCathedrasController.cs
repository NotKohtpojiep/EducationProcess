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
    public class EmployeeCathedrasController : ControllerBase
    {
        private readonly ILogger<EmployeeCathedrasController> _logger;
        private readonly IEmployeeCathedraService _employeeCathedraService;

        public EmployeeCathedrasController(ILogger<EmployeeCathedrasController> logger, IEmployeeCathedraService employeeCathedraService)
        {
            _logger = logger;
            _employeeCathedraService = employeeCathedraService;
        }

        [HttpGet("range/by-cathedra/{id:int}")]
        [ProducesResponseType(typeof(EmployeeCathedra[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRangeByCathedraId([FromRoute] int id)
        {
            EmployeeCathedra[] employeeCathedras = await _employeeCathedraService.GetAllEmployeeCathedraByCathedraIdAsync(id);
            if (employeeCathedras is null)
                return NotFound();
            return Ok(employeeCathedras);
        }

        [HttpGet("range/by-employee/{id:int}")]
        [ProducesResponseType(typeof(EmployeeCathedra[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRangeByEmployeeId([FromRoute] int id)
        {
            EmployeeCathedra[] employeeCathedras = await _employeeCathedraService.GetAllEmployeeCathedraByEmployeeIdAsync(id);
            if (employeeCathedras is null)
                return NotFound();
            return Ok(employeeCathedras);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(EmployeeCathedra[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            EmployeeCathedra[] employeeCathedras = await _employeeCathedraService.GetAllEmployeeCathedrasAsync();
            if (employeeCathedras.Length == 0)
                return NotFound();
            return Ok(employeeCathedras);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeCathedra), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EmployeeCathedra([FromBody] EmployeeCathedra employeeCathedra)
        {
            EmployeeCathedra addedEmployeeCathedra = await _employeeCathedraService.AddEmployeeCathedraAsync(employeeCathedra);
            if (addedEmployeeCathedra is null)
                return NotFound();
            return Ok(addedEmployeeCathedra);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(EmployeeCathedra[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EmployeeCathedraRange([FromBody] EmployeeCathedra[] employeeCathedras)
        {
            EmployeeCathedra[] addedEmployeeCathedras = await _employeeCathedraService.AddRangeEmployeeCathedraAsync(employeeCathedras);
            if (addedEmployeeCathedras is null)
                return NotFound();
            return Ok(addedEmployeeCathedras);
        }

        [HttpPut]
        [ProducesResponseType(typeof(EmployeeCathedra), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] EmployeeCathedra employeeCathedra)
        {
            EmployeeCathedra updatedEmployeeCathedra = await _employeeCathedraService.UpdateEmployeeCathedraAsync(employeeCathedra);
            if (updatedEmployeeCathedra is null)
                return NotFound();
            return Ok(updatedEmployeeCathedra);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(EmployeeCathedra[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] EmployeeCathedra[] employeeCathedras)
        {
            EmployeeCathedra[] updatedEmployeeCathedras = await _employeeCathedraService.UpdateRangeEmployeeCathedraAsync(employeeCathedras);
            if (updatedEmployeeCathedras is null)
                return NotFound();
            return Ok(updatedEmployeeCathedras);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] EmployeeCathedra employeeCathedra)
        {
            await _employeeCathedraService.DeleteEmployeeCathedraAsync(employeeCathedra);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] EmployeeCathedra[] employeeCathedras)
        {
            await _employeeCathedraService.DeleteRangeEmployeeCathedraAsync(employeeCathedras);
            return Ok();
        }
    }
}
