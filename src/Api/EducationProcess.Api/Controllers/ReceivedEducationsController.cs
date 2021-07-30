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
    public class ReceivedEducationsController : ControllerBase
    {
        private readonly ILogger<ReceivedEducationsController> _logger;
        private readonly IReceivedEducationService _receivedEducationService;

        public ReceivedEducationsController(ILogger<ReceivedEducationsController> logger, IReceivedEducationService receivedEducationService)
        {
            _logger = logger;
            _receivedEducationService = receivedEducationService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ReceivedEducation), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            ReceivedEducation receivedEducation = await _receivedEducationService.GetReceivedEducationByIdAsync(id);
            if (receivedEducation is null)
                return NotFound();
            return Ok(receivedEducation);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(ReceivedEducation[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            ReceivedEducation[] receivedEducations = await _receivedEducationService.GetAllReceivedEducationsAsync();
            if (receivedEducations.Length == 0)
                return NotFound();
            return Ok(receivedEducations);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReceivedEducation), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ReceivedEducation([FromBody] ReceivedEducation receivedEducation)
        {
            ReceivedEducation addedReceivedEducation = await _receivedEducationService.AddReceivedEducationAsync(receivedEducation);
            if (addedReceivedEducation is null)
                return NotFound();
            return Ok(addedReceivedEducation);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(ReceivedEducation[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ReceivedEducationRange([FromBody] ReceivedEducation[] receivedEducations)
        {
            ReceivedEducation[] addedReceivedEducations = await _receivedEducationService.AddRangeReceivedEducationAsync(receivedEducations);
            if (addedReceivedEducations is null)
                return NotFound();
            return Ok(addedReceivedEducations);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ReceivedEducation), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] ReceivedEducation receivedEducation)
        {
            ReceivedEducation updatedReceivedEducation = await _receivedEducationService.UpdateReceivedEducationAsync(receivedEducation);
            if (updatedReceivedEducation is null)
                return NotFound();
            return Ok(updatedReceivedEducation);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(ReceivedEducation[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] ReceivedEducation[] receivedEducations)
        {
            ReceivedEducation[] updatedReceivedEducations = await _receivedEducationService.UpdateRangeReceivedEducationAsync(receivedEducations);
            if (updatedReceivedEducations is null)
                return NotFound();
            return Ok(updatedReceivedEducations);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] ReceivedEducation receivedEducation)
        {
            await _receivedEducationService.DeleteReceivedEducationAsync(receivedEducation);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] ReceivedEducation[] receivedEducations)
        {
            await _receivedEducationService.DeleteRangeReceivedEducationAsync(receivedEducations);
            return Ok();
        }
    }
}
