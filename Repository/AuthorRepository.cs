using api.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext context;
        public AuthorRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await context.Authors
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            return await context.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);
        }
        public async Task<int> DeleteAuthor(int id)
        {
            await context.Authors
                .Where(x => x.id == id)
                .ExecuteDeleteAsync();
            context.SaveChanges();
            return id;
        }
        public async Task UpdateAuthor(Author author)
        {
            context.Authors.Update(author);
            await context.SaveChangesAsync();
        }
        public async Task AddAuthor(Author author)
        {
            await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();
        }
    }
}
