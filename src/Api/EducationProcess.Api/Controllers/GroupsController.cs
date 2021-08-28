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
    public class GroupsController : ControllerBase
    {
        private readonly ILogger<GroupsController> _logger;
        private readonly IGroupService _groupService;

        public GroupsController(ILogger<GroupsController> logger, IGroupService groupService)
        {
            _logger = logger;
            _groupService = groupService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Group), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Group group = await _groupService.GetGroupByIdAsync(id);
            if (group is null)
                return NotFound();
            return Ok(group);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Group[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            Group[] groups = await _groupService.GetAllGroupsAsync();
            if (groups.Length == 0)
                return NotFound();
            return Ok(groups);
        }

        [HttpGet("current")]
        [ProducesResponseType(typeof(Group[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetCurrentGroups([FromQuery] DateTime date)
        {
            Group[] currentGroups = await _groupService.GetAllCurrentGroupsByDateAsync(date);
            if (currentGroups.Length == 0)
                return NotFound();
            return Ok(currentGroups);
        }

        [HttpPost("{id:int}")]
        [ProducesResponseType(typeof(Group), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Group([FromBody] Group group)
        {
            Group addedGroup = await _groupService.AddGroupAsync(group);
            if (addedGroup is null)
                return NotFound();
            return Ok(addedGroup);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Group[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GroupRange([FromBody] Group[] groups)
        {
            Group[] addedGroups = await _groupService.AddRangeGroupAsync(groups);
            if (addedGroups is null)
                return NotFound();
            return Ok(addedGroups);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(Group), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] Group group)
        {
            Group updatedGroup = await _groupService.UpdateGroupAsync(group);
            if (updatedGroup is null)
                return NotFound();
            return Ok(updatedGroup);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Group[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] Group[] groups)
        {
            Group[] updatedGroups = await _groupService.UpdateRangeGroupAsync(groups);
            if (updatedGroups is null)
                return NotFound();
            return Ok(updatedGroups);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] Group group)
        {
            await _groupService.DeleteGroupAsync(group);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] Group[] groups)
        {
            await _groupService.DeleteRangeGroupAsync(groups);
            return Ok();
        }
    }
}
