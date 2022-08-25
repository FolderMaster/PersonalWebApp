using Microsoft.EntityFrameworkCore;

namespace PersonalWebApp.Models
{
    public class UserLogin
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public UserLogin()
        {
        }

        public UserLogin(string name, string password, bool rememberMe)
        {
            Name = name;
            Password = password;
            RememberMe = rememberMe;
        }

        public static async Task<User?> Login(UserLogin login, UserDbContext dbContext)
        {
            return await dbContext.Users.FirstOrDefaultAsync(user => user.Name == login.Name && user.Password == login.Password);
        }
    }
}
