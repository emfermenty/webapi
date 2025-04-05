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
            return Ok(await service.GetAllAuthors());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await service.GetAuthorByIdAsync(id));
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Author author)
        {
            await service.AddAuthor(author);
            return Ok(author);
        }
        [HttpGet("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await service.DeleteAuthor(id));
        }
        [HttpPut("edit/{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Author author)
        {
            await service.UpdateAuthor(author);
            return Ok();
        }
    }
}
