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
    public class CathedrasController : ControllerBase
    {
        private readonly ILogger<CathedrasController> _logger;
        private readonly ICathedraService _cathedraService;

        public CathedrasController(ILogger<CathedrasController> logger, ICathedraService cathedraService)
        {
            _logger = logger;
            _cathedraService = cathedraService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Cathedra), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Cathedra cathedra = await _cathedraService.GetCathedraByIdAsync(id);
            if (cathedra is null)
                return NotFound();
            return Ok(cathedra);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(Cathedra[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            Cathedra[] cathedras = await _cathedraService.GetAllCathedrasAsync();
            if (cathedras.Length == 0)
                return NotFound();
            return Ok(cathedras);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Cathedra), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Cathedra([FromBody] Cathedra cathedra)
        {
            Cathedra addedCathedra = await _cathedraService.AddCathedraAsync(cathedra);
            if (addedCathedra is null)
                return NotFound();
            return Ok(addedCathedra);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(Cathedra[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> CathedraRange([FromBody] Cathedra[] cathedras)
        {
            Cathedra[] addedCathedras = await _cathedraService.AddRangeCathedraAsync(cathedras);
            if (addedCathedras is null)
                return NotFound();
            return Ok(addedCathedras);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Cathedra), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] Cathedra cathedra)
        {
            Cathedra updatedCathedra = await _cathedraService.UpdateCathedraAsync(cathedra);
            if (updatedCathedra is null)
                return NotFound();
            return Ok(updatedCathedra);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(Cathedra[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] Cathedra[] cathedras)
        {
            Cathedra[] updatedCathedras = await _cathedraService.UpdateRangeCathedraAsync(cathedras);
            if (updatedCathedras is null)
                return NotFound();
            return Ok(updatedCathedras);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] Cathedra cathedra)
        {
            await _cathedraService.DeleteCathedraAsync(cathedra);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] Cathedra[] cathedras)
        {
            await _cathedraService.DeleteRangeCathedraAsync(cathedras);
            return Ok();
        }
    }
}
