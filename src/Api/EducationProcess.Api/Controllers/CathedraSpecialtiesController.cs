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
    public class CathedraSpecialtiesController : ControllerBase
    {
        private readonly ILogger<CathedraSpecialtiesController> _logger;
        private readonly ICathedraSpecialtyService _cathedraSpecialtyService;

        public CathedraSpecialtiesController(ILogger<CathedraSpecialtiesController> logger, ICathedraSpecialtyService cathedraSpecialtyService)
        {
            _logger = logger;
            _cathedraSpecialtyService = cathedraSpecialtyService;
        }

        [HttpGet("range/by-cathedra/{id:int}")]
        [ProducesResponseType(typeof(CathedraSpecialty[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByCathedraId([FromRoute] int id)
        {
            CathedraSpecialty[] cathedraSpecialties = await _cathedraSpecialtyService.GetAllCathedraSpecialtiesByCathedraIdAsync(id);
            if (cathedraSpecialties is null)
                return NotFound();
            return Ok(cathedraSpecialties);
        }

        [HttpGet("range/by-specialty/{id:int}")]
        [ProducesResponseType(typeof(CathedraSpecialty[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetBySpecialtyId([FromRoute] int id)
        {
            CathedraSpecialty[] cathedraSpecialties = await _cathedraSpecialtyService.GetAllCathedraSpecialtiesBySpecialtyIdAsync(id);
            if (cathedraSpecialties is null)
                return NotFound();
            return Ok(cathedraSpecialties);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(CathedraSpecialty[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            CathedraSpecialty[] cathedraSpecialties = await _cathedraSpecialtyService.GetAllCathedraSpecialtiesAsync();
            if (cathedraSpecialties.Length == 0)
                return NotFound();
            return Ok(cathedraSpecialties);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CathedraSpecialty), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> CathedraSpecialty([FromBody] CathedraSpecialty cathedraSpecialty)
        {
            CathedraSpecialty addedCathedraSpecialty = await _cathedraSpecialtyService.AddCathedraSpecialtyAsync(cathedraSpecialty);
            if (addedCathedraSpecialty is null)
                return NotFound();
            return Ok(addedCathedraSpecialty);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(CathedraSpecialty[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> CathedraSpecialtyRange([FromBody] CathedraSpecialty[] cathedraSpecialties)
        {
            CathedraSpecialty[] addedCathedraSpecialties = await _cathedraSpecialtyService.AddRangeCathedraSpecialtyAsync(cathedraSpecialties);
            if (addedCathedraSpecialties is null)
                return NotFound();
            return Ok(addedCathedraSpecialties);
        }

        [HttpPut]
        [ProducesResponseType(typeof(CathedraSpecialty), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] CathedraSpecialty cathedraSpecialty)
        {
            CathedraSpecialty updatedCathedraSpecialty = await _cathedraSpecialtyService.UpdateCathedraSpecialtyAsync(cathedraSpecialty);
            if (updatedCathedraSpecialty is null)
                return NotFound();
            return Ok(updatedCathedraSpecialty);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(CathedraSpecialty[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] CathedraSpecialty[] cathedraSpecialties)
        {
            CathedraSpecialty[] updatedCathedraSpecialties = await _cathedraSpecialtyService.UpdateRangeCathedraSpecialtyAsync(cathedraSpecialties);
            if (updatedCathedraSpecialties is null)
                return NotFound();
            return Ok(updatedCathedraSpecialties);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] CathedraSpecialty cathedraSpecialty)
        {
            await _cathedraSpecialtyService.DeleteCathedraSpecialtyAsync(cathedraSpecialty);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] CathedraSpecialty[] cathedraSpecialties)
        {
            await _cathedraSpecialtyService.DeleteRangeCathedraSpecialtyAsync(cathedraSpecialties);
            return Ok();
        }
    }
}
