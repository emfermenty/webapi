using api.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class AuthorRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        public AuthorRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationContext( _options );
            SeedDatabase();
        }
        private void SeedDatabase()
        {
            _context.Authors.AddRange(
                new Author { id = 1, name = "Author 1", biography = "fpsadf" },
                new Author { id = 2, name = "Author 2", biography = "sadfasdf" }
            );
            _context.SaveChanges();
        }
        [Fact]
        public async Task GetAllAuthorsAsync_ReturnsAllAuthors()
        {
            var repository = new AuthorRepository(_context);
            
            var result = await repository.GetAllAuthorsAsync(CancellationToken.None);
            
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public async Task GetAuthorByIdAsync_ReturnsAuthor_WhenAuthorExist()
        {
            var repository = new AuthorRepository(_context);
            var result = await repository.GetAuthorByIdAsync(1, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal(1, result.id);
        }
        [Fact]
        public async Task GetAuthorByIdAsync_ReturnsNull_WhenAuthorDoesExist()
        {
            var repository = new AuthorRepository(_context);
            var result = await repository.GetAuthorByIdAsync(100, CancellationToken.None);
            Assert.Null(result);
        }
        [Fact]
        public async Task AddNewAuthor()
        {
            var repository = new AuthorRepository(_context);
            var author = new Author { id = 3, name = "dima", biography = "sdfasdf" };
            await repository.AddAuthor(author, CancellationToken.None);
            var author2 = await _context.Authors.FindAsync(3);
            Assert.NotNull(author2);
            Assert.Equal("dima", author2.name);
        }
        [Fact]
        public async Task DeleteAuthor_RemovesAuthor()
        {
            var repository = new AuthorRepository(_context);
            var result = await repository.DeleteAuthor(1, CancellationToken.None);

            Assert.Equal(1, result);
            var deletedAuthor = await _context.Authors.FindAsync(1);
            Assert.Null(deletedAuthor);
        }
        [Fact]
        public async Task UpdateAuthor_UpdatesExistingAuthor()
        {
            var repository = new AuthorRepository(_context);
            var authorToUpdate = new Author { id = 1, name = "Updated Author", biography = "New bio" };

            await repository.UpdateAuthor(authorToUpdate, CancellationToken.None);

            var updatedAuthor = await _context.Authors.FindAsync(1);
            Assert.Equal("Updated Author", updatedAuthor.name);
            Assert.Equal("New bio", updatedAuthor.biography);
        }
    }
}
