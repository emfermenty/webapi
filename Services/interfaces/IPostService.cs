using api.Dto;

namespace api.Services.interfaces
{
    public interface IPostService
    {
        Task CreatePost(Post post, CancellationToken cancellationToken);
        Task<int> DeletePost(int id, CancellationToken cancellationToken);
        Task<List<PostDto>> GetAllPostsAsync(CancellationToken cancellationToken);
        Task<PostDto> GetPostByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(Post post, CancellationToken cancellationToken);
    }
}