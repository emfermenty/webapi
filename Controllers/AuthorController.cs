using api.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/authors")]
    [Authorize(Policy = "EveryOne")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService service;
        public AuthorController(IAuthorService service) { 
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAuthors(CancellationToken cancellationToken)
        {
            return Ok(await service.GetAllAuthors(cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            return Ok(await service.GetAuthorByIdAsync(id, cancellationToken));
        }
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] Author author, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await service.AddAuthor(author, cancellationToken);
            return Ok(author);
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await service.DeleteAuthor(id, cancellationToken));
        }
        [HttpPut("edit/{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Author author, CancellationToken cancellationToken)
        {
            await service.UpdateAuthor(author, cancellationToken);
            return Ok();
        }
    }
}
