using api.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationContext context;
        public PostRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await context.Posts
                .AsNoTracking()
                .Include(p => p.Author)
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .ToListAsync();
         
        }
        public async Task<Post?> GetPostById(int id)
        {
            return await context.Posts
                .Include(p => p.Author)
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<int> DeletePostAsync(int id)
        {
            await context.Posts
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
        public async Task AddPostAsync(Post post)
        {
            if (post.Author != null)
            {
                context.Entry(post.Author).State = EntityState.Unchanged;
            }
            await context.AddAsync(post);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Post post)
        {
            context.Posts.Update(post);
            await context.SaveChangesAsync();
        }
    }
}
