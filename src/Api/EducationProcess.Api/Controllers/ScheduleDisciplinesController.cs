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
    public class ScheduleDisciplinesController : ControllerBase
    {
        private readonly ILogger<ScheduleDisciplinesController> _logger;
        private readonly IScheduleDisciplineService _scheduleDisciplineService;

        public ScheduleDisciplinesController(ILogger<ScheduleDisciplinesController> logger, IScheduleDisciplineService scheduleDisciplineService)
        {
            _logger = logger;
            _scheduleDisciplineService = scheduleDisciplineService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ScheduleDiscipline), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            ScheduleDiscipline scheduleDiscipline = await _scheduleDisciplineService.GetScheduleDisciplineById(id);
            if (scheduleDiscipline is null)
                return NotFound();
            return Ok(scheduleDiscipline);
        }
    }
}
