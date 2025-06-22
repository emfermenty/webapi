using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Identity;

namespace api.Services
{
    public class AccountService(AccountRepository accountRepository, JwtService jwtService)
    {
        public async Task Register(string UserName, string Email, string PasswordHash, CancellationToken cancellationToken)
        {
            var account = new User
            {
                Id = Guid.NewGuid(),
                UserName = UserName,
                Email = Email,
                PasswordHash = PasswordHash
            };
            var passhash = new PasswordHasher<User>().HashPassword(account, PasswordHash);
            account.PasswordHash = passhash;
            await accountRepository.AddUserAsync(account, cancellationToken);
        }
        public async Task<string> Login(string userName, string PasswordHash, CancellationToken cancellationToken)
        {
            var account = await accountRepository.GetUserByName(userName, cancellationToken);
            var result = new PasswordHasher<User>()
                .VerifyHashedPassword(account, account.PasswordHash, PasswordHash);
            if (result == PasswordVerificationResult.Success)
            {
                return jwtService.GenerateToken(account);
            }
            else
            {
                return "";
            }
        }
    }
}
