using api.Dto;
using api.Repository.interfaces;
using api.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPostsAsync()
        {
            return Ok(await postService.GetAllPostsAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPostById(int id)
        {
            return Ok(await postService.GetPostByIdAsync(id));
        }
        [HttpGet("delete/{id}")]
        public async Task<ActionResult<int>> DeletePost(int id)
        {
            return Ok(await postService.DeletePost(id));
        }
        //[HttpPost("create")]
        //public async Task<ActionResult> CreatePost([FromBody] Post post)
        //{

        //}
    }
}
