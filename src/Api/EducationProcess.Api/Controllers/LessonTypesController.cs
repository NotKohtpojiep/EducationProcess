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
    public class LessonTypesController : ControllerBase
    {
        private readonly ILogger<LessonTypesController> _logger;
        private readonly ILessonTypeService _lessonTypeService;

        public LessonTypesController(ILogger<LessonTypesController> logger, ILessonTypeService lessonTypeService)
        {
            _logger = logger;
            _lessonTypeService = lessonTypeService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(LessonType), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            LessonType lessonType = await _lessonTypeService.GetLessonTypeByIdAsync(id);
            if (lessonType is null)
                return NotFound();
            return Ok(lessonType);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(LessonType[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            LessonType[] lessonTypes = await _lessonTypeService.GetAllLessonTypesAsync();
            if (lessonTypes.Length == 0)
                return NotFound();
            return Ok(lessonTypes);
        }

        [HttpPost]
        [ProducesResponseType(typeof(LessonType), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> LessonType([FromBody] LessonType lessonType)
        {
            LessonType addedLessonType = await _lessonTypeService.AddLessonTypeAsync(lessonType);
            if (addedLessonType is null)
                return NotFound();
            return Ok(addedLessonType);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(LessonType[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> LessonTypeRange([FromBody] LessonType[] lessonTypes)
        {
            LessonType[] addedLessonTypes = await _lessonTypeService.AddRangeLessonTypeAsync(lessonTypes);
            if (addedLessonTypes is null)
                return NotFound();
            return Ok(addedLessonTypes);
        }

        [HttpPut]
        [ProducesResponseType(typeof(LessonType), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] LessonType lessonType)
        {
            LessonType updatedLessonType = await _lessonTypeService.UpdateLessonTypeAsync(lessonType);
            if (updatedLessonType is null)
                return NotFound();
            return Ok(updatedLessonType);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(LessonType[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] LessonType[] lessonTypes)
        {
            LessonType[] updatedLessonTypes = await _lessonTypeService.UpdateRangeLessonTypeAsync(lessonTypes);
            if (updatedLessonTypes is null)
                return NotFound();
            return Ok(updatedLessonTypes);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] LessonType lessonType)
        {
            await _lessonTypeService.DeleteLessonTypeAsync(lessonType);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] LessonType[] lessonTypes)
        {
            await _lessonTypeService.DeleteRangeLessonTypeAsync(lessonTypes);
            return Ok();
        }
    }
}
