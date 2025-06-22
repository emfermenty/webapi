namespace api.Repository.interfaces
{
    public interface IAuthorRepository
    {
        Task AddAuthor(Author author, CancellationToken cancellationToken);
        Task<int> DeleteAuthor(int id, CancellationToken cancellationToken);
        Task<List<Author>> GetAllAuthorsAsync(CancellationToken cancellationToken);
        Task<Author?> GetAuthorByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAuthor(Author author, CancellationToken cancellationToken);
    }
}