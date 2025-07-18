﻿using api.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext context;
        public AuthorRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<List<Author>> GetAllAuthorsAsync(CancellationToken cancellationToken)
        {
            return await context.Authors
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        public async Task<Author?> GetAuthorByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id, cancellationToken);
        }
        public async Task<int> DeleteAuthor(int id, CancellationToken cancellationToken)
        {
            var author = await context.Authors
                 .Where(x => x.id == id)
                 .FirstOrDefaultAsync();
            context.Authors.Remove(author);
            await context.SaveChangesAsync(cancellationToken);
            return id;
        }
        public async Task UpdateAuthor(Author author, CancellationToken cancellationToken)
        {
            var existingAuthor = await context.Authors.FindAsync(author.id);
            if (existingAuthor != null)
            {
                context.Entry(existingAuthor).CurrentValues.SetValues(author);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
        public async Task AddAuthor(Author author, CancellationToken cancellationToken)
        {
            await context.Authors.AddAsync(author);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
