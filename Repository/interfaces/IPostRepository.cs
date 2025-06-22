namespace api.Repository.interfaces
{
    public interface IPostRepository
    {
        Task AddPostAsync(Post post, CancellationToken cancellationToken);
        Task<int> DeletePostAsync(int id, CancellationToken cancellationToken);
        Task<List<Post>> GetAllPostsAsync(CancellationToken cancellationToken);
        Task<Post?> GetPostById(int id, CancellationToken cancellationToken);
        Task UpdateAsync(Post post, CancellationToken cancellationToken);
    }
}