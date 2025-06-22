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
        public async Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            return await context.Categories
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        public async Task<Category?> GetCategoriesById(int id, CancellationToken cancellationToken)
        {
            return await context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }
        public async Task<int> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            int affectedRows = await context.Categories
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

            return affectedRows; 
        }
        public async Task<int> UpdateCategory(Category category, CancellationToken cancellationToken)
        {
            context.Categories.Update(category);
            await context.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
        public async Task AddCategory(Category category, CancellationToken cancellationToken)
        {
            await context.Categories.AddAsync(category, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
