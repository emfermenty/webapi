using api.Repository.interfaces;
using api.Services.interfaces;

namespace api.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository repository;
        public AuthorService(IAuthorRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<Author>> GetAllAuthors()
        {
            return await repository.GetAllAuthorsAsync();
        }
        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            return await repository.GetAuthorByIdAsync(id);
        }
        public async Task<int> DeleteAuthor(int id)
        {
            return await repository.DeleteAuthor(id);
        }
        public async Task UpdateAuthor(Author author)
        {
            await repository.UpdateAuthor(author);
        }
        public async Task AddAuthor(Author author)
        {
            await repository.AddAuthor(author);
        }
    }
}
