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
        public async Task<List<Post>> GetAllPostsAsync(CancellationToken cancellationToken)
        {
            return await context.Posts
                .AsNoTracking()
                .Include(p => p.Author)
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .ToListAsync(cancellationToken);

        }
        public async Task<Post?> GetPostById(int id, CancellationToken cancellationToken)
        {
            return await context.Posts
                .Include(p => p.Author)
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }
        public async Task<int> DeletePostAsync(int id, CancellationToken cancellationToken)
        {
            await context.Posts
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync(cancellationToken);
            return id;
        }
        public async Task AddPostAsync(Post post, CancellationToken cancellationToken)
        {
            if (post.Author != null)
            {
                context.Entry(post.Author).State = EntityState.Unchanged;
            }
            await context.AddAsync(post, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(Post post, CancellationToken cancellationToken)
        {
            context.Posts.Update(post);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
