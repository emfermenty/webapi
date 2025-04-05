using api.Repository.interfaces;
using api.Services.interfaces;

namespace api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;
        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await repository.GetAllCategoriesAsync();
        }
        public async Task<Category?> GetCategoriesById(int id)
        {
            return await repository.GetCategoriesById(id);
        }
        public async Task<int> DeleteCategory(int id)
        {
            return await repository.DeleteCategory(id);
        }
        public async Task AddCategory(Category category)
        {
            await repository.AddCategory(category);
        }
        public async Task<int> UpdateCategory(Category category)
        {
            await repository.UpdateCategory(category);
            return category.Id;
        }
    }
}
