namespace api.Services.interfaces
{
    public interface IAuthorService
    {
        Task AddAuthor(Author author);
        Task<int> DeleteAuthor(int id);
        Task<List<Author>> GetAllAuthors();
        Task<Author?> GetAuthorByIdAsync(int id);
        Task UpdateAuthor(Author author);
    }
}