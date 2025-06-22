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
        public async Task<List<Author>> GetAllAuthors(CancellationToken cancellationToken)
        {
            return await repository.GetAllAuthorsAsync(cancellationToken);
        }
        public async Task<Author?> GetAuthorByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await repository.GetAuthorByIdAsync(id, cancellationToken);
        }
        public async Task<int> DeleteAuthor(int id, CancellationToken cancellationToken)
        {
            return await repository.DeleteAuthor(id, cancellationToken);
        }
        public async Task UpdateAuthor(Author author, CancellationToken cancellationToken)
        {
            await repository.UpdateAuthor(author, cancellationToken);
        }
        public async Task AddAuthor(Author author, CancellationToken cancellationToken)
        {
            await repository.AddAuthor(author, cancellationToken);
        }
    }
}
