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
    public class FsesCategoriesController : ControllerBase
    {
        private readonly ILogger<FsesCategoriesController> _logger;
        private readonly IFsesCategoryService _fsesCategoryService;

        public FsesCategoriesController(ILogger<FsesCategoriesController> logger, IFsesCategoryService fsesCategoryService)
        {
            _logger = logger;
            _fsesCategoryService = fsesCategoryService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(FsesCategory), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            FsesCategory fsesCategory = await _fsesCategoryService.GetFsesCategoryByIdAsync(id);
            if (fsesCategory is null)
                return NotFound();
            return Ok(fsesCategory);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(FsesCategory[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            FsesCategory[] fsesCategorys = await _fsesCategoryService.GetAllFsesCategoriesAsync();
            if (fsesCategorys.Length == 0)
                return NotFound();
            return Ok(fsesCategorys);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FsesCategory), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> FsesCategory([FromBody] FsesCategory fsesCategory)
        {
            FsesCategory addedFsesCategory = await _fsesCategoryService.AddFsesCategoryAsync(fsesCategory);
            if (addedFsesCategory is null)
                return NotFound();
            return Ok(addedFsesCategory);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(FsesCategory[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> FsesCategoryRange([FromBody] FsesCategory[] fsesCategorys)
        {
            FsesCategory[] addedFsesCategories = await _fsesCategoryService.AddRangeFsesCategoryAsync(fsesCategorys);
            if (addedFsesCategories is null)
                return NotFound();
            return Ok(addedFsesCategories);
        }

        [HttpPut]
        [ProducesResponseType(typeof(FsesCategory), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] FsesCategory fsesCategory)
        {
            FsesCategory updatedFsesCategory = await _fsesCategoryService.UpdateFsesCategoryAsync(fsesCategory);
            if (updatedFsesCategory is null)
                return NotFound();
            return Ok(updatedFsesCategory);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(FsesCategory[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] FsesCategory[] fsesCategorys)
        {
            FsesCategory[] updatedFsesCategories = await _fsesCategoryService.UpdateRangeFsesCategoryAsync(fsesCategorys);
            if (updatedFsesCategories is null)
                return NotFound();
            return Ok(updatedFsesCategories);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] FsesCategory fsesCategory)
        {
            await _fsesCategoryService.DeleteFsesCategoryAsync(fsesCategory);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] FsesCategory[] fsesCategorys)
        {
            await _fsesCategoryService.DeleteRangeFsesCategoryAsync(fsesCategorys);
            return Ok();
        }
    }
}
