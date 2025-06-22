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
        public async Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            return await repository.GetAllCategoriesAsync(cancellationToken);
        }
        public async Task<Category?> GetCategoriesById(int id, CancellationToken cancellationToken)
        {
            return await repository.GetCategoriesById(id, cancellationToken);
        }
        public async Task<int> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            return await repository.DeleteCategory(id, cancellationToken);
        }
        public async Task AddCategory(Category category, CancellationToken cancellationToken)
        {
            await repository.AddCategory(category, cancellationToken);
        }
        public async Task<int> UpdateCategory(Category category, CancellationToken cancellationToken)
        {
            await repository.UpdateCategory(category, cancellationToken);
            return category.Id;
        }
    }
}
