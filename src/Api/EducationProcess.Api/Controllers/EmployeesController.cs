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
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Employee), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Employee employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee is null)
                return NotFound();
            return Ok(employee);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(Employee[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            Employee[] employees = await _employeeService.GetAllEmployeesAsync();
            if (employees.Length == 0)
                return NotFound();
            return Ok(employees);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Employee), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Employee([FromBody] Employee employee)
        {
            Employee addedEmployee = await _employeeService.AddEmployeeAsync(employee);
            if (addedEmployee is null)
                return NotFound();
            return Ok(addedEmployee);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(Employee[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EmployeeRange([FromBody] Employee[] employees)
        {
            Employee[] addedEmployees = await _employeeService.AddRangeEmployeeAsync(employees);
            if (addedEmployees is null)
                return NotFound();
            return Ok(addedEmployees);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Employee), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] Employee employee)
        {
            Employee updatedEmployee = await _employeeService.UpdateEmployeeAsync(employee);
            if (updatedEmployee is null)
                return NotFound();
            return Ok(updatedEmployee);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(Employee[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] Employee[] employees)
        {
            Employee[] updatedEmployees = await _employeeService.UpdateRangeEmployeeAsync(employees);
            if (updatedEmployees is null)
                return NotFound();
            return Ok(updatedEmployees);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] Employee employee)
        {
            await _employeeService.DeleteEmployeeAsync(employee);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] Employee[] employees)
        {
            await _employeeService.DeleteRangeEmployeeAsync(employees);
            return Ok();
        }
    }
}
