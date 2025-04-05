using api.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/categories")]  // Базовый маршрут
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        // Метод для получения всех категорий
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await service.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // Метод для получения категории по id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await service.GetCategoriesById(id));
        }

        // Метод для создания категории
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            await service.AddCategory(category);
            return Ok();
        }

        [HttpGet("delete/{id}")] 
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.GetCategoriesById(id));
        }

        // Метод для обновления категории
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Category category)
        {
            if (id != category.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await service.UpdateCategory(category));
        }
    }
}
