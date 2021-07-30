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
    public class ReceivedEducationFormsController : ControllerBase
    {
        private readonly ILogger<ReceivedEducationFormsController> _logger;
        private readonly IReceivedEducationFormService _receivedEducationFormService;

        public ReceivedEducationFormsController(ILogger<ReceivedEducationFormsController> logger, IReceivedEducationFormService receivedEducationFormService)
        {
            _logger = logger;
            _receivedEducationFormService = receivedEducationFormService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ReceivedEducationForm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            ReceivedEducationForm receivedEducationForm = await _receivedEducationFormService.GetReceivedEducationFormByIdAsync(id);
            if (receivedEducationForm is null)
                return NotFound();
            return Ok(receivedEducationForm);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(ReceivedEducationForm[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            ReceivedEducationForm[] receivedEducationForms = await _receivedEducationFormService.GetAllReceivedEducationFormsAsync();
            if (receivedEducationForms.Length == 0)
                return NotFound();
            return Ok(receivedEducationForms);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReceivedEducationForm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ReceivedEducationForm([FromBody] ReceivedEducationForm receivedEducationForm)
        {
            ReceivedEducationForm addedReceivedEducationForm = await _receivedEducationFormService.AddReceivedEducationFormAsync(receivedEducationForm);
            if (addedReceivedEducationForm is null)
                return NotFound();
            return Ok(addedReceivedEducationForm);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(ReceivedEducationForm[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ReceivedEducationFormRange([FromBody] ReceivedEducationForm[] receivedEducationForms)
        {
            ReceivedEducationForm[] addedReceivedEducationForms = await _receivedEducationFormService.AddRangeReceivedEducationFormAsync(receivedEducationForms);
            if (addedReceivedEducationForms is null)
                return NotFound();
            return Ok(addedReceivedEducationForms);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ReceivedEducationForm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] ReceivedEducationForm receivedEducationForm)
        {
            ReceivedEducationForm updatedReceivedEducationForm = await _receivedEducationFormService.UpdateReceivedEducationFormAsync(receivedEducationForm);
            if (updatedReceivedEducationForm is null)
                return NotFound();
            return Ok(updatedReceivedEducationForm);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(ReceivedEducationForm[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] ReceivedEducationForm[] receivedEducationForms)
        {
            ReceivedEducationForm[] updatedReceivedEducationForms = await _receivedEducationFormService.UpdateRangeReceivedEducationFormAsync(receivedEducationForms);
            if (updatedReceivedEducationForms is null)
                return NotFound();
            return Ok(updatedReceivedEducationForms);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] ReceivedEducationForm receivedEducationForm)
        {
            await _receivedEducationFormService.DeleteReceivedEducationFormAsync(receivedEducationForm);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] ReceivedEducationForm[] receivedEducationForms)
        {
            await _receivedEducationFormService.DeleteRangeReceivedEducationFormAsync(receivedEducationForms);
            return Ok();
        }
    }
}
