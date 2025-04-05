using api.Dto;

namespace api.Services.interfaces
{
    public interface IPostService
    {
        Task<int> DeletePost(int id);
        Task<List<PostDto>> GetAllPostsAsync();
        Task<PostDto> GetPostByIdAsync(int id);
    }
}