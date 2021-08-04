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
    public class FsesCategoryPartitionsController : ControllerBase
    {
        private readonly ILogger<FsesCategoryPartitionsController> _logger;
        private readonly IFsesCategoryPartitionService _fsesCategoryPartitionService;

        public FsesCategoryPartitionsController(ILogger<FsesCategoryPartitionsController> logger, IFsesCategoryPartitionService fsesCategoryPartitionService)
        {
            _logger = logger;
            _fsesCategoryPartitionService = fsesCategoryPartitionService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(FsesCategoryPartition), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            FsesCategoryPartition fsesCategoryPartition = await _fsesCategoryPartitionService.GetFsesCategoryPartitionByIdAsync(id);
            if (fsesCategoryPartition is null)
                return NotFound();
            return Ok(fsesCategoryPartition);
        }

        [HttpGet("array")]
        [ProducesResponseType(typeof(FsesCategoryPartition[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            FsesCategoryPartition[] fsesCategoryPartitions = await _fsesCategoryPartitionService.GetAllFsesCategoryPartitionsAsync();
            if (fsesCategoryPartitions.Length == 0)
                return NotFound();
            return Ok(fsesCategoryPartitions);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FsesCategoryPartition), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> FsesCategoryPartition([FromBody] FsesCategoryPartition fsesCategoryPartition)
        {
            FsesCategoryPartition addedFsesCategoryPartition = await _fsesCategoryPartitionService.AddFsesCategoryPartitionAsync(fsesCategoryPartition);
            if (addedFsesCategoryPartition is null)
                return NotFound();
            return Ok(addedFsesCategoryPartition);
        }

        [HttpPost("array")]
        [ProducesResponseType(typeof(FsesCategoryPartition[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> FsesCategoryPartitionRange([FromBody] FsesCategoryPartition[] fsesCategoryPartitions)
        {
            FsesCategoryPartition[] addedFsesCategoryPartitions = await _fsesCategoryPartitionService.AddRangeFsesCategoryPartitionAsync(fsesCategoryPartitions);
            if (addedFsesCategoryPartitions is null)
                return NotFound();
            return Ok(addedFsesCategoryPartitions);
        }

        [HttpPut]
        [ProducesResponseType(typeof(FsesCategoryPartition), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] FsesCategoryPartition fsesCategoryPartition)
        {
            FsesCategoryPartition updatedFsesCategoryPartition = await _fsesCategoryPartitionService.UpdateFsesCategoryPartitionAsync(fsesCategoryPartition);
            if (updatedFsesCategoryPartition is null)
                return NotFound();
            return Ok(updatedFsesCategoryPartition);
        }

        [HttpPut("array")]
        [ProducesResponseType(typeof(FsesCategoryPartition[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] FsesCategoryPartition[] fsesCategoryPartitions)
        {
            FsesCategoryPartition[] updatedFsesCategoryPartitions = await _fsesCategoryPartitionService.UpdateRangeFsesCategoryPartitionAsync(fsesCategoryPartitions);
            if (updatedFsesCategoryPartitions is null)
                return NotFound();
            return Ok(updatedFsesCategoryPartitions);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] FsesCategoryPartition fsesCategoryPartition)
        {
            await _fsesCategoryPartitionService.DeleteFsesCategoryPartitionAsync(fsesCategoryPartition);
            return Ok();
        }

        [HttpDelete("array")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] FsesCategoryPartition[] fsesCategoryPartitions)
        {
            await _fsesCategoryPartitionService.DeleteRangeFsesCategoryPartitionAsync(fsesCategoryPartitions);
            return Ok();
        }
    }
}
