namespace api.Services.interfaces
{
    public interface IAuthorService
    {
        Task AddAuthor(Author author, CancellationToken cancellationToken);
        Task<int> DeleteAuthor(int id, CancellationToken cancellationToken);
        Task<List<Author>> GetAllAuthors(CancellationToken cancellationToken);
        Task<Author?> GetAuthorByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAuthor(Author author, CancellationToken cancellationToken);
    }
}