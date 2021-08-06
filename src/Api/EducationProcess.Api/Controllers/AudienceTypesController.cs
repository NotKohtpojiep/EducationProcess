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
    public class AudienceTypesController : ControllerBase
    {
        private readonly ILogger<AudienceTypesController> _logger;
        private readonly IAudienceTypeService _audienceTypeService;

        public AudienceTypesController(ILogger<AudienceTypesController> logger, IAudienceTypeService audienceTypeService)
        {
            _logger = logger;
            _audienceTypeService = audienceTypeService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AudienceType), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            AudienceType audienceType = await _audienceTypeService.GetAudienceTypeByIdAsync(id);
            if (audienceType is null)
                return NotFound();
            return Ok(audienceType);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(AudienceType[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            AudienceType[] audienceTypes = await _audienceTypeService.GetAllAudienceTypesAsync();
            if (audienceTypes.Length == 0)
                return NotFound();
            return Ok(audienceTypes);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AudienceType), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AudienceType([FromBody] AudienceType audienceType)
        {
            AudienceType addedAudienceType = await _audienceTypeService.AddAudienceTypeAsync(audienceType);
            if (addedAudienceType is null)
                return NotFound();
            return Ok(addedAudienceType);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(AudienceType[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AudienceTypeRange([FromBody] AudienceType[] audienceTypes)
        {
            AudienceType[] addedAudienceTypes = await _audienceTypeService.AddRangeAudienceTypeAsync(audienceTypes);
            if (addedAudienceTypes is null)
                return NotFound();
            return Ok(addedAudienceTypes);
        }

        [HttpPut]
        [ProducesResponseType(typeof(AudienceType), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] AudienceType audienceType)
        {
            AudienceType updatedAudienceType = await _audienceTypeService.UpdateAudienceTypeAsync(audienceType);
            if (updatedAudienceType is null)
                return NotFound();
            return Ok(updatedAudienceType);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(AudienceType[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] AudienceType[] audienceTypes)
        {                                   
            AudienceType[] updatedAudienceTypes = await _audienceTypeService.UpdateRangeAudienceTypeAsync(audienceTypes);
            if (updatedAudienceTypes is null)
                return NotFound();
            return Ok(updatedAudienceTypes);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] AudienceType audienceType)
        {
            await _audienceTypeService.DeleteAudienceTypeAsync(audienceType);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] AudienceType[] audienceTypes)
        {
            await _audienceTypeService.DeleteRangeAudienceTypeAsync(audienceTypes);
            return Ok();
        }
    }
}
