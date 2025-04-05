using api.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService service;
        public AuthorController(IAuthorService service) { 
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAuthors()
        {
            var authors = await service.GetAllAuthors();
            return Ok(authors);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var author = await service.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Author author)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await service.AddAuthor(author);
            return Ok(author);
        }
        [HttpGet("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var author = await service.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound(id);
            }
            await service.DeleteAuthor(id);
            return NoContent();
        }
        [HttpPut("edit/{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Author author)
        {
            if(id != author.id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            await service.UpdateAuthor(author);
            return NoContent();
        }
    }
}
