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
    public class ReceivedSpecialtiesController : ControllerBase
    {
        private readonly ILogger<ReceivedSpecialtiesController> _logger;
        private readonly IReceivedSpecialtyService _receivedSpecialtyService;

        public ReceivedSpecialtiesController(ILogger<ReceivedSpecialtiesController> logger, IReceivedSpecialtyService receivedSpecialtyService)
        {
            _logger = logger;
            _receivedSpecialtyService = receivedSpecialtyService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ReceivedSpecialty), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            ReceivedSpecialty receivedSpecialty = await _receivedSpecialtyService.GetReceivedSpecialtyByIdAsync(id);
            if (receivedSpecialty is null)
                return NotFound();
            return Ok(receivedSpecialty);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(ReceivedSpecialty[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            ReceivedSpecialty[] receivedSpecialtys = await _receivedSpecialtyService.GetAllReceivedSpecialtiesAsync();
            if (receivedSpecialtys.Length == 0)
                return NotFound();
            return Ok(receivedSpecialtys);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReceivedSpecialty), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ReceivedSpecialty([FromBody] ReceivedSpecialty receivedSpecialty)
        {
            ReceivedSpecialty addedReceivedSpecialty = await _receivedSpecialtyService.AddReceivedSpecialtyAsync(receivedSpecialty);
            if (addedReceivedSpecialty is null)
                return NotFound();
            return Ok(addedReceivedSpecialty);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(ReceivedSpecialty[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ReceivedSpecialtyRange([FromBody] ReceivedSpecialty[] receivedSpecialtys)
        {
            ReceivedSpecialty[] addedReceivedSpecialties = await _receivedSpecialtyService.AddRangeReceivedSpecialtyAsync(receivedSpecialtys);
            if (addedReceivedSpecialties is null)
                return NotFound();
            return Ok(addedReceivedSpecialties);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ReceivedSpecialty), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] ReceivedSpecialty receivedSpecialty)
        {
            ReceivedSpecialty updatedReceivedSpecialty = await _receivedSpecialtyService.UpdateReceivedSpecialtyAsync(receivedSpecialty);
            if (updatedReceivedSpecialty is null)
                return NotFound();
            return Ok(updatedReceivedSpecialty);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(ReceivedSpecialty[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] ReceivedSpecialty[] receivedSpecialtys)
        {
            ReceivedSpecialty[] updatedReceivedSpecialties = await _receivedSpecialtyService.UpdateRangeReceivedSpecialtyAsync(receivedSpecialtys);
            if (updatedReceivedSpecialties is null)
                return NotFound();
            return Ok(updatedReceivedSpecialties);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] ReceivedSpecialty receivedSpecialty)
        {
            await _receivedSpecialtyService.DeleteReceivedSpecialtyAsync(receivedSpecialty);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] ReceivedSpecialty[] receivedSpecialtys)
        {
            await _receivedSpecialtyService.DeleteRangeReceivedSpecialtyAsync(receivedSpecialtys);
            return Ok();
        }
    }
}
