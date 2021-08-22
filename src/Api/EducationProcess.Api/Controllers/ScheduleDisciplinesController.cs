using System;
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
    public class ScheduleDisciplinesController : ControllerBase
    {
        private readonly ILogger<ScheduleDisciplinesController> _logger;
        private readonly IScheduleDisciplineService _scheduleDisciplineService;

        public ScheduleDisciplinesController(ILogger<ScheduleDisciplinesController> logger, IScheduleDisciplineService scheduleDisciplineService)
        {
            _logger = logger;
            _scheduleDisciplineService = scheduleDisciplineService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ScheduleDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            ScheduleDiscipline scheduleDiscipline = await _scheduleDisciplineService.GetScheduleDisciplineByIdAsync(id);
            if (scheduleDiscipline is null)
                return NotFound();
            return Ok(scheduleDiscipline);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ScheduleDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Post([FromBody] ScheduleDiscipline scheduleDiscipline)
        {
            ScheduleDiscipline addedScheduleDiscipline = await _scheduleDisciplineService.AddScheduleDisciplineAsync(scheduleDiscipline);
            if (addedScheduleDiscipline is null)
                return NotFound();
            return Ok(addedScheduleDiscipline);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(ScheduleDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PostRange([FromBody] ScheduleDiscipline[] scheduleDisciplines)
        {
            ScheduleDiscipline[] addedScheduleDisciplines = await _scheduleDisciplineService.AddRangeScheduleDisciplineAsync(scheduleDisciplines);
            if (addedScheduleDisciplines is null)
                return NotFound();
            return Ok(addedScheduleDisciplines);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ScheduleDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] ScheduleDiscipline scheduleDiscipline)
        {
            ScheduleDiscipline updatedScheduleDiscipline = await _scheduleDisciplineService.UpdateScheduleDisciplineAsync(scheduleDiscipline);
            if (updatedScheduleDiscipline is null)
                return NotFound();
            return Ok(updatedScheduleDiscipline);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(ScheduleDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] ScheduleDiscipline[] scheduleDisciplines)
        {                                   
            ScheduleDiscipline[] updatedScheduleDisciplines = await _scheduleDisciplineService.UpdateRangeScheduleDisciplineAsync(scheduleDisciplines);
            if (updatedScheduleDisciplines is null)
                return NotFound();
            return Ok(updatedScheduleDisciplines);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] ScheduleDiscipline scheduleDiscipline)
        {
            await _scheduleDisciplineService.DeleteScheduleDisciplineAsync(scheduleDiscipline);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] ScheduleDiscipline[] scheduleDisciplines)
        {
            await _scheduleDisciplineService.DeleteRangeScheduleDisciplineAsync(scheduleDisciplines);
            return Ok();
        }

        [HttpGet("for-all/{date:DateTime}")]
        [ProducesResponseType(typeof(ScheduleDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetForAllGroupsForWeekByDate([FromRoute] DateTime date)
        {
            ScheduleDiscipline[] updatedScheduleDiscipline = await _scheduleDisciplineService.GetScheduleForWeekAndAllGroupsByDateWithIncludeAsync(date);
            if (updatedScheduleDiscipline is null)
                return NotFound();
            return Ok(updatedScheduleDiscipline);
        }

        [HttpGet("for/{groupId:int}")]
        [ProducesResponseType(typeof(ScheduleDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetCurrentForGroup([FromRoute] int groupId)
        {
            ScheduleDiscipline[] updatedScheduleDisciplines = await _scheduleDisciplineService.GetScheduleForWeekByGroupIdWithIncludeAsync(groupId);
            if (updatedScheduleDisciplines is null)
                return NotFound();
            return Ok(updatedScheduleDisciplines);
        }

        [HttpGet("for-department/{departmentId:int}/{date:DateTime}")]
        [ProducesResponseType(typeof(ScheduleDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetForAllGroupsForWeekByDateAndDepartment([FromRoute] int departmentId, DateTime date)
        {
            ScheduleDiscipline[] updatedScheduleDiscipline = await _scheduleDisciplineService.GetScheduleForWeekAndAllGroupsByDateAndDepartmentIdWithIncludeAsync(departmentId, date);
            if (updatedScheduleDiscipline is null)
                return NotFound();
            return Ok(updatedScheduleDiscipline);
        }

        [HttpGet("for-teacher/{teacherId:int}")]
        [ProducesResponseType(typeof(ScheduleDiscipline[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetCurrentForTeacher([FromRoute] int teacherId)
        {
            ScheduleDiscipline[] updatedScheduleDisciplines = await _scheduleDisciplineService.GetScheduleForWeekForTeacherByTeacherIdWithIncludeAsync(teacherId, new DateTime(2020,5,19));
            if (updatedScheduleDisciplines is null)
                return NotFound();
            return Ok(updatedScheduleDisciplines);
        }
    }
}
