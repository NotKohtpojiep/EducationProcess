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
    public class AudiencesController : ControllerBase
    {
        private readonly ILogger<AudiencesController> _logger;
        private readonly IAudienceService _audienceService;

        public AudiencesController(ILogger<AudiencesController> logger, IAudienceService audienceService)
        {
            _logger = logger;
            _audienceService = audienceService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Audience), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Audience audience = await _audienceService.GetAudienceByIdAsync(id);
            if (audience is null)
                return NotFound();
            return Ok(audience);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(Audience[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            Audience[] audiences = await _audienceService.GetAllAudiencesAsync();
            if (audiences.Length == 0)
                return NotFound();
            return Ok(audiences);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Audience), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Audience([FromBody] Audience audience)
        {
            Audience addedAudience = await _audienceService.AddAudienceAsync(audience);
            if (addedAudience is null)
                return NotFound();
            return Ok(addedAudience);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(Audience[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AudienceRange([FromBody] Audience[] audiences)
        {
            Audience[] addedAudiences = await _audienceService.AddRangeAudienceAsync(audiences);
            if (addedAudiences is null)
                return NotFound();
            return Ok(addedAudiences);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Audience), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] Audience audience)
        {
            Audience updatedAudience = await _audienceService.UpdateAudienceAsync(audience);
            if (updatedAudience is null)
                return NotFound();
            return Ok(updatedAudience);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(Audience[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] Audience[] audiences)
        {
            Audience[] updatedAudiences = await _audienceService.UpdateRangeAudienceAsync(audiences);
            if (updatedAudiences is null)
                return NotFound();
            return Ok(updatedAudiences);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] Audience audience)
        {
            await _audienceService.DeleteAudienceAsync(audience);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] Audience[] audiences)
        {
            await _audienceService.DeleteRangeAudienceAsync(audiences);
            return Ok();
        }
    }
}
