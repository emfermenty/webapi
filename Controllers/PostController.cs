using api.Dto;
using api.Repository.interfaces;
using api.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/posts")]
    [Authorize(Policy = "EveryOne")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly ILogger<PostController> logger;
        public PostController(IPostService postService, ILogger<PostController> logger)
        {
            this.postService = postService;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPostsAsync(CancellationToken cancellationToken)
        {
            return Ok(await postService.GetAllPostsAsync(cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPostById(int id, CancellationToken cancellationToken)
        {
            return Ok(await postService.GetPostByIdAsync(id, cancellationToken));
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<int>> DeletePost(int id, CancellationToken cancellationToken)
        {
            return Ok(await postService.DeletePost(id, cancellationToken));
        }
        [HttpPost("create")]
        public async Task<ActionResult> CreatePost([FromBody] Post post, CancellationToken cancellationToken)
        {
            await postService.CreatePost(post, cancellationToken);
            return Ok();
        }
        [HttpPut("edit/{id}")]
        public async Task<ActionResult> EditPost(int id, [FromBody] Post post, CancellationToken cancellationToken)
        {
            await postService.UpdateAsync(post, cancellationToken);
            return Ok();
        }
    }
}
