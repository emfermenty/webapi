using api.Repository.interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace api.Repository.Decorators
{
    public class CachedPostRepository : IPostRepository
    {
        private readonly IPostRepository _repository;
        private readonly IDistributedCache _cache;
        public CachedPostRepository(IPostRepository repository, IDistributedCache cache)
        {
            _repository = repository;
            _cache = cache;
        }
        public async Task<List<Post>> GetAllPostsAsync(CancellationToken cancellationToken)
        {
            const string cachekey = "all_posts_cache";
            var cachedata = await _cache.GetStringAsync(cachekey, cancellationToken);
            if (cachedata != null) {
                Console.WriteLine("Данные получены из кэша");
                return JsonSerializer.Deserialize<List<Post>>(cachedata);
            }
            Console.WriteLine("Данные получены из базы данных");
            var data = await _repository.GetAllPostsAsync(cancellationToken);
            await _cache.SetStringAsync(
                cachekey,
                JsonSerializer.Serialize(data),
                new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) },
                cancellationToken
                );
            Console.WriteLine("Данные получены из кэша");
            return data;
        }
        public async Task<Post> GetPostById(int id, CancellationToken cancellationToken)
        {
            string cachekey = $"post_{id}";
            var cachedata = await _cache.GetStringAsync(cachekey, cancellationToken);
            if (cachedata != null)
            {
                return JsonSerializer.Deserialize<Post>(cachedata);
            }
            var data = await _repository.GetPostById(id, cancellationToken);
            if(data != null)
            {
                await _cache.SetStringAsync(cachekey,
                    JsonSerializer.Serialize(data),
                    new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)},
                    cancellationToken
                    );
            }
            return data;
        }
        public async Task<int> DeletePostAsync(int id, CancellationToken cancellationToken)
        {
            await _repository.DeletePostAsync(id, cancellationToken);
            await _cache.RemoveAsync($"post_{id}", cancellationToken);
            await _cache.RemoveAsync("all_posts_cache", cancellationToken);
            return id;
        }
        public async Task UpdateAsync(Post post, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(post, cancellationToken);
            await _cache.RemoveAsync($"{post.Id}", cancellationToken);
            await _cache.RemoveAsync("all_posts_cache", cancellationToken);
        }
        public async Task AddPostAsync(Post post, CancellationToken cancellationToken)
        {
            await _repository.AddPostAsync(post, cancellationToken);
            await _cache.RemoveAsync("all_posts_cache", cancellationToken);
        }
    }
}
