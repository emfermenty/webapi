namespace api.Repository.interfaces
{
    public interface ICategoryRepository
    {
        Task AddCategory(Category category);
        Task<int> DeleteCategory(int id);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoriesById(int id);
        Task<int> UpdateCategory(Category category);
    }
}