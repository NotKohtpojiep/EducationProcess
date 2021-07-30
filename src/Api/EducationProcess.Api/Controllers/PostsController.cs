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
    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;
        private readonly IPostService _postService;

        public PostsController(ILogger<PostsController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Post), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Post post = await _postService.GetPostByIdAsync(id);
            if (post is null)
                return NotFound();
            return Ok(post);
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(Post[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRange()
        {
            Post[] posts = await _postService.GetAllPostsAsync();
            if (posts.Length == 0)
                return NotFound();
            return Ok(posts);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Post), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
            Post addedPost = await _postService.AddPostAsync(post);
            if (addedPost is null)
                return NotFound();
            return Ok(addedPost);
        }

        [HttpPost("range")]
        [ProducesResponseType(typeof(Post[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PostRange([FromBody] Post[] posts)
        {
            Post[] addedPosts = await _postService.AddRangePostAsync(posts);
            if (addedPosts is null)
                return NotFound();
            return Ok(addedPosts);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Post), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromBody] Post post)
        {
            Post updatedPost = await _postService.UpdatePostAsync(post);
            if (updatedPost is null)
                return NotFound();
            return Ok(updatedPost);
        }

        [HttpPut("range")]
        [ProducesResponseType(typeof(Post[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutRange([FromBody] Post[] posts)
        {                                   
            Post[] updatedPosts = await _postService.UpdateRangePostAsync(posts);
            if (updatedPosts is null)
                return NotFound();
            return Ok(updatedPosts);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromBody] Post post)
        {
            await _postService.DeletePostAsync(post);
            return Ok();
        }

        [HttpDelete("range")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRange([FromBody] Post[] posts)
        {
            await _postService.DeleteRangePostAsync(posts);
            return Ok();
        }
    }
}
