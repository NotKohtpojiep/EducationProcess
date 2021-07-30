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
    public class EducationFormsController : ControllerBase
    {
        private readonly ILogger<EducationFormsController> _logger;
        private readonly IEducationFormService _educationFormService;

        public EducationFormsController(ILogger<EducationFormsController> logger, IEducationFormService educationFormService)
        {
            _logger = logger;
            _educationFormService = educationFormService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(EducationForm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            EducationForm educationForm = await _educationFormService.GetEducationFormByIdAsync(id);
            if (educationForm is null)
                return NotFound();
            return Ok(educationForm);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(EducationForm[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            EducationForm[] educationForms = await _educationFormService.GetAllEducationFormsAsync();
            if (educationForms.Length == 0)
                return NotFound();
            return Ok(educationForms);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EducationForm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EducationForm([FromBody] EducationForm educationForm)
        {
            EducationForm addedEducationForm = await _educationFormService.AddEducationFormAsync(educationForm);
            if (addedEducationForm is null)
                return NotFound();
            return Ok(addedEducationForm);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(EducationForm[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EducationFormRange([FromBody] EducationForm[] educationForms)
        {
            EducationForm[] addedEducationForms = await _educationFormService.AddRangeEducationFormAsync(educationForms);
            if (addedEducationForms is null)
                return NotFound();
            return Ok(addedEducationForms);
        }

        [HttpPut]
        [ProducesResponseType(typeof(EducationForm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] EducationForm educationForm)
        {
            EducationForm updatedEducationForm = await _educationFormService.UpdateEducationFormAsync(educationForm);
            if (updatedEducationForm is null)
                return NotFound();
            return Ok(updatedEducationForm);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(EducationForm[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] EducationForm[] educationForms)
        {
            EducationForm[] updatedEducationForms = await _educationFormService.UpdateRangeEducationFormAsync(educationForms);
            if (updatedEducationForms is null)
                return NotFound();
            return Ok(updatedEducationForms);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] EducationForm educationForm)
        {
            await _educationFormService.DeleteEducationFormAsync(educationForm);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] EducationForm[] educationForms)
        {
            await _educationFormService.DeleteRangeEducationFormAsync(educationForms);
            return Ok();
        }
    }
}
