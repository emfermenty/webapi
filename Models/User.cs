using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        private User(Guid id, string userName, string email, string password)
        {
            Id = id;
            UserName = userName;
            Email = email;
            PasswordHash = password;
        }
        public static User Create(Guid id, string userName, string email, string password)
        {
            return new User(id, userName, email, password);
        }
        public User()
        {

        }
    }
}
