namespace api.Repository.interfaces
{
    public interface IAuthorRepository
    {
        Task AddAuthor(Author author);
        Task<int> DeleteAuthor(int id);
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author?> GetAuthorByIdAsync(int id);
        Task UpdateAuthor(Author author);
    }
}