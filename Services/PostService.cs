using api.Dto;
using api.Repository.interfaces;
using api.Services.interfaces;

namespace api.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository repository;
        public PostService(IPostRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<PostDto>> GetAllPostsAsync()
        {
            var posts = await repository.GetAllPostsAsync();
            return posts.Select(posts => new PostDto
            {
                Id = posts.Id,
                Name = posts.Name,
                Description = posts.Description,
                Rating = posts.post_rating,
                AuthorName = posts.Author?.name,
                Categories = posts.PostCategories
                    .Select(pc => pc.Category?.Category_Name ?? string.Empty)
                    .ToList()
            }).ToList();
        }
        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            var post = await repository.GetPostById(id);
            return new PostDto
            {
                Id = post.Id,
                Name = post.Name,
                Description = post.Description,
                Rating = post.post_rating,
                AuthorName = post.Author?.name,
                Categories = post.PostCategories?
                .Select(pc => pc.Category?.Category_Name ?? "")
                .ToList()
            };
        }
        public async Task<int> DeletePost(int id)
        {
            return await repository.DeletePostAsync(id);
        }
    }
}
