using api.Dto;

namespace api.Repository.interfaces
{
    public interface IPostRepository
    {
        Task AddPostAsync(Post post);
        Task<int> DeletePostAsync(int id);
        Task<List<Post>> GetAllPostsAsync();
        Task<Post> GetPostById(int id);
        Task UpdateAsync(Post post);
    }
}