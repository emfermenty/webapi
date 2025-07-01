using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AccountRepository
    {
        private readonly ApplicationContext context;
        public AccountRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task AddUserAsync(User user, CancellationToken cancellationToken)
        {
            await context.Users.AddAsync(user, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
        public async Task<User?> GetUserByName(string name, CancellationToken cancellationToken)
        {
            User? user = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.UserName == name, cancellationToken);
            return user;
        }
    }
}
