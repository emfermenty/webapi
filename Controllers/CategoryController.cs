using api.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Authorize(Policy = "EveryOne")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var categories = await service.GetAllCategoriesAsync(cancellationToken);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            return Ok(await service.GetCategoriesById(id, cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Category category, CancellationToken cancellationToken)
        {
            await service.AddCategory(category, cancellationToken);
            return Ok();
        }

        [HttpDelete("delete/{id}")] 
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await service.GetCategoriesById(id, cancellationToken));
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Category category, CancellationToken cancellationToken)
        {
            if (id != category.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await service.UpdateCategory(category, cancellationToken));
        }
    }
}
