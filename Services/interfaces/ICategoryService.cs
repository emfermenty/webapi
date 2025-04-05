namespace api.Services.interfaces
{
    public interface ICategoryService
    {
        Task AddCategory(Category category);
        Task<int> DeleteCategory(int id);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoriesById(int id);
        Task<int> UpdateCategory(Category category);
    }
}