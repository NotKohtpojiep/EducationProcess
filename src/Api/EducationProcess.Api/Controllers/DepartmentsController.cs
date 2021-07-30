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
    public class DepartmentsController : ControllerBase
    {
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(ILogger<DepartmentsController> logger, IDepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Department), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Department department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department is null)
                return NotFound();
            return Ok(department);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(Department[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            Department[] departments = await _departmentService.GetAllDepartmentsAsync();
            if (departments.Length == 0)
                return NotFound();
            return Ok(departments);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Department), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Department([FromBody] Department department)
        {
            Department addedDepartment = await _departmentService.AddDepartmentAsync(department);
            if (addedDepartment is null)
                return NotFound();
            return Ok(addedDepartment);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(Department[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DepartmentRange([FromBody] Department[] departments)
        {
            Department[] addedDepartments = await _departmentService.AddRangeDepartmentAsync(departments);
            if (addedDepartments is null)
                return NotFound();
            return Ok(addedDepartments);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Department), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] Department department)
        {
            Department updatedDepartment = await _departmentService.UpdateDepartmentAsync(department);
            if (updatedDepartment is null)
                return NotFound();
            return Ok(updatedDepartment);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(Department[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] Department[] departments)
        {
            Department[] updatedDepartments = await _departmentService.UpdateRangeDepartmentAsync(departments);
            if (updatedDepartments is null)
                return NotFound();
            return Ok(updatedDepartments);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] Department department)
        {
            await _departmentService.DeleteDepartmentAsync(department);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] Department[] departments)
        {
            await _departmentService.DeleteRangeDepartmentAsync(departments);
            return Ok();
        }
    }
}
