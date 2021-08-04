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
    public class IntermediateCertificationFormsController : ControllerBase
    {
        private readonly ILogger<IntermediateCertificationFormsController> _logger;
        private readonly IIntermediateCertificationFormService _intermediateCertificationFormService;

        public IntermediateCertificationFormsController(ILogger<IntermediateCertificationFormsController> logger, IIntermediateCertificationFormService intermediateCertificationFormService)
        {
            _logger = logger;
            _intermediateCertificationFormService = intermediateCertificationFormService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(IntermediateCertificationForm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            IntermediateCertificationForm intermediateCertificationForm = await _intermediateCertificationFormService.GetIntermediateCertificationFormByIdAsync(id);
            if (intermediateCertificationForm is null)
                return NotFound();
            return Ok(intermediateCertificationForm);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(IntermediateCertificationForm[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            IntermediateCertificationForm[] intermediateCertificationForms = await _intermediateCertificationFormService.GetAllIntermediateCertificationFormsAsync();
            if (intermediateCertificationForms.Length == 0)
                return NotFound();
            return Ok(intermediateCertificationForms);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IntermediateCertificationForm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> IntermediateCertificationForm([FromBody] IntermediateCertificationForm intermediateCertificationForm)
        {
            IntermediateCertificationForm addedIntermediateCertificationForm = await _intermediateCertificationFormService.AddIntermediateCertificationFormAsync(intermediateCertificationForm);
            if (addedIntermediateCertificationForm is null)
                return NotFound();
            return Ok(addedIntermediateCertificationForm);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(IntermediateCertificationForm[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> IntermediateCertificationFormRange([FromBody] IntermediateCertificationForm[] intermediateCertificationForms)
        {
            IntermediateCertificationForm[] addedIntermediateCertificationForms = await _intermediateCertificationFormService.AddRangeIntermediateCertificationFormAsync(intermediateCertificationForms);
            if (addedIntermediateCertificationForms is null)
                return NotFound();
            return Ok(addedIntermediateCertificationForms);
        }

        [HttpPut]
        [ProducesResponseType(typeof(IntermediateCertificationForm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] IntermediateCertificationForm intermediateCertificationForm)
        {
            IntermediateCertificationForm updatedIntermediateCertificationForm = await _intermediateCertificationFormService.UpdateIntermediateCertificationFormAsync(intermediateCertificationForm);
            if (updatedIntermediateCertificationForm is null)
                return NotFound();
            return Ok(updatedIntermediateCertificationForm);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(IntermediateCertificationForm[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] IntermediateCertificationForm[] intermediateCertificationForms)
        {
            IntermediateCertificationForm[] updatedIntermediateCertificationForms = await _intermediateCertificationFormService.UpdateRangeIntermediateCertificationFormAsync(intermediateCertificationForms);
            if (updatedIntermediateCertificationForms is null)
                return NotFound();
            return Ok(updatedIntermediateCertificationForms);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] IntermediateCertificationForm intermediateCertificationForm)
        {
            await _intermediateCertificationFormService.DeleteIntermediateCertificationFormAsync(intermediateCertificationForm);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] IntermediateCertificationForm[] intermediateCertificationForms)
        {
            await _intermediateCertificationFormService.DeleteRangeIntermediateCertificationFormAsync(intermediateCertificationForms);
            return Ok();
        }
    }
}
