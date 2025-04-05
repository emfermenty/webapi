using api.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext context;
        public CategoryRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await context.Categories
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Category?> GetCategoriesById(int id)
        {
            return await context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<int> DeleteCategory(int id)
        {
            int affectedRows = await context.Categories
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();

            return affectedRows; // Возвращает количество удалённых записей
        }
        public async Task<int> UpdateCategory(Category category)
        {
            context.Categories.Update(category);
            await context.SaveChangesAsync();
            return category.Id;
        }
        public async Task AddCategory(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();
        }
    }
}
