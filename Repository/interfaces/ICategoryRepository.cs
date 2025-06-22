namespace api.Repository.interfaces
{
    public interface ICategoryRepository
    {
        Task AddCategory(Category category, CancellationToken cancellationToken);
        Task<int> DeleteCategory(int id, CancellationToken cancellationToken);
        Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken);
        Task<Category?> GetCategoriesById(int id, CancellationToken cancellationToken);
        Task<int> UpdateCategory(Category category, CancellationToken cancellationToken);
    }
}