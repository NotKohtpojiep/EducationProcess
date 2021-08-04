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
    public class EducationPlansController : ControllerBase
    {
        private readonly ILogger<EducationPlansController> _logger;
        private readonly IEducationPlanService _educationPlanService;

        public EducationPlansController(ILogger<EducationPlansController> logger, IEducationPlanService educationPlanService)
        {
            _logger = logger;
            _educationPlanService = educationPlanService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(EducationPlan), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            EducationPlan educationPlan = await _educationPlanService.GetEducationPlanByIdAsync(id);
            if (educationPlan is null)
                return NotFound();
            return Ok(educationPlan);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(EducationPlan[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            EducationPlan[] educationPlans = await _educationPlanService.GetAllEducationPlansAsync();
            if (educationPlans.Length == 0)
                return NotFound();
            return Ok(educationPlans);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EducationPlan), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EducationPlan([FromBody] EducationPlan educationPlan)
        {
            EducationPlan addedEducationPlan = await _educationPlanService.AddEducationPlanAsync(educationPlan);
            if (addedEducationPlan is null)
                return NotFound();
            return Ok(addedEducationPlan);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(EducationPlan[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EducationPlanRange([FromBody] EducationPlan[] educationPlans)
        {
            EducationPlan[] addedEducationPlans = await _educationPlanService.AddRangeEducationPlanAsync(educationPlans);
            if (addedEducationPlans is null)
                return NotFound();
            return Ok(addedEducationPlans);
        }

        [HttpPut]
        [ProducesResponseType(typeof(EducationPlan), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] EducationPlan educationPlan)
        {
            EducationPlan updatedEducationPlan = await _educationPlanService.UpdateEducationPlanAsync(educationPlan);
            if (updatedEducationPlan is null)
                return NotFound();
            return Ok(updatedEducationPlan);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(EducationPlan[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] EducationPlan[] educationPlans)
        {
            EducationPlan[] updatedEducationPlans = await _educationPlanService.UpdateRangeEducationPlanAsync(educationPlans);
            if (updatedEducationPlans is null)
                return NotFound();
            return Ok(updatedEducationPlans);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] EducationPlan educationPlan)
        {
            await _educationPlanService.DeleteEducationPlanAsync(educationPlan);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] EducationPlan[] educationPlans)
        {
            await _educationPlanService.DeleteRangeEducationPlanAsync(educationPlans);
            return Ok();
        }
    }
}
